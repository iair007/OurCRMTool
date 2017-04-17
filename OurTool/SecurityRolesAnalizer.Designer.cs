namespace OurCRMTool
{
    partial class SecurityRolesAnalizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityRolesAnalizer));
            this.txtEntityFilter = new System.Windows.Forms.TextBox();
            this.butUserClear = new System.Windows.Forms.Button();
            this.gridEntitties = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.butRefresh = new System.Windows.Forms.Button();
            this.butCheck = new System.Windows.Forms.Button();
            this.butAccessClear = new System.Windows.Forms.Button();
            this.butAccessSelectAll = new System.Windows.Forms.Button();
            this.butPrivDepthClear = new System.Windows.Forms.Button();
            this.butPrivDepthSelectAll = new System.Windows.Forms.Button();
            this.gridAccessRight = new System.Windows.Forms.DataGridView();
            this.AccessRigthCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AccessRigth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessRigthNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPrivDepth = new System.Windows.Forms.DataGridView();
            this.PrivDepthCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrivDepth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivilageDepthNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivilageDepthImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtUserFilter = new System.Windows.Forms.TextBox();
            this.butClearSearch = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUsersCount = new System.Windows.Forms.Label();
            this.lbSecurityRoles = new System.Windows.Forms.Label();
            this.lbTeams = new System.Windows.Forms.Label();
            this.txtTeamFilter = new System.Windows.Forms.TextBox();
            this.butClearTeamFilter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoleFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butClearRoleFilter = new System.Windows.Forms.Button();
            this.checkOnlyRoles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntitties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrivDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEntityFilter
            // 
            this.txtEntityFilter.Location = new System.Drawing.Point(72, 18);
            this.txtEntityFilter.Name = "txtEntityFilter";
            this.txtEntityFilter.Size = new System.Drawing.Size(198, 20);
            this.txtEntityFilter.TabIndex = 24;
            this.txtEntityFilter.TextChanged += new System.EventHandler(this.txtEntityFilter_TextChanged);
            // 
            // butUserClear
            // 
            this.butUserClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUserClear.Location = new System.Drawing.Point(276, 18);
            this.butUserClear.Name = "butUserClear";
            this.butUserClear.Size = new System.Drawing.Size(44, 23);
            this.butUserClear.TabIndex = 23;
            this.butUserClear.Text = "Clear";
            this.butUserClear.UseVisualStyleBackColor = true;
            this.butUserClear.Click += new System.EventHandler(this.butUserClear_Click);
            // 
            // gridEntitties
            // 
            this.gridEntitties.AllowUserToAddRows = false;
            this.gridEntitties.AllowUserToDeleteRows = false;
            this.gridEntitties.AllowUserToResizeColumns = false;
            this.gridEntitties.AllowUserToResizeRows = false;
            this.gridEntitties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEntitties.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridEntitties.Location = new System.Drawing.Point(12, 44);
            this.gridEntitties.MultiSelect = false;
            this.gridEntitties.Name = "gridEntitties";
            this.gridEntitties.RowHeadersVisible = false;
            this.gridEntitties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEntitties.Size = new System.Drawing.Size(308, 391);
            this.gridEntitties.TabIndex = 22;
            this.gridEntitties.SelectionChanged += new System.EventHandler(this.gridEntitties_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Entities";
            // 
            // butRefresh
            // 
            this.butRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butRefresh.Location = new System.Drawing.Point(208, 443);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(112, 23);
            this.butRefresh.TabIndex = 26;
            this.butRefresh.Text = "Refresh Entities";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // butCheck
            // 
            this.butCheck.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.butCheck.Enabled = false;
            this.butCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butCheck.Location = new System.Drawing.Point(425, 429);
            this.butCheck.Name = "butCheck";
            this.butCheck.Size = new System.Drawing.Size(124, 48);
            this.butCheck.TabIndex = 31;
            this.butCheck.Text = "Retrieving data...";
            this.butCheck.UseVisualStyleBackColor = false;
            this.butCheck.Click += new System.EventHandler(this.butCheck_Click);
            // 
            // butAccessClear
            // 
            this.butAccessClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butAccessClear.Location = new System.Drawing.Point(474, 253);
            this.butAccessClear.Name = "butAccessClear";
            this.butAccessClear.Size = new System.Drawing.Size(75, 23);
            this.butAccessClear.TabIndex = 33;
            this.butAccessClear.Text = "Clear";
            this.butAccessClear.UseVisualStyleBackColor = true;
            this.butAccessClear.Click += new System.EventHandler(this.butAccessClear_Click);
            // 
            // butAccessSelectAll
            // 
            this.butAccessSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butAccessSelectAll.Location = new System.Drawing.Point(339, 253);
            this.butAccessSelectAll.Name = "butAccessSelectAll";
            this.butAccessSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butAccessSelectAll.TabIndex = 32;
            this.butAccessSelectAll.Text = "Select All";
            this.butAccessSelectAll.UseVisualStyleBackColor = true;
            this.butAccessSelectAll.Click += new System.EventHandler(this.butAccessSelectAll_Click);
            // 
            // butPrivDepthClear
            // 
            this.butPrivDepthClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butPrivDepthClear.Location = new System.Drawing.Point(474, 400);
            this.butPrivDepthClear.Name = "butPrivDepthClear";
            this.butPrivDepthClear.Size = new System.Drawing.Size(75, 23);
            this.butPrivDepthClear.TabIndex = 35;
            this.butPrivDepthClear.Text = "Clear";
            this.butPrivDepthClear.UseVisualStyleBackColor = true;
            this.butPrivDepthClear.Click += new System.EventHandler(this.butPrivDepthClear_Click);
            // 
            // butPrivDepthSelectAll
            // 
            this.butPrivDepthSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butPrivDepthSelectAll.Location = new System.Drawing.Point(339, 400);
            this.butPrivDepthSelectAll.Name = "butPrivDepthSelectAll";
            this.butPrivDepthSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butPrivDepthSelectAll.TabIndex = 34;
            this.butPrivDepthSelectAll.Text = "Select All";
            this.butPrivDepthSelectAll.UseVisualStyleBackColor = true;
            this.butPrivDepthSelectAll.Click += new System.EventHandler(this.butPrivDepthSelectAll_Click);
            // 
            // gridAccessRight
            // 
            this.gridAccessRight.AllowUserToAddRows = false;
            this.gridAccessRight.AllowUserToDeleteRows = false;
            this.gridAccessRight.AllowUserToResizeColumns = false;
            this.gridAccessRight.AllowUserToResizeRows = false;
            this.gridAccessRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccessRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccessRigthCheck,
            this.AccessRigth,
            this.AccessRigthNumber});
            this.gridAccessRight.Location = new System.Drawing.Point(339, 44);
            this.gridAccessRight.Name = "gridAccessRight";
            this.gridAccessRight.RowHeadersVisible = false;
            this.gridAccessRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAccessRight.Size = new System.Drawing.Size(210, 203);
            this.gridAccessRight.TabIndex = 36;
            this.gridAccessRight.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAccessRight_CellClick);
            // 
            // AccessRigthCheck
            // 
            this.AccessRigthCheck.HeaderText = "";
            this.AccessRigthCheck.Name = "AccessRigthCheck";
            this.AccessRigthCheck.Width = 30;
            // 
            // AccessRigth
            // 
            this.AccessRigth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AccessRigth.HeaderText = "AccessRigth";
            this.AccessRigth.Name = "AccessRigth";
            this.AccessRigth.ReadOnly = true;
            // 
            // AccessRigthNumber
            // 
            this.AccessRigthNumber.HeaderText = "AccessRigthNumber";
            this.AccessRigthNumber.Name = "AccessRigthNumber";
            this.AccessRigthNumber.Visible = false;
            // 
            // gridPrivDepth
            // 
            this.gridPrivDepth.AllowUserToAddRows = false;
            this.gridPrivDepth.AllowUserToDeleteRows = false;
            this.gridPrivDepth.AllowUserToResizeColumns = false;
            this.gridPrivDepth.AllowUserToResizeRows = false;
            this.gridPrivDepth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrivDepth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrivDepthCheck,
            this.PrivDepth,
            this.PrivilageDepthNumber,
            this.PrivilageDepthImg});
            this.gridPrivDepth.Location = new System.Drawing.Point(339, 284);
            this.gridPrivDepth.Name = "gridPrivDepth";
            this.gridPrivDepth.RowHeadersVisible = false;
            this.gridPrivDepth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPrivDepth.Size = new System.Drawing.Size(210, 110);
            this.gridPrivDepth.TabIndex = 37;
            this.gridPrivDepth.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPrivDepth_CellClick);
            // 
            // PrivDepthCheck
            // 
            this.PrivDepthCheck.HeaderText = "";
            this.PrivDepthCheck.Name = "PrivDepthCheck";
            this.PrivDepthCheck.Width = 30;
            // 
            // PrivDepth
            // 
            this.PrivDepth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PrivDepth.HeaderText = "Privilage Depth";
            this.PrivDepth.Name = "PrivDepth";
            this.PrivDepth.ReadOnly = true;
            this.PrivDepth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PrivDepth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PrivilageDepthNumber
            // 
            this.PrivilageDepthNumber.HeaderText = "PrivilageDepthNumber";
            this.PrivilageDepthNumber.Name = "PrivilageDepthNumber";
            this.PrivilageDepthNumber.Visible = false;
            // 
            // PrivilageDepthImg
            // 
            this.PrivilageDepthImg.HeaderText = "";
            this.PrivilageDepthImg.Name = "PrivilageDepthImg";
            this.PrivilageDepthImg.ReadOnly = true;
            this.PrivilageDepthImg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PrivilageDepthImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PrivilageDepthImg.Width = 20;
            // 
            // txtUserFilter
            // 
            this.txtUserFilter.Location = new System.Drawing.Point(613, 21);
            this.txtUserFilter.Name = "txtUserFilter";
            this.txtUserFilter.Size = new System.Drawing.Size(171, 20);
            this.txtUserFilter.TabIndex = 41;
            this.txtUserFilter.TextChanged += new System.EventHandler(this.txtUserFilter_TextChanged);
            // 
            // butClearSearch
            // 
            this.butClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearSearch.Location = new System.Drawing.Point(790, 19);
            this.butClearSearch.Name = "butClearSearch";
            this.butClearSearch.Size = new System.Drawing.Size(27, 23);
            this.butClearSearch.TabIndex = 40;
            this.butClearSearch.Text = "Clear";
            this.butClearSearch.UseVisualStyleBackColor = true;
            this.butClearSearch.Click += new System.EventHandler(this.butClearSearch_Click);
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            this.gridUsers.AllowUserToDeleteRows = false;
            this.gridUsers.AllowUserToResizeRows = false;
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridUsers.Location = new System.Drawing.Point(572, 44);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(791, 404);
            this.gridUsers.TabIndex = 39;
            this.gridUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(573, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Users";
            // 
            // lbUsersCount
            // 
            this.lbUsersCount.AutoSize = true;
            this.lbUsersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUsersCount.Location = new System.Drawing.Point(905, 453);
            this.lbUsersCount.Name = "lbUsersCount";
            this.lbUsersCount.Size = new System.Drawing.Size(60, 17);
            this.lbUsersCount.TabIndex = 42;
            this.lbUsersCount.Text = "Users: ";
            // 
            // lbSecurityRoles
            // 
            this.lbSecurityRoles.AutoSize = true;
            this.lbSecurityRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbSecurityRoles.Location = new System.Drawing.Point(573, 453);
            this.lbSecurityRoles.Name = "lbSecurityRoles";
            this.lbSecurityRoles.Size = new System.Drawing.Size(118, 17);
            this.lbSecurityRoles.TabIndex = 43;
            this.lbSecurityRoles.Text = "Security Roles:";
            // 
            // lbTeams
            // 
            this.lbTeams.AutoSize = true;
            this.lbTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbTeams.Location = new System.Drawing.Point(779, 453);
            this.lbTeams.Name = "lbTeams";
            this.lbTeams.Size = new System.Drawing.Size(61, 17);
            this.lbTeams.TabIndex = 44;
            this.lbTeams.Text = "Teams:";
            // 
            // txtTeamFilter
            // 
            this.txtTeamFilter.Location = new System.Drawing.Point(860, 21);
            this.txtTeamFilter.Name = "txtTeamFilter";
            this.txtTeamFilter.Size = new System.Drawing.Size(185, 20);
            this.txtTeamFilter.TabIndex = 47;
            this.txtTeamFilter.TextChanged += new System.EventHandler(this.txtTeamFilter_TextChanged);
            // 
            // butClearTeamFilter
            // 
            this.butClearTeamFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearTeamFilter.Location = new System.Drawing.Point(1050, 18);
            this.butClearTeamFilter.Name = "butClearTeamFilter";
            this.butClearTeamFilter.Size = new System.Drawing.Size(26, 23);
            this.butClearTeamFilter.TabIndex = 46;
            this.butClearTeamFilter.Text = "Clear";
            this.butClearTeamFilter.UseVisualStyleBackColor = true;
            this.butClearTeamFilter.Click += new System.EventHandler(this.butClearTeamFilter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(817, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Team";
            // 
            // txtRoleFilter
            // 
            this.txtRoleFilter.Location = new System.Drawing.Point(1120, 19);
            this.txtRoleFilter.Name = "txtRoleFilter";
            this.txtRoleFilter.Size = new System.Drawing.Size(207, 20);
            this.txtRoleFilter.TabIndex = 50;
            this.txtRoleFilter.TextChanged += new System.EventHandler(this.txtRoleFilter_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(1086, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Role";
            // 
            // butClearRoleFilter
            // 
            this.butClearRoleFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearRoleFilter.Location = new System.Drawing.Point(1333, 16);
            this.butClearRoleFilter.Name = "butClearRoleFilter";
            this.butClearRoleFilter.Size = new System.Drawing.Size(26, 23);
            this.butClearRoleFilter.TabIndex = 51;
            this.butClearRoleFilter.Text = "Clear";
            this.butClearRoleFilter.UseVisualStyleBackColor = true;
            this.butClearRoleFilter.Click += new System.EventHandler(this.butClearRoleFilter_Click);
            // 
            // checkOnlyRoles
            // 
            this.checkOnlyRoles.AutoSize = true;
            this.checkOnlyRoles.Location = new System.Drawing.Point(339, 18);
            this.checkOnlyRoles.Name = "checkOnlyRoles";
            this.checkOnlyRoles.Size = new System.Drawing.Size(105, 17);
            this.checkOnlyRoles.TabIndex = 52;
            this.checkOnlyRoles.Text = "Show only Roles";
            this.checkOnlyRoles.UseVisualStyleBackColor = true;
            this.checkOnlyRoles.CheckedChanged += new System.EventHandler(this.checkOnlyRoles_CheckedChanged);
            // 
            // SecurityRolesAnalizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 479);
            this.Controls.Add(this.checkOnlyRoles);
            this.Controls.Add(this.butClearRoleFilter);
            this.Controls.Add(this.txtRoleFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTeamFilter);
            this.Controls.Add(this.butClearTeamFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTeams);
            this.Controls.Add(this.lbSecurityRoles);
            this.Controls.Add(this.lbUsersCount);
            this.Controls.Add(this.txtUserFilter);
            this.Controls.Add(this.butClearSearch);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridPrivDepth);
            this.Controls.Add(this.gridAccessRight);
            this.Controls.Add(this.butPrivDepthClear);
            this.Controls.Add(this.butPrivDepthSelectAll);
            this.Controls.Add(this.butAccessClear);
            this.Controls.Add(this.butAccessSelectAll);
            this.Controls.Add(this.butCheck);
            this.Controls.Add(this.butRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEntityFilter);
            this.Controls.Add(this.butUserClear);
            this.Controls.Add(this.gridEntitties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SecurityRolesAnalizer";
            this.Text = "Security Roles Analizer";
            ((System.ComponentModel.ISupportInitialize)(this.gridEntitties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccessRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrivDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEntityFilter;
        private System.Windows.Forms.Button butUserClear;
        private System.Windows.Forms.DataGridView gridEntitties;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.Button butCheck;
        private System.Windows.Forms.Button butAccessClear;
        private System.Windows.Forms.Button butAccessSelectAll;
        private System.Windows.Forms.Button butPrivDepthClear;
        private System.Windows.Forms.Button butPrivDepthSelectAll;
        private System.Windows.Forms.DataGridView gridAccessRight;
        private System.Windows.Forms.DataGridView gridPrivDepth;
        private System.Windows.Forms.TextBox txtUserFilter;
        private System.Windows.Forms.Button butClearSearch;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AccessRigthCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessRigth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessRigthNumber;
        private System.Windows.Forms.Label lbUsersCount;
        private System.Windows.Forms.Label lbSecurityRoles;
        private System.Windows.Forms.Label lbTeams;
        private System.Windows.Forms.TextBox txtTeamFilter;
        private System.Windows.Forms.Button butClearTeamFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRoleFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butClearRoleFilter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrivDepthCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivilageDepthNumber;
        private System.Windows.Forms.DataGridViewImageColumn PrivilageDepthImg;
        private System.Windows.Forms.CheckBox checkOnlyRoles;
    }
}