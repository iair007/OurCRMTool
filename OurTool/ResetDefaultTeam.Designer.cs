namespace OurCRMTool
{
    partial class ResetDefaultTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetDefaultTeam));
            this.label1 = new System.Windows.Forms.Label();
            this.gridTeams = new System.Windows.Forms.DataGridView();
            this.TeamCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.gridBusinessUnit = new System.Windows.Forms.DataGridView();
            this.BUname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.butTeamSelectAll = new System.Windows.Forms.Button();
            this.butTeamClear = new System.Windows.Forms.Button();
            this.butTeamInvert = new System.Windows.Forms.Button();
            this.butUserInvert = new System.Windows.Forms.Button();
            this.butUserClear = new System.Windows.Forms.Button();
            this.butUserSelectAll = new System.Windows.Forms.Button();
            this.txtUserFilter = new System.Windows.Forms.TextBox();
            this.butClearSearch = new System.Windows.Forms.Button();
            this.butDeleteDef = new System.Windows.Forms.Button();
            this.checkCloseWhenFinish = new System.Windows.Forms.CheckBox();
            this.checkAssign = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusinessUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(217, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teams";
            // 
            // gridTeams
            // 
            this.gridTeams.AllowUserToAddRows = false;
            this.gridTeams.AllowUserToDeleteRows = false;
            this.gridTeams.AllowUserToResizeRows = false;
            this.gridTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamCheck,
            this.TeamName,
            this.teamId});
            this.gridTeams.Location = new System.Drawing.Point(220, 35);
            this.gridTeams.Name = "gridTeams";
            this.gridTeams.RowHeadersVisible = false;
            this.gridTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTeams.Size = new System.Drawing.Size(308, 310);
            this.gridTeams.TabIndex = 1;
            this.gridTeams.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTeams_CellClick);
            // 
            // TeamCheck
            // 
            this.TeamCheck.HeaderText = "";
            this.TeamCheck.Name = "TeamCheck";
            this.TeamCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TeamCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TeamCheck.Width = 30;
            // 
            // TeamName
            // 
            this.TeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeamName.HeaderText = "Name";
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            // 
            // teamId
            // 
            this.teamId.HeaderText = "TeamId";
            this.teamId.Name = "teamId";
            this.teamId.ReadOnly = true;
            this.teamId.Visible = false;
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            this.gridUsers.AllowUserToDeleteRows = false;
            this.gridUsers.AllowUserToResizeRows = false;
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Location = new System.Drawing.Point(538, 35);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(367, 310);
            this.gridUsers.TabIndex = 3;
            this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(535, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Users";
            // 
            // gridBusinessUnit
            // 
            this.gridBusinessUnit.AllowUserToAddRows = false;
            this.gridBusinessUnit.AllowUserToDeleteRows = false;
            this.gridBusinessUnit.AllowUserToResizeRows = false;
            this.gridBusinessUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBusinessUnit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BUname,
            this.BUid});
            this.gridBusinessUnit.Location = new System.Drawing.Point(4, 35);
            this.gridBusinessUnit.MultiSelect = false;
            this.gridBusinessUnit.Name = "gridBusinessUnit";
            this.gridBusinessUnit.ReadOnly = true;
            this.gridBusinessUnit.RowHeadersVisible = false;
            this.gridBusinessUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBusinessUnit.Size = new System.Drawing.Size(206, 310);
            this.gridBusinessUnit.TabIndex = 7;
            this.gridBusinessUnit.SelectionChanged += new System.EventHandler(this.gridBusinessUnit_SelectionChanged);
            // 
            // BUname
            // 
            this.BUname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BUname.HeaderText = "Name";
            this.BUname.Name = "BUname";
            this.BUname.ReadOnly = true;
            // 
            // BUid
            // 
            this.BUid.HeaderText = "Id";
            this.BUid.Name = "BUid";
            this.BUid.ReadOnly = true;
            this.BUid.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(7, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "BusinessUnit";
            // 
            // butTeamSelectAll
            // 
            this.butTeamSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamSelectAll.Location = new System.Drawing.Point(220, 351);
            this.butTeamSelectAll.Name = "butTeamSelectAll";
            this.butTeamSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butTeamSelectAll.TabIndex = 8;
            this.butTeamSelectAll.Text = "Select All";
            this.butTeamSelectAll.UseVisualStyleBackColor = true;
            this.butTeamSelectAll.Click += new System.EventHandler(this.butTeamSelectAll_Click);
            // 
            // butTeamClear
            // 
            this.butTeamClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamClear.Location = new System.Drawing.Point(453, 351);
            this.butTeamClear.Name = "butTeamClear";
            this.butTeamClear.Size = new System.Drawing.Size(75, 23);
            this.butTeamClear.TabIndex = 9;
            this.butTeamClear.Text = "Clear";
            this.butTeamClear.UseVisualStyleBackColor = true;
            this.butTeamClear.Click += new System.EventHandler(this.butTeamClear_Click);
            // 
            // butTeamInvert
            // 
            this.butTeamInvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamInvert.Location = new System.Drawing.Point(301, 351);
            this.butTeamInvert.Name = "butTeamInvert";
            this.butTeamInvert.Size = new System.Drawing.Size(75, 23);
            this.butTeamInvert.TabIndex = 10;
            this.butTeamInvert.Text = "Invert";
            this.butTeamInvert.UseVisualStyleBackColor = true;
            this.butTeamInvert.Click += new System.EventHandler(this.butTeamInvert_Click);
            // 
            // butUserInvert
            // 
            this.butUserInvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUserInvert.Location = new System.Drawing.Point(619, 351);
            this.butUserInvert.Name = "butUserInvert";
            this.butUserInvert.Size = new System.Drawing.Size(75, 23);
            this.butUserInvert.TabIndex = 13;
            this.butUserInvert.Text = "Invert";
            this.butUserInvert.UseVisualStyleBackColor = true;
            this.butUserInvert.Click += new System.EventHandler(this.butUserInvert_Click);
            // 
            // butUserClear
            // 
            this.butUserClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUserClear.Location = new System.Drawing.Point(830, 351);
            this.butUserClear.Name = "butUserClear";
            this.butUserClear.Size = new System.Drawing.Size(75, 23);
            this.butUserClear.TabIndex = 12;
            this.butUserClear.Text = "Clear";
            this.butUserClear.UseVisualStyleBackColor = true;
            this.butUserClear.Click += new System.EventHandler(this.butUserClear_Click);
            // 
            // butUserSelectAll
            // 
            this.butUserSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUserSelectAll.Location = new System.Drawing.Point(538, 351);
            this.butUserSelectAll.Name = "butUserSelectAll";
            this.butUserSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butUserSelectAll.TabIndex = 11;
            this.butUserSelectAll.Text = "Select All";
            this.butUserSelectAll.UseVisualStyleBackColor = true;
            this.butUserSelectAll.Click += new System.EventHandler(this.butUserSelectAll_Click);
            // 
            // txtUserFilter
            // 
            this.txtUserFilter.Location = new System.Drawing.Point(586, 12);
            this.txtUserFilter.Name = "txtUserFilter";
            this.txtUserFilter.Size = new System.Drawing.Size(269, 20);
            this.txtUserFilter.TabIndex = 24;
            this.txtUserFilter.TextChanged += new System.EventHandler(this.txtUserFilter_TextChanged);
            // 
            // butClearSearch
            // 
            this.butClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearSearch.Location = new System.Drawing.Point(861, 9);
            this.butClearSearch.Name = "butClearSearch";
            this.butClearSearch.Size = new System.Drawing.Size(44, 23);
            this.butClearSearch.TabIndex = 23;
            this.butClearSearch.Text = "Clear";
            this.butClearSearch.UseVisualStyleBackColor = true;
            this.butClearSearch.Click += new System.EventHandler(this.butClearSearch_Click);
            // 
            // butDeleteDef
            // 
            this.butDeleteDef.BackColor = System.Drawing.Color.IndianRed;
            this.butDeleteDef.Enabled = false;
            this.butDeleteDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butDeleteDef.Location = new System.Drawing.Point(945, 140);
            this.butDeleteDef.Name = "butDeleteDef";
            this.butDeleteDef.Size = new System.Drawing.Size(123, 72);
            this.butDeleteDef.TabIndex = 25;
            this.butDeleteDef.Text = "Delete default Team";
            this.butDeleteDef.UseVisualStyleBackColor = false;
            this.butDeleteDef.Click += new System.EventHandler(this.butDeleteDef_Click);
            // 
            // checkCloseWhenFinish
            // 
            this.checkCloseWhenFinish.AutoSize = true;
            this.checkCloseWhenFinish.Location = new System.Drawing.Point(917, 241);
            this.checkCloseWhenFinish.Name = "checkCloseWhenFinish";
            this.checkCloseWhenFinish.Size = new System.Drawing.Size(111, 17);
            this.checkCloseWhenFinish.TabIndex = 26;
            this.checkCloseWhenFinish.Text = "Close when Finish";
            this.checkCloseWhenFinish.UseVisualStyleBackColor = true;
            // 
            // checkAssign
            // 
            this.checkAssign.AutoSize = true;
            this.checkAssign.Location = new System.Drawing.Point(917, 218);
            this.checkAssign.Name = "checkAssign";
            this.checkAssign.Size = new System.Drawing.Size(173, 17);
            this.checkAssign.TabIndex = 27;
            this.checkAssign.Text = "Assign Default team to all users";
            this.checkAssign.UseVisualStyleBackColor = true;
            // 
            // ResetDefaultTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 390);
            this.Controls.Add(this.checkAssign);
            this.Controls.Add(this.checkCloseWhenFinish);
            this.Controls.Add(this.butDeleteDef);
            this.Controls.Add(this.txtUserFilter);
            this.Controls.Add(this.butClearSearch);
            this.Controls.Add(this.butUserInvert);
            this.Controls.Add(this.butUserClear);
            this.Controls.Add(this.butUserSelectAll);
            this.Controls.Add(this.butTeamInvert);
            this.Controls.Add(this.butTeamClear);
            this.Controls.Add(this.butTeamSelectAll);
            this.Controls.Add(this.gridBusinessUnit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridTeams);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResetDefaultTeam";
            this.Text = "Users Settings Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResetDefaultTeam_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusinessUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridTeams;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridBusinessUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUname;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUid;
        private System.Windows.Forms.Button butTeamSelectAll;
        private System.Windows.Forms.Button butTeamClear;
        private System.Windows.Forms.Button butTeamInvert;
        private System.Windows.Forms.Button butUserInvert;
        private System.Windows.Forms.Button butUserClear;
        private System.Windows.Forms.Button butUserSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TeamCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.TextBox txtUserFilter;
        private System.Windows.Forms.Button butClearSearch;
        private System.Windows.Forms.Button butDeleteDef;
        private System.Windows.Forms.CheckBox checkCloseWhenFinish;
        private System.Windows.Forms.CheckBox checkAssign;
    }
}