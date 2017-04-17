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
    public partial class CheckDefaultTeam : Form
    {
        private BL bl;
        private DataTable dtUsers = new DataTable();
        private EntityCollection _usersBackUp;

        private EntityCollection AllUsers
        {
            get
            {
                if (_usersBackUp == null)
                {
                    _usersBackUp = bl.GetUsersWithDafultTeam();
                }
                return _usersBackUp;
            }
            set
            {
                _usersBackUp = value;
            }
        }

        public CheckDefaultTeam(BL _bl)
        {
            InitializeComponent();
            bl = _bl;
            this.Text = "Check Default Team - Connected to: " + bl.url;
            CreatedtUsersColumns();
            SetTeams();
            SetUsersGrid();
            txtExplanation.Text = "Select a team to get all the Users that have that team as Default team,"
                                  + "Or Select a User to know what is it's default team"
                                  + "You can do doble click in a user to open it's record";
        }

        private void CreatedtUsersColumns()
        {
            dtUsers.Columns.Add("UserName", typeof(string));
            dtUsers.Columns.Add("UserId", typeof(string));

            dtUsers.PrimaryKey = new DataColumn[] { dtUsers.Columns["UserId"] };
        }

        #region Team

        private void SetTeams()
        {
            try
            {
                gridTeams.Rows.Clear();
                gridTeams.Rows.Add("כל הצוותים", null);

                EntityCollection businessUnits = bl.GetBusinessUnit();

                EntityCollection allTeams = bl.GetTeams(businessUnits.Entities.Select(a => a.Id).ToList<Guid>());
                foreach (Entity t in allTeams.Entities)
                {
                    gridTeams.Rows.Add(t.Attributes["name"], t.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void butSelectAll_Click(object sender, EventArgs e)
        {
            gridTeams.Rows[0].Selected = true;
            SetUsersGrid();
        }

        private void gridTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            if (senderGridView.CurrentRow != null)
            {
                if (senderGridView.CurrentRow.Cells["teamId"].Value != null)
                {
                    SetUsersGrid(new Guid(senderGridView.CurrentRow.Cells["teamId"].Value.ToString()));
                }
                else
                {
                    SetUsersGrid();
                }
            }
        }

        #endregion

        #region User

        private void butUserClear_Click(object sender, EventArgs e)
        {
            txtUserFilter.Text = string.Empty;
        }

        private void gridUsers_DoubleClick(object sender, EventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            if (senderGridView.CurrentRow != null)
            {
                bl.OpenWithArguments(senderGridView.CurrentRow.Cells["UserId"].Value.ToString(), "systemuser");
            }
        }

        private void SetUsersGrid(Guid? defaultTeamid = null)
        {
            try
            {
                dtUsers.Rows.Clear();
                
                var usersNames = AllUsers.Entities.Where(u => u.GetAttributeValue<EntityReference>("new_id_related_team").Id == defaultTeamid || defaultTeamid == null).Select(r => new { fullname = r["fullname"], r.Id }).Distinct();
                foreach (var u in usersNames)
                {
                    //if the user is not in the 
                    dtUsers.Rows.Add(u.fullname, u.Id);
                }
               
                gridUsers.DataSource = dtUsers;

                lbUsersCount.Text = "Users: " + dtUsers.Rows.Count.ToString();

                gridUsers.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridUsers.Columns["UserName"].HeaderText = "User";
                gridUsers.Columns["UserName"].ReadOnly = true;
                gridUsers.Columns["UserId"].Visible = false;

                gridUsers.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

                var usersTeamId = AllUsers.Entities.Where(u => u.Id == new Guid(senderGridView.CurrentRow.Cells["UserId"].Value.ToString())).Select(u => u.GetAttributeValue<EntityReference>("new_id_related_team").Id);

                foreach (DataGridViewRow r in gridTeams.Rows)
                {
                    if (r.Cells["TeamId"].Value != null && r.Cells["TeamId"].Value.ToString() == usersTeamId.First().ToString())
                    {
                        r.Selected = true;
                        gridTeams.FirstDisplayedScrollingRowIndex = r.Index;
                        break;
                    }
                }
            }
        }

        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {
            dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "UserName", txtUserFilter.Text);
            txtUserFilter.Focus();

            lbUsersCount.Text = "Users: " + gridUsers.Rows.Count.ToString();
        }

        #endregion

        #region TootTips
        
        private void gridTeams_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(gridTeams, "Show all the teams in the System");
        }

        private void gridUsers_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(gridUsers, "Show the Users with the selected team set Default Team." + Environment.NewLine + "If doble click will open the User's record");
        }

        private void butSelectAll_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(butSelectAll, "Will select the first record (All the teams)");
        }

        #endregion


    }
}
