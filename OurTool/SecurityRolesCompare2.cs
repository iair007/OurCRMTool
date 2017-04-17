using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using System.Web.Security;

namespace OurCRMTool
{
    public partial class SecurityRolesCompare2 : Form
    {
        #region CONS/VAR
        
        private BL bl;
        string FIRST_CUSTOM = "fistCustom";  //to create/identified columns of first selected role for customer entities
        string SECOND_CUSTOM = "secondCustom"; //to create/identified columns of second selected role for customer entities
        string FIRST_SYSTEM = "fistSystem"; //to create/identified columns of first selected role for system entities
        string SECOND_SYSTEM = "secondSystem"; //to create/identified columns of second selected role for system entities
        string FIRST_GLOBAL = "fistGlobal"; //to create/identified columns of first selected role for global privilege
        string SECOND_GLOBAL = "secondGlobal"; //to create/identified columns of second selected role for global privilege
        SecurityRolesCompare parentForm;
        bool commingFromOtherSelect = false;  //used when changeSelection in grids
        Guid firstRoleId;
        Guid secondRoleId;

        #endregion

        #region Contructor

        public SecurityRolesCompare2(BL _bl, SecurityRolesCompare _parentForm, Guid _firstRole, string firstRoleName, Guid _secondRole, string secondRoleName)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            bl = _bl;
            parentForm = _parentForm;
            firstRoleId = _firstRole;
            secondRoleId = _secondRole;
            this.Text = "Security Roles Analizer - Connected to: " + bl.url;
            lbFirstSystemRole.Text = "Role: " + firstRoleName;
            panel1.Text = "Role: " + firstRoleName;
            lbFirstGlobal.Text = "Role: " + firstRoleName;
            lbFirstCustomRole.Text = "Role: " + firstRoleName;
            lbSecondSystemRole.Text = "Role: " + secondRoleName;
            lbSecondCustomRole.Text = "Role: " + secondRoleName;
            lbSecondGlobal.Text = "Role: " + secondRoleName;

            SetGrids();
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
            Cursor.Current = Cursors.WaitCursor;
            parentForm.ResetGrids();
            SetGrids();
            Cursor.Current = Cursors.Default;
        }

        #endregion

        /// <summary>
        /// Will set all the grids data
        /// </summary>
        private void SetGrids()
        {
            gridFirstCustomEntities.DataSource = parentForm.dtFirstCustomEntities;
            gridFirstSystemEntities.DataSource = parentForm.dtFirstSystemEntities;
            gridFirstGlobal.DataSource = parentForm.dtFirstGlobal;

            gridSecondCustomEntities.DataSource = parentForm.dtSecondCustomEntities;
            gridSecondSystemEntities.DataSource = parentForm.dtSecondSystemEntities;
            gridSecondGlobal.DataSource = parentForm.dtSecondGlobal;

            SetRoleGrid(firstRoleId, parentForm.dtFirstCustomEntities, parentForm.dtFirstSystemEntities, parentForm.dtFirstGlobal);
            SetRoleGrid(secondRoleId, parentForm.dtSecondCustomEntities, parentForm.dtSecondSystemEntities, parentForm.dtSecondGlobal);

            SetGridEntityProperties(gridFirstCustomEntities, FIRST_CUSTOM);
            SetGridEntityProperties(gridFirstSystemEntities, FIRST_SYSTEM);
            SetGridEntityProperties(gridSecondCustomEntities, SECOND_CUSTOM);
            SetGridEntityProperties(gridSecondSystemEntities, SECOND_SYSTEM);
            SetGridGlobalProperties(gridFirstGlobal, FIRST_GLOBAL);
            SetGridGlobalProperties(gridSecondGlobal, SECOND_GLOBAL);

            gridFirstSystemEntities.Focus();
        }

        /// <summary>
        /// Will set the grid according the roleId and is is the first or second Role comparing
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="customEntitiesDT"></param>
        /// <param name="systemEntitiesDT"></param>
        /// <param name="globalDT"></param>
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
                        if (row.Table.Columns.Contains(privToUpdate + FIRST_CUSTOM))
                        {
                            row[privToUpdate + FIRST_CUSTOM] = privImage;
                        }
                        else if (row.Table.Columns.Contains(privToUpdate + SECOND_CUSTOM))
                        {
                            row[privToUpdate + SECOND_CUSTOM] = privImage;
                        }
                    }
                    else
                    {
                        row = systemEntitiesDT.Rows.Find(name);
                        if (row != null)
                        {
                            if (row.Table.Columns.Contains(privToUpdate + FIRST_SYSTEM))
                            {
                                row[privToUpdate + FIRST_SYSTEM] = privImage;
                            }
                            else if (row.Table.Columns.Contains(privToUpdate + SECOND_SYSTEM))
                            {
                                row[privToUpdate + SECOND_SYSTEM] = privImage;
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
                        if (row.Table.Columns.Contains("priv" + FIRST_GLOBAL))
                        {
                            row["priv" + FIRST_GLOBAL] = privImage;
                        }
                        else if (row.Table.Columns.Contains("priv" + SECOND_GLOBAL))
                        {
                            row["priv" + SECOND_GLOBAL] = privImage;
                        }
                    }
                }
            }
        }

        private void OpenSecondRole(object sender, EventArgs e)
        {
            bl.OpenRole(secondRoleId.ToString());
        }

        private void OpenFirstRole(object sender, EventArgs e)
        {
            bl.OpenRole(firstRoleId.ToString());
        }

        #region Grids Events
        private void gridFirstSystemEntities_Scroll(object sender, ScrollEventArgs e)
        {
            gridSecondSystemEntities.FirstDisplayedScrollingRowIndex = gridFirstSystemEntities.FirstDisplayedScrollingRowIndex; ;
        }

        private void gridSecondSystemEntities_Scroll(object sender, ScrollEventArgs e)
        {
            gridFirstSystemEntities.FirstDisplayedScrollingRowIndex = gridFirstSystemEntities.FirstDisplayedScrollingRowIndex;
        }

        private void gridFirstGlobal_Scroll(object sender, ScrollEventArgs e)
        {
            gridSecondGlobal.FirstDisplayedScrollingRowIndex = gridFirstGlobal.FirstDisplayedScrollingRowIndex;
        }

        private void gridSecondGlobal_Scroll(object sender, ScrollEventArgs e)
        {
            gridFirstGlobal.FirstDisplayedScrollingRowIndex = gridSecondGlobal.FirstDisplayedScrollingRowIndex;
        }

        private void gridFirstCustomEntities_Scroll(object sender, ScrollEventArgs e)
        {
            gridSecondCustomEntities.FirstDisplayedScrollingRowIndex = gridFirstCustomEntities.FirstDisplayedScrollingRowIndex;
        }

        private void gridSecondCustomEntities_Scroll(object sender, ScrollEventArgs e)
        {
            gridFirstCustomEntities.FirstDisplayedScrollingRowIndex = gridSecondCustomEntities.FirstDisplayedScrollingRowIndex;
        }

        private void gridFirstSystemEntities_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                if (gridSecondSystemEntities.Rows.Count > 0)
                {
                    DataGridView senderGridView = (sender as DataGridView);
                    DataGridViewRow selectedRow = senderGridView.CurrentRow;
                    if (selectedRow != null)
                    {
                        int selectedIndex = selectedRow.Index;
                        commingFromOtherSelect = true;
                        gridSecondSystemEntities.Rows[selectedIndex].Selected = true;
                    }
                    commingFromOtherSelect = false;
                }
            }
        }

        private void gridSecondSystemEntities_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                if (gridFirstSystemEntities.Rows.Count > 0)
                {
                    DataGridView senderGridView = (sender as DataGridView);
                    DataGridViewRow selectedRow = senderGridView.CurrentRow;
                    if (selectedRow != null)
                    {
                        int selectedIndex = selectedRow.Index;
                        commingFromOtherSelect = true;
                        gridFirstSystemEntities.Rows[selectedIndex].Selected = true;
                    }
                    commingFromOtherSelect = false;
                }
            }
        }

        private void gridFirstGlobal_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                if (gridSecondGlobal.Rows.Count > 0)
                {
                    DataGridView senderGridView = (sender as DataGridView);
                    DataGridViewRow selectedRow = senderGridView.CurrentRow;
                    if (selectedRow != null)
                    {
                        int selectedIndex = selectedRow.Index;
                        commingFromOtherSelect = true;
                        gridSecondGlobal.Rows[selectedIndex].Selected = true;
                    }
                }
                commingFromOtherSelect = false;
            }
        }

        private void gridSecondGlobal_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                if (gridFirstGlobal.Rows.Count > 0)
                {
                    DataGridView senderGridView = (sender as DataGridView);
                    DataGridViewRow selectedRow = senderGridView.CurrentRow;
                    if (selectedRow != null)
                    {
                        int selectedIndex = selectedRow.Index;
                        commingFromOtherSelect = true;
                        gridFirstGlobal.Rows[selectedIndex].Selected = true;
                    }
                }
                commingFromOtherSelect = false;
            }
        }

        private void gridFirstCustomEntities_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                if (gridSecondCustomEntities.Rows.Count > 0)
                {
                    DataGridView senderGridView = (sender as DataGridView);
                    DataGridViewRow selectedRow = senderGridView.CurrentRow;
                    if (selectedRow != null)
                    {
                        int selectedIndex = selectedRow.Index;
                        commingFromOtherSelect = true;
                        gridSecondCustomEntities.Rows[selectedIndex].Selected = true;
                    }
                }
                commingFromOtherSelect = false;
            }
        }

        private void gridSecondCustomEntities_SelectionChanged(object sender, EventArgs e)
        {
            if (!commingFromOtherSelect)
            {
                if (gridFirstCustomEntities.Rows.Count > 0)
                {
                    DataGridView senderGridView = (sender as DataGridView);
                    DataGridViewRow selectedRow = senderGridView.CurrentRow;
                    if (selectedRow != null)
                    {

                        int selectedIndex = selectedRow.Index;
                        commingFromOtherSelect = true;
                        gridFirstCustomEntities.Rows[selectedIndex].Selected = true;
                    }
                }
                commingFromOtherSelect = false;
            }
        }

        private void lbFirstCustomRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (panel1.SelectedIndex)
            {
                case 0:
                    gridFirstSystemEntities.Focus();
                    break;
                case 1:
                    gridFirstGlobal.Focus();
                    break;
                case 2:
                    gridFirstCustomEntities.Focus();
                    break;
            }
        }

        private void txtSystemSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridFirstSystemEntities.Rows)
            {
                if (row.Cells["Name" + FIRST_SYSTEM].Value.ToString().ToLower().Contains(txtSystemSearch.Text.ToLower()))
                {
                    gridSecondSystemEntities.FirstDisplayedScrollingRowIndex = row.Index;
                    gridFirstSystemEntities.FirstDisplayedScrollingRowIndex = row.Index;
                    gridFirstSystemEntities.Rows[row.Index].Selected = true;
                    break;
                }
            }
            txtSystemSearch.Focus();
        }

        private void txtPrivilegeSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridFirstGlobal.Rows)
            {
                if (row.Cells["Name" + FIRST_GLOBAL].Value.ToString().ToLower().Contains(txtPrivilegeSearch.Text.ToLower()))
                {
                    gridSecondGlobal.FirstDisplayedScrollingRowIndex = row.Index;
                    gridFirstGlobal.FirstDisplayedScrollingRowIndex = row.Index;
                    gridFirstGlobal.Rows[row.Index].Selected = true;
                    break;
                }
            }
            txtPrivilegeSearch.Focus();
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridFirstCustomEntities.Rows)
            {
                if (row.Cells["Name" + FIRST_CUSTOM].Value.ToString().ToLower().Contains(txtCustomerSearch.Text.ToLower())
                    || row.Cells["LogicName" + FIRST_CUSTOM].Value.ToString().ToLower().Contains(txtCustomerSearch.Text.ToLower()))
                {
                    gridSecondCustomEntities.FirstDisplayedScrollingRowIndex = row.Index;
                    gridFirstCustomEntities.FirstDisplayedScrollingRowIndex = row.Index;
                    gridFirstCustomEntities.Rows[row.Index].Selected = true;
                    break;
                }
            }
            txtCustomerSearch.Focus();
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
