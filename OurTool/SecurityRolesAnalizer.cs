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
    public partial class SecurityRolesAnalizer : Form
    {
        private BL bl;
        private RetrieveAllEntitiesResponse response;
        DataTable dtUsersWithPriv = new DataTable();
        DataTable dtOnlyRoles = new DataTable();
        DataTable dtEntities = new DataTable();
        EntityCollection securityRolesCollection;
        Dictionary<int, string> _accessRigthDic = new Dictionary<int, string>();
        Dictionary<int, string> _privDepthDic = new Dictionary<int, string>();
        BackgroundWorker worker = new BackgroundWorker();
        log4net.ILog log;

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

        #region Contructor

        public SecurityRolesAnalizer(BL _bl, log4net.ILog _log)
        {
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            bl = _bl;
            log = _log;
            this.Text = "Security Roles Analizer - Connected to: " + bl.url;
            CreatedtUsersWithPrivColumns();
            CreatedtdtEntitiesColumns();
            CreatedtOnlyRolesColumns();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();


            SetPrivDepthGrid();
            SetAccessRightGrid();
            Cursor.Current = Cursors.Default;
            txtEntityFilter.Focus();
        }

        private void CreatedtUsersWithPrivColumns()
        {
            dtUsersWithPriv.Columns.Add("DomName", typeof(string));
            dtUsersWithPriv.Columns.Add("UserName", typeof(string));
            dtUsersWithPriv.Columns.Add("UserId", typeof(string));
            dtUsersWithPriv.Columns.Add("Team", typeof(string));
            dtUsersWithPriv.Columns.Add("TeamId", typeof(string));
            dtUsersWithPriv.Columns.Add("RoleName", typeof(string));
            dtUsersWithPriv.Columns.Add("RoleManaged", typeof(string));
            dtUsersWithPriv.Columns.Add("RoleManagedImg", typeof(Image));
            dtUsersWithPriv.Columns.Add("RoleId", typeof(string));
            dtUsersWithPriv.Columns.Add("AccessRight", typeof(string));
            dtUsersWithPriv.Columns.Add("PrivilegeDepthImg", typeof(Image));
            dtUsersWithPriv.Columns.Add("PrivilageDepth", typeof(string));
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

        private void CreatedtdtEntitiesColumns()
        {
            dtEntities.Columns.Add("EntityName", typeof(string));
            dtEntities.Columns.Add("ObjectTypeCode", typeof(string));
        }

        #endregion

        #region Entities

        private string SetEntityGrid()
        {
            try
            {
                dtEntities.Rows.Clear();
                if (response == null)
                {
                    response = bl.GetEntities();
                }

                foreach (EntityMetadata currentEntity in response.EntityMetadata)
                {
                    if (currentEntity.DisplayName != null && currentEntity.DisplayName.UserLocalizedLabel != null)
                    {
                        dtEntities.Rows.Add(currentEntity.DisplayName.UserLocalizedLabel.Label, (int)currentEntity.ObjectTypeCode);
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void txtEntityFilter_TextChanged(object sender, EventArgs e)
        {
            dtEntities.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "EntityName", txtEntityFilter.Text);
            txtEntityFilter.Focus();
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {

            response = null;
            butCheck.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            SetEntityGrid();

            butCheck.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void butUserClear_Click(object sender, EventArgs e)
        {
            txtEntityFilter.Text = string.Empty;
        }

        private void gridEntitties_SelectionChanged(object sender, EventArgs e)
        {
            dtUsersWithPriv.Rows.Clear();
            txtUserFilter.Text = string.Empty;
            txtTeamFilter.Text = string.Empty;
            txtRoleFilter.Text = string.Empty;
        }

        #endregion

        #region PrivDepth

        private void SetPrivDepthDic()
        {
            _privDepthDic.Add(1, "User");
            _privDepthDic.Add(2, "Business Unit");
            _privDepthDic.Add(4, "Parent");
            _privDepthDic.Add(8, "Organization");
        }

        private void SetPrivDepthGrid()
        {
            for (int i = 0; i < PrivDepthDic.Count(); i++)
            {
                gridPrivDepth.Rows.Add(false, PrivDepthDic.ElementAt(i).Value, PrivDepthDic.ElementAt(i).Key, bl.GetImage(PrivDepthDic.ElementAt(i).Key));
            }
        }

        private void butPrivDepthSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridPrivDepth.Rows.Count; i++)
            {
                gridPrivDepth.Rows[i].Cells["PrivDepthCheck"].Value = true;
            }
        }

        private void butPrivDepthClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridPrivDepth.Rows.Count; i++)
            {
                gridPrivDepth.Rows[i].Cells["PrivDepthCheck"].Value = false;
            }
        }

        private void gridPrivDepth_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewCell cellClicked = senderGridView.CurrentCell;
            if (senderGridView.CurrentRow != null)
            {
                senderGridView.CurrentRow.Cells["PrivDepthCheck"].Value = !(bool)senderGridView.CurrentRow.Cells["PrivDepthCheck"].Value;
            }
        }

        private List<int> GetCheckedPriviDepth()
        {
            List<int> privDepthList = new List<int>();

            for (int i = 0; i < gridPrivDepth.Rows.Count; i++)
            {
                if ((bool)gridPrivDepth.Rows[i].Cells["PrivDepthCheck"].Value == true)
                {
                    privDepthList.Add((int)gridPrivDepth.Rows[i].Cells["PrivilageDepthNumber"].Value);
                }
            }
            return privDepthList;
        }

        #endregion

        #region AccessRight

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

        private void SetAccessRightGrid()
        {
            for (int i = 0; i < AccessRigthDic.Count(); i++)
            {
                gridAccessRight.Rows.Add(false, AccessRigthDic.ElementAt(i).Value, AccessRigthDic.ElementAt(i).Key);
            }
        }

        private void butAccessSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridAccessRight.Rows.Count; i++)
            {
                gridAccessRight.Rows[i].Cells["AccessRigthCheck"].Value = true;
            }
        }

        private void butAccessClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridAccessRight.Rows.Count; i++)
            {
                gridAccessRight.Rows[i].Cells["AccessRigthCheck"].Value = false;
            }
        }

        private void gridAccessRight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewCell cellClicked = senderGridView.CurrentCell;
            if (senderGridView.CurrentRow != null)
            {
                senderGridView.CurrentRow.Cells["AccessRigthCheck"].Value = !(bool)senderGridView.CurrentRow.Cells["AccessRigthCheck"].Value;
            }
        }

        private List<string> GetCheckedAccessRigth()
        {
            List<string> accessRigthList = new List<string>();

            for (int i = 0; i < gridAccessRight.Rows.Count; i++)
            {
                if ((bool)gridAccessRight.Rows[i].Cells["AccessRigthCheck"].Value == true)
                {
                    accessRigthList.Add(gridAccessRight.Rows[i].Cells["AccessRigth"].Value.ToString().ToLower());
                }
            }

            return accessRigthList;
        }
        #endregion

        #region Worker

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string message = SetEntityGrid();
            e.Result = message;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() != string.Empty)
            {
                MessageBox.Show(e.Result.ToString());
                butCheck.Text = "Error getting Entity list";
            }
            else
            {
                if (dtEntities.Rows.Count > 0)
                {
                    gridEntitties.DataSource = dtEntities;

                    //set Columns properties
                    gridEntitties.Columns["EntityName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gridEntitties.Columns["EntityName"].HeaderText = "Entity Display Name";
                    gridEntitties.Columns["EntityName"].ReadOnly = true;

                    gridEntitties.Columns["ObjectTypeCode"].Width = 100;
                    gridEntitties.Columns["ObjectTypeCode"].HeaderText = "Object Type Code";
                    gridEntitties.Columns["ObjectTypeCode"].ReadOnly = true;

                    gridEntitties.Sort(gridEntitties.Columns["EntityName"], ListSortDirection.Ascending);

                    butCheck.Enabled = true;
                    butCheck.Text = "Check";
                    butCheck.BackColor = Color.Olive;
                }
            }
        }
        #endregion


        /// <summary>
        /// Get all the users that have the privilege that have access to the selected entity, and set the corresponding tables
        /// </summary>
        /// <param name="refresh"></param>
        private void SetUsersGrid(bool refresh = true)
        {
            EntityCollection usersCollection;
            if (dtUsersWithPriv.Rows.Count == 0 || refresh == true)
            {
                //get the userCollection by selections
                List<string> accessRigthList = GetCheckedAccessRigth();

                if (accessRigthList.Count == 0)
                {
                    MessageBox.Show("Please select at least one Access Rigth");
                    return;

                }

                List<int> privilegeDepthMaskList = GetCheckedPriviDepth();
                if (privilegeDepthMaskList.Count == 0)
                {
                    MessageBox.Show("Please select at least one Privilage Depth");
                    return;
                }

                //will retrieve all the roles with privileges to entity and then will filter it for the selected accessrigths and privilegedeptmask
                usersCollection = GetUsersWithPrivilage(AccessRigthDic.Select(a => a.Key).ToList(), PrivDepthDic.Select(a => a.Key).ToList());  //get all the privilege for this entity


                dtUsersWithPriv.Rows.Clear();

                foreach (Entity u in usersCollection.Entities)
                {
                    string userName = u.Contains("username") ? u.GetAttributeValue<string>("username") : string.Empty;
                    string domName = u.Contains("domname") ? u.GetAttributeValue<string>("domname") : string.Empty;
                    Guid userId = u.Contains("userid") ? u.GetAttributeValue<Guid>("userid") : Guid.Empty;
                    string roleName = u.GetAttributeValue<string>("rolename");
                    string roleManaged = u.GetAttributeValue<string>("roleManaged");
                    Image roleManagedImg = roleManaged.ToLower() == "true" ? bl.GetImage("LockClose.png") : bl.GetImage("LockOpen.png");
                    Guid roleId = u.GetAttributeValue<Guid>("roleid");
                    string privilageDepth = PrivDepthDic[u.GetAttributeValue<int>("privilegedepthmask")];
                    Image privilageDepthImg = bl.GetImage(u.GetAttributeValue<int>("privilegedepthmask"));
                    string accessRigth = u.GetAttributeValue<string>("accessright");
                    string team = u.Contains("teamname") ? u.GetAttributeValue<string>("teamname") : string.Empty;
                    Guid teamId = u.Contains("teamid") ? u.GetAttributeValue<Guid>("teamid") : Guid.Empty;

                    if (accessRigthList.IndexOf(u.GetAttributeValue<string>("accessright").ToLower()) != -1 && privilegeDepthMaskList.IndexOf(u.GetAttributeValue<int>("privilegedepthmask")) != -1)
                    {
                        //only add to the grid the ones that accessrigth and privilegedeptmask match the user's selection
                        dtUsersWithPriv.Rows.Add(domName, userName, userId, team, teamId, roleName, roleManaged, roleManagedImg, roleId, accessRigth, privilageDepthImg, privilageDepth);
                    }

                    //set rolesOnly datatable
                    int roleIndex = dtOnlyRoles.Rows.IndexOf(dtOnlyRoles.Rows.Find(u.GetAttributeValue<Guid>("roleid")));
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
            SetGridUsersProperties();
            gridUsers.Focus();
        }

        /// <summary>
        /// Set grid datasource and columns properties
        /// </summary>
        private void SetGridUsersProperties()
        {
            if (checkOnlyRoles.Checked)
            {
                gridUsers.DataSource = dtOnlyRoles;

                gridUsers.Columns["Id"].Visible = false;
                gridUsers.Columns["Managed"].Visible = false;

                gridUsers.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                gridUsers.Columns["Name"].HeaderText = "Role's Name";
                gridUsers.Columns["ManagedImg"].HeaderText = "Is Managed";
                gridUsers.Columns["ManagedImg"].Width = 40;

                foreach (KeyValuePair<int, string> a in AccessRigthDic)
                {
                    gridUsers.Columns[a.Value].HeaderText = a.Value;
                    gridUsers.Columns[a.Value].Width = 40;
                }

                gridUsers.Sort(gridUsers.Columns["Name"], ListSortDirection.Ascending);
            }
            else
            {
                gridUsers.DataSource = null;
                gridUsers.DataSource = dtUsersWithPriv;

                //Set Columns Properties
                //hide columns
                gridUsers.Columns["UserId"].Visible = false;
                gridUsers.Columns["TeamId"].Visible = false;
                gridUsers.Columns["RoleId"].Visible = false;
                gridUsers.Columns["roleManaged"].Visible = false;
                gridUsers.Columns["RoleManagedImg"].Visible = false;
                gridUsers.Columns["domname"].Visible = false;

                //Set columns width
                gridUsers.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridUsers.Columns["Team"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridUsers.Columns["RoleName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridUsers.Columns["AccessRight"].Width = 60;
                gridUsers.Columns["PrivilegeDepthImg"].Width = 40;
                gridUsers.Columns["PrivilageDepth"].Width = 60;

                //Set Columns HeaderText
                gridUsers.Columns["UserName"].HeaderText = "User's Name";
                gridUsers.Columns["Team"].HeaderText = "Team's Name";
                gridUsers.Columns["RoleName"].HeaderText = "Role's Name";
                gridUsers.Columns["PrivilegeDepthImg"].HeaderText = "";

                //Set Columns ReadOnly
                gridUsers.Columns["UserName"].ReadOnly = true;
                gridUsers.Columns["Team"].ReadOnly = true;
                gridUsers.Columns["RoleName"].ReadOnly = true;
                gridUsers.Columns["PrivilegeDepthImg"].ReadOnly = true;

                gridUsers.Sort(gridUsers.Columns["UserName"], ListSortDirection.Ascending);
            }
        }

        /// <summary>
        /// Get all the privilege that have access to the selected entity
        /// </summary>
        /// <param name="accessRigthList"></param>
        /// <param name="privilegeDepthMaskList"></param>
        /// <returns></returns>
        private EntityCollection GetUsersWithPrivilage(List<int> accessRigthList, List<int> privilegeDepthMaskList)
        {
            EntityCollection usersWithRole = new EntityCollection();
            EntityCollection teamsWithRole = new EntityCollection();
            EntityCollection usersInTeam = new EntityCollection();

            int objectTypeSelected = int.Parse(gridEntitties.SelectedRows[0].Cells["ObjectTypeCode"].Value.ToString());
            securityRolesCollection = bl.GetSecurityRolesWithPrivilege(objectTypeSelected, accessRigthList, privilegeDepthMaskList);

            if (securityRolesCollection.Entities.Count() > 0)
            {
                usersWithRole = bl.GetUserWithRole(securityRolesCollection.Entities.Select(e => e.GetAttributeValue<AliasedValue>("role.name").Value.ToString()).ToList<string>());
                teamsWithRole = bl.GetTeamsWithRole(securityRolesCollection.Entities.Select(e => e.GetAttributeValue<AliasedValue>("role.name").Value.ToString()).ToList<string>());
                //get all the users in the teams that have the security roles 
                if (teamsWithRole.Entities.Count() > 0)
                {
                    usersInTeam = bl.GetUsersByTeam(teamsWithRole.Entities.Select(t => new Guid(t.GetAttributeValue<AliasedValue>("team.teamid").Value.ToString())).ToList());
                }
            }

            EntityCollection newCollection = new EntityCollection();

            foreach (Entity s in securityRolesCollection.Entities)
            {
                Entity newToShow = new Entity();
                bool findUserOrTeamWithRole = false;
                //add users
                foreach (Entity e in usersWithRole.Entities)
                {
                    if (s.GetAttributeValue<AliasedValue>("role.name").Value.ToString() == e.GetAttributeValue<AliasedValue>("role.name").Value.ToString())
                    {
                        newToShow = new Entity();
                        newToShow["accessright"] = AccessRigthDic[s.GetAttributeValue<int>("accessright")];
                        newToShow["privilegedepthmask"] = (int)s.GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value;
                        newToShow["rolename"] = s.GetAttributeValue<AliasedValue>("role.name").Value.ToString();
                        newToShow["roleManaged"] = s.GetAttributeValue<AliasedValue>("role.ismanaged").Value.ToString();
                        newToShow["roleid"] = s.GetAttributeValue<AliasedValue>("role.roleid").Value;
                        newToShow["username"] = e.Contains("user.fullname") ? e.GetAttributeValue<AliasedValue>("user.fullname").Value.ToString() : e.GetAttributeValue<AliasedValue>("user.domainname").Value.ToString();
                        newToShow["domname"] = e.GetAttributeValue<AliasedValue>("user.domainname").Value.ToString();
                        newToShow["userid"] = new Guid(e.GetAttributeValue<AliasedValue>("user.systemuserid").Value.ToString());
                        findUserOrTeamWithRole = true;
                        newCollection.Entities.Add(newToShow);
                    }
                }

                //add teams
                foreach (Entity t in teamsWithRole.Entities)
                {
                    if (s.GetAttributeValue<AliasedValue>("role.name").Value.ToString() == t.GetAttributeValue<AliasedValue>("role.name").Value.ToString())
                    {
                        findUserOrTeamWithRole = true;
                        Guid teamId = new Guid(t.GetAttributeValue<AliasedValue>("team.teamid").Value.ToString());
                        bool findUserInTeam = false;
                        foreach (Entity u in usersInTeam.Entities)  //add all the users that are in this team
                        {
                            if (new Guid(u.GetAttributeValue<AliasedValue>("teamMembership.teamid").Value.ToString()) == teamId)
                            {
                                newToShow = new Entity();
                                newToShow["accessright"] = AccessRigthDic[s.GetAttributeValue<int>("accessright")];
                                newToShow["privilegedepthmask"] = (int)s.GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value;
                                newToShow["rolename"] = s.GetAttributeValue<AliasedValue>("role.name").Value.ToString();
                                newToShow["roleManaged"] = s.GetAttributeValue<AliasedValue>("role.ismanaged").Value.ToString();
                                newToShow["roleid"] = s.GetAttributeValue<AliasedValue>("role.roleid").Value;
                                newToShow["teamname"] = t.GetAttributeValue<AliasedValue>("team.name").Value.ToString();
                                newToShow["teamid"] = teamId;
                                newToShow["username"] = u.Contains("fullname") ? u.GetAttributeValue<string>("fullname") : u.GetAttributeValue<string>("domainname");
                                newToShow["domname"] = u.GetAttributeValue<string>("domainname");
                                newToShow["userid"] = u.GetAttributeValue<Guid>("systemuserid");
                                findUserInTeam = true;
                                newCollection.Entities.Add(newToShow);
                            }
                        }
                        if (!findUserInTeam)
                        {   //if the team has no user, will show the team alone
                            newToShow = new Entity();
                            newToShow["accessright"] = AccessRigthDic[s.GetAttributeValue<int>("accessright")];
                            newToShow["privilegedepthmask"] = (int)s.GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value;
                            newToShow["rolename"] = s.GetAttributeValue<AliasedValue>("role.name").Value.ToString();
                            newToShow["roleManaged"] = s.GetAttributeValue<AliasedValue>("role.ismanaged").Value.ToString();
                            newToShow["roleid"] = s.GetAttributeValue<AliasedValue>("role.roleid").Value;
                            newToShow["teamname"] = t.GetAttributeValue<AliasedValue>("team.name").Value.ToString();
                            newToShow["teamid"] = teamId;
                            newCollection.Entities.Add(newToShow);
                        }
                    }
                }

                if (!findUserOrTeamWithRole)  // if there is no team or User with this security role will show it alone
                {
                    newToShow = new Entity();
                    newToShow["accessright"] = AccessRigthDic[s.GetAttributeValue<int>("accessright")];
                    newToShow["privilegedepthmask"] = (int)s.GetAttributeValue<AliasedValue>("roleP.privilegedepthmask").Value;
                    newToShow["rolename"] = s.GetAttributeValue<AliasedValue>("role.name").Value.ToString();
                    newToShow["roleManaged"] = s.GetAttributeValue<AliasedValue>("role.ismanaged").Value.ToString();
                    newToShow["roleid"] = s.GetAttributeValue<AliasedValue>("role.roleid").Value;
                    newCollection.Entities.Add(newToShow);
                }
            }

            int nrRoles = securityRolesCollection.Entities.Select(r => r.GetAttributeValue<AliasedValue>("role.roleid").Value).Distinct().Count();
            int nrOfUsers = usersWithRole.Entities.Select(u => u.GetAttributeValue<AliasedValue>("user.systemuserid").Value).Distinct().Count();
            int nrTeams = teamsWithRole.Entities.Select(t => t.GetAttributeValue<AliasedValue>("team.teamid").Value).Distinct().Count();

            lbUsersCount.Text = "Users: " + nrOfUsers.ToString();
            lbSecurityRoles.Text = "Security Roles: " + nrRoles.ToString();
            lbTeams.Text = "Teams: " + nrTeams.ToString();
            return newCollection;
        }

        #region Events

        private void butCheck_Click(object sender, EventArgs e)
        {
            dtUsersWithPriv.Rows.Clear();
            dtOnlyRoles.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            SetUsersGrid();
            Cursor.Current = Cursors.Default;
        }

        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {
            //            dtUsersWithPriv.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "UserName", txtUserFilter.Text);
            dtUsersWithPriv.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "UserName", txtUserFilter.Text);


            txtUserFilter.Focus();
        }

        private void txtTeamFilter_TextChanged(object sender, EventArgs e)
        {
            dtUsersWithPriv.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Team", txtTeamFilter.Text);
            txtTeamFilter.Focus();
        }

        private void txtRoleFilter_TextChanged(object sender, EventArgs e)
        {
            dtUsersWithPriv.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "RoleName", txtRoleFilter.Text);
            dtOnlyRoles.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Name", txtRoleFilter.Text);
            txtRoleFilter.Focus();
        }

        private void butClearTeamFilter_Click(object sender, EventArgs e)
        {
            txtTeamFilter.Text = string.Empty;
        }

        private void butClearSearch_Click(object sender, EventArgs e)
        {
            txtUserFilter.Text = string.Empty;
        }

        private void butClearRoleFilter_Click(object sender, EventArgs e)
        {
            txtRoleFilter.Text = string.Empty;
        }

        private void gridUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void checkOnlyRoles_CheckedChanged(object sender, EventArgs e)
        {
            string selectedRoleId = gridUsers.Columns.Contains("RoleId") ? gridUsers.SelectedRows[0].Cells["RoleId"].Value.ToString() : string.Empty;
            SetGridUsersProperties();
            txtRoleFilter_TextChanged(null, null);
            txtTeamFilter.Enabled = !checkOnlyRoles.Checked;
            txtUserFilter.Enabled = !checkOnlyRoles.Checked;
            butClearTeamFilter.Enabled = !checkOnlyRoles.Checked;
            butClearSearch.Enabled = !checkOnlyRoles.Checked;

            if (selectedRoleId != string.Empty)
            {
                foreach (DataGridViewRow row in gridUsers.Rows)
                {
                    if (row.Cells["Id"].Value.ToString() == selectedRoleId)
                    {
                        row.Selected = true;
                    }
                }
            }
        }
    }
}
