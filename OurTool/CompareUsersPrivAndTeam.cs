using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurCRMTool
{
    public partial class CompareUsersPrivAndTeam : Form
    {
        private BL bl;
        private DataTable dtUsers = new DataTable();
        private DataTable dtUsers2 = new DataTable();
        log4net.ILog log;
        LogUtils _log = new LogUtils();
        public CompareUsersPrivAndTeam(BL _bl, log4net.ILog _log)
        {
            InitializeComponent();
            bl = _bl;
            log = _log;
            CreatedtUsersColumns();
            SetUsersGrid();
            Cursor.Current = Cursors.Default;
        }


        private void CreatedtUsersColumns()
        {
            dtUsers.Columns.Add("UserCheck", typeof(bool));
            dtUsers.Columns.Add("UserName", typeof(string));
            dtUsers.Columns.Add("UserId", typeof(string));
            dtUsers.Columns.Add("BusinessUnitName", typeof(string));
            dtUsers.Columns.Add("BusinessUnitId", typeof(string));

            dtUsers.PrimaryKey = new DataColumn[] { dtUsers.Columns["UserId"] };

            dtUsers2.Columns.Add("UserCheck", typeof(bool));
            dtUsers2.Columns.Add("UserName", typeof(string));
            dtUsers2.Columns.Add("UserId", typeof(string));
            dtUsers2.Columns.Add("BusinessUnitName", typeof(string));
            dtUsers2.Columns.Add("BusinessUnitId", typeof(string));

            dtUsers2.PrimaryKey = new DataColumn[] { dtUsers2.Columns["UserId"] };
        }

        #region grids

        private void SetUsersGrid()
        {
            try
            {
                dtUsers.Rows.Clear();

                EntityCollection usersCol = bl.GetAllUsers();

                foreach (Entity u in usersCol.Entities)
                {
                    //if the user is not in the 
                    if (dtUsers.Rows.Find(u.Id) == null)
                    {
                        string userName = u.Contains("fullname") ? u.Attributes["fullname"].ToString() : u.Attributes["domainname"].ToString();

                        EntityReference BusinessUnitRef = u.Contains("businessunitid") ? u.GetAttributeValue<EntityReference>("businessunitid") : null;
                        string BusinessUnitName = BusinessUnitRef != null ? BusinessUnitRef.Name : string.Empty;
                        string BusinessUnitId = BusinessUnitRef != null ? BusinessUnitRef.Id.ToString() : string.Empty;

                        dtUsers.Rows.Add(false, userName, u.Id, BusinessUnitName, BusinessUnitId);
                        dtUsers2.Rows.Add(false, userName, u.Id, BusinessUnitName, BusinessUnitId);
                    }
                }

                gridUsers.DataSource = dtUsers;
                gridUsers2.DataSource = dtUsers2;
                SetGridUsersColumnsProp();
                gridUsers.Focus();
            }
            catch (Exception ex)
            {
                _log.HandleException(ex, 1, ex.Message);
                log.Error("CompareUsersPrivAndTeam.SetUsersGrid: " + ex);
            }
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

            gridUsers.Columns["BusinessUnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridUsers.Columns["BusinessUnitName"].HeaderText = "User";
            gridUsers.Columns["BusinessUnitName"].ReadOnly = true;

            gridUsers.Columns["BusinessUnitId"].Visible = false;


            gridUsers2.Columns["UserCheck"].Width = 30;
            gridUsers2.Columns["UserCheck"].HeaderText = "";
            gridUsers2.Columns["UserCheck"].ReadOnly = false;

            gridUsers2.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridUsers2.Columns["UserName"].HeaderText = "User";
            gridUsers2.Columns["UserName"].ReadOnly = true;

            gridUsers2.Columns["UserId"].Visible = false;

            gridUsers2.Columns["BusinessUnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridUsers2.Columns["BusinessUnitName"].HeaderText = "User";
            gridUsers2.Columns["BusinessUnitName"].ReadOnly = true;

            gridUsers2.Columns["BusinessUnitId"].Visible = false;

        }

        #endregion

        #region Events
        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {
            dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "UserName", txtUserFilter.Text);
            txtUserFilter.Focus();
        }

        private void txtUserFilter2_TextChanged(object sender, EventArgs e)
        {
            dtUsers2.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "UserName", txtUserFilter2.Text);
            txtUserFilter2.Focus();
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
                log.Error("CompareUsersPrivAndTeam.gridUsers_CellClick: " + ex);
            }
        }



        /// <summary>
        /// If the row was already selected, will make it false, if it was not, will make sure is the only row selected
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        private void MakeOnlyOneSelection(DataGridView grid, DataGridViewRow row)
        {
            bl.MakeOnlyOneSelection(grid, row);
        }

        private void EnableButOption()
        {
            if (GetCheckedRow(gridUsers) == 1 && GetCheckedRow(gridUsers2) == 1)
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

        private int GetCheckedRow(DataGridView grid)
        {
            int nrRecordsCheked = 0;
            foreach (DataGridViewRow r in grid.Rows)
            {
                if ((bool)r.Cells[0].Value == true)
                {
                    nrRecordsCheked++;
                    if (nrRecordsCheked > 1)
                    {
                        break;
                    }
                }
            }

            return nrRecordsCheked;
        }

        private void butClearSearch_Click(object sender, EventArgs e)
        {
            txtUserFilter.Text = string.Empty;
        }

        private void butClearSearch2_Click(object sender, EventArgs e)
        {
            txtUserFilter2.Text = string.Empty;
        }

        #endregion

        private void butOpenUser_Click(object sender, EventArgs e)
        {
            Guid id = Guid.Empty;
            string userName = string.Empty;
            Guid id2 = Guid.Empty;
            string userName2 = string.Empty;
            string userBusinessUnit= string.Empty;
            string userBusinessUnit2 = string.Empty;
            for (int i = 0; i < gridUsers.Rows.Count; i++)
            {
                if ((bool)gridUsers.Rows[i].Cells["UserCheck"].Value == true)
                {
                    id = new Guid(gridUsers.Rows[i].Cells["UserId"].Value.ToString());
                    userName = gridUsers.Rows[i].Cells["UserName"].Value.ToString();
                    userBusinessUnit = gridUsers.Rows[i].Cells["BusinessUnitId"].Value.ToString();
                    break;
                }
            }
            for (int i = 0; i < gridUsers2.Rows.Count; i++)
            {
                if ((bool)gridUsers2.Rows[i].Cells["UserCheck"].Value == true)
                {
                    id2 = new Guid(gridUsers2.Rows[i].Cells["UserId"].Value.ToString());
                    userName2 = gridUsers2.Rows[i].Cells["UserName"].Value.ToString();
                    userBusinessUnit2 = gridUsers2.Rows[i].Cells["BusinessUnitId"].Value.ToString();
                    break;
                }
            }
            if (userBusinessUnit.ToLower() != userBusinessUnit2.ToLower()) {
                MessageBox.Show("Users from different Business Unit, make sure that users are in the same business unit");
                return;
            }
            if (id != Guid.Empty && id2 != Guid.Empty)
            {
                Cursor.Current = Cursors.WaitCursor;
                CompareUsersPrivAndTeam2 form = new CompareUsersPrivAndTeam2(bl, log, id, userName, id2, userName2);
                form.ShowDialog();

            }
            else {
                MessageBox.Show("Need to select users to compare");
            }



        }
    }
}
