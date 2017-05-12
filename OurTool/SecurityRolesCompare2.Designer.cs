namespace OurCRMTool
{
    partial class SecurityRolesCompare2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityRolesCompare2));
            this.butRefresh = new System.Windows.Forms.Button();
            this.gridFirstSystemEntities = new System.Windows.Forms.DataGridView();
            this.gridSecondSystemEntities = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFirstSystemRole = new System.Windows.Forms.Label();
            this.lbSecondSystemRole = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.TabControl();
            this.tabSystemEntities = new System.Windows.Forms.TabPage();
            this.txtSystemSearch = new System.Windows.Forms.TextBox();
            this.tabGlobal = new System.Windows.Forms.TabPage();
            this.txtPrivilegeSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSecondGlobal = new System.Windows.Forms.Label();
            this.lbFirstGlobal = new System.Windows.Forms.Label();
            this.gridSecondGlobal = new System.Windows.Forms.DataGridView();
            this.gridFirstGlobal = new System.Windows.Forms.DataGridView();
            this.tabCustomEntities = new System.Windows.Forms.TabPage();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSecondCustomRole = new System.Windows.Forms.Label();
            this.lbFirstCustomRole = new System.Windows.Forms.Label();
            this.gridSecondCustomEntities = new System.Windows.Forms.DataGridView();
            this.gridFirstCustomEntities = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridFirstSystemEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSecondSystemEntities)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabSystemEntities.SuspendLayout();
            this.tabGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSecondGlobal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFirstGlobal)).BeginInit();
            this.tabCustomEntities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSecondCustomEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFirstCustomEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // butRefresh
            // 
            this.butRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butRefresh.Location = new System.Drawing.Point(1146, 508);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(95, 29);
            this.butRefresh.TabIndex = 26;
            this.butRefresh.Text = "Refresh Roles";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // gridFirstSystemEntities
            // 
            this.gridFirstSystemEntities.AllowUserToAddRows = false;
            this.gridFirstSystemEntities.AllowUserToDeleteRows = false;
            this.gridFirstSystemEntities.AllowUserToResizeRows = false;
            this.gridFirstSystemEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFirstSystemEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridFirstSystemEntities.Location = new System.Drawing.Point(6, 58);
            this.gridFirstSystemEntities.MultiSelect = false;
            this.gridFirstSystemEntities.Name = "gridFirstSystemEntities";
            this.gridFirstSystemEntities.RowHeadersVisible = false;
            this.gridFirstSystemEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFirstSystemEntities.Size = new System.Drawing.Size(577, 393);
            this.gridFirstSystemEntities.TabIndex = 39;
            this.gridFirstSystemEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            this.gridFirstSystemEntities.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridFirstSystemEntities_Scroll);
            this.gridFirstSystemEntities.SelectionChanged += new System.EventHandler(this.gridFirstSystemEntities_SelectionChanged);
            // 
            // gridSecondSystemEntities
            // 
            this.gridSecondSystemEntities.AllowUserToAddRows = false;
            this.gridSecondSystemEntities.AllowUserToDeleteRows = false;
            this.gridSecondSystemEntities.AllowUserToResizeRows = false;
            this.gridSecondSystemEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSecondSystemEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridSecondSystemEntities.Location = new System.Drawing.Point(608, 57);
            this.gridSecondSystemEntities.MultiSelect = false;
            this.gridSecondSystemEntities.Name = "gridSecondSystemEntities";
            this.gridSecondSystemEntities.RowHeadersVisible = false;
            this.gridSecondSystemEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSecondSystemEntities.Size = new System.Drawing.Size(593, 394);
            this.gridSecondSystemEntities.TabIndex = 52;
            this.gridSecondSystemEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            this.gridSecondSystemEntities.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridSecondSystemEntities_Scroll);
            this.gridSecondSystemEntities.SelectionChanged += new System.EventHandler(this.gridSecondSystemEntities_SelectionChanged);
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
            // lbFirstSystemRole
            // 
            this.lbFirstSystemRole.AutoSize = true;
            this.lbFirstSystemRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbFirstSystemRole.Location = new System.Drawing.Point(24, 5);
            this.lbFirstSystemRole.Name = "lbFirstSystemRole";
            this.lbFirstSystemRole.Size = new System.Drawing.Size(46, 17);
            this.lbFirstSystemRole.TabIndex = 59;
            this.lbFirstSystemRole.Text = "Role:";
            this.lbFirstSystemRole.DoubleClick += new System.EventHandler(this.OpenFirstRole);
            // 
            // lbSecondSystemRole
            // 
            this.lbSecondSystemRole.AutoSize = true;
            this.lbSecondSystemRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbSecondSystemRole.Location = new System.Drawing.Point(621, 5);
            this.lbSecondSystemRole.Name = "lbSecondSystemRole";
            this.lbSecondSystemRole.Size = new System.Drawing.Size(46, 17);
            this.lbSecondSystemRole.TabIndex = 60;
            this.lbSecondSystemRole.Text = "Role:";
            this.lbSecondSystemRole.DoubleClick += new System.EventHandler(this.OpenSecondRole);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabSystemEntities);
            this.panel1.Controls.Add(this.tabGlobal);
            this.panel1.Controls.Add(this.tabCustomEntities);
            this.panel1.Location = new System.Drawing.Point(18, 12);
            this.panel1.Name = "panel1";
            this.panel1.SelectedIndex = 0;
            this.panel1.Size = new System.Drawing.Size(1229, 490);
            this.panel1.TabIndex = 63;
            this.panel1.SelectedIndexChanged += new System.EventHandler(this.lbFirstCustomRole_SelectedIndexChanged);
            // 
            // tabSystemEntities
            // 
            this.tabSystemEntities.Controls.Add(this.txtSystemSearch);
            this.tabSystemEntities.Controls.Add(this.lbFirstSystemRole);
            this.tabSystemEntities.Controls.Add(this.lbSecondSystemRole);
            this.tabSystemEntities.Controls.Add(this.label1);
            this.tabSystemEntities.Controls.Add(this.gridSecondSystemEntities);
            this.tabSystemEntities.Controls.Add(this.gridFirstSystemEntities);
            this.tabSystemEntities.Location = new System.Drawing.Point(4, 22);
            this.tabSystemEntities.Name = "tabSystemEntities";
            this.tabSystemEntities.Padding = new System.Windows.Forms.Padding(3);
            this.tabSystemEntities.Size = new System.Drawing.Size(1221, 464);
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
            this.tabGlobal.Controls.Add(this.lbSecondGlobal);
            this.tabGlobal.Controls.Add(this.lbFirstGlobal);
            this.tabGlobal.Controls.Add(this.gridSecondGlobal);
            this.tabGlobal.Controls.Add(this.gridFirstGlobal);
            this.tabGlobal.Location = new System.Drawing.Point(4, 22);
            this.tabGlobal.Name = "tabGlobal";
            this.tabGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlobal.Size = new System.Drawing.Size(1221, 464);
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
            // lbSecondGlobal
            // 
            this.lbSecondGlobal.AutoSize = true;
            this.lbSecondGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbSecondGlobal.Location = new System.Drawing.Point(487, 16);
            this.lbSecondGlobal.Name = "lbSecondGlobal";
            this.lbSecondGlobal.Size = new System.Drawing.Size(46, 17);
            this.lbSecondGlobal.TabIndex = 61;
            this.lbSecondGlobal.Text = "Role:";
            this.lbSecondGlobal.DoubleClick += new System.EventHandler(this.OpenSecondRole);
            // 
            // lbFirstGlobal
            // 
            this.lbFirstGlobal.AutoSize = true;
            this.lbFirstGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbFirstGlobal.Location = new System.Drawing.Point(13, 16);
            this.lbFirstGlobal.Name = "lbFirstGlobal";
            this.lbFirstGlobal.Size = new System.Drawing.Size(46, 17);
            this.lbFirstGlobal.TabIndex = 60;
            this.lbFirstGlobal.Text = "Role:";
            this.lbFirstGlobal.DoubleClick += new System.EventHandler(this.OpenFirstRole);
            // 
            // gridSecondGlobal
            // 
            this.gridSecondGlobal.AllowUserToAddRows = false;
            this.gridSecondGlobal.AllowUserToDeleteRows = false;
            this.gridSecondGlobal.AllowUserToResizeRows = false;
            this.gridSecondGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSecondGlobal.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridSecondGlobal.Location = new System.Drawing.Point(481, 65);
            this.gridSecondGlobal.MultiSelect = false;
            this.gridSecondGlobal.Name = "gridSecondGlobal";
            this.gridSecondGlobal.RowHeadersVisible = false;
            this.gridSecondGlobal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSecondGlobal.Size = new System.Drawing.Size(462, 393);
            this.gridSecondGlobal.TabIndex = 41;
            this.gridSecondGlobal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridSecondGlobal_Scroll);
            this.gridSecondGlobal.SelectionChanged += new System.EventHandler(this.gridSecondGlobal_SelectionChanged);
            // 
            // gridFirstGlobal
            // 
            this.gridFirstGlobal.AllowUserToAddRows = false;
            this.gridFirstGlobal.AllowUserToDeleteRows = false;
            this.gridFirstGlobal.AllowUserToResizeRows = false;
            this.gridFirstGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFirstGlobal.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridFirstGlobal.Location = new System.Drawing.Point(6, 65);
            this.gridFirstGlobal.MultiSelect = false;
            this.gridFirstGlobal.Name = "gridFirstGlobal";
            this.gridFirstGlobal.RowHeadersVisible = false;
            this.gridFirstGlobal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFirstGlobal.Size = new System.Drawing.Size(462, 393);
            this.gridFirstGlobal.TabIndex = 40;
            this.gridFirstGlobal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridFirstGlobal_Scroll);
            this.gridFirstGlobal.SelectionChanged += new System.EventHandler(this.gridFirstGlobal_SelectionChanged);
            // 
            // tabCustomEntities
            // 
            this.tabCustomEntities.Controls.Add(this.txtCustomerSearch);
            this.tabCustomEntities.Controls.Add(this.label2);
            this.tabCustomEntities.Controls.Add(this.lbSecondCustomRole);
            this.tabCustomEntities.Controls.Add(this.lbFirstCustomRole);
            this.tabCustomEntities.Controls.Add(this.gridSecondCustomEntities);
            this.tabCustomEntities.Controls.Add(this.gridFirstCustomEntities);
            this.tabCustomEntities.Location = new System.Drawing.Point(4, 22);
            this.tabCustomEntities.Name = "tabCustomEntities";
            this.tabCustomEntities.Size = new System.Drawing.Size(1221, 464);
            this.tabCustomEntities.TabIndex = 2;
            this.tabCustomEntities.Text = "Custom Entities";
            this.tabCustomEntities.UseVisualStyleBackColor = true;
            // 
            // txtCustomEntitySearch
            // 
            this.txtCustomerSearch.Location = new System.Drawing.Point(71, 42);
            this.txtCustomerSearch.Name = "txtCustomEntitySearch";
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
            // lbSecondCustomRole
            // 
            this.lbSecondCustomRole.AutoSize = true;
            this.lbSecondCustomRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbSecondCustomRole.Location = new System.Drawing.Point(605, 13);
            this.lbSecondCustomRole.Name = "lbSecondCustomRole";
            this.lbSecondCustomRole.Size = new System.Drawing.Size(46, 17);
            this.lbSecondCustomRole.TabIndex = 61;
            this.lbSecondCustomRole.Text = "Role:";
            this.lbSecondCustomRole.DoubleClick += new System.EventHandler(this.OpenSecondRole);
            // 
            // lbFirstCustomRole
            // 
            this.lbFirstCustomRole.AutoSize = true;
            this.lbFirstCustomRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbFirstCustomRole.Location = new System.Drawing.Point(19, 13);
            this.lbFirstCustomRole.Name = "lbFirstCustomRole";
            this.lbFirstCustomRole.Size = new System.Drawing.Size(46, 17);
            this.lbFirstCustomRole.TabIndex = 60;
            this.lbFirstCustomRole.Text = "Role:";
            this.lbFirstCustomRole.DoubleClick += new System.EventHandler(this.OpenFirstRole);
            // 
            // gridSecondCustomEntities
            // 
            this.gridSecondCustomEntities.AllowUserToAddRows = false;
            this.gridSecondCustomEntities.AllowUserToDeleteRows = false;
            this.gridSecondCustomEntities.AllowUserToResizeRows = false;
            this.gridSecondCustomEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSecondCustomEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridSecondCustomEntities.Location = new System.Drawing.Point(594, 68);
            this.gridSecondCustomEntities.MultiSelect = false;
            this.gridSecondCustomEntities.Name = "gridSecondCustomEntities";
            this.gridSecondCustomEntities.RowHeadersVisible = false;
            this.gridSecondCustomEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSecondCustomEntities.Size = new System.Drawing.Size(624, 393);
            this.gridSecondCustomEntities.TabIndex = 41;
            this.gridSecondCustomEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            this.gridSecondCustomEntities.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridSecondCustomEntities_Scroll);
            this.gridSecondCustomEntities.SelectionChanged += new System.EventHandler(this.gridSecondCustomEntities_SelectionChanged);
            // 
            // gridFirstCustomEntities
            // 
            this.gridFirstCustomEntities.AllowUserToAddRows = false;
            this.gridFirstCustomEntities.AllowUserToDeleteRows = false;
            this.gridFirstCustomEntities.AllowUserToResizeRows = false;
            this.gridFirstCustomEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFirstCustomEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridFirstCustomEntities.Location = new System.Drawing.Point(3, 68);
            this.gridFirstCustomEntities.MultiSelect = false;
            this.gridFirstCustomEntities.Name = "gridFirstCustomEntities";
            this.gridFirstCustomEntities.RowHeadersVisible = false;
            this.gridFirstCustomEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFirstCustomEntities.Size = new System.Drawing.Size(575, 393);
            this.gridFirstCustomEntities.TabIndex = 40;
            this.gridFirstCustomEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            this.gridFirstCustomEntities.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gridFirstCustomEntities_Scroll);
            this.gridFirstCustomEntities.SelectionChanged += new System.EventHandler(this.gridFirstCustomEntities_SelectionChanged);
            // 
            // SecurityRolesCompare2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 538);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SecurityRolesCompare2";
            this.Text = "Security Roles Analizer";
            ((System.ComponentModel.ISupportInitialize)(this.gridFirstSystemEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSecondSystemEntities)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabSystemEntities.ResumeLayout(false);
            this.tabSystemEntities.PerformLayout();
            this.tabGlobal.ResumeLayout(false);
            this.tabGlobal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSecondGlobal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFirstGlobal)).EndInit();
            this.tabCustomEntities.ResumeLayout(false);
            this.tabCustomEntities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSecondCustomEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFirstCustomEntities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.DataGridView gridFirstSystemEntities;
        private System.Windows.Forms.DataGridView gridSecondSystemEntities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFirstSystemRole;
        private System.Windows.Forms.Label lbSecondSystemRole;
        private System.Windows.Forms.TabControl panel1;
        private System.Windows.Forms.TabPage tabSystemEntities;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.TabPage tabCustomEntities;
        private System.Windows.Forms.DataGridView gridFirstCustomEntities;
        private System.Windows.Forms.DataGridView gridSecondCustomEntities;
        private System.Windows.Forms.DataGridView gridSecondGlobal;
        private System.Windows.Forms.DataGridView gridFirstGlobal;
        private System.Windows.Forms.Label lbSecondGlobal;
        private System.Windows.Forms.Label lbFirstGlobal;
        private System.Windows.Forms.Label lbSecondCustomRole;
        private System.Windows.Forms.Label lbFirstCustomRole;
        private System.Windows.Forms.TextBox txtSystemSearch;
        private System.Windows.Forms.TextBox txtPrivilegeSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}