namespace OurCRMTool
{
    partial class SerurityRoleAnalizerByUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerurityRoleAnalizerByUser));
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
            this.txtUserFilter = new System.Windows.Forms.TextBox();
            this.butClearSearch = new System.Windows.Forms.Button();
            this.butOpenUser = new System.Windows.Forms.Button();
            this.butOpenTeam = new System.Windows.Forms.Button();
            this.butTeamClear = new System.Windows.Forms.Button();
            this.butTeamSelectAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusinessUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(225, 12);
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
            this.gridTeams.Location = new System.Drawing.Point(228, 35);
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
            this.gridUsers.Location = new System.Drawing.Point(552, 35);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(308, 310);
            this.gridUsers.TabIndex = 3;
            this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(549, 12);
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
            // txtUserFilter
            // 
            this.txtUserFilter.Location = new System.Drawing.Point(600, 12);
            this.txtUserFilter.Name = "txtUserFilter";
            this.txtUserFilter.Size = new System.Drawing.Size(216, 20);
            this.txtUserFilter.TabIndex = 24;
            this.txtUserFilter.TextChanged += new System.EventHandler(this.txtUserFilter_TextChanged);
            // 
            // butClearSearch
            // 
            this.butClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearSearch.Location = new System.Drawing.Point(816, 10);
            this.butClearSearch.Name = "butClearSearch";
            this.butClearSearch.Size = new System.Drawing.Size(44, 23);
            this.butClearSearch.TabIndex = 23;
            this.butClearSearch.Text = "Clear";
            this.butClearSearch.UseVisualStyleBackColor = true;
            this.butClearSearch.Click += new System.EventHandler(this.butClearSearch_Click);
            // 
            // butOpenUser
            // 
            this.butOpenUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.butOpenUser.Enabled = false;
            this.butOpenUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butOpenUser.Location = new System.Drawing.Point(866, 102);
            this.butOpenUser.Name = "butOpenUser";
            this.butOpenUser.Size = new System.Drawing.Size(155, 72);
            this.butOpenUser.TabIndex = 25;
            this.butOpenUser.Text = "Retrieving data...";
            this.butOpenUser.UseVisualStyleBackColor = false;
            this.butOpenUser.Click += new System.EventHandler(this.butOpenUser_Click);
            // 
            // butOpenTeam
            // 
            this.butOpenTeam.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.butOpenTeam.Enabled = false;
            this.butOpenTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butOpenTeam.Location = new System.Drawing.Point(866, 180);
            this.butOpenTeam.Name = "butOpenTeam";
            this.butOpenTeam.Size = new System.Drawing.Size(155, 76);
            this.butOpenTeam.TabIndex = 26;
            this.butOpenTeam.Text = "Retrieving data...";
            this.butOpenTeam.UseVisualStyleBackColor = false;
            this.butOpenTeam.Click += new System.EventHandler(this.butOpenTeam_Click);
            // 
            // butTeamClear
            // 
            this.butTeamClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamClear.Location = new System.Drawing.Point(461, 351);
            this.butTeamClear.Name = "butTeamClear";
            this.butTeamClear.Size = new System.Drawing.Size(75, 23);
            this.butTeamClear.TabIndex = 9;
            this.butTeamClear.Text = "Clear";
            this.butTeamClear.UseVisualStyleBackColor = true;
            this.butTeamClear.Click += new System.EventHandler(this.butTeamClear_Click);
            // 
            // butTeamSelectAll
            // 
            this.butTeamSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamSelectAll.Location = new System.Drawing.Point(380, 351);
            this.butTeamSelectAll.Name = "butTeamSelectAll";
            this.butTeamSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butTeamSelectAll.TabIndex = 8;
            this.butTeamSelectAll.Text = "Select All";
            this.butTeamSelectAll.UseVisualStyleBackColor = true;
            this.butTeamSelectAll.Click += new System.EventHandler(this.butTeamSelectAll_Click);
            // 
            // SerurityRoleAnalizerByUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 390);
            this.Controls.Add(this.butOpenTeam);
            this.Controls.Add(this.butOpenUser);
            this.Controls.Add(this.txtUserFilter);
            this.Controls.Add(this.butClearSearch);
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
            this.Name = "SerurityRoleAnalizerByUser";
            this.Text = "Users Settings Update";
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn TeamCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.TextBox txtUserFilter;
        private System.Windows.Forms.Button butClearSearch;
        private System.Windows.Forms.Button butOpenUser;
        private System.Windows.Forms.Button butOpenTeam;
        private System.Windows.Forms.Button butTeamClear;
        private System.Windows.Forms.Button butTeamSelectAll;
    }
}