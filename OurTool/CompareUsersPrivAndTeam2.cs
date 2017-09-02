using Microsoft.Crm.Sdk.Messages;
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
    public partial class CompareUsersPrivAndTeam2 : Form
    {
        private BL bl;
        log4net.ILog log;
        DataTable dtRoles = new DataTable();
        DataTable dtRoles2 = new DataTable();
        DataTable dtTeams = new DataTable();
        DataTable dtTeams2 = new DataTable();
        EntityReference userOrTeamRef;
        EntityReference userOrTeamRef2;
        EntityCollection usersTeams;
        EntityCollection usersTeams2;
        string userTeamName;
        string userTeamName2;
        Guid id;
        Guid id2;
        int inBothTeam;
        int inBothRole;

        #region ToolTrip

        private void AddToolTip2(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if ((e.ColumnIndex == 3) && e.Value != null)
            {
                SetToolTips2(grid, e.RowIndex);
            }
        }
        private void SetToolTips2(DataGridView grid, int rowIndex)
        {
            if (grid.Name.ToLower() == "gridroles" || grid.Name.ToLower() == "gridroles2")
            {
                if (grid.Rows[rowIndex].Cells["UserTeamsNames"] != null)
                {
                    DataGridViewCell cell2 = grid.Rows[rowIndex].Cells["CommingFrom"];
                    cell2.ToolTipText = grid.Rows[rowIndex].Cells["UserTeamsNames"].Value.ToString();
                }
            }
        }

        #endregion

        public CompareUsersPrivAndTeam2(BL _bl, log4net.ILog _log, Guid _id, string _userTeamName, Guid _id2, string _userTeamName2)
        {
            InitializeComponent();
            bl = _bl;
            log = _log;
            id = _id;
            id2 = _id2;
            CreatedtdtRolesColumns(dtRoles);
            CreatedtdtRolesColumns(dtRoles2);
            userTeamName = _userTeamName;
            userTeamName2 = _userTeamName2;

            SetTeams();
            SetRoles();
            Cursor.Current = Cursors.Default;
        }

        private void CreatedtdtRolesColumns(DataTable table)
        {
            table.Columns.Add("RoleCheck", typeof(bool));
            table.Columns.Add("RoleName", typeof(string));
            table.Columns.Add("RoleId", typeof(string));
            table.Columns.Add("CommingFrom", typeof(string));  //who gives the privilege, team or user
            table.Columns.Add("UserTeamsNames", typeof(string));
            table.Columns.Add("BusinessUnitName", typeof(string));
            
            table.PrimaryKey = new DataColumn[] { table.Columns["RoleId"] };
        }

        private void SetGridRolesProperties(DataGridView grid)
        {
            if (grid.Columns.Count > 0)
            {
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

                grid.Columns["BusinessUnitName"].Width = 80;
                grid.Columns["BusinessUnitName"].HeaderText = "Business Unit";
                grid.Columns["BusinessUnitName"].ReadOnly = true;
                grid.Columns["BusinessUnitName"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void EnableButOption()
        {
            bool ebableTeamButtons = inBothTeam != gridTeams.Rows.Count || inBothTeam != gridTeams2.Rows.Count;
            bool ebableRoleButtons = inBothRole != gridRoles.Rows.Count || inBothRole != gridRoles2.Rows.Count;
            butTeamFrom1To2.Enabled = ebableTeamButtons && GetCheckedRow(gridTeams) != null;
            butTeamFrom2To1.Enabled = ebableTeamButtons && GetCheckedRow(gridTeams2) != null;
            butRoleFrom1To2.Enabled = ebableRoleButtons &&  GetCheckedRow(gridRoles) != null;
            butRoleFrom2To1.Enabled = ebableRoleButtons && GetCheckedRow(gridRoles2) != null;
        }

        private void user_Click(object sender, EventArgs e)
        {
            bl.OpenWithArguments(id.ToString(), "systemuser");
        }

        private void user2_Click(object sender, EventArgs e)
        {
            bl.OpenWithArguments(id2.ToString(), "systemuser");
        }

        #region Team Events

        private void gridTeams_MouseHover(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);

            if (e.ColumnIndex == 1 && e.RowIndex < senderGridView.Rows.Count)
            {
                senderGridView.Cursor = Cursors.Hand;
            }
            else
            {
                senderGridView.Cursor = Cursors.Default;
            }
        }

        private void gridTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null && rowClicked.Index != -1)
            {
                if ((bool)senderGridView.CurrentRow.Cells[3].Value == true)
                {
                    //is default team
                    MessageBox.Show("This team is a default team for a business unit, and cannot be copied to other user");
                    senderGridView.CurrentRow.Cells[0].Value = false;
                    return;
                }
                if ((bool)senderGridView.CurrentRow.Cells[0].Value == false)
                {
                    senderGridView.CurrentRow.Cells[0].Value = true;
                }
                else
                {
                    senderGridView.CurrentRow.Cells[0].Value = false;
                }
                EnableButOption();
                DataGridView secondGrid = senderGridView.Name == "gridTeams" ? gridTeams2 : gridTeams;
                ScrollToTeamInSecondGrid(secondGrid, rowClicked);
            }
        }

        private void gridTeams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView);

            if (dataGridView.CurrentCell.Value == null || dataGridView.CurrentCell.Value.ToString() == string.Empty) return;

            bl.OpenWithArguments(dataGridView.CurrentRow.Cells[2].Value.ToString(), "team");
        }

        private void butTeamFrom1To2_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            DialogResult res = MessageBox.Show("Befor adding teams to '" + userTeamName2 + "' would you like to remove him from all current teams", "Add teams to user", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            else if (res == DialogResult.Yes)
            {
                //remove user frow current teams
                Cursor.Current = Cursors.WaitCursor;
                message += RemoveTeamsFromUser(gridTeams, gridTeams2, id2);
            }
            Cursor.Current = Cursors.WaitCursor;
            message += CopyTeams(gridTeams, gridTeams2, id2);
            Cursor.Current = Cursors.Default;
            if (message != string.Empty)
            {
                MessageBox.Show(message);
                Cursor.Current = Cursors.WaitCursor;
                SetTeams();
                Cursor.Current = Cursors.Default;
            }
        }

        private void butTeamFrom2To1_Click(object sender, EventArgs e)
        {

            string message = string.Empty;
            DialogResult res = MessageBox.Show("Befor adding teams to '" + userTeamName + "' would you like to remove him from all current teams", "Add teams to user", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            else if (res == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                //remove user frow current teams
                message += RemoveTeamsFromUser(gridTeams2, gridTeams, id);
            }
            Cursor.Current = Cursors.WaitCursor;
            message += CopyTeams(gridTeams2, gridTeams, id);

            Cursor.Current = Cursors.Default;
            if (message != string.Empty)
            {
                MessageBox.Show(message);
                Cursor.Current = Cursors.WaitCursor;
                SetTeams();
                Cursor.Current = Cursors.Default;
            }

        }

        private void butTeamSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridTeams.Rows)
            {
                if ((bool)row.Cells[3].Value == false)
                { //if is not default team
                    row.Cells[0].Value = true;
                }
            }
            EnableButOption();
        }

        private void butTeamClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridTeams.Rows)
            {
                row.Cells[0].Value = false;
            }
            EnableButOption();
        }

        private void butTeamSelectAll2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridTeams2.Rows)
            {
                if ((bool)row.Cells[3].Value == false)
                { //if is not default team
                    row.Cells[0].Value = true;
                }
            }
            EnableButOption();
        }

        private void butTeamClear2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridTeams2.Rows)
            {
                row.Cells[0].Value = false;
            }
            EnableButOption();
        }

        private void butRefreshTeams_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetTeams();
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Role Events

        private void gridRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (sender as DataGridView);

            if (dataGridView.CurrentCell.Value == null || dataGridView.CurrentCell.Value.ToString() == string.Empty) return;

            bl.OpenWithArguments(dataGridView.CurrentRow.Cells["RoleId"].Value.ToString(), "role");
        }

        private void gridRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null && rowClicked.Index != -1)
            {
                if (senderGridView.CurrentRow.Cells["CommingFrom"].Value.ToString() != "Team" && (bool)senderGridView.CurrentRow.Cells["RoleCheck"].Value == false)
                {
                    senderGridView.CurrentRow.Cells["RoleCheck"].Value = true;
                }
                else
                {
                    senderGridView.CurrentRow.Cells["RoleCheck"].Value = false;
                }
                EnableButOption();

                //find same record in second grid
                DataGridView secondGrid = senderGridView.Name == "gridRoles" ? gridRoles2 : gridRoles;
                ScrollToRoleInSecondGrid(secondGrid, rowClicked);
            }
        }

        private void gridGridRoles_MouseHover(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);

            if (e.ColumnIndex == 1 && e.RowIndex < senderGridView.Rows.Count)
            {
                senderGridView.Cursor = Cursors.Hand;
            }
            else
            {
                senderGridView.Cursor = Cursors.Default;
            }
        }

        private void butRoleSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridRoles.Rows)
            {
                if (row.Cells["CommingFrom"].Value.ToString() != "Team")
                {
                    row.Cells["RoleCheck"].Value = true;
                }
            }
            EnableButOption();
        }

        private void butRoleClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridRoles.Rows)
            {
                row.Cells[0].Value = false;
            }
            EnableButOption();
        }

        private void butRoleSelectAll2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridRoles2.Rows)
            {
                if (row.Cells["CommingFrom"].Value.ToString() != "Team")
                {
                    row.Cells["RoleCheck"].Value = true;
                }
            }
            EnableButOption();
        }

        private void butRoleClear2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridRoles2.Rows)
            {
                row.Cells[0].Value = false;
            }
            EnableButOption();
        }

        private void butRoleFrom1To2_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            DialogResult res = MessageBox.Show("Befor adding Roles to '" + userTeamName2 + "' would you like to remove his current roles", "Add Roles to user", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            else if (res == DialogResult.Yes)
            {
                //remove user frow current teams
                Cursor.Current = Cursors.WaitCursor;
                message += RemoveRolesFromUser(gridRoles, gridRoles2, id2);
            }
            Cursor.Current = Cursors.WaitCursor;
            message += CopyRoles(gridRoles, gridRoles2, id2);
            Cursor.Current = Cursors.Default;
            if (message != string.Empty)
            {
                MessageBox.Show(message);
                Cursor.Current = Cursors.WaitCursor;
                SetRoles();
                Cursor.Current = Cursors.Default;
            }
        }

        private void butRoleFrom2To1_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            DialogResult res = MessageBox.Show("Befor adding Roles to '" + userTeamName + "' would you like to remove his current roles", "Add Roles to user", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            else if (res == DialogResult.Yes)
            {
                //remove user frow current teams
                Cursor.Current = Cursors.WaitCursor;
                message += RemoveRolesFromUser(gridRoles2, gridRoles, id);
            }
            Cursor.Current = Cursors.WaitCursor;
            message += CopyRoles(gridRoles2, gridRoles, id);
            Cursor.Current = Cursors.Default;
            if (message != string.Empty)
            {
                MessageBox.Show(message);
                Cursor.Current = Cursors.WaitCursor;
                SetRoles();
                Cursor.Current = Cursors.Default;
            }
        }

        private void butRefreshRoles_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SetRoles();
            Cursor.Current = Cursors.Default;

        }
        #endregion

        #region Teams
        private void SetTeams()
        {
            try
            {
                gridTeams.Rows.Clear();
                gridTeams2.Rows.Clear();
                usersTeams = bl.GetTeamsByUser(id);
                foreach (Entity t in usersTeams.Entities)
                {
                    gridTeams.Rows.Add(false, t.GetAttributeValue<AliasedValue>("team.name").Value.ToString(), t.GetAttributeValue<AliasedValue>("team.teamid").Value.ToString(), (bool)t.GetAttributeValue<AliasedValue>("team.isdefault").Value);
                }
                usersTeams2 = bl.GetTeamsByUser(id2);

                foreach (Entity t in usersTeams2.Entities)
                {
                    gridTeams2.Rows.Add(false, t.GetAttributeValue<AliasedValue>("team.name").Value.ToString(), t.GetAttributeValue<AliasedValue>("team.teamid").Value.ToString(), (bool)t.GetAttributeValue<AliasedValue>("team.isdefault").Value);
                }

                gridTeams.Sort(gridTeams.Columns[1], ListSortDirection.Ascending);
                gridTeams2.Sort(gridTeams2.Columns[1], ListSortDirection.Ascending);

                EnableButOption();
                SetCountLabletTeam();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// will set all the teams checked in the teamGridToCopy to the userId received
        /// if the users has altready a team, will not do it again  
        /// </summary>
        /// <param name="teamGridToCopy"></param>
        /// <param name="usersTeams"></param>
        /// <param name="userId"></param>
        /// <param name="copyAll"></param>
        private string CopyTeams(DataGridView teamGridToCopy, DataGridView usersTeams, Guid userId, bool copyAll = false)
        {
            int teamsCopied = 0;
            string message = string.Empty;
            foreach (DataGridViewRow row in teamGridToCopy.Rows)
            {
                if ((bool)row.Cells[3].Value == false && (copyAll == true || (bool)row.Cells[0].Value == true))
                {
                    if (userIsMemberOfTeam(usersTeams, row.Cells[2].Value.ToString(), false))   //when I cpying I check if the new team is already a team for user, do dont need to check if is checked or not
                    {
                        message += Environment.NewLine + "User is already a member of " + row.Cells[1].Value.ToString();
                    }
                    else
                    {
                        AddMembersTeamRequest addMembersTeamRequest = new AddMembersTeamRequest();
                        addMembersTeamRequest.TeamId = new Guid(row.Cells[2].Value.ToString());
                        addMembersTeamRequest.MemberIds = new Guid[] { userId };

                        bl.service.Execute(addMembersTeamRequest);
                        teamsCopied++;
                    }
                }
            }
            return "- Finished to copy " + teamsCopied.ToString() + " teams" +
                                message +
                                Environment.NewLine + Environment.NewLine + "***Remember Default Teams cannot be copied";
        }

        private string RemoveTeamsFromUser(DataGridView teamGridToCopy, DataGridView usersTeams, Guid userId, bool copyAll = false)
        {
            int teamsRemoved = 0;
            string message = string.Empty;
            foreach (DataGridViewRow row in usersTeams.Rows)
            {
                if ((bool)row.Cells[3].Value == false)
                {
                    if (userIsMemberOfTeam(teamGridToCopy, row.Cells[2].Value.ToString(), !copyAll))   //when I removing I check if the team that i am removing is not one of the teams that will need to copy later, so check if is cheked only if is copying some of the teams
                    {
                        //if the user is already a member of a team that is getting in again, dont remove and do anything
                    }
                    else
                    {
                        RemoveMembersTeamRequest removeMembersTeamRequest = new RemoveMembersTeamRequest();
                        removeMembersTeamRequest.TeamId = new Guid(row.Cells[2].Value.ToString());
                        removeMembersTeamRequest.MemberIds = new Guid[] { userId };

                        bl.service.Execute(removeMembersTeamRequest);
                        teamsRemoved++;
                    }
                }
            }
            return "- Removed " + teamsRemoved.ToString() + " teams" + Environment.NewLine;

        }

        private bool userIsMemberOfTeam(DataGridView gridToFindTeam, string teamId, bool checkIfCheked)
        {
            bool userIsMember = false;
            foreach (DataGridViewRow row in gridToFindTeam.Rows)
            {
                if (checkIfCheked == false || (checkIfCheked == true && (bool)row.Cells[0].Value == true))
                    if (row.Cells[2].Value.ToString().ToLower() == teamId.ToLower())
                    {
                        userIsMember = true;
                        break;
                    }
            }
            return userIsMember;
        }

        /// <summary>
        /// if the role selected exist in the second grid, will scroll to show you 
        /// </summary>
        private void ScrollToTeamInSecondGrid(DataGridView secondGrid, DataGridViewRow selectedRow)
        {
            foreach (DataGridViewRow row in secondGrid.Rows)
            {
                if (row.Cells[2].Value.ToString().ToLower() == selectedRow.Cells[2].Value.ToString().ToLower())
                {
                    row.Selected = true;
                    secondGrid.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void SetCountLabletTeam()
        {
            int onlyIn = 0;
            int onlyIn2 = 0;
            inBothTeam = 0;
            //set teams lables count
            OnlyInOneGridTeam(gridTeams, gridTeams2, ref onlyIn, ref inBothTeam);
            inBothTeam = 0;
            OnlyInOneGridTeam(gridTeams2, gridTeams, ref onlyIn2, ref inBothTeam);

            lblTeams.Text = "Teams for user: " + userTeamName + " - " + gridTeams.Rows.Count.ToString();
            lblTeams2.Text = "Teams for user: " + userTeamName2 + " - " + gridTeams2.Rows.Count.ToString();

            lblTeamCount.Text = "Teams Only in " + userTeamName + ": " + onlyIn.ToString();
            lblTeamCount2.Text = "Teams Only in " + userTeamName2 + ": " + onlyIn2.ToString();

            if (onlyIn == 0 && onlyIn2 == 0)
            {
                lblTeamInBoth.Text = "Users have the sames teams";
                lblTeamInBoth.BackColor = Color.Green;
            }
            else
            {
                lblTeamInBoth.Text = "Teams in both users: " + inBothTeam.ToString();
            }
        }

        private void OnlyInOneGridTeam(DataGridView grid1, DataGridView grid2, ref int onlyInGrid1, ref int inBoth)
        {
            foreach (DataGridViewRow row in grid1.Rows)
            {
                bool found = false;
                foreach (DataGridViewRow row2 in grid2.Rows)
                {
                    if (row.Cells[2].Value.ToString().ToLower() == row2.Cells[2].Value.ToString().ToLower())
                    {
                        inBoth++;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    onlyInGrid1++;
                }
            }
        }
        #endregion

        #region Roles

        private void SetRoles()
        {

            //****set roles grid for user A***
            List<Entity> userOrTeamList = new List<Entity>();
            userOrTeamRef = new EntityReference("systemuser", id);
            Entity e = new Entity();
            e.LogicalName = userOrTeamRef.LogicalName;
            e.Id = userOrTeamRef.Id;
            e["name"] = userTeamName;
            userOrTeamList.Add(e);

            usersTeams = bl.GetTeamsByUser(id);
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

            SetRoleGrid(userOrTeamList, dtRoles, gridRoles);

            //****set roles grid for user B***
            List<Entity> userOrTeamList2 = new List<Entity>();
            userOrTeamRef2 = new EntityReference("systemuser", id2);
            Entity e2 = new Entity();
            e2.LogicalName = userOrTeamRef2.LogicalName;
            e2.Id = userOrTeamRef2.Id;
            e2["name"] = userTeamName2;
            userOrTeamList2.Add(e2);

            usersTeams2 = bl.GetTeamsByUser(id2);
            if (usersTeams2.Entities.Count() > 0)
            {
                foreach (Entity t in usersTeams2.Entities)
                {
                    Entity team2 = new Entity();
                    team2.LogicalName = "team";
                    team2.Id = (Guid)t.GetAttributeValue<AliasedValue>("team.teamid").Value;
                    team2["name"] = t.GetAttributeValue<AliasedValue>("team.name").Value.ToString();
                    userOrTeamList2.Add(team2);
                }
            }

            SetRoleGrid(userOrTeamList2, dtRoles2, gridRoles2);
            SetCountLabletRole();
        }

        private void SetRoleGrid(List<Entity> userOrTeamList, DataTable dt, DataGridView grid)
        {
            dt.Rows.Clear();
            string usersTeamsNames = string.Empty;
            List<Guid> rolesAdded = new List<Guid>();
            foreach (Entity u in userOrTeamList)
            {
                EntityCollection rolesCol = bl.GetRolesByUserId(u.ToEntityReference(), false);

                foreach (Entity role in rolesCol.Entities)
                {
                    bool addRole = true;
                    Guid roleId;
                    roleId = role.Id;
                    string commingFrom = string.Empty;

                    if (rolesAdded.Contains(roleId))
                    {
                        DataRow row = dt.Rows.Find(roleId);
                        if (row != null)
                        {
                            row["UserTeamsNames"] = row["UserTeamsNames"].ToString() + ", " + u.GetAttributeValue<string>("name");

                            if (row["CommingFrom"].ToString().ToLower() != u.LogicalName.ToLower())
                            {
                                row["CommingFrom"] = "User & Team";
                            }
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
                        dt.Rows.Add(false, role.GetAttributeValue<string>("name"), roleId, commingFrom, usersTeamsNames, role.GetAttributeValue<EntityReference>("businessunitid").Name);
                    }
                }
            }

            DataView view = dt.DefaultView;
            view.Sort = "RoleName ASC,CommingFrom DESC";
            grid.DataSource = view; //rebind the data source

            SetGridRolesProperties(grid);
        }

        private string RemoveRolesFromUser(DataGridView roleGridToCopy, DataGridView usersRoles, Guid userId, bool copyAll = false)
        {
            int roleRemoved = 0;
            string message = string.Empty;
            foreach (DataGridViewRow row in usersRoles.Rows)
            {
                if (row.Cells["CommingFrom"].Value.ToString() != "Team")  //only remove roles that are assigned to the user
                {
                    if (userHasRole(roleGridToCopy, row.Cells["RoleId"].Value.ToString(), !copyAll))   //when I removing I check if the role that i am removing is not one of the roles that will need to copy later, so check if is cheked only if is copying some of the teams
                    {
                        //if the user is already have a role that is getting in again, dont remove and do anything
                    }
                    else
                    {
                        bl.service.Disassociate("systemuser",
                       userId,
                       new Relationship("systemuserroles_association"),
                       new EntityReferenceCollection() { new EntityReference("role", new Guid(row.Cells["RoleId"].Value.ToString())) });
                        roleRemoved++;
                    }
                }
            }
            return "- Removed " + roleRemoved.ToString() + " Roles" + Environment.NewLine;
        }

        /// <summary>
        /// will set all the teams checked in the teamGridToCopy to the userId received
        /// if the users has altready a team, will not do it again  
        /// </summary>
        /// <param name="rolesGridToCopy"></param>
        /// <param name="usersRoles"></param>
        /// <param name="userId"></param>
        /// <param name="copyAll"></param>
        private string CopyRoles(DataGridView rolesGridToCopy, DataGridView usersRoles, Guid userId, bool copyAll = false)
        {
            int rolesCopied = 0;
            string message = string.Empty;
            foreach (DataGridViewRow row in rolesGridToCopy.Rows)
            {
                if (copyAll == true || (bool)row.Cells["RoleCheck"].Value == true)
                {
                    if (userIsMemberOfTeam(usersRoles, row.Cells["RoleId"].Value.ToString(), false))   //when I cpying I check if the new team is already a team for user, do dont need to check if is checked or not
                    {
                        message += Environment.NewLine + "User already has role " + row.Cells["RoleName"].Value.ToString();
                    }
                    else
                    {
                        try
                        {
                            AddMembersTeamRequest addMembersTeamRequest = new AddMembersTeamRequest();
                            addMembersTeamRequest.TeamId = new Guid(row.Cells[2].Value.ToString());
                            addMembersTeamRequest.MemberIds = new Guid[] { userId };

                            bl.service.Associate("systemuser", userId, new Relationship("systemuserroles_association"), new EntityReferenceCollection() { new EntityReference("role", new Guid(row.Cells["RoleId"].Value.ToString())) });
                            rolesCopied++;
                        }
                        catch (Exception ex)
                        {
                            string error = Environment.NewLine + "Error adding Role: " + row.Cells["RoleName"].Value.ToString() + " -> " + ex.Message;
                            message += error;
                            log.Error(error);
                        }
                    }
                }
            }
            return "- Finished to copy " + rolesCopied.ToString() + " Roles" + message;
        }

        private bool userHasRole(DataGridView gridToFindRole, string roleId, bool checkIfCheked)
        {
            bool userHasRole = false;
            foreach (DataGridViewRow row in gridToFindRole.Rows)
            {
                if (checkIfCheked == false || (checkIfCheked == true && (bool)row.Cells[0].Value == true))
                    if (row.Cells["RoleId"].Value.ToString().ToLower() == roleId.ToLower())
                    {
                        userHasRole = true;
                        break;
                    }
            }
            return userHasRole;
        }

        /// <summary>
        /// if the role selected exist in the second grid, will scroll to show you 
        /// </summary>
        private void ScrollToRoleInSecondGrid(DataGridView secondGrid, DataGridViewRow selectedRow)
        {
            foreach (DataGridViewRow row in secondGrid.Rows)
            {
                if (row.Cells["RoleId"].Value.ToString().ToLower() == selectedRow.Cells["RoleId"].Value.ToString().ToLower())
                {
                    row.Selected = true;
                    secondGrid.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void SetCountLabletRole()
        {
            int onlyIn = 0;
            int onlyIn2 = 0;
            inBothRole = 0;
            //set teams lables count
            OnlyInOneGridRole(gridRoles, gridRoles2, ref onlyIn, ref inBothRole);
            inBothRole = 0;
            OnlyInOneGridRole(gridRoles2, gridRoles, ref onlyIn2, ref inBothRole);

            lblRole.Text = "Roles for user: " + userTeamName + " - " + gridRoles.Rows.Count.ToString();
            lblRole2.Text = "Roles for user: " + userTeamName2 + " - " + gridRoles2.Rows.Count.ToString();

            lblRoleCount.Text = "Roles Only in User: " + onlyIn.ToString();
            lblRoleCount2.Text = "Roles Only in User: " + onlyIn2.ToString();

            if (onlyIn == 0 && onlyIn2 == 0)
            {
                lblRoleInBoth.Text = "Users have the sames roles";
                lblRoleInBoth.BackColor = Color.Green;
            }
            else
            {
                lblRoleInBoth.Text = "Roles in both users: " + inBothRole.ToString();
            }
        }

        private void OnlyInOneGridRole(DataGridView grid1, DataGridView grid2, ref int onlyInGrid1, ref int inBoth)
        {
            foreach (DataGridViewRow row in grid1.Rows)
            {
                bool found = false;
                foreach (DataGridViewRow row2 in grid2.Rows)
                {
                    if (row.Cells["RoleId"].Value.ToString().ToLower() == row2.Cells["RoleId"].Value.ToString().ToLower())
                    {
                        inBoth++;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    onlyInGrid1++;
                }
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

        private void butCopyAllFrom1To2_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            DialogResult res = MessageBox.Show("This will set teams and Roles of '" + userTeamName2 + "' the same as user '" + userTeamName + "'", "Copy all Teams and Roles", MessageBoxButtons.OKCancel);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            else if (res == DialogResult.OK)
            {
                //remove user frow current teams
                Cursor.Current = Cursors.WaitCursor;
                message += RemoveTeamsFromUser(gridTeams, gridTeams2, id2, true);
                message += CopyTeams(gridTeams, gridTeams2, id2,true);
                message += RemoveRolesFromUser(gridRoles, gridRoles2, id2, true);
                message += CopyRoles(gridRoles, gridRoles2, id2, true);
                Cursor.Current = Cursors.Default;
                if (message != string.Empty)
                {
                    MessageBox.Show(message);
                    Cursor.Current = Cursors.WaitCursor;
                    SetTeams();
                    SetRoles();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void butCopyAllFrom2To1_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            DialogResult res = MessageBox.Show("This will set teams and Roles of '" + userTeamName + "' the same as user '" + userTeamName2 + "'", "Copy all Teams and Roles", MessageBoxButtons.OKCancel);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            else if (res == DialogResult.OK)
            {
                //remove user frow current teams
                Cursor.Current = Cursors.WaitCursor;
                message += RemoveTeamsFromUser(gridTeams2, gridTeams, id, true);
                message += CopyTeams(gridTeams2, gridTeams, id, true);
                message += RemoveRolesFromUser(gridRoles2, gridRoles, id, true);
                message += CopyRoles(gridRoles2, gridRoles, id, true);
                Cursor.Current = Cursors.Default;
                if (message != string.Empty)
                {
                    MessageBox.Show(message);
                    Cursor.Current = Cursors.WaitCursor;
                    SetTeams();
                    SetRoles();
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
