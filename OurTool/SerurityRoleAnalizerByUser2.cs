using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System.ComponentModel;
using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;

namespace OurCRMTool
{
    public partial class SerurityRoleAnalizerByUser2 : Form
    {
        #region CONS/VAR

        private BL bl;
        string userTeamName;
        string entityName;
        log4net.ILog log;
        string OPEN_ROLE_IN_CRM = "Open Role in CRM";
        bool finishRetrievingData = false;
        EntityReference userOrTeamRef;
        public DataTable dtCustomEntities = new DataTable();
        public DataTable dtSystemEntities = new DataTable();
        public DataTable dtGlobal = new DataTable();
        string CUSTOM = "fistCustom";  //to create/identified columns of customer entities
        string SYSTEM = "fistSystem"; //to create/identified columns of system entities
        string GLOBAL = "fistGlobal"; //to create/identified columns of global privilege
        RetrieveAllEntitiesResponse entityMetadata = null;
        DataTable dtRoles = new DataTable();
        EntityCollection rolesCol = new EntityCollection();
        BackgroundWorker worker = new BackgroundWorker();
        DataTable selectedRows = new DataTable();

        #endregion

        #region Contructor

        public SerurityRoleAnalizerByUser2(BL _bl, Guid _id, string _userTeamName, string _entityName, RetrieveAllEntitiesResponse _entityMetadata, log4net.ILog _log)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            bl = _bl;
            log = _log;
            userOrTeamRef = new EntityReference(_entityName, _id);
            userTeamName = _userTeamName;
            entityName = _entityName;
            this.Text = "SerurityRoleAnalizerByUser2 - " + userTeamName;
            lbUser1.Text = _entityName + ": " + userTeamName;
            lbUser2.Text = _entityName + ": " + userTeamName;
            lbUser3.Text = _entityName + ": " + userTeamName;
            entityMetadata = _entityMetadata;

            CreatedtdtRolesColumns(dtRoles);
            CreatedtdtEntitiesColumns(dtCustomEntities, CUSTOM);
            CreatedtdtEntitiesColumns(dtSystemEntities, SYSTEM);
            CreatedtdtGlobalColumns(dtGlobal, GLOBAL);
            CreatedtSelectedRowsColumns();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();

            List<Entity> userOrTeamList = new List<Entity>();
            Entity e = new Entity();
            e.LogicalName = userOrTeamRef.LogicalName;
            e.Id = userOrTeamRef.Id;
            e["name"] = _userTeamName;
            userOrTeamList.Add(e);

            if (_entityName == "systemuser")
            {
                EntityCollection usersTeams = bl.GetTeamsByUser(_id);
                if (usersTeams.Entities.Count() > 0)
                {
                    foreach (Entity t in usersTeams.Entities)
                    {
                        Entity team = new Entity();
                        team.LogicalName = "team";
                        team.Id = (Guid)t.GetAttributeValue<AliasedValue>("team.teamid").Value;
                        team["name"] = t.GetAttributeValue<AliasedValue>("team.name").Value.ToString();
                        userOrTeamList.Add(team);
                    }
                }
            }
            SetRoleGrid(userOrTeamList);
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Worker

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //ResetPrivilegGrid();
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butCheck.Text = "Check >>";
            finishRetrievingData = true;
        }
        #endregion


        #region Tables

        private void SetGridEntityProperties(DataGridView grid, string identifier)
        {
            if (grid.Columns.Count > 0)
            {
                //set Columns properties
                grid.Columns["LogicName" + identifier].Visible = false;
                grid.Columns["LogicName" + identifier].ReadOnly = true;
                grid.Columns["LogicName" + identifier].SortMode = DataGridViewColumnSortMode.NotSortable;

                grid.Columns["Name" + identifier].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns["Name" + identifier].HeaderText = "Entity Name";
                grid.Columns["Name" + identifier].ReadOnly = true;
                grid.Columns["Name" + identifier].SortMode = DataGridViewColumnSortMode.Automatic;

                grid.Columns["Create" + identifier].Width = 40;
                grid.Columns["Create" + identifier].HeaderText = "Create";
                grid.Columns["Create" + identifier].ReadOnly = true;

                grid.Columns["Read" + identifier].Width = 40;
                grid.Columns["Read" + identifier].HeaderText = "Read";
                grid.Columns["Read" + identifier].ReadOnly = true;

                grid.Columns["Write" + identifier].Width = 40;
                grid.Columns["Write" + identifier].HeaderText = "Write";
                grid.Columns["Write" + identifier].ReadOnly = true;

                grid.Columns["Delete" + identifier].Width = 40;
                grid.Columns["Delete" + identifier].HeaderText = "Delete";
                grid.Columns["Delete" + identifier].ReadOnly = true;

                grid.Columns["Append" + identifier].Width = 40;
                grid.Columns["Append" + identifier].HeaderText = "Append";
                grid.Columns["Append" + identifier].ReadOnly = true;

                grid.Columns["AppendTo" + identifier].Width = 40;
                grid.Columns["AppendTo" + identifier].HeaderText = "Append to";
                grid.Columns["AppendTo" + identifier].ReadOnly = true;

                grid.Columns["Assign" + identifier].Width = 40;
                grid.Columns["Assign" + identifier].HeaderText = "Assign";
                grid.Columns["Assign" + identifier].ReadOnly = true;

                grid.Columns["Share" + identifier].Width = 40;
                grid.Columns["Share" + identifier].HeaderText = "Share";
                grid.Columns["Share" + identifier].ReadOnly = true;
            }
        }
        private void SetGridGlobalProperties(DataGridView grid, string identifier)
        {
            if (grid.Columns.Count > 0)
            {
                //set Columns properties
                grid.Columns["Name" + identifier].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns["Name" + identifier].HeaderText = "Privilege Name";
                grid.Columns["Name" + identifier].ReadOnly = true;
                grid.Columns["Name" + identifier].SortMode = DataGridViewColumnSortMode.Automatic;

                grid.Columns["priv" + identifier].Width = 40;
                grid.Columns["priv" + identifier].HeaderText = "";
                grid.Columns["priv" + identifier].ReadOnly = true;
            }
        }
        private void SetGridRolesProperties(DataGridView grid)
        {
            if (grid.Columns.Count > 0)
            {
                //set Columns properties
                grid.Columns["openRoleInCRM"].Width = 100;
                grid.Columns["openRoleInCRM"].HeaderText = "";
                grid.Columns["openRoleInCRM"].ReadOnly = true;

                grid.Columns["RoleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns["RoleName"].HeaderText = "Role Name";
                grid.Columns["RoleName"].ReadOnly = true;
                grid.Columns["RoleName"].SortMode = DataGridViewColumnSortMode.Automatic;

                grid.Columns["RoleCheck"].Width = 30;
                grid.Columns["RoleCheck"].HeaderText = "";
                grid.Columns["RoleCheck"].ReadOnly = false;

                grid.Columns["RoleId"].Width = 100;
                grid.Columns["RoleId"].HeaderText = "id";
                grid.Columns["RoleId"].ReadOnly = true;
                grid.Columns["RoleId"].Visible = false;

                grid.Columns["CommingFrom"].Width = 80;
                grid.Columns["CommingFrom"].HeaderText = "Assigned to";
                grid.Columns["CommingFrom"].ReadOnly = true;
                grid.Columns["CommingFrom"].SortMode = DataGridViewColumnSortMode.NotSortable;

                grid.Columns["UserTeamsNames"].Visible = false;
                grid.Columns["UserTeamsNames"].ReadOnly = true;
                grid.Columns["UserTeamsNames"].SortMode = DataGridViewColumnSortMode.NotSortable;
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
        private void CreatedtdtRolesColumns(DataTable table)
        {
            table.Columns.Add("openRoleInCRM", typeof(string));
            table.Columns.Add("RoleCheck", typeof(bool));
            table.Columns.Add("RoleName", typeof(string));
            table.Columns.Add("RoleId", typeof(string));
            table.Columns.Add("CommingFrom", typeof(string));  //who gives the privilege, team or user
            table.Columns.Add("UserTeamsNames", typeof(string));
            table.PrimaryKey = new DataColumn[] { table.Columns["RoleId"] };
        }
        private void CreatedtSelectedRowsColumns()
        {
            selectedRows.Columns.Add("RoleId", typeof(string));
            selectedRows.Columns.Add("RoleName", typeof(string));
        }

        #endregion  Tables

        #region Privileges

        private void butCheck_Click(object sender, EventArgs e)
        {
            UpdatePrivilegeGrid();
        }

        private void UpdatePrivilegeGrid()
        {
            Cursor.Current = Cursors.WaitCursor;
            SetGrids();
            ResetPrivilegGrid();
            SetPrivilegeGrid();
            Cursor.Current = Cursors.Default;

        }

        private void SetPrivilegeGrid()
        {
            List<Guid> selectedRoles = GetSelectedRoles();

            //TODO: when mouse over, show the privilege that gives that permision

            //EntityCollection privilegeForRoles = bl.GetPrivilege(selectedRoles);
            foreach (Guid id in selectedRoles)
            {
                SetPrivilegeGridByRoleId(id);
            }
        }

        private void SetPrivilegeGridByRoleId(Guid roleId)
        {
            EntityCollection privilegeRole = bl.GetPrivilege(roleId);

            for (int i = 0; i < privilegeRole.Entities.Count(); i++)
            {
                if (privilegeRole.Entities[i].Contains("objecttypecodes.objecttypecode")
                    && privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("objecttypecodes.objecttypecode").Value != null
                    && privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("objecttypecodes.objecttypecode").Value.ToString() != "none")
                {
                    string name = privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("objecttypecodes.objecttypecode").Value.ToString();
                    string privToUpdate = string.Empty;

                    int privDepth = (int)privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value;
                    Image privImage = bl.GetImage(privDepth);

                    switch (privilegeRole.Entities[i].GetAttributeValue<int>("accessright"))
                    {
                        case 1:  //read
                            privToUpdate = "Read";
                            break;
                        case 2:  //write
                            privToUpdate = "Write";
                            break;
                        case 4:  //append
                            privToUpdate = "Append";
                            break;
                        case 16:  //append to
                            privToUpdate = "AppendTo";
                            break;
                        case 32:  //Create
                            privToUpdate = "Create";
                            break;
                        case 65536:  //delete
                            privToUpdate = "Delete";
                            break;
                        case 262144:  //share
                            privToUpdate = "Share";
                            break;
                        case 524288:  //assign
                            privToUpdate = "Assign";
                            break;
                    }

                    DataRow row = dtCustomEntities.Rows.Find(name);
                    if (row != null)
                    {
                        if (row.Table.Columns.Contains(privToUpdate + CUSTOM))
                        {
                            //if new privilege is bigger than the old one
                            if ((row[privToUpdate + CUSTOM] as Image).Tag == null || bl.GetDepthByImage((row[privToUpdate + CUSTOM] as Image).Tag.ToString()) < privDepth)
                            {
                                row[privToUpdate + CUSTOM] = privImage;
                            }
                        }
                    }
                    else
                    {
                        row = dtSystemEntities.Rows.Find(name);
                        if (row != null)
                        {
                            if (row.Table.Columns.Contains(privToUpdate + SYSTEM))
                            {
                                //if new privilege is bigger than the old one
                                if ((row[privToUpdate + SYSTEM] as Image).Tag == null || bl.GetDepthByImage((row[privToUpdate + SYSTEM] as Image).Tag.ToString()) < privDepth)
                                {
                                    row[privToUpdate + SYSTEM] = privImage;
                                }
                            }
                        }
                    }
                }
                else if (privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("objecttypecodes.objecttypecode").Value.ToString() == "none")
                {
                    //is global privilege
                    string name = privilegeRole.Entities[i].GetAttributeValue<string>("name");
                    int privDepth = (int)privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value;
                    Image privImage = bl.GetImage(privDepth);

                    DataRow row = dtGlobal.Rows.Find(name);
                    if (row != null)
                    {
                        if (row.Table.Columns.Contains("priv" + GLOBAL))
                        {
                            //if new privilege is bigger than the old one
                            if ((row["priv" + GLOBAL] as Image).Tag == null || bl.GetDepthByImage((row["priv" + GLOBAL] as Image).Tag.ToString()) < privDepth)
                            {
                                row["priv" + GLOBAL] = privImage;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// this function will set the rows of each grid
        /// </summary>
        public void ResetPrivilegGrid()
        {
            try
            {
                EntityCollection rolePrivilege = new EntityCollection();
                dtCustomEntities.Clear();
                dtSystemEntities.Clear();
                dtGlobal.Clear();

                if (entityMetadata == null)
                {
                    entityMetadata = bl.GetEntities();
                }
                rolePrivilege = bl.GetGlobalPrivilege();

                Image nonePrivImage = bl.GetImage();

                foreach (EntityMetadata currentEntity in entityMetadata.EntityMetadata)
                {
                    if (currentEntity.DisplayName != null && currentEntity.DisplayName.UserLocalizedLabel != null)
                    {
                        if ((bool)currentEntity.IsCustomEntity == true)
                        {
                            dtCustomEntities.Rows.Add(currentEntity.LogicalName, currentEntity.DisplayName.UserLocalizedLabel.Label, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage);
                        }
                        else
                        {
                            dtSystemEntities.Rows.Add(currentEntity.LogicalName, currentEntity.DisplayName.UserLocalizedLabel.Label, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage, nonePrivImage);
                        }
                    }
                }

                foreach (Entity p in rolePrivilege.Entities)
                {
                    if (!dtGlobal.Rows.Contains(p.GetAttributeValue<string>("name")))
                    {
                        dtGlobal.Rows.Add(p.GetAttributeValue<string>("name"), nonePrivImage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearPrivilegeGrids()
        {
            dtCustomEntities.Clear();
            dtSystemEntities.Clear();
            dtGlobal.Clear();
        }

        #endregion

        #region Roles

        private List<Guid> GetSelectedRoles()
        {
            List<Guid> selectedRows = new List<Guid>();

            foreach (DataGridViewRow r in gridRoles.Rows)
            {
                if (r.Cells["RoleCheck"].Value.ToString() != string.Empty && (bool)r.Cells["RoleCheck"].Value == true)
                {
                    selectedRows.Add(new Guid(r.Cells["RoleId"].Value.ToString()));
                }
            }
            return selectedRows;
        }

        private void SetRoleGrid(List<Entity> userOrTeamList)
        {
            dtRoles.Rows.Clear();
            string usersTeamsNames = string.Empty;
            List<Guid> rolesAdded = new List<Guid>();
            foreach (Entity u in userOrTeamList)
            {
                rolesCol.Entities.Clear();
                rolesCol = bl.GetRolesByUserId(u.ToEntityReference());

                foreach (Entity role in rolesCol.Entities)
                {
                    bool addRole = true;
                    Guid roleId;
                    if (role.Contains("parentroleid"))
                    {
                        roleId = role.GetAttributeValue<EntityReference>("parentroleid").Id;
                    }
                    else
                    {
                        roleId = role.Id;
                    }
                    string commingFrom = string.Empty;

                    if (rolesAdded.Contains(roleId))
                    {
                        DataRow row = dtRoles.Rows.Find(roleId);
                        if (row != null) {
                            row["UserTeamsNames"] = row["UserTeamsNames"].ToString() + ", " + u.GetAttributeValue<string>("name");
                            row["CommingFrom"] = "User & Team";
                            addRole = false;
                        }
                    }
                    else
                    {
                        usersTeamsNames = u.GetAttributeValue<string>("name");
                        rolesAdded.Add(roleId);
                        if (u.LogicalName.ToLower() == "team")
                        {
                            commingFrom = "Team";
                        }
                        else
                        {
                            commingFrom = "User";
                        }
                    }
                    if (addRole)
                    {
                        dtRoles.Rows.Add(OPEN_ROLE_IN_CRM, false, role.GetAttributeValue<string>("name"), roleId, commingFrom, usersTeamsNames);
                    }
                }
            }
            gridRoles.DataSource = dtRoles;
            SetGridRolesProperties(gridRoles);
        }

        private void butClearAllRoles_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridRoles.Rows)
            {
                r.Cells["RoleCheck"].Value = false;
            }
            ClearPrivilegeGrids();
        }

        private void butSelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridRoles.Rows)
            {
                r.Cells["RoleCheck"].Value = true;
            }
            UpdatePrivilegeGrid();
        }

        private void gridRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ClearPrivilegeGrids();
                DataGridView senderGridView = (sender as DataGridView);

                if (senderGridView.CurrentCell.Value.ToString() != OPEN_ROLE_IN_CRM)
                {
                    if (senderGridView.CurrentRow != null)
                    {
                        senderGridView.CurrentRow.Cells["RoleCheck"].Value = !(bool)senderGridView.CurrentRow.Cells["RoleCheck"].Value;
                        EnableButOption(senderGridView);
                    }

                    if (GetCheckedRow(gridRoles) > 0)
                    {
                        if (chkUpdateGridOnSelect.Checked)
                        {
                            UpdatePrivilegeGrid();
                        }
                    }
                    else
                    {
                        ClearPrivilegeGrids();
                    }
                }
                else
                {
                    //open the role in CRM
                    bl.OpenRole(senderGridView.CurrentRow.Cells["RoleId"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //  log.HandleException(ex, 0, "SerurityRoleAnalizerByUser2.CellClick");
            }
        }

        #endregion

        /// <summary>
        /// Will set all the grids data
        /// </summary>
        private void SetGrids()
        {
            if (gridCustomEntities.DataSource == null || gridSystemEntities.DataSource == null || gridGlobal.DataSource == null)
            {
                gridCustomEntities.DataSource = dtCustomEntities;
                gridSystemEntities.DataSource = dtSystemEntities;
                gridGlobal.DataSource = dtGlobal;

                SetGridGlobalProperties(gridGlobal, GLOBAL);
                SetGridEntityProperties(gridCustomEntities, CUSTOM);
                SetGridEntityProperties(gridSystemEntities, SYSTEM);
                gridSystemEntities.Focus();
            }
        }


        #region Grids Events

        private void txtSystemSearch_TextChanged(object sender, EventArgs e)
        {
            dtSystemEntities.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Name" + SYSTEM, txtSystemSearch.Text);
            txtSystemSearch.Focus();
        }

        private void txtPrivilegeSearch_TextChanged(object sender, EventArgs e)
        {
            dtGlobal.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Name" + GLOBAL, txtPrivilegeSearch.Text);
            txtPrivilegeSearch.Focus();
        }

        private void txtCustomEntitySearch_TextChanged(object sender, EventArgs e)
        {
            dtCustomEntities.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%' OR [{2}] LIKE '%{3}%'", "Name" + CUSTOM, txtCustomEntitySearch.Text, "LogicName" + CUSTOM, txtCustomEntitySearch.Text);
            txtCustomEntitySearch.Focus();
        }

        #endregion

        #region ToolTip

        private void AddToolTip(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if ((e.ColumnIndex == 1) && e.Value != null)
            {
                SetToolTips(grid, e.RowIndex);
            }
        }
        private void SetToolTips(DataGridView grid, int rowIndex)
        {
            DataGridViewCell cell = grid.Rows[rowIndex].Cells[1];              // 1 = Name
            cell.ToolTipText = grid.Rows[rowIndex].Cells[0].Value.ToString();  // 0 = LogicName

            if (grid.Name.ToLower() == "gridroles")
            {
                if (grid.Rows[rowIndex].Cells["UserTeamsNames"] != null)
                {
                    DataGridViewCell cell2 = grid.Rows[rowIndex].Cells["UserTeamsNames"];
                    cell2.ToolTipText = grid.Rows[rowIndex].Cells["CommingFrom"].Value.ToString();
                }
            }

        }

        private void AddToolTip2(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if ((e.ColumnIndex == 4) && e.Value != null)
            {
                SetToolTips2(grid, e.RowIndex);
            }
        }
        private void SetToolTips2(DataGridView grid, int rowIndex)
        {
            if (grid.Name.ToLower() == "gridroles")
            {
                if (grid.Rows[rowIndex].Cells["UserTeamsNames"] != null)
                {
                    DataGridViewCell cell2 = grid.Rows[rowIndex].Cells["CommingFrom"];
                    cell2.ToolTipText = grid.Rows[rowIndex].Cells["UserTeamsNames"].Value.ToString();
                }
            }
        }

        #endregion


        private int GetCheckedRow(DataGridView grid)
        {
            selectedRows.Clear();

            int nrRecordsCheked = 0;
            foreach (DataGridViewRow r in grid.Rows)
            {
                if ((bool)r.Cells["RoleCheck"].Value == true)
                {
                    selectedRows.Rows.Add(r.Cells["RoleId"].Value.ToString(), r.Cells["RoleName"].Value.ToString());
                    nrRecordsCheked++;
                    if (nrRecordsCheked > 1)
                    {  //used for teams grid, only can be selected one team to check its security Roles
                        break;
                    }
                }
            }
            return nrRecordsCheked;
        }

        private void EnableButOption(DataGridView grid)
        {
            if (finishRetrievingData && butCheck.Visible)
            {
                if (GetCheckedRow(grid) > 0)
                {
                    butCheck.BackColor = Color.Olive;
                    butCheck.Enabled = true;
                }
                else
                {
                    butCheck.BackColor = Color.Gray;
                    butCheck.Enabled = false;
                }
            }
        }

        private void chkUpdateGridOnSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox sendercheckBox = (sender as CheckBox);
            butCheck.Visible = !sendercheckBox.Checked;
            EnableButOption(gridRoles);
        }

        private void panel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGridGlobalProperties(gridGlobal, GLOBAL);
            SetGridEntityProperties(gridCustomEntities, CUSTOM);
            SetGridEntityProperties(gridSystemEntities, SYSTEM);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetCheckedRow(gridRoles) == 2)
            {
                SecurityRolesCompare form = new SecurityRolesCompare(bl, log, new Guid(selectedRows.Rows[0]["RoleId"].ToString()), selectedRows.Rows[0]["RoleName"].ToString(), new Guid(selectedRows.Rows[1]["RoleId"].ToString()), selectedRows.Rows[1]["RoleName"].ToString());
                form.Show();
            }
            else
            {
                MessageBox.Show("Please select 2 Roles to compare");
            }
        }

        private void lbUser1_Click(object sender, EventArgs e)
        {
            bl.OpenWithArguments(userOrTeamRef.Id.ToString(), userOrTeamRef.LogicalName);
        }

        private void lbUser2_Click(object sender, EventArgs e)
        {
            bl.OpenWithArguments(userOrTeamRef.Id.ToString(), userOrTeamRef.LogicalName);
        }

        private void lbUser3_Click(object sender, EventArgs e)
        {
            bl.OpenWithArguments(userOrTeamRef.Id.ToString(), userOrTeamRef.LogicalName);
        }
    }
}
