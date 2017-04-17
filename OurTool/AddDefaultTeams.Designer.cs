namespace OurCRMTool
{
    partial class AddDefaultTeams
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
            this.butTeamInvert = new System.Windows.Forms.Button();
            this.butTeamClear = new System.Windows.Forms.Button();
            this.butTeamSelectAll = new System.Windows.Forms.Button();
            this.gridTeams = new System.Windows.Forms.DataGridView();
            this.TeamCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butUndo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).BeginInit();
            this.SuspendLayout();
            // 
            // butTeamInvert
            // 
            this.butTeamInvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamInvert.Location = new System.Drawing.Point(99, 546);
            this.butTeamInvert.Name = "butTeamInvert";
            this.butTeamInvert.Size = new System.Drawing.Size(75, 23);
            this.butTeamInvert.TabIndex = 15;
            this.butTeamInvert.Text = "Invert";
            this.butTeamInvert.UseVisualStyleBackColor = true;
            this.butTeamInvert.Click += new System.EventHandler(this.butTeamInvert_Click);
            // 
            // butTeamClear
            // 
            this.butTeamClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamClear.Location = new System.Drawing.Point(280, 546);
            this.butTeamClear.Name = "butTeamClear";
            this.butTeamClear.Size = new System.Drawing.Size(46, 23);
            this.butTeamClear.TabIndex = 14;
            this.butTeamClear.Text = "Clear";
            this.butTeamClear.UseVisualStyleBackColor = true;
            this.butTeamClear.Click += new System.EventHandler(this.butTeamClear_Click);
            // 
            // butTeamSelectAll
            // 
            this.butTeamSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butTeamSelectAll.Location = new System.Drawing.Point(18, 546);
            this.butTeamSelectAll.Name = "butTeamSelectAll";
            this.butTeamSelectAll.Size = new System.Drawing.Size(75, 23);
            this.butTeamSelectAll.TabIndex = 13;
            this.butTeamSelectAll.Text = "Select All";
            this.butTeamSelectAll.UseVisualStyleBackColor = true;
            this.butTeamSelectAll.Click += new System.EventHandler(this.butTeamSelectAll_Click);
            // 
            // gridTeams
            // 
            this.gridTeams.AllowUserToAddRows = false;
            this.gridTeams.AllowUserToDeleteRows = false;
            this.gridTeams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTeams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamCheck,
            this.TeamName,
            this.teamId});
            this.gridTeams.Location = new System.Drawing.Point(19, 31);
            this.gridTeams.Name = "gridTeams";
            this.gridTeams.RowHeadersVisible = false;
            this.gridTeams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTeams.Size = new System.Drawing.Size(308, 509);
            this.gridTeams.TabIndex = 12;
            this.gridTeams.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTeams_CellClick_1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "List of Possibles Defaults Teams";
            // 
            // butUpdate
            // 
            this.butUpdate.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.butUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUpdate.Location = new System.Drawing.Point(333, 233);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(87, 36);
            this.butUpdate.TabIndex = 16;
            this.butUpdate.Text = "Update";
            this.butUpdate.UseVisualStyleBackColor = false;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click_1);
            // 
            // butUndo
            // 
            this.butUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUndo.Location = new System.Drawing.Point(180, 546);
            this.butUndo.Name = "butUndo";
            this.butUndo.Size = new System.Drawing.Size(75, 23);
            this.butUndo.TabIndex = 17;
            this.butUndo.Text = "Undo All";
            this.butUndo.UseVisualStyleBackColor = true;
            this.butUndo.Click += new System.EventHandler(this.butUndo_Click);
            // 
            // AddDefaultTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 581);
            this.Controls.Add(this.butUndo);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.butTeamInvert);
            this.Controls.Add(this.butTeamClear);
            this.Controls.Add(this.butTeamSelectAll);
            this.Controls.Add(this.gridTeams);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddDefaultTeams";
            this.Text = "AddDefaultTeams";
            ((System.ComponentModel.ISupportInitialize)(this.gridTeams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butTeamInvert;
        private System.Windows.Forms.Button butTeamClear;
        private System.Windows.Forms.Button butTeamSelectAll;
        private System.Windows.Forms.DataGridView gridTeams;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TeamCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butUndo;
    }
}