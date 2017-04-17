using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk;
using System.ComponentModel;

namespace OurCRMTool
{
    public partial class SecurityRolesCompare : Form
    {
        private BL bl;
        log4net.ILog log;
        EntityCollection rolesCol = null;
        RetrieveAllEntitiesResponse entityMetadata = null;
        EntityCollection globalPrivilege = null;
        string FIRST_CUSTOM = "fistCustom";  //to create/identified columns of first selected role for customer entities
        string SECOND_CUSTOM = "secondCustom"; //to create/identified columns of second selected role for customer entities
        string FIRST_SYSTEM = "fistSystem"; //to create/identified columns of first selected role for system entities
        string SECOND_SYSTEM = "secondSystem"; //to create/identified columns of second selected role for system entities
        string FIRST_GLOBAL = "fistGlobal"; //to create/identified columns of first selected role for global privilege
        string SECOND_GLOBAL = "secondGlobal"; //to create/identified columns of second selected role for global privilege
        string FIRST_ROLE = "first";
        string SECOND_ROLE = "second";
        DataTable dtRoles = new DataTable();
        DataTable dtRoles2 = new DataTable();
        public DataTable dtFirstCustomEntities = new DataTable();
        public DataTable dtSecondCustomEntities = new DataTable();
        public DataTable dtFirstSystemEntities = new DataTable();
        public DataTable dtSecondSystemEntities = new DataTable();
        public DataTable dtFirstGlobal = new DataTable();
        public DataTable dtSecondGlobal = new DataTable();
        BackgroundWorker worker = new BackgroundWorker();

        #region Contructor

        public SecurityRolesCompare(BL _bl, log4net.ILog _log, Guid? selectedRole = null)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            bl = _bl;
            log = _log;
            this.Text = "Security Roles Analizer - Connected to: " + bl.url;
            CreatedtdtRolesColumns(dtRoles, FIRST_ROLE);
            CreatedtdtRolesColumns(dtRoles2, SECOND_ROLE);
            CreatedtdtEntitiesColumns(dtFirstCustomEntities, FIRST_CUSTOM);
            CreatedtdtEntitiesColumns(dtFirstSystemEntities, FIRST_SYSTEM);
            CreatedtdtEntitiesColumns(dtSecondCustomEntities, SECOND_CUSTOM);
            CreatedtdtEntitiesColumns(dtSecondSystemEntities, SECOND_SYSTEM);
            CreatedtdtGlobalColumns(dtFirstGlobal, FIRST_GLOBAL);
            CreatedtdtGlobalColumns(dtSecondGlobal, SECOND_GLOBAL);

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();

            SetRoleGrid(selectedRole);
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Tables

        private void CreatedtdtRolesColumns(DataTable table, string identifier)
        {
            table.Columns.Add("RoleCheck" + identifier, typeof(bool));
            table.Columns.Add("RoleName" + identifier, typeof(string));
            table.Columns.Add("RoleId" + identifier, typeof(string));
        }
        private void SetGridRolesProperties(DataGridView grid, string identifier)
        {
            if (grid.Columns.Count > 0)
            {
                //set Columns properties
                grid.Columns["RoleName" + identifier].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns["RoleName" + identifier].HeaderText = "Role Name";
                grid.Columns["RoleName" + identifier].ReadOnly = true;

                grid.Columns["RoleCheck" + identifier].Width = 30;
                grid.Columns["RoleCheck" + identifier].HeaderText = "";
                grid.Columns["RoleCheck" + identifier].ReadOnly = false;

                grid.Columns["RoleId" + identifier].Width = 100;
                grid.Columns["RoleId" + identifier].HeaderText = "id";
                grid.Columns["RoleId" + identifier].ReadOnly = true;
                grid.Columns["RoleId" + identifier].Visible = false;
            }
        }
        private void CreatedtdtEntitiesColumns(DataTable table, string identifier)
        {
            table.Columns.Add("LogicName" + identifier, typeof(string));  //Entity's logical name
            table.Columns.Add("Name" + identifier, typeof(string));  //Entity's name
            table.Columns.Add("Create" + identifier, typeof(Image));
            table.Columns.Add("Read" + identifier, typeof(Image));
            table.Columns.Add("Write" + identifier, typeof(Image));
            table.Columns.Add("Delete" + identifier, typeof(Image));
            table.Columns.Add("Append" + identifier, typeof(Image));
            table.Columns.Add("AppendTo" + identifier, typeof(Image));
            table.Columns.Add("Assign" + identifier, typeof(Image));
            table.Columns.Add("Share" + identifier, typeof(Image));
            table.PrimaryKey = new DataColumn[] { table.Columns["LogicName" + identifier] };
        }
        private void CreatedtdtGlobalColumns(DataTable table, string identifier)
        {
            table.Columns.Add("Name" + identifier, typeof(string));
            table.Columns.Add("priv" + identifier, typeof(Image));
            table.PrimaryKey = new DataColumn[] { table.Columns["Name" + identifier] };
        }

        #endregion  Tables

        #region Roles

        private void SetRoleGrid(Guid? selectedRole = null)
        {
            dtRoles.Rows.Clear();
            dtRoles2.Rows.Clear();
            if (rolesCol == null)
            {
                rolesCol = bl.GetAllSecurityRoles();
            }

            foreach (Entity role in rolesCol.Entities)
            {
                dtRoles.Rows.Add(selectedRole != null && selectedRole == role.Id, role.GetAttributeValue<string>("name"), role.Id);
                dtRoles2.Rows.Add(selectedRole != null && selectedRole == role.Id, role.GetAttributeValue<string>("name"), role.Id);
            }
            gridRoles.DataSource = dtRoles;
            gridRoles2.DataSource = dtRoles2;

            SetGridRolesProperties(gridRoles, FIRST_ROLE);
            SetGridRolesProperties(gridRoles2, SECOND_ROLE);
        }

        #endregion

        #region Worker

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ResetGrids();
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butCheck.Enabled = true;
            butCheck.Text = "Compare";
            butCheck.BackColor = Color.Olive;
        }
        #endregion

        #region Events

        private void butCheck_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Guid? firstSelectedRole = null;
            Guid? secondSelectedRole = null;
            string firstRoleName = string.Empty;
            string secondRoleName = string.Empty;
            ResetGrids();
            for (int i = 0; i < gridRoles.Rows.Count; i++)
            {
                if ((bool)gridRoles.Rows[i].Cells["RoleCheck" + FIRST_ROLE].Value == true)
                {
                    firstSelectedRole = new Guid(gridRoles.Rows[i].Cells["RoleId" + FIRST_ROLE].Value.ToString());
                    firstRoleName = gridRoles.Rows[i].Cells["RoleName" + FIRST_ROLE].Value.ToString();
                    break;
                }
            }
            for (int i = 0; i < gridRoles2.Rows.Count; i++)
            {
                if ((bool)gridRoles2.Rows[i].Cells["RoleCheck" + SECOND_ROLE].Value == true)
                {
                    secondSelectedRole = new Guid(gridRoles2.Rows[i].Cells["RoleId" + SECOND_ROLE].Value.ToString());
                    secondRoleName = gridRoles2.Rows[i].Cells["RoleName" + SECOND_ROLE].Value.ToString();
                    break;
                }
            }

            Cursor.Current = Cursors.Default;
            if (firstSelectedRole != null && secondSelectedRole != null)
            {
                SecurityRolesCompare2 securityRolesCompare2 = new SecurityRolesCompare2(bl, this, (Guid)firstSelectedRole, firstRoleName, (Guid)secondSelectedRole, secondRoleName);
                securityRolesCompare2.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Have to check 2 roles to compare");
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView);

            if (dataGridView.CurrentCell.Value == null || dataGridView.CurrentCell.Value.ToString() == string.Empty) return;

            switch (dataGridView.CurrentCell.OwningColumn.Name)
            {
                case "RoleName":
                    bl.OpenRole(dataGridView.CurrentRow.Cells["RoleId"].Value.ToString());
                    break;
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
            }
        }

        private void txtRoleSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridRoles.Rows)
            {
                if (row.Cells["RoleName" + FIRST_ROLE].Value.ToString().ToLower().Contains(txtRoleSearch.Text.ToLower()))
                {
                    row.Selected = true;
                    gridRoles.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
            txtRoleSearch.Focus();
        }

        private void txtRole2Search_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridRoles2.Rows)
            {
                if (row.Cells["RoleName" + SECOND_ROLE].Value.ToString().ToLower().Contains(txtRole2Search.Text.ToLower()))
                {
                    row.Selected = true;
                    gridRoles2.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
            txtRole2Search.Focus();
        }
        #endregion

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

        public void ResetGrids()
        {
            try
            {
                dtFirstCustomEntities.Clear();
                dtFirstSystemEntities.Clear();
                dtFirstGlobal.Clear();
                dtSecondCustomEntities.Clear();
                dtSecondSystemEntities.Clear();
                dtSecondGlobal.Clear();

                if (entityMetadata == null)
                {
                    entityMetadata = bl.GetEntities();
                }
                if (globalPrivilege == null)
                {
                    globalPrivilege = bl.GetGlobalPrivilege();
                }

                Image nonePrivImage = bl.GetImage();

                foreach (EntityMetadata currentEntity in entityMetadata.EntityMetadata)
                {
                    if (currentEntity.DisplayName != null && currentEntity.DisplayName.UserLocalizedLabel != null)
                    {
                        if ((bool)currentEntity.IsCustomEntity == true)
                        {
                            dtFirstCustomEntities.Rows.Add(currentEntity.LogicalName, currentEntity.DisplayName.UserLocalizedLabel.Label, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage);
                            dtSecondCustomEntities.Rows.Add(currentEntity.LogicalName, currentEntity.DisplayName.UserLocalizedLabel.Label, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage);
                        }
                        else
                        {
                            dtFirstSystemEntities.Rows.Add(currentEntity.LogicalName, currentEntity.DisplayName.UserLocalizedLabel.Label, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage);
                            dtSecondSystemEntities.Rows.Add(currentEntity.LogicalName, currentEntity.DisplayName.UserLocalizedLabel.Label, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage);
                        }
                    }
                }

                foreach (Entity p in globalPrivilege.Entities)
                {
                    dtFirstGlobal.Rows.Add(p.GetAttributeValue<string>("name"), nonePrivImage);
                    dtSecondGlobal.Rows.Add(p.GetAttributeValue<string>("name"), nonePrivImage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
