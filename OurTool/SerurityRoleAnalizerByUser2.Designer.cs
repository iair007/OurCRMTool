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
            this.butCheck = new System.Windows.Forms.Button();
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
            this.txtCustomEntitySearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUser3 = new System.Windows.Forms.Label();
            this.gridCustomEntities = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.txtRoleSearch = new System.Windows.Forms.TextBox();
            this.gridRoles = new System.Windows.Forms.DataGridView();
            this.butClearRoles = new System.Windows.Forms.Button();
            this.butSelAll = new System.Windows.Forms.Button();
            this.chkUpdateGridOnSelect = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSystemEntities)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabSystemEntities.SuspendLayout();
            this.tabGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGlobal)).BeginInit();
            this.tabCustomEntities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // butCheck
            // 
            this.butCheck.BackColor = System.Drawing.Color.Gray;
            this.butCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butCheck.Location = new System.Drawing.Point(419, 497);
            this.butCheck.Name = "butCheck";
            this.butCheck.Size = new System.Drawing.Size(105, 39);
            this.butCheck.TabIndex = 26;
            this.butCheck.Text = "Retrieving...";
            this.butCheck.UseVisualStyleBackColor = false;
            this.butCheck.Visible = false;
            this.butCheck.Click += new System.EventHandler(this.butCheck_Click);
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
            this.gridSystemEntities.Size = new System.Drawing.Size(626, 394);
            this.gridSystemEntities.TabIndex = 39;
            this.gridSystemEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Logical Or Display Entity Name";
            // 
            // lbUser1
            // 
            this.lbUser1.AutoSize = true;
            this.lbUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUser1.Location = new System.Drawing.Point(21, 18);
            this.lbUser1.Name = "lbUser1";
            this.lbUser1.Size = new System.Drawing.Size(47, 17);
            this.lbUser1.TabIndex = 59;
            this.lbUser1.Text = "User:";
            this.lbUser1.Click += new System.EventHandler(this.lbUser1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabSystemEntities);
            this.panel1.Controls.Add(this.tabGlobal);
            this.panel1.Controls.Add(this.tabCustomEntities);
            this.panel1.Location = new System.Drawing.Point(539, 30);
            this.panel1.Name = "panel1";
            this.panel1.SelectedIndex = 0;
            this.panel1.Size = new System.Drawing.Size(652, 483);
            this.panel1.TabIndex = 63;
            this.panel1.SelectedIndexChanged += new System.EventHandler(this.panel1_SelectedIndexChanged);
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
            this.tabSystemEntities.Size = new System.Drawing.Size(644, 457);
            this.tabSystemEntities.TabIndex = 0;
            this.tabSystemEntities.Text = "System Entities";
            this.tabSystemEntities.UseVisualStyleBackColor = true;
            // 
            // txtSystemSearch
            // 
            this.txtSystemSearch.Location = new System.Drawing.Point(260, 32);
            this.txtSystemSearch.Name = "txtSystemSearch";
            this.txtSystemSearch.Size = new System.Drawing.Size(372, 20);
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
            this.tabGlobal.Size = new System.Drawing.Size(644, 457);
            this.tabGlobal.TabIndex = 1;
            this.tabGlobal.Text = "Global";
            this.tabGlobal.UseVisualStyleBackColor = true;
            // 
            // txtPrivilegeSearch
            // 
            this.txtPrivilegeSearch.Location = new System.Drawing.Point(136, 39);
            this.txtPrivilegeSearch.Name = "txtPrivilegeSearch";
            this.txtPrivilegeSearch.Size = new System.Drawing.Size(404, 20);
            this.txtPrivilegeSearch.TabIndex = 65;
            this.txtPrivilegeSearch.TextChanged += new System.EventHandler(this.txtPrivilegeSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(13, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "Privilege Name";
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
            this.lbUser2.Click += new System.EventHandler(this.lbUser2_Click);
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
            this.gridGlobal.Size = new System.Drawing.Size(534, 393);
            this.gridGlobal.TabIndex = 40;
            // 
            // tabCustomEntities
            // 
            this.tabCustomEntities.Controls.Add(this.txtCustomEntitySearch);
            this.tabCustomEntities.Controls.Add(this.label2);
            this.tabCustomEntities.Controls.Add(this.lbUser3);
            this.tabCustomEntities.Controls.Add(this.gridCustomEntities);
            this.tabCustomEntities.Location = new System.Drawing.Point(4, 22);
            this.tabCustomEntities.Name = "tabCustomEntities";
            this.tabCustomEntities.Size = new System.Drawing.Size(644, 457);
            this.tabCustomEntities.TabIndex = 2;
            this.tabCustomEntities.Text = "Custom Entities";
            this.tabCustomEntities.UseVisualStyleBackColor = true;
            // 
            // txtCustomEntitySearch
            // 
            this.txtCustomEntitySearch.Location = new System.Drawing.Point(255, 42);
            this.txtCustomEntitySearch.Name = "txtCustomEntitySearch";
            this.txtCustomEntitySearch.Size = new System.Drawing.Size(381, 20);
            this.txtCustomEntitySearch.TabIndex = 65;
            this.txtCustomEntitySearch.TextChanged += new System.EventHandler(this.txtCustomEntitySearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Logical Or Display Entity Name";
            // 
            // lbUser3
            // 
            this.lbUser3.AutoSize = true;
            this.lbUser3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbUser3.Location = new System.Drawing.Point(16, 22);
            this.lbUser3.Name = "lbUser3";
            this.lbUser3.Size = new System.Drawing.Size(47, 17);
            this.lbUser3.TabIndex = 60;
            this.lbUser3.Text = "User:";
            this.lbUser3.Click += new System.EventHandler(this.lbUser3_Click);
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
            this.gridCustomEntities.Size = new System.Drawing.Size(633, 393);
            this.gridCustomEntities.TabIndex = 40;
            this.gridCustomEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl.Location = new System.Drawing.Point(12, 30);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(46, 17);
            this.lbl.TabIndex = 66;
            this.lbl.Text = "Role:";
            // 
            // txtRoleSearch
            // 
            this.txtRoleSearch.Location = new System.Drawing.Point(87, 30);
            this.txtRoleSearch.Name = "txtRoleSearch";
            this.txtRoleSearch.Size = new System.Drawing.Size(437, 20);
            this.txtRoleSearch.TabIndex = 65;
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
            this.gridRoles.Size = new System.Drawing.Size(512, 435);
            this.gridRoles.TabIndex = 64;
            this.gridRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRoles_CellClick);
            this.gridRoles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AddToolTip2);
            // 
            // butClearRoles
            // 
            this.butClearRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearRoles.Location = new System.Drawing.Point(12, 497);
            this.butClearRoles.Name = "butClearRoles";
            this.butClearRoles.Size = new System.Drawing.Size(57, 34);
            this.butClearRoles.TabIndex = 80;
            this.butClearRoles.Text = "Clear All";
            this.butClearRoles.UseVisualStyleBackColor = true;
            this.butClearRoles.Click += new System.EventHandler(this.butClearAllRoles_Click);
            // 
            // butSelAll
            // 
            this.butSelAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelAll.Location = new System.Drawing.Point(75, 497);
            this.butSelAll.Name = "butSelAll";
            this.butSelAll.Size = new System.Drawing.Size(53, 34);
            this.butSelAll.TabIndex = 79;
            this.butSelAll.Text = "Select All";
            this.butSelAll.UseVisualStyleBackColor = true;
            this.butSelAll.Click += new System.EventHandler(this.butSelAll_Click);
            // 
            // chkUpdateGridOnSelect
            // 
            this.chkUpdateGridOnSelect.AutoSize = true;
            this.chkUpdateGridOnSelect.Checked = true;
            this.chkUpdateGridOnSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateGridOnSelect.Location = new System.Drawing.Point(87, 7);
            this.chkUpdateGridOnSelect.Name = "chkUpdateGridOnSelect";
            this.chkUpdateGridOnSelect.Size = new System.Drawing.Size(134, 17);
            this.chkUpdateGridOnSelect.TabIndex = 81;
            this.chkUpdateGridOnSelect.Text = "Get Privilege on Select";
            this.chkUpdateGridOnSelect.UseVisualStyleBackColor = true;
            this.chkUpdateGridOnSelect.CheckedChanged += new System.EventHandler(this.chkUpdateGridOnSelect_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightYellow;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(134, 495);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 39);
            this.button1.TabIndex = 82;
            this.button1.Text = "Compare Roles";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SerurityRoleAnalizerByUser2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkUpdateGridOnSelect);
            this.Controls.Add(this.butClearRoles);
            this.Controls.Add(this.butSelAll);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtRoleSearch);
            this.Controls.Add(this.gridRoles);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butCheck);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCheck;
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
        private System.Windows.Forms.TextBox txtCustomEntitySearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtRoleSearch;
        private System.Windows.Forms.DataGridView gridRoles;
        private System.Windows.Forms.Button butClearRoles;
        private System.Windows.Forms.Button butSelAll;
        private System.Windows.Forms.CheckBox chkUpdateGridOnSelect;
        private System.Windows.Forms.Button button1;
    }
}