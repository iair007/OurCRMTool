using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System.ComponentModel;
using Microsoft.Xrm.Sdk.Metadata;

namespace OurCRMTool
{
    public partial class SerurityRoleAnalizerByUser2 : Form
    {
        #region CONS/VAR

        private BL bl;
        Guid id;
        string userName;
        string entityName;
        log4net.ILog log;
        EntityCollection usersRoles = null;
        public DataTable dtCustomEntities = new DataTable();
        public DataTable dtSystemEntities = new DataTable();
        public DataTable dtGlobal = new DataTable();
        string CUSTOM = "fistCustom";  //to create/identified columns of customer entities
        string SYSTEM = "fistSystem"; //to create/identified columns of system entities
        string GLOBAL = "fistGlobal"; //to create/identified columns of global privilege
        RetrieveAllEntitiesResponse entityMetadata = null;

        #endregion

        #region Contructor

        public SerurityRoleAnalizerByUser2(BL _bl, Guid _id, string _userName, string _entityName, RetrieveAllEntitiesResponse _entityMetadata, log4net.ILog _log)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            bl = _bl;
            log = _log;
            userName = _userName;
            entityName = _entityName;
            this.Text = "SerurityRoleAnalizerByUser2 - " + userName;
            lbUser1.Text = entityName + ": " + userName;
            lbUser2.Text = entityName + ": " + userName;
            lbUser3.Text = entityName + ": " + userName;
            entityMetadata = _entityMetadata;
            SetGrids();

            CreatedtdtEntitiesColumns(dtCustomEntities, CUSTOM);
            CreatedtdtEntitiesColumns(dtSystemEntities, SYSTEM);
            CreatedtdtGlobalColumns(dtGlobal, GLOBAL);

            Cursor.Current = Cursors.Default;
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
                grid.Columns["Name" + identifier].SortMode = DataGridViewColumnSortMode.NotSortable;

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
                grid.Columns["Name" + identifier].SortMode = DataGridViewColumnSortMode.NotSortable;

                grid.Columns["priv" + identifier].Width = 40;
                grid.Columns["priv" + identifier].HeaderText = "";
                grid.Columns["priv" + identifier].ReadOnly = true;
            }
        }

        #endregion  Tables

        #region Roles

        private void butRefresh_Click(object sender, EventArgs e)
        {
            //TODO: finish this
            Cursor.Current = Cursors.WaitCursor;
            //    parentForm.ResetGrids();
            //    SetGrids();
            Cursor.Current = Cursors.Default;
        }

        #endregion

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

        /// <summary>
        /// Will set all the grids data
        /// </summary>
        private void SetGrids()
        {
            gridCustomEntities.DataSource = dtCustomEntities;
            gridSystemEntities.DataSource = dtSystemEntities;
            gridGlobal.DataSource = dtGlobal;


         //   SetRoleGrid(firstRoleId, dtCustomEntities, dtSystemEntities, dtGlobal);

            SetGridEntityProperties(gridCustomEntities, CUSTOM);
            SetGridEntityProperties(gridSystemEntities, SYSTEM);
            SetGridGlobalProperties(gridGlobal, GLOBAL);

            gridSystemEntities.Focus();
        }

        ///// <summary>
        ///// Will set the grid according the roleId and is is the first or second Role comparing
        ///// </summary>
        ///// <param name="roleId"></param>
        ///// <param name="customEntitiesDT"></param>
        ///// <param name="systemEntitiesDT"></param>
        ///// <param name="globalDT"></param>
        private void SetRoleGrid(Guid roleId, DataTable customEntitiesDT, DataTable systemEntitiesDT, DataTable globalDT)
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

                    Image privImage = bl.GetImage((int)privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value);
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

                    DataRow row = customEntitiesDT.Rows.Find(name);
                    if (row != null)
                    {
                        if (row.Table.Columns.Contains(privToUpdate + CUSTOM))
                        {
                            row[privToUpdate + CUSTOM] = privImage;
                        }
                    }
                    else
                    {
                        row = systemEntitiesDT.Rows.Find(name);
                        if (row != null)
                        {
                            if (row.Table.Columns.Contains(privToUpdate + SYSTEM))
                            {
                                row[privToUpdate + SYSTEM] = privImage;
                            }
                        }
                    }
                }
                else if (privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("objecttypecodes.objecttypecode").Value.ToString() == "none")
                {
                    //is global privilege
                    string name = privilegeRole.Entities[i].GetAttributeValue<string>("name");
                    Image privImage = bl.GetImage((int)privilegeRole.Entities[i].GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value);

                    DataRow row = globalDT.Rows.Find(name);
                    if (row != null)
                    {
                        if (row.Table.Columns.Contains("priv" + GLOBAL))
                        {
                            row["priv" + GLOBAL] = privImage;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// this function will set the rows of each grid
        /// </summary>
        public void ResetGrids()
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
                if (usersRoles == null)
                {
                    usersRoles = bl.GetRolesByUserId(new EntityReference(entityName,id));
                }

                foreach (Entity r in usersRoles.Entities) {
                    rolePrivilege = bl.GetPrivilege(r.Id);
                }

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

                ///IAIR, NEED TO SEE IF DO IT LIKE THIS OR JUST SET THE SYSTEM ADMINISTRATOR ROLE TO GET ALL THE POSIBBLE GLOBAL PRIVILEGES
                foreach (Entity p in rolePrivilege.Entities)
                {
                    dtGlobal.Rows.Add(p.GetAttributeValue<string>("name"), nonePrivImage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Grids Events

        private void gridFirstSystemEntities_SelectionChanged(object sender, EventArgs e)
        {
            //    if (!commingFromOtherSelect)
            //    {
            //        if (gridSecondSystemEntities.Rows.Count > 0)
            //        {
            //            DataGridView senderGridView = (sender as DataGridView);
            //            DataGridViewRow selectedRow = senderGridView.CurrentRow;
            //            if (selectedRow != null)
            //            {
            //                int selectedIndex = selectedRow.Index;
            //                commingFromOtherSelect = true;
            //                gridSecondSystemEntities.Rows[selectedIndex].Selected = true;
            //            }
            //            commingFromOtherSelect = false;
            //        }
            //    }
        }

        private void gridSecondSystemEntities_SelectionChanged(object sender, EventArgs e)
        {
            //    if (!commingFromOtherSelect)
            //    {
            //        if (gridFirstSystemEntities.Rows.Count > 0)
            //        {
            //            DataGridView senderGridView = (sender as DataGridView);
            //            DataGridViewRow selectedRow = senderGridView.CurrentRow;
            //            if (selectedRow != null)
            //            {
            //                int selectedIndex = selectedRow.Index;
            //                commingFromOtherSelect = true;
            //                gridFirstSystemEntities.Rows[selectedIndex].Selected = true;
            //            }
            //            commingFromOtherSelect = false;
            //        }
            //    }
        }

        private void gridFirstGlobal_SelectionChanged(object sender, EventArgs e)
        {
            //    if (!commingFromOtherSelect)
            //    {
            //        if (gridSecondGlobal.Rows.Count > 0)
            //        {
            //            DataGridView senderGridView = (sender as DataGridView);
            //            DataGridViewRow selectedRow = senderGridView.CurrentRow;
            //            if (selectedRow != null)
            //            {
            //                int selectedIndex = selectedRow.Index;
            //                commingFromOtherSelect = true;
            //                gridSecondGlobal.Rows[selectedIndex].Selected = true;
            //            }
            //        }
            //        commingFromOtherSelect = false;
            //    }
        }

        private void gridSecondGlobal_SelectionChanged(object sender, EventArgs e)
        {
            //    if (!commingFromOtherSelect)
            //    {
            //        if (gridFirstGlobal.Rows.Count > 0)
            //        {
            //            DataGridView senderGridView = (sender as DataGridView);
            //            DataGridViewRow selectedRow = senderGridView.CurrentRow;
            //            if (selectedRow != null)
            //            {
            //                int selectedIndex = selectedRow.Index;
            //                commingFromOtherSelect = true;
            //                gridFirstGlobal.Rows[selectedIndex].Selected = true;
            //            }
            //        }
            //        commingFromOtherSelect = false;
            //    }
        }

        private void gridFirstCustomEntities_SelectionChanged(object sender, EventArgs e)
        {
            //    if (!commingFromOtherSelect)
            //    {
            //        if (gridSecondCustomEntities.Rows.Count > 0)
            //        {
            //            DataGridView senderGridView = (sender as DataGridView);
            //            DataGridViewRow selectedRow = senderGridView.CurrentRow;
            //            if (selectedRow != null)
            //            {
            //                int selectedIndex = selectedRow.Index;
            //                commingFromOtherSelect = true;
            //                gridSecondCustomEntities.Rows[selectedIndex].Selected = true;
            //            }
            //        }
            //        commingFromOtherSelect = false;
            //    }
        }

        private void gridSecondCustomEntities_SelectionChanged(object sender, EventArgs e)
        {
            //    if (!commingFromOtherSelect)
            //    {
            //        if (gridFirstCustomEntities.Rows.Count > 0)
            //        {
            //            DataGridView senderGridView = (sender as DataGridView);
            //            DataGridViewRow selectedRow = senderGridView.CurrentRow;
            //            if (selectedRow != null)
            //            {

            //                int selectedIndex = selectedRow.Index;
            //                commingFromOtherSelect = true;
            //                gridFirstCustomEntities.Rows[selectedIndex].Selected = true;
            //            }
            //        }
            //        commingFromOtherSelect = false;
            //    }
        }

        private void lbFirstCustomRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    switch (panel1.SelectedIndex)
            //    {
            //        case 0:
            //            gridFirstSystemEntities.Focus();
            //            break;
            //        case 1:
            //            gridFirstGlobal.Focus();
            //            break;
            //        case 2:
            //            gridFirstCustomEntities.Focus();
            //            break;
            //    }
        }

        private void txtSystemSearch_TextChanged(object sender, EventArgs e)
        {
            //    foreach (DataGridViewRow row in gridFirstSystemEntities.Rows)
            //    {
            //        if (row.Cells["Name" + FIRST_SYSTEM].Value.ToString().ToLower().Contains(txtSystemSearch.Text.ToLower()))
            //        {
            //            gridSecondSystemEntities.FirstDisplayedScrollingRowIndex = row.Index;
            //            gridFirstSystemEntities.FirstDisplayedScrollingRowIndex = row.Index;
            //            gridFirstSystemEntities.Rows[row.Index].Selected = true;
            //            break;
            //        }
            //    }
            //    txtSystemSearch.Focus();
        }

        private void txtPrivilegeSearch_TextChanged(object sender, EventArgs e)
        {
            //    foreach (DataGridViewRow row in gridFirstGlobal.Rows)
            //    {
            //        if (row.Cells["Name" + FIRST_GLOBAL].Value.ToString().ToLower().Contains(txtPrivilegeSearch.Text.ToLower()))
            //        {
            //            gridSecondGlobal.FirstDisplayedScrollingRowIndex = row.Index;
            //            gridFirstGlobal.FirstDisplayedScrollingRowIndex = row.Index;
            //            gridFirstGlobal.Rows[row.Index].Selected = true;
            //            break;
            //        }
            //    }
            //    txtPrivilegeSearch.Focus();
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            //    foreach (DataGridViewRow row in gridFirstCustomEntities.Rows)
            //    {
            //        if (row.Cells["Name" + FIRST_CUSTOM].Value.ToString().ToLower().Contains(txtCustomerSearch.Text.ToLower())
            //            || row.Cells["LogicName" + FIRST_CUSTOM].Value.ToString().ToLower().Contains(txtCustomerSearch.Text.ToLower()))
            //        {
            //            gridSecondCustomEntities.FirstDisplayedScrollingRowIndex = row.Index;
            //            gridFirstCustomEntities.FirstDisplayedScrollingRowIndex = row.Index;
            //            gridFirstCustomEntities.Rows[row.Index].Selected = true;
            //            break;
            //        }
            //    }
            //    txtCustomerSearch.Focus();
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
            DataGridViewCell cell = grid.Rows[rowIndex].Cells[1];
            cell.ToolTipText = grid.Rows[rowIndex].Cells[0].Value.ToString();
        }

        #endregion
    }
}
