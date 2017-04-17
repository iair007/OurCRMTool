namespace OurCRMTool
{
    partial class SerurityRoleAnalizerByUser2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerurityRoleAnalizerByUser2));
            this.butRefresh = new System.Windows.Forms.Button();
            this.gridSystemEntities = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUser1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.TabControl();
            this.tabSystemEntities = new System.Windows.Forms.TabPage();
            this.txtSystemSearch = new System.Windows.Forms.TextBox();
            this.tabGlobal = new System.Windows.Forms.TabPage();
            this.txtPrivilegeSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUser2 = new System.Windows.Forms.Label();
            this.gridGlobal = new System.Windows.Forms.DataGridView();
            this.tabCustomEntities = new System.Windows.Forms.TabPage();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUser3 = new System.Windows.Forms.Label();
            this.gridCustomEntities = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridSystemEntities)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabSystemEntities.SuspendLayout();
            this.tabGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGlobal)).BeginInit();
            this.tabCustomEntities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // butRefresh
            // 
            this.butRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butRefresh.Location = new System.Drawing.Point(644, 504);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(95, 29);
            this.butRefresh.TabIndex = 26;
            this.butRefresh.Text = "Refresh Roles";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // gridSystemEntities
            // 
            this.gridSystemEntities.AllowUserToAddRows = false;
            this.gridSystemEntities.AllowUserToDeleteRows = false;
            this.gridSystemEntities.AllowUserToResizeRows = false;
            this.gridSystemEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSystemEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridSystemEntities.Location = new System.Drawing.Point(6, 58);
            this.gridSystemEntities.MultiSelect = false;
            this.gridSystemEntities.Name = "gridSystemEntities";
            this.gridSystemEntities.RowHeadersVisible = false;
            this.gridSystemEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSystemEntities.Size = new System.Drawing.Size(701, 393);
            this.gridSystemEntities.TabIndex = 39;
            this.gridSystemEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            this.gridSystemEntities.SelectionChanged += new System.EventHandler(this.gridFirstSystemEntities_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Entity";
            // 
            // lbUser1
            // 
            this.lbUser1.AutoSize = true;
            this.lbUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUser1.Location = new System.Drawing.Point(24, 5);
            this.lbUser1.Name = "lbUser1";
            this.lbUser1.Size = new System.Drawing.Size(47, 17);
            this.lbUser1.TabIndex = 59;
            this.lbUser1.Text = "User:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabSystemEntities);
            this.panel1.Controls.Add(this.tabGlobal);
            this.panel1.Controls.Add(this.tabCustomEntities);
            this.panel1.Location = new System.Drawing.Point(18, 12);
            this.panel1.Name = "panel1";
            this.panel1.SelectedIndex = 0;
            this.panel1.Size = new System.Drawing.Size(721, 490);
            this.panel1.TabIndex = 63;
            this.panel1.SelectedIndexChanged += new System.EventHandler(this.lbFirstCustomRole_SelectedIndexChanged);
            // 
            // tabSystemEntities
            // 
            this.tabSystemEntities.Controls.Add(this.txtSystemSearch);
            this.tabSystemEntities.Controls.Add(this.lbUser1);
            this.tabSystemEntities.Controls.Add(this.label1);
            this.tabSystemEntities.Controls.Add(this.gridSystemEntities);
            this.tabSystemEntities.Location = new System.Drawing.Point(4, 22);
            this.tabSystemEntities.Name = "tabSystemEntities";
            this.tabSystemEntities.Padding = new System.Windows.Forms.Padding(3);
            this.tabSystemEntities.Size = new System.Drawing.Size(713, 464);
            this.tabSystemEntities.TabIndex = 0;
            this.tabSystemEntities.Text = "System Entities";
            this.tabSystemEntities.UseVisualStyleBackColor = true;
            // 
            // txtSystemSearch
            // 
            this.txtSystemSearch.Location = new System.Drawing.Point(76, 32);
            this.txtSystemSearch.Name = "txtSystemSearch";
            this.txtSystemSearch.Size = new System.Drawing.Size(507, 20);
            this.txtSystemSearch.TabIndex = 63;
            this.txtSystemSearch.TextChanged += new System.EventHandler(this.txtSystemSearch_TextChanged);
            // 
            // tabGlobal
            // 
            this.tabGlobal.Controls.Add(this.txtPrivilegeSearch);
            this.tabGlobal.Controls.Add(this.label3);
            this.tabGlobal.Controls.Add(this.lbUser2);
            this.tabGlobal.Controls.Add(this.gridGlobal);
            this.tabGlobal.Location = new System.Drawing.Point(4, 22);
            this.tabGlobal.Name = "tabGlobal";
            this.tabGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlobal.Size = new System.Drawing.Size(713, 464);
            this.tabGlobal.TabIndex = 1;
            this.tabGlobal.Text = "Global";
            this.tabGlobal.UseVisualStyleBackColor = true;
            // 
            // txtPrivilegeSearch
            // 
            this.txtPrivilegeSearch.Location = new System.Drawing.Point(90, 42);
            this.txtPrivilegeSearch.Name = "txtPrivilegeSearch";
            this.txtPrivilegeSearch.Size = new System.Drawing.Size(378, 20);
            this.txtPrivilegeSearch.TabIndex = 65;
            this.txtPrivilegeSearch.TextChanged += new System.EventHandler(this.txtPrivilegeSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "Privilege";
            // 
            // lbUser2
            // 
            this.lbUser2.AutoSize = true;
            this.lbUser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUser2.Location = new System.Drawing.Point(13, 16);
            this.lbUser2.Name = "lbUser2";
            this.lbUser2.Size = new System.Drawing.Size(47, 17);
            this.lbUser2.TabIndex = 60;
            this.lbUser2.Text = "User:";
            // 
            // gridGlobal
            // 
            this.gridGlobal.AllowUserToAddRows = false;
            this.gridGlobal.AllowUserToDeleteRows = false;
            this.gridGlobal.AllowUserToResizeRows = false;
            this.gridGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGlobal.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridGlobal.Location = new System.Drawing.Point(6, 65);
            this.gridGlobal.MultiSelect = false;
            this.gridGlobal.Name = "gridGlobal";
            this.gridGlobal.RowHeadersVisible = false;
            this.gridGlobal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGlobal.Size = new System.Drawing.Size(701, 393);
            this.gridGlobal.TabIndex = 40;
            this.gridGlobal.SelectionChanged += new System.EventHandler(this.gridFirstGlobal_SelectionChanged);
            // 
            // tabCustomEntities
            // 
            this.tabCustomEntities.Controls.Add(this.txtCustomerSearch);
            this.tabCustomEntities.Controls.Add(this.label2);
            this.tabCustomEntities.Controls.Add(this.lbUser3);
            this.tabCustomEntities.Controls.Add(this.gridCustomEntities);
            this.tabCustomEntities.Location = new System.Drawing.Point(4, 22);
            this.tabCustomEntities.Name = "tabCustomEntities";
            this.tabCustomEntities.Size = new System.Drawing.Size(713, 464);
            this.tabCustomEntities.TabIndex = 2;
            this.tabCustomEntities.Text = "Custom Entities";
            this.tabCustomEntities.UseVisualStyleBackColor = true;
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(71, 42);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(507, 20);
            this.txtCustomerSearch.TabIndex = 65;
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Entity";
            // 
            // lbUser3
            // 
            this.lbUser3.AutoSize = true;
            this.lbUser3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUser3.Location = new System.Drawing.Point(19, 13);
            this.lbUser3.Name = "lbUser3";
            this.lbUser3.Size = new System.Drawing.Size(47, 17);
            this.lbUser3.TabIndex = 60;
            this.lbUser3.Text = "User:";
            // 
            // gridCustomEntities
            // 
            this.gridCustomEntities.AllowUserToAddRows = false;
            this.gridCustomEntities.AllowUserToDeleteRows = false;
            this.gridCustomEntities.AllowUserToResizeRows = false;
            this.gridCustomEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCustomEntities.Location = new System.Drawing.Point(3, 68);
            this.gridCustomEntities.MultiSelect = false;
            this.gridCustomEntities.Name = "gridCustomEntities";
            this.gridCustomEntities.RowHeadersVisible = false;
            this.gridCustomEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCustomEntities.Size = new System.Drawing.Size(707, 393);
            this.gridCustomEntities.TabIndex = 40;
            this.gridCustomEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            this.gridCustomEntities.SelectionChanged += new System.EventHandler(this.gridFirstCustomEntities_SelectionChanged);
            // 
            // SerurityRoleAnalizerByUser2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 538);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SerurityRoleAnalizerByUser2";
            this.Text = "Security Roles Analizer";
            ((System.ComponentModel.ISupportInitialize)(this.gridSystemEntities)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabSystemEntities.ResumeLayout(false);
            this.tabSystemEntities.PerformLayout();
            this.tabGlobal.ResumeLayout(false);
            this.tabGlobal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGlobal)).EndInit();
            this.tabCustomEntities.ResumeLayout(false);
            this.tabCustomEntities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.DataGridView gridSystemEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUser1;
        private System.Windows.Forms.TabControl panel1;
        private System.Windows.Forms.TabPage tabSystemEntities;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.TabPage tabCustomEntities;
        private System.Windows.Forms.DataGridView gridCustomEntities;
        private System.Windows.Forms.DataGridView gridGlobal;
        private System.Windows.Forms.Label lbUser2;
        private System.Windows.Forms.Label lbUser3;
        private System.Windows.Forms.TextBox txtSystemSearch;
        private System.Windows.Forms.TextBox txtPrivilegeSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}