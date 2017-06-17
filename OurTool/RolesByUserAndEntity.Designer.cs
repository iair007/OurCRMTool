namespace OurCRMTool
{
    partial class RolesByUserAndEntity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolesByUserAndEntity));
            this.label2 = new System.Windows.Forms.Label();
            this.gridRoles = new System.Windows.Forms.DataGridView();
            this.lbSecurityRoles = new System.Windows.Forms.Label();
            this.butRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Entities";
            // 
            // gridRoles
            // 
            this.gridRoles.AllowUserToAddRows = false;
            this.gridRoles.AllowUserToDeleteRows = false;
            this.gridRoles.AllowUserToResizeRows = false;
            this.gridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRoles.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridRoles.Location = new System.Drawing.Point(12, 39);
            this.gridRoles.MultiSelect = false;
            this.gridRoles.Name = "gridRoles";
            this.gridRoles.RowHeadersVisible = false;
            this.gridRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRoles.Size = new System.Drawing.Size(618, 404);
            this.gridRoles.TabIndex = 39;
            this.gridRoles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRoles_CellDoubleClick);
            // 
            // lbSecurityRoles
            // 
            this.lbSecurityRoles.AutoSize = true;
            this.lbSecurityRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbSecurityRoles.Location = new System.Drawing.Point(9, 453);
            this.lbSecurityRoles.Name = "lbSecurityRoles";
            this.lbSecurityRoles.Size = new System.Drawing.Size(118, 17);
            this.lbSecurityRoles.TabIndex = 43;
            this.lbSecurityRoles.Text = "Security Roles:";
            // 
            // butRefresh
            // 
            this.butRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butRefresh.Location = new System.Drawing.Point(518, 450);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(112, 23);
            this.butRefresh.TabIndex = 53;
            this.butRefresh.Text = "Refresh Entities";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click_1);
            // 
            // RolesByUserAndEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 479);
            this.Controls.Add(this.butRefresh);
            this.Controls.Add(this.lbSecurityRoles);
            this.Controls.Add(this.gridRoles);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RolesByUserAndEntity";
            this.Text = "Roles By User And Entity";
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridRoles;
        private System.Windows.Forms.Label lbSecurityRoles;
        private System.Windows.Forms.Button butRefresh;
    }
}