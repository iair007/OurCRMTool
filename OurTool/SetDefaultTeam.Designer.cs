namespace OurCRMTool
{
    partial class SetDefaultTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetDefaultTeam));
            this.gridTeams = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.butAssign = new System.Windows.Forms.Button();
            this.butUserClear = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.butTeamClear = new System.Windows.Forms.Button();
            this.txtUserFilter = new System.Windows.Forms.TextBox();
            this.lbUsersCount = new System.Windows.Forms.Label();
            this.butUpdateList = new System.Windows.Forms.Button();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.butReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTeams
            // 
            this.gridTeams.AllowUserToAddRows = false;
            this.gridTeams.AllowUserToDeleteRows = false;
            this.gridTeams.AllowUserToResizeRows = false;
            this.gridTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamName,
            this.teamId});
            this.gridTeams.Location = new System.Drawing.Point(10, 50);
            this.gridTeams.Name = "gridTeams";
            this.gridTeams.RowHeadersVisible = false;
            this.gridTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTeams.Size = new System.Drawing.Size(308, 310);
            this.gridTeams.TabIndex = 3;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "List of posible Default Teams";
            // 
            // butAssign
            // 
            this.butAssign.BackColor = System.Drawing.Color.SeaGreen;
            this.butAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butAssign.Location = new System.Drawing.Point(650, 327);
            this.butAssign.Name = "butAssign";
            this.butAssign.Size = new System.Drawing.Size(136, 33);
            this.butAssign.TabIndex = 4;
            this.butAssign.Text = "Assign Default Teams";
            this.butAssign.UseVisualStyleBackColor = false;
            this.butAssign.Click += new System.EventHandler(this.butAssign_Click);
            // 
            // butUserClear
            // 
            this.butUserClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUserClear.Location = new System.Drawing.Point(600, 50);
            this.butUserClear.Name = "butUserClear";
            this.butUserClear.Size = new System.Drawing.Size(44, 23);
            this.butUserClear.TabIndex = 17;
            this.butUserClear.Text = "Clear";
            this.butUserClear.UseVisualStyleBackColor = true;
            this.butUserClear.Click += new System.EventHandler(this.butUserClear_Click);
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            this.gridUsers.AllowUserToDeleteRows = false;
            this.gridUsers.AllowUserToResizeRows = false;
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.UserId});
            this.gridUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridUsers.Location = new System.Drawing.Point(336, 76);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(308, 284);
            this.gridUsers.TabIndex = 15;
            this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellClick);
            this.gridUsers.DoubleClick += new System.EventHandler(this.gridUsers_DoubleClick);
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.HeaderText = "Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserId
            // 
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(342, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Users without default team";
            // 
            // butTeamClear
            // 
            this.butTeamClear.Enabled = false;
            this.butTeamClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamClear.Location = new System.Drawing.Point(243, 366);
            this.butTeamClear.Name = "butTeamClear";
            this.butTeamClear.Size = new System.Drawing.Size(75, 23);
            this.butTeamClear.TabIndex = 20;
            this.butTeamClear.Text = "Delete";
            this.butTeamClear.UseVisualStyleBackColor = true;
            this.butTeamClear.Click += new System.EventHandler(this.butTeamClear_Click_1);
            // 
            // txtUserFilter
            // 
            this.txtUserFilter.Location = new System.Drawing.Point(336, 50);
            this.txtUserFilter.Name = "txtUserFilter";
            this.txtUserFilter.Size = new System.Drawing.Size(258, 20);
            this.txtUserFilter.TabIndex = 21;
            this.txtUserFilter.TextChanged += new System.EventHandler(this.txtUserFilter_TextChanged);
            // 
            // lbUsersCount
            // 
            this.lbUsersCount.AutoSize = true;
            this.lbUsersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUsersCount.Location = new System.Drawing.Point(564, 366);
            this.lbUsersCount.Name = "lbUsersCount";
            this.lbUsersCount.Size = new System.Drawing.Size(60, 17);
            this.lbUsersCount.TabIndex = 22;
            this.lbUsersCount.Text = "Users: ";
            // 
            // butUpdateList
            // 
            this.butUpdateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUpdateList.Location = new System.Drawing.Point(10, 366);
            this.butUpdateList.Name = "butUpdateList";
            this.butUpdateList.Size = new System.Drawing.Size(58, 23);
            this.butUpdateList.TabIndex = 23;
            this.butUpdateList.Text = "Update List";
            this.butUpdateList.UseVisualStyleBackColor = true;
            this.butUpdateList.Click += new System.EventHandler(this.butUpdateList_Click);
            // 
            // txtExplanation
            // 
            this.txtExplanation.Enabled = false;
            this.txtExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtExplanation.Location = new System.Drawing.Point(651, 50);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(135, 271);
            this.txtExplanation.TabIndex = 24;
            // 
            // butReset
            // 
            this.butReset.BackColor = System.Drawing.Color.IndianRed;
            this.butReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butReset.Location = new System.Drawing.Point(651, 364);
            this.butReset.Name = "butReset";
            this.butReset.Size = new System.Drawing.Size(135, 31);
            this.butReset.TabIndex = 25;
            this.butReset.Text = "Re-Set Default Teams";
            this.butReset.UseVisualStyleBackColor = false;
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // SetDefaultTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 396);
            this.Controls.Add(this.butReset);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.butUpdateList);
            this.Controls.Add(this.lbUsersCount);
            this.Controls.Add(this.txtUserFilter);
            this.Controls.Add(this.butTeamClear);
            this.Controls.Add(this.butUserClear);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butAssign);
            this.Controls.Add(this.gridTeams);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetDefaultTeam";
            this.Text = "SetDefaultTeam";
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butAssign;
        private System.Windows.Forms.Button butUserClear;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butTeamClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.TextBox txtUserFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.Label lbUsersCount;
        private System.Windows.Forms.Button butUpdateList;
        private System.Windows.Forms.TextBox txtExplanation;
        private System.Windows.Forms.Button butReset;
    }
}