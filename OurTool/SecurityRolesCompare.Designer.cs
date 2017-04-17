namespace OurCRMTool
{
    partial class SecurityRolesCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityRolesCompare));
            this.gridRoles = new System.Windows.Forms.DataGridView();
            this.butCheck = new System.Windows.Forms.Button();
            this.txtRoleSearch = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRole2Search = new System.Windows.Forms.TextBox();
            this.gridRoles2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRoles
            // 
            this.gridRoles.AllowUserToAddRows = false;
            this.gridRoles.AllowUserToDeleteRows = false;
            this.gridRoles.AllowUserToResizeColumns = false;
            this.gridRoles.AllowUserToResizeRows = false;
            this.gridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRoles.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridRoles.Location = new System.Drawing.Point(12, 56);
            this.gridRoles.MultiSelect = false;
            this.gridRoles.Name = "gridRoles";
            this.gridRoles.RowHeadersVisible = false;
            this.gridRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRoles.Size = new System.Drawing.Size(308, 430);
            this.gridRoles.TabIndex = 22;
            this.gridRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.gridRoles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // butCheck
            // 
            this.butCheck.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.butCheck.Enabled = false;
            this.butCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butCheck.Location = new System.Drawing.Point(661, 187);
            this.butCheck.Name = "butCheck";
            this.butCheck.Size = new System.Drawing.Size(91, 61);
            this.butCheck.TabIndex = 31;
            this.butCheck.Text = "Retrieving data...";
            this.butCheck.UseVisualStyleBackColor = false;
            this.butCheck.Click += new System.EventHandler(this.butCheck_Click);
            // 
            // txtRoleSearch
            // 
            this.txtRoleSearch.Location = new System.Drawing.Point(87, 30);
            this.txtRoleSearch.Name = "txtRoleSearch";
            this.txtRoleSearch.Size = new System.Drawing.Size(233, 20);
            this.txtRoleSearch.TabIndex = 61;
            this.txtRoleSearch.TextChanged += new System.EventHandler(this.txtRoleSearch_TextChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl.Location = new System.Drawing.Point(12, 30);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(46, 17);
            this.lbl.TabIndex = 62;
            this.lbl.Text = "Role:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(347, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "Role:";
            // 
            // txtRole2Search
            // 
            this.txtRole2Search.Location = new System.Drawing.Point(422, 30);
            this.txtRole2Search.Name = "txtRole2Search";
            this.txtRole2Search.Size = new System.Drawing.Size(233, 20);
            this.txtRole2Search.TabIndex = 64;
            this.txtRole2Search.TextChanged += new System.EventHandler(this.txtRole2Search_TextChanged);
            // 
            // gridRoles2
            // 
            this.gridRoles2.AllowUserToAddRows = false;
            this.gridRoles2.AllowUserToDeleteRows = false;
            this.gridRoles2.AllowUserToResizeColumns = false;
            this.gridRoles2.AllowUserToResizeRows = false;
            this.gridRoles2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRoles2.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridRoles2.Location = new System.Drawing.Point(347, 56);
            this.gridRoles2.MultiSelect = false;
            this.gridRoles2.Name = "gridRoles2";
            this.gridRoles2.RowHeadersVisible = false;
            this.gridRoles2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRoles2.Size = new System.Drawing.Size(308, 430);
            this.gridRoles2.TabIndex = 63;
            this.gridRoles2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.gridRoles2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // SecurityRolesCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 498);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRole2Search);
            this.Controls.Add(this.gridRoles2);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtRoleSearch);
            this.Controls.Add(this.butCheck);
            this.Controls.Add(this.gridRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SecurityRolesCompare";
            this.Text = "Security Roles Analizer";
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridRoles;
        private System.Windows.Forms.Button butCheck;
        private System.Windows.Forms.TextBox txtRoleSearch;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRole2Search;
        private System.Windows.Forms.DataGridView gridRoles2;
    }
}