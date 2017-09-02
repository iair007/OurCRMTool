namespace OurCRMTool
{
    partial class CompareUsersPrivAndTeam
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
            this.txtUserFilter = new System.Windows.Forms.TextBox();
            this.butClearSearch = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserFilter2 = new System.Windows.Forms.TextBox();
            this.butClearSearch2 = new System.Windows.Forms.Button();
            this.gridUsers2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butOpenUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserFilter
            // 
            this.txtUserFilter.Location = new System.Drawing.Point(63, 55);
            this.txtUserFilter.Name = "txtUserFilter";
            this.txtUserFilter.Size = new System.Drawing.Size(216, 20);
            this.txtUserFilter.TabIndex = 28;
            this.txtUserFilter.TextChanged += new System.EventHandler(this.txtUserFilter_TextChanged);
            // 
            // butClearSearch
            // 
            this.butClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearSearch.Location = new System.Drawing.Point(279, 53);
            this.butClearSearch.Name = "butClearSearch";
            this.butClearSearch.Size = new System.Drawing.Size(44, 23);
            this.butClearSearch.TabIndex = 27;
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
            this.gridUsers.Location = new System.Drawing.Point(15, 78);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers.Size = new System.Drawing.Size(308, 523);
            this.gridUsers.TabIndex = 26;
            this.gridUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Users";
            // 
            // txtUserFilter2
            // 
            this.txtUserFilter2.Location = new System.Drawing.Point(421, 53);
            this.txtUserFilter2.Name = "txtUserFilter2";
            this.txtUserFilter2.Size = new System.Drawing.Size(216, 20);
            this.txtUserFilter2.TabIndex = 32;
            this.txtUserFilter2.TextChanged += new System.EventHandler(this.txtUserFilter2_TextChanged);
            // 
            // butClearSearch2
            // 
            this.butClearSearch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearSearch2.Location = new System.Drawing.Point(637, 51);
            this.butClearSearch2.Name = "butClearSearch2";
            this.butClearSearch2.Size = new System.Drawing.Size(44, 23);
            this.butClearSearch2.TabIndex = 31;
            this.butClearSearch2.Text = "Clear";
            this.butClearSearch2.UseVisualStyleBackColor = true;
            this.butClearSearch2.Click += new System.EventHandler(this.butClearSearch2_Click);
            // 
            // gridUsers2
            // 
            this.gridUsers2.AllowUserToAddRows = false;
            this.gridUsers2.AllowUserToDeleteRows = false;
            this.gridUsers2.AllowUserToResizeRows = false;
            this.gridUsers2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers2.Location = new System.Drawing.Point(373, 76);
            this.gridUsers2.MultiSelect = false;
            this.gridUsers2.Name = "gridUsers2";
            this.gridUsers2.RowHeadersVisible = false;
            this.gridUsers2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsers2.Size = new System.Drawing.Size(308, 525);
            this.gridUsers2.TabIndex = 30;
            this.gridUsers2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUsers_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(370, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Users";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Choose User A to compare";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(390, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "Choose User B to compare";
            // 
            // butOpenUser
            // 
            this.butOpenUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.butOpenUser.Enabled = false;
            this.butOpenUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butOpenUser.Location = new System.Drawing.Point(702, 529);
            this.butOpenUser.Name = "butOpenUser";
            this.butOpenUser.Size = new System.Drawing.Size(155, 72);
            this.butOpenUser.TabIndex = 35;
            this.butOpenUser.Text = "Compare User\'s Privileges and Teams";
            this.butOpenUser.UseVisualStyleBackColor = false;
            this.butOpenUser.Click += new System.EventHandler(this.butOpenUser_Click);
            // 
            // CompareUsersPrivAndTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 613);
            this.Controls.Add(this.butOpenUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserFilter2);
            this.Controls.Add(this.butClearSearch2);
            this.Controls.Add(this.gridUsers2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserFilter);
            this.Controls.Add(this.butClearSearch);
            this.Controls.Add(this.gridUsers);
            this.Controls.Add(this.label2);
            this.Name = "CompareUsersPrivAndTeam";
            this.Text = "CompareUsersPrivAndTeam";
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserFilter;
        private System.Windows.Forms.Button butClearSearch;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserFilter2;
        private System.Windows.Forms.Button butClearSearch2;
        private System.Windows.Forms.DataGridView gridUsers2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butOpenUser;
    }
}