namespace OurCRMTool
{
    partial class CheckDefaultTeam
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
            this.components = new System.ComponentModel.Container();
            this.gridTeams = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.butUserClear = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.butSelectAll = new System.Windows.Forms.Button();
            this.txtUserFilter = new System.Windows.Forms.TextBox();
            this.lbUsersCount = new System.Windows.Forms.Label();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.gridTeams.Location = new System.Drawing.Point(18, 38);
            this.gridTeams.MultiSelect = false;
            this.gridTeams.Name = "gridTeams";
            this.gridTeams.RowHeadersVisible = false;
            this.gridTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTeams.Size = new System.Drawing.Size(308, 310);
            this.gridTeams.TabIndex = 3;
            this.gridTeams.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTeams_CellClick);
            this.gridTeams.MouseHover += new System.EventHandler(this.gridTeams_MouseHover);
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
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "All Teams";
            // 
            // butUserClear
            // 
            this.butUserClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUserClear.Location = new System.Drawing.Point(621, 35);
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
            this.gridUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridUsers.Location = new System.Drawing.Point(357, 64);
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(308, 284);
            this.gridUsers.TabIndex = 15;
            this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellClick);
            this.gridUsers.DoubleClick += new System.EventHandler(this.gridUsers_DoubleClick);
            this.gridUsers.MouseHover += new System.EventHandler(this.gridUsers_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(354, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Users with selected team as Default team";
            // 
            // butSelectAll
            // 
            this.butSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelectAll.Location = new System.Drawing.Point(251, 354);
            this.butSelectAll.Name = "butSelectAll";
            this.butSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butSelectAll.TabIndex = 20;
            this.butSelectAll.Text = "Select All Teams";
            this.butSelectAll.UseVisualStyleBackColor = true;
            this.butSelectAll.Click += new System.EventHandler(this.butSelectAll_Click);
            this.butSelectAll.MouseHover += new System.EventHandler(this.butSelectAll_MouseHover);
            // 
            // txtUserFilter
            // 
            this.txtUserFilter.Location = new System.Drawing.Point(357, 38);
            this.txtUserFilter.Name = "txtUserFilter";
            this.txtUserFilter.Size = new System.Drawing.Size(258, 20);
            this.txtUserFilter.TabIndex = 21;
            this.txtUserFilter.TextChanged += new System.EventHandler(this.txtUserFilter_TextChanged);
            // 
            // lbUsersCount
            // 
            this.lbUsersCount.AutoSize = true;
            this.lbUsersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUsersCount.Location = new System.Drawing.Point(354, 354);
            this.lbUsersCount.Name = "lbUsersCount";
            this.lbUsersCount.Size = new System.Drawing.Size(60, 17);
            this.lbUsersCount.TabIndex = 22;
            this.lbUsersCount.Text = "Users: ";
            // 
            // txtExplanation
            // 
            this.txtExplanation.Enabled = false;
            this.txtExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtExplanation.Location = new System.Drawing.Point(672, 38);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(135, 310);
            this.txtExplanation.TabIndex = 24;
            // 
            // CheckDefaultTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 379);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.lbUsersCount);
            this.Controls.Add(this.txtUserFilter);
            this.Controls.Add(this.butSelectAll);
            this.Controls.Add(this.butUserClear);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridTeams);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CheckDefaultTeam";
            this.Text = "Check Default Team";
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butUserClear;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSelectAll;
        private System.Windows.Forms.TextBox txtUserFilter;
        private System.Windows.Forms.Label lbUsersCount;
        private System.Windows.Forms.TextBox txtExplanation;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}