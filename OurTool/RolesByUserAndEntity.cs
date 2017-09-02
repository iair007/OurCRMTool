using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk;

namespace OurCRMTool
{
    public partial class RolesByUserAndEntity : Form
    {
        private BL bl;
        DataTable dtUsersWithPriv = new DataTable();
        DataTable dtOnlyRoles = new DataTable();
        List<Guid> securityRolesCollection;
        Dictionary<int, string> _accessRigthDic = new Dictionary<int, string>();
        Dictionary<int, string> _privDepthDic = new Dictionary<int, string>();
        BackgroundWorker worker = new BackgroundWorker();
        int objectTypeCode;
        log4net.ILog log;
        Dictionary<int, string> AccessRigthDic
        {
            get
            {
                if (_accessRigthDic == null || _accessRigthDic.Count == 0)
                {
                    SetAccessRigthDic();
                }
                return _accessRigthDic;
            }
        }
        private void SetAccessRigthDic()
        {
            _accessRigthDic.Add(32, "Create");
            _accessRigthDic.Add(1, "Read");
            _accessRigthDic.Add(2, "Write");
            _accessRigthDic.Add(65536, "Delete");
            _accessRigthDic.Add(4, "Append");
            _accessRigthDic.Add(16, "Append To");
            _accessRigthDic.Add(524288, "Assign");
            _accessRigthDic.Add(262144, "Share");
        }
        Dictionary<int, string> PrivDepthDic
        {
            get
            {
                if (_privDepthDic == null || _privDepthDic.Count == 0)
                {
                    SetPrivDepthDic();
                }
                return _privDepthDic;
            }
        }
        private void SetPrivDepthDic()
        {
            _privDepthDic.Add(1, "User");
            _privDepthDic.Add(2, "Business Unit");
            _privDepthDic.Add(4, "Parent");
            _privDepthDic.Add(8, "Organization");
        }
        #region Contructor

        public RolesByUserAndEntity(int _objectTypeSelected, string entityName, string userName, List<Guid> _securityRolesCollection, BL _bl, log4net.ILog _log)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            bl = _bl;
            log = _log;
            objectTypeCode = _objectTypeSelected;
            securityRolesCollection = _securityRolesCollection;
            this.Text = "Roles by User and Entity - Connected to: " + bl.url;
            label2.Text = userName + "'s roles for " + entityName;
            CreatedtOnlyRolesColumns();
            dtOnlyRoles.TableName = "Roles for " + entityName;
            SetRoleGrid();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();

            Cursor.Current = Cursors.Default;
        }

        private void CreatedtOnlyRolesColumns()
        {
            dtOnlyRoles.Columns.Add("Id", typeof(string));
            dtOnlyRoles.Columns.Add("Name", typeof(string));
            dtOnlyRoles.Columns.Add("Managed", typeof(string));
            dtOnlyRoles.Columns.Add("ManagedImg", typeof(Image));

            foreach (KeyValuePair<int, string> a in AccessRigthDic)
            {
                dtOnlyRoles.Columns.Add(a.Value, typeof(Image));
            }
            dtOnlyRoles.PrimaryKey = new DataColumn[] { dtOnlyRoles.Columns["Id"] };
        }

        #endregion

        private void butRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetRoleGrid();

            Cursor.Current = Cursors.Default;
        }

        #region Worker

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // string message = SetRoleGrid();
            //e.Result = message;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetGridRolesProperties();
        }
        #endregion

        /// <summary>
        /// Set grid datasource and columns properties
        /// </summary>
        private void SetGridRolesProperties()
        {
            gridRoles.DataSource = dtOnlyRoles;

            gridRoles.Columns["Id"].Visible = false;
            gridRoles.Columns["Managed"].Visible = false;

            gridRoles.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridRoles.Columns["Name"].HeaderText = "Role's Name";
            gridRoles.Columns["ManagedImg"].HeaderText = "Is Managed";
            gridRoles.Columns["ManagedImg"].Width = 40;

            foreach (KeyValuePair<int, string> a in AccessRigthDic)
            {
                gridRoles.Columns[a.Value].HeaderText = a.Value;
                gridRoles.Columns[a.Value].Width = 40;
            }

            gridRoles.Sort(gridRoles.Columns["Name"], ListSortDirection.Ascending);
        }

        private string SetRoleGrid()
        {
            dtOnlyRoles.Clear();
            string message = "";
            foreach (Guid roleId in securityRolesCollection)
            {
                EntityCollection privilegeRole = bl.GetPrivilegeByRoleAndEntity(roleId, objectTypeCode);

                foreach (Entity p in privilegeRole.Entities)
                {
                    string roleName = p.GetAttributeValue<AliasedValue>("role.name").Value.ToString();
                    string roleManaged = p.GetAttributeValue<AliasedValue>("role.ismanaged").Value.ToString();
                    Image roleManagedImg = roleManaged.ToLower() == "true" ? bl.GetImage("LockClose.png") : bl.GetImage("LockOpen.png");
                    int privilegeDepthMask = (int)p.GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value;
                    string privilageDepth = PrivDepthDic[privilegeDepthMask];
                    Image privilageDepthImg = bl.GetImage(privilegeDepthMask);
                    int access = p.GetAttributeValue<int>("accessright");
                    string accessRigth = string.Empty;
                    if (AccessRigthDic.ContainsKey(access))
                        accessRigth = AccessRigthDic[access];

                    //set rolesOnly datatable
                    int roleIndex = dtOnlyRoles.Rows.IndexOf(dtOnlyRoles.Rows.Find(roleId));
                    if (roleIndex != -1)
                    {
                        foreach (KeyValuePair<int, string> a in AccessRigthDic)
                        {
                            if (a.Value.ToLower() == accessRigth.ToLower())
                            {
                                dtOnlyRoles.Rows[roleIndex][a.Value] = privilageDepthImg;
                                break;
                            }
                        }
                    }
                    else
                    {
                        dtOnlyRoles.Rows.Add(roleId, roleName, roleManaged, roleManagedImg);
                        foreach (KeyValuePair<int, string> a in AccessRigthDic)
                        {
                            if (a.Value.ToLower() == accessRigth.ToLower())
                            {
                                dtOnlyRoles.Rows[dtOnlyRoles.Rows.Count - 1][a.Value] = privilageDepthImg;
                            }
                            else
                            {
                                dtOnlyRoles.Rows[dtOnlyRoles.Rows.Count - 1][a.Value] = bl.GetImage((int?)null);
                            }
                        }
                    }
                }
            }
            return message;
        }

        #region Events

        private void gridRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView);

            if (dataGridView.CurrentCell.Value == null || dataGridView.CurrentCell.Value.ToString() == string.Empty) return;

            switch (dataGridView.CurrentCell.OwningColumn.Name)
            {
                case "UserName":
                    bl.OpenWithArguments(dataGridView.CurrentRow.Cells["UserId"].Value.ToString(), "systemuser");
                    break;
                case "Team":
                    bl.OpenWithArguments(dataGridView.CurrentRow.Cells["TeamId"].Value.ToString(), "team");
                    break;
                case "RoleName":
                    bl.OpenRole(dataGridView.CurrentRow.Cells["RoleId"].Value.ToString());
                    break;
                case "Name":
                    bl.OpenRole(dataGridView.CurrentRow.Cells["Id"].Value.ToString());
                    break;
            }
        }

        #endregion

        private void butRefresh_Click_1(object sender, EventArgs e)
        {
            SetRoleGrid();
        }

        private void butToExcel_Click(object sender, EventArgs e)
        {
            List<DataTable> tablesList = new List<DataTable>();

            tablesList.Add(DataTableToExcel.TransforImageInDTToString(dtOnlyRoles));

            ExcelForm excelForm = new ExcelForm(tablesList, label2.Text + ".xlsx", label2.Text, bl.GetPrivilegeChar());
            excelForm.ShowDialog();
        }
    }
}
