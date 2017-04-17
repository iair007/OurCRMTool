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

namespace OurCRMTool
{
    public partial class ResetDefaultTeam : Form
    {
        private BL bl;
        log4net.ILog log;
        private EntityCollection usersCol;
        private DataTable dtUsers = new DataTable();
        UsersSettingsUpdate2 UsersSettingsUpdate2;
        List<Guid> _usersIds = new List<Guid>();
        SetDefaultTeam parentForm = null;

        public List<Guid> UsersSelected
        {
            get { return GetUserSelecteds(); }
        }

        #region Constructor

        public ResetDefaultTeam(BL _bl, log4net.ILog _log ,SetDefaultTeam _partentForm = null)
        {
            InitializeComponent();
            bl = _bl;
            log = _log;
            parentForm = _partentForm;
            UsersSettingsUpdate2 = new UsersSettingsUpdate2(bl);
            this.Text = "Users Settings Update - Connected to: " + bl.url;
            CreatedtUsersColumns();
            SetBusinessUnits();
        }

        private void CreatedtUsersColumns()
        {
            dtUsers.Columns.Add("UserCheck", typeof(bool));
            dtUsers.Columns.Add("UserName", typeof(string));
            dtUsers.Columns.Add("DefaultTeam", typeof(string));
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
                throw ex;
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
                throw ex;
            }
        }

        private void butTeamSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = true;
            }
            UpdateUsersGrid();
        }

        private void butTeamInvert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = !(bool)gridTeams.Rows[i].Cells["TeamCheck"].Value;
            }

            UpdateUsersGrid();
        }

        private void butTeamClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = false;
            }
            dtUsers.Rows.Clear();
        }

        private void gridTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewCell cellClicked = senderGridView.CurrentCell;
            if (senderGridView.CurrentRow != null)
            {
                senderGridView.CurrentRow.Cells["TeamCheck"].Value = !(bool)senderGridView.CurrentRow.Cells["TeamCheck"].Value;

                UpdateUsersGrid();
            }
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
                        string defaultTeam = u.Contains("new_id_related_team") ? u.GetAttributeValue<EntityReference>("new_id_related_team").Name : string.Empty;
                        dtUsers.Rows.Add(false, u.Attributes["fullname"], defaultTeam, u.Id);
                    }
                }

                gridUsers.DataSource = dtUsers;
                SetGridUsersColumnsProp();
                gridUsers.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void butUserClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridUsers.Rows.Count; i++)
            {
                gridUsers.Rows[i].Cells["UserCheck"].Value = false;
            }
            EnableButDeleteDef();
        }

        private void butUserInvert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridUsers.Rows.Count; i++)
            {
                gridUsers.Rows[i].Cells["UserCheck"].Value = !(bool)gridUsers.Rows[i].Cells["UserCheck"].Value;
            }
            EnableButDeleteDef();
        }

        private void butUserSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridUsers.Rows.Count; i++)
            {
                gridUsers.Rows[i].Cells["UserCheck"].Value = true;
            }
            EnableButDeleteDef();
        }

        private void gridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            if (senderGridView.CurrentRow != null)
            {
                senderGridView.CurrentRow.Cells["UserCheck"].Value = !(bool)senderGridView.CurrentRow.Cells["UserCheck"].Value;

                EnableButDeleteDef();

                if (txtUserFilter.Text != string.Empty)
                {
                    txtUserFilter.Text = senderGridView.CurrentRow.Cells["UserName"].Value.ToString();
                }
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

            gridUsers.Columns["UserName"].Width = 130;
            gridUsers.Columns["UserName"].HeaderText = "User";
            gridUsers.Columns["UserName"].ReadOnly = true;

            gridUsers.Columns["DefaultTeam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridUsers.Columns["DefaultTeam"].HeaderText = "Default Team";
            gridUsers.Columns["DefaultTeam"].ReadOnly = true;

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

        private DataGridViewRow GetCheckedRow(DataGridView grid)
        {
            DataGridViewRow checkedRow = null;
            foreach (DataGridViewRow r in grid.Rows)
            {
                if ((bool)r.Cells[0].Value == true)
                {
                    checkedRow = r;
                    break;
                }
            }

            return checkedRow;
        }

        private void EnableButDeleteDef()
        {
            butDeleteDef.Enabled = GetCheckedRow(gridUsers) != null;
        }

        private void butDeleteDef_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string message = bl.DeleteDefaultTeams(UsersSelected);
                Cursor.Current = Cursors.Default;
                if (checkAssign.Checked)
                {
                    if (parentForm == null)
                    {
                        SetDefaultTeam newParent = new SetDefaultTeam(bl, log);
                        parentForm = newParent;
                    }
                    parentForm.AssignDefaultTeams();
                }
                if (checkCloseWhenFinish.Checked)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message);
                    UpdateUsersGrid();
                    EnableButDeleteDef();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private void ResetDefaultTeam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.ResetForm();
            }
        }
    }
}
