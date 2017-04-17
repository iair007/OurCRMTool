using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using System.IO;
using System.Diagnostics;

namespace OurCRMTool
{
    public partial class SetDefaultTeam : Form
    {
        private BL bl;
        string _csvPath;
        private EntityCollection _usersBackUp;
        List<string> teamsInCsvList = new List<string>();
        log4net.ILog log;
        private string CsvPath
        {
            get
            {
                if (_csvPath == null)
                {
                    _csvPath = bl.ResourcesPath + "\\DefaultTeams.csv";
                }
                return _csvPath;
            }
        }

        private EntityCollection AllUsers
        {
            get
            {
                if (_usersBackUp == null)
                {
                    _usersBackUp = bl.GetUsersWithoutDefaultTeam();
                }
                return _usersBackUp;
            }
            set
            {
                _usersBackUp = value;
            }
        }

        public SetDefaultTeam(BL _bl, log4net.ILog _log)
        {
            InitializeComponent();
            bl = _bl;
            log = _log;
            this.Text = "SetDefaultTeam - Connected to: " + bl.url;
            SetTeams();
            SetUsersGrid();
            txtExplanation.Text = "When press assign, will check all the users in the User's list and check if the user has one of the Default Teams. "
                                   + "If it does, will set it as Default team."
                                    + "If the user is not part of any of the Defaults teams, "
                                    + "it will do Nothing and will show you a message at the end of the process."
                                    + "You can do doble click in the user to open it's record in CRM to add a new team to it."
                                    + "Re-set default team Buttom will open a new form to Delete default teams of users";
        }

        #region Team

        private void SetTeams()
        {
            try
            {
                gridTeams.Rows.Clear();
                teamsInCsvList.Clear();

                using (CsvFileReader reader = new CsvFileReader(CsvPath))
                {

                    CsvRow row = new CsvRow();
                    while (reader.ReadRow(row))
                    {
                        if (row[0] != "Team Name")
                        {
                            teamsInCsvList.Add(row[0]);
                        }
                    }

                    foreach (string t in teamsInCsvList)
                    {
                        gridTeams.Rows.Add(t);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("SetDefaultTeam.SetTeams: " + ex.Message);
            }
        }

        #endregion

        #region User

        private void SetUsersGrid()
        {
            try
            {
                gridUsers.Rows.Clear();

                var usersNames = AllUsers.Entities.Select(r => new { domainName = r["domainname"], r.Id }).Distinct();

                foreach (var u in usersNames)
                {
                    //if the user is not in the 
                    gridUsers.Rows.Add(u.domainName, u.Id);
                }
                lbUsersCount.Text = "Users: " + gridUsers.Rows.Count.ToString();
                gridUsers.Focus();

            }
            catch (Exception ex)
            {
                log.Error("SetDefaultTeam.SetUsersGrid: " + ex.Message);
            }
        }

        private void butUserClear_Click(object sender, EventArgs e)
        {
            txtUserFilter.Text = string.Empty;
        }

        private void gridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewCell cellClicked = senderGridView.CurrentCell;
            if (senderGridView.CurrentRow != null)
            {
                if (txtUserFilter.Text != string.Empty)
                {
                    txtUserFilter.Text = senderGridView.CurrentRow.Cells["UserName"].Value.ToString();
                }
            }
        }

        #endregion

        private void butTeamClear_Click_1(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Are you sure you want to delete this team from the DefaultTeams.csv file", "", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                foreach (DataGridViewRow r in gridTeams.SelectedRows)
                {

                    gridTeams.Rows.Remove(r);
                }

                using (CsvFileWriter writer = new CsvFileWriter(CsvPath))
                {
                    CsvRow row = new CsvRow();
                    row.Add(string.Format("{0},{1}", "Team Name", "Business Unit"));
                    foreach (DataGridViewRow r in gridTeams.Rows)
                    {
                        //                        for (int i = 0; i < 100; i++)  //go all columns
                        //                      {
                        row.Add(string.Format("{0},{1}", r.Cells["TeamName"].Value, ""));
                        //                    }
                    }
                    writer.WriteRow(row);
                }
            }
        }

        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {
            SetUsersGrid();
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            if (txtUserFilter.Text != string.Empty)
            {
                foreach (DataGridViewRow r in gridUsers.Rows)
                {
                    string userName = r.Cells["UserName"].Value.ToString().ToLower();
                    if (userName.IndexOf(txtUserFilter.Text.ToLower()) == -1)
                    {
                        rowsToDelete.Add(r);  //need to do this because if I remove here, will change the gridRows list and will skip some rows
                    }
                }


                foreach (DataGridViewRow r in rowsToDelete)
                {
                    gridUsers.Rows.Remove(r);
                }
            }
            txtUserFilter.Focus();

            lbUsersCount.Text = "Users: " + gridUsers.Rows.Count.ToString();
        }

        private void butAssign_Click(object sender, EventArgs e)
        {
            AssignDefaultTeams();
        }

        public void AssignDefaultTeams()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dictionary<Guid, Guid> userTeamDictionary = new Dictionary<Guid, Guid>(); //list of users with its default team

                List<Guid> teamIds = new List<Guid>();
                EntityCollection teamsInCsvColl = bl.GetTeamsByName(teamsInCsvList);

                teamIds = teamsInCsvColl.Entities.Select(t => t.Id).ToList();

                List<string> usersNotUpdated = new List<string>();

                var usersNames = AllUsers.Entities.Select(r => new { domainName = r["domainname"], fullname = r["fullname"], r.Id }).Distinct();  //set list of users distinc() 

                foreach (DataGridViewRow r in gridUsers.Rows)
                {
                    //check the user's teams, if is in the list of the possibles Default teams, will add to the dictionary to update later
                    // If there is no a tema that can be default team, will add to the list of users that have to make the update by hand
                    Guid rowUserId = new Guid(r.Cells["UserId"].Value.ToString());
                    bool haveDefaultTeam = false;
                    var usersTeams = AllUsers.Entities.Where(u => u.Id == rowUserId);  //get all the user's team

                    Dictionary<string, Guid> teamsDic = new Dictionary<string, Guid>();
                    foreach (Entity u in usersTeams)
                    {    //make a dictionary with team's Name and team's Guid
                        Guid teamId = (Guid)u.GetAttributeValue<AliasedValue>("team.teamid").Value;
                        string teamName = u.GetAttributeValue<AliasedValue>("team.name").Value.ToString();
                        teamsDic.Add(teamName, teamId);
                    }

                    foreach (string t in teamsInCsvList)
                    {
                        //Check all the list of posible default temas and if there exist int he user's tema will add it as default
                        if (teamsDic.ContainsKey(t))
                        {
                            userTeamDictionary.Add(rowUserId, teamsDic[t]);
                            haveDefaultTeam = true;
                            break;
                        }
                    }

                    if (haveDefaultTeam == false)
                    {
                        usersNotUpdated.Add(r.Cells["UserName"].Value.ToString());
                    }
                }

                string message = bl.AssignDefaultTeam(userTeamDictionary);

                if (usersNotUpdated.Count() > 0)
                {
                    message += Environment.NewLine + usersNotUpdated.Count().ToString() + " Users inside " + gridUsers.Rows.Count.ToString() + " were not updated:";
                    foreach (string fullName in usersNotUpdated)
                    {
                        message += Environment.NewLine + " - " + fullName;
                    }
                }
                ResetForm();
                DefaultTeamsMessageStatus mes = new DefaultTeamsMessageStatus(message);
                Cursor.Current = Cursors.Default;
                mes.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error("SetDefaultTeam.AssignDefaultTeams: " + ex.Message);
            }
        }
        public void ResetForm()
        {
            AllUsers = bl.GetUsersWithoutDefaultTeam();
            SetUsersGrid();
            txtUserFilter.Text = string.Empty;
        }

        private void butUpdateList_Click(object sender, EventArgs e)
        {
            EntityCollection teamsInCsvColl = bl.GetTeamsByName(teamsInCsvList);
            AddDefaultTeams addDefaultTeams = new AddDefaultTeams(bl, teamsInCsvColl, CsvPath);
            addDefaultTeams.ShowDialog();
            SetTeams();
        }

        private void gridUsers_DoubleClick(object sender, EventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            if (senderGridView.CurrentRow != null)
            {
                bl.OpenWithArguments(senderGridView.CurrentRow.Cells["UserId"].Value.ToString(), "systemuser");
            }
        }

        private void butReset_Click(object sender, EventArgs e)
        {
            ResetDefaultTeam resetDefaultTeam = new ResetDefaultTeam(bl, log, this);
            resetDefaultTeam.ShowDialog();
        }
    }
}
