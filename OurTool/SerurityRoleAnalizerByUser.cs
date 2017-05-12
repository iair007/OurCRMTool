using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;

namespace OurCRMTool
{
    public partial class SerurityRoleAnalizerByUser : Form
    {
        private BL bl;
        private EntityCollection usersCol;
        private DataTable dtUsers = new DataTable();
        List<Guid> _usersIds = new List<Guid>();
        log4net.ILog log;
        bool finishRetrievingData = false;
        RetrieveAllEntitiesResponse entityMetadata = null;
        BackgroundWorker worker = new BackgroundWorker();

        public List<Guid> UsersSelected
        {
            get { return GetUserSelecteds(); }
        }

        #region Constructor

        public SerurityRoleAnalizerByUser(BL _bl, log4net.ILog _log)
        {
            InitializeComponent();
            log = _log;
            bl = _bl;
            this.Text = "SerurityRoleAnalizerByUser - Connected to: " + bl.url;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();

            CreatedtUsersColumns();
            SetBusinessUnits();

        }

        private void CreatedtUsersColumns()
        {
            dtUsers.Columns.Add("UserCheck", typeof(bool));
            dtUsers.Columns.Add("UserName", typeof(string));
            dtUsers.Columns.Add("UserId", typeof(string));

            dtUsers.PrimaryKey = new DataColumn[] { dtUsers.Columns["UserId"] };
        }
        #endregion

        #region BusinessUnit

        private void SetBusinessUnits()
        {
            try
            {
                EntityCollection businessUnits = bl.GetBusinessUnit();

                foreach (Entity b in businessUnits.Entities)
                {
                    gridBusinessUnit.Rows.Add(b.Attributes["name"], b.Id);
                }
            }
            catch (Exception ex)
            {
                log.Error("UsersSettingsUpdate.SetBusinessUnits: " + ex.Message);
            }
        }

        private void gridBusinessUnit_SelectionChanged(object sender, EventArgs e)
        {
            SetTeams();
            UpdateUsersGrid();
            gridTeams.Focus();
        }

        #endregion

        #region Team

        private void SetTeams()
        {
            try
            {
                if (gridBusinessUnit.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Business Unit to Continue");
                    return;
                }
                gridTeams.Rows.Clear();
                Guid businessUnitId = new Guid(gridBusinessUnit.SelectedRows[0].Cells["BUid"].Value.ToString());
                EntityCollection teams = bl.GetTeams(businessUnitId);

                foreach (Entity t in teams.Entities)
                {
                    gridTeams.Rows.Add(false, t.Attributes["name"], t.Id);
                }
            }
            catch (Exception ex)
            {
                log.Error("UsersSettingsUpdate.SetTeams:" + ex.Message);
            }
        }

        private void butTeamSelectAll_Click(object sender, EventArgs e)
        {
            gridTeams.CellContentClick -= gridTeams_CellClick;
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = true;
            }
            UpdateUsersGrid();
            EnableButOption();
            gridTeams.CellContentClick += new DataGridViewCellEventHandler(gridTeams_CellClick);
        }

        private void butTeamClear_Click(object sender, EventArgs e)
        {
            gridTeams.CellContentClick -= gridTeams_CellClick;
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = false;
            }
            dtUsers.Rows.Clear();
            EnableButOption();
            gridTeams.CellContentClick += new DataGridViewCellEventHandler(gridTeams_CellClick);
        }

        private void gridTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (rowClicked != null && rowClicked.Index != -1)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
                UpdateUsersGrid();
                EnableButOption();
            }
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region User

        private void UpdateUsersGrid()
        {
            try
            {
                dtUsers.Rows.Clear();
                List<Guid> teamIds = new List<Guid>();
                for (int i = 0; i < gridTeams.Rows.Count; i++)
                {
                    if ((bool)gridTeams.Rows[i].Cells["TeamCheck"].Value == true)
                    {
                        teamIds.Add(new Guid(gridTeams.Rows[i].Cells["teamId"].Value.ToString()));
                    }
                }
                usersCol = bl.GetUsersByTeam(teamIds);

                foreach (Entity u in usersCol.Entities)
                {
                    //if the user is not in the 
                    if (dtUsers.Rows.Find(u.Id) == null)
                    {
                        string userName = u.Contains("fullname") ? u.Attributes["fullname"].ToString() : u.Attributes["domainname"].ToString();
                        dtUsers.Rows.Add(false, userName, u.Id);
                    }
                }

                gridUsers.DataSource = dtUsers;
                SetGridUsersColumnsProp();
                gridUsers.Focus();
            }
            catch (Exception ex)
            {
                log.Error("UsersSettingsUpdate.UpdateUsersGrid: " + ex);
            }
        }

        private void gridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView senderGridView = (sender as DataGridView);
                DataGridViewRow rowClicked = senderGridView.CurrentRow;
                if (senderGridView.CurrentRow != null && rowClicked.Index != -1)
                {
                    MakeOnlyOneSelection(senderGridView, rowClicked);
                    EnableButOption();
                }
            }
            catch (Exception ex)
            {
                log.Error("UsersSettingsUpdate.gridUsers_CellClick: " + ex);
            }
        }

        private void butClearSearch_Click(object sender, EventArgs e)
        {
            txtUserFilter.Text = string.Empty;
        }

        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {
            dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "UserName", txtUserFilter.Text);
            txtUserFilter.Focus();
        }

        /// <summary>
        /// Will set the properties of the columns for gridUsers
        /// </summary>
        private void SetGridUsersColumnsProp()
        {
            gridUsers.Columns["UserCheck"].Width = 30;
            gridUsers.Columns["UserCheck"].HeaderText = "";
            gridUsers.Columns["UserCheck"].ReadOnly = false;

            gridUsers.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridUsers.Columns["UserName"].HeaderText = "User";
            gridUsers.Columns["UserName"].ReadOnly = true;

            gridUsers.Columns["UserId"].Visible = false;
        }
        #endregion

        #region Other user's settings

        /// <summary>
        /// If the row was already selected, will make it false, if it was not, will make sure is the only row selected
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        private void MakeOnlyOneSelection(DataGridView grid, DataGridViewRow row)
        {
            if ((bool)row.Cells[0].Value == true)
            {
                row.Cells[0].Value = false;
            }
            else
            {
                foreach (DataGridViewRow r in grid.Rows)
                {
                    if (r.Equals(row))
                    {
                        r.Cells[0].Value = true;
                    }
                    else
                    {
                        r.Cells[0].Value = false;
                    }
                }
            }
        }

        private void gridUpdateUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
            }
        }

        #endregion

        #region Worker

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            entityMetadata = bl.GetEntities();
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butOpenUser.Text = "Check User's Privileges";
            butOpenTeam.Text = "Check Team's Privileges";
            finishRetrievingData = true;
            EnableButOption();
        }
        #endregion

        private int GetCheckedRow(DataGridView grid)
        {
            int nrRecordsCheked = 0;
            foreach (DataGridViewRow r in grid.Rows)
            {
                if ((bool)r.Cells[0].Value == true)
                {
                    nrRecordsCheked++;
                    if (nrRecordsCheked > 1)
                    {  //used for teams grid, only can be selected one team to check its security Roles
                        break;
                    }
                }
            }

            return nrRecordsCheked;
        }

        private void EnableButOption()
        {
            if (finishRetrievingData)
            {
                if (GetCheckedRow(gridTeams) == 1)
                {
                    butOpenTeam.BackColor = Color.Olive;
                    butOpenTeam.Enabled = true;
                }
                else
                {
                    butOpenTeam.BackColor = Color.Gray;
                    butOpenTeam.Enabled = false;

                }
                if (GetCheckedRow(gridUsers) == 1)
                {
                    butOpenUser.BackColor = Color.Olive;
                    butOpenUser.Enabled = true;
                }
                else
                {
                    butOpenUser.BackColor = Color.Gray;
                    butOpenUser.Enabled = false;
                }
            }
        }

        private void butOpenUser_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Empty;
                string userName = string.Empty;
                for (int i = 0; i < gridUsers.Rows.Count; i++)
                {
                    if ((bool)gridUsers.Rows[i].Cells["UserCheck"].Value == true)
                    {
                        id = new Guid(gridUsers.Rows[i].Cells["UserId"].Value.ToString());
                        userName = gridUsers.Rows[i].Cells["UserName"].Value.ToString();
                        break;
                    }
                }
                if (id != Guid.Empty)
                {
                    openSerurityRoleAnalizerByUser2(id, userName, "systemuser");
                }
            }
            catch (Exception ex)
            {
                log.Error("SerurityRoleAnalizerByUser.butOpenUser_Click: " + ex);
            }
        }

        private void butOpenTeam_Click(object sender, EventArgs e)
        {
            try
            {
                Guid id = Guid.Empty;
                string name = string.Empty;
                for (int i = 0; i < gridTeams.Rows.Count; i++)
                {
                    if ((bool)gridTeams.Rows[i].Cells["TeamCheck"].Value == true)
                    {
                        id = new Guid(gridTeams.Rows[i].Cells["TeamId"].Value.ToString());
                        name = gridTeams.Rows[i].Cells["TeamName"].Value.ToString();
                        break;
                    }
                }
                if (id != Guid.Empty)
                {
                    openSerurityRoleAnalizerByUser2(id, name, "team");
                }
            }
            catch (Exception ex)
            {
                log.Error("SerurityRoleAnalizerByUser.butOpenTeam_Click: " + ex);
                throw ex;
            }
        }

        private void openSerurityRoleAnalizerByUser2(Guid id, string name, string entityName)
        {
            SerurityRoleAnalizerByUser2 form = new SerurityRoleAnalizerByUser2(bl, id, name, entityName, entityMetadata, log);
            form.ShowDialog();
        }
        /// <summary>
        /// Every time the user selected change, will update the list of users in the form "User Options"
        /// </summary>
        public List<Guid> GetUserSelecteds()
        {
            List<Guid> selectedUsers = new List<Guid>();

            for (int i = 0; i < gridUsers.Rows.Count; i++)
            {
                if ((bool)gridUsers.Rows[i].Cells["UserCheck"].Value == true)
                {
                    selectedUsers.Add(new Guid(gridUsers.Rows[i].Cells["UserId"].Value.ToString()));
                }
            }
            return selectedUsers;
        }


    }
}
