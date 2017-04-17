namespace OurCRMTool
{
    partial class CompareRecords1
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.butClearKey = new System.Windows.Forms.Button();
            this.butSelectKeyAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboDirecction = new System.Windows.Forms.ComboBox();
            this.comboOrderBy = new System.Windows.Forms.ComboBox();
            this.butCompare = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.gridFieldsToCheck = new System.Windows.Forms.DataGridView();
            this.butClearCompare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butSelectCompareAll = new System.Windows.Forms.Button();
            this.butFieldClear = new System.Windows.Forms.Button();
            this.butClearSelect = new System.Windows.Forms.Button();
            this.txtFieldFilter = new System.Windows.Forms.TextBox();
            this.butSelectAll = new System.Windows.Forms.Button();
            this.butGetFields = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntityFilter = new System.Windows.Forms.TextBox();
            this.butEntityClear = new System.Windows.Forms.Button();
            this.gridEntities = new System.Windows.Forms.DataGridView();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldsToCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.butClearKey);
            this.groupBox.Controls.Add(this.butSelectKeyAll);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.comboDirecction);
            this.groupBox.Controls.Add(this.comboOrderBy);
            this.groupBox.Controls.Add(this.butCompare);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtTop);
            this.groupBox.Controls.Add(this.chkAll);
            this.groupBox.Controls.Add(this.gridFieldsToCheck);
            this.groupBox.Controls.Add(this.butClearCompare);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.butSelectCompareAll);
            this.groupBox.Controls.Add(this.butFieldClear);
            this.groupBox.Controls.Add(this.butClearSelect);
            this.groupBox.Controls.Add(this.txtFieldFilter);
            this.groupBox.Controls.Add(this.butSelectAll);
            this.groupBox.Enabled = false;
            this.groupBox.Location = new System.Drawing.Point(383, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(840, 492);
            this.groupBox.TabIndex = 52;
            this.groupBox.TabStop = false;
            // 
            // butClearKey
            // 
            this.butClearKey.BackColor = System.Drawing.Color.LightGray;
            this.butClearKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearKey.Location = new System.Drawing.Point(153, 440);
            this.butClearKey.Name = "butClearKey";
            this.butClearKey.Size = new System.Drawing.Size(75, 42);
            this.butClearKey.TabIndex = 61;
            this.butClearKey.Text = "Clear Key ";
            this.butClearKey.UseVisualStyleBackColor = false;
            this.butClearKey.Click += new System.EventHandler(this.butClearKey_Click);
            // 
            // butSelectKeyAll
            // 
            this.butSelectKeyAll.BackColor = System.Drawing.Color.LightGray;
            this.butSelectKeyAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelectKeyAll.Location = new System.Drawing.Point(72, 440);
            this.butSelectKeyAll.Name = "butSelectKeyAll";
            this.butSelectKeyAll.Size = new System.Drawing.Size(75, 42);
            this.butSelectKeyAll.TabIndex = 60;
            this.butSelectKeyAll.Text = "Select All Key";
            this.butSelectKeyAll.UseVisualStyleBackColor = false;
            this.butSelectKeyAll.Click += new System.EventHandler(this.butSelectKeyAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(584, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 59;
            this.label5.Text = "Direcction";
            // 
            // comboDirecction
            // 
            this.comboDirecction.FormattingEnabled = true;
            this.comboDirecction.Location = new System.Drawing.Point(668, 81);
            this.comboDirecction.Name = "comboDirecction";
            this.comboDirecction.Size = new System.Drawing.Size(147, 21);
            this.comboDirecction.TabIndex = 58;
            // 
            // comboOrderBy
            // 
            this.comboOrderBy.FormattingEnabled = true;
            this.comboOrderBy.Location = new System.Drawing.Point(668, 53);
            this.comboOrderBy.Name = "comboOrderBy";
            this.comboOrderBy.Size = new System.Drawing.Size(147, 21);
            this.comboOrderBy.TabIndex = 57;
            // 
            // butCompare
            // 
            this.butCompare.BackColor = System.Drawing.Color.SeaGreen;
            this.butCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butCompare.Location = new System.Drawing.Point(604, 424);
            this.butCompare.Name = "butCompare";
            this.butCompare.Size = new System.Drawing.Size(211, 58);
            this.butCompare.TabIndex = 56;
            this.butCompare.Text = "Compare Records in Enviroment";
            this.butCompare.UseVisualStyleBackColor = false;
            this.butCompare.Click += new System.EventHandler(this.butCompare_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(584, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "Order By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(597, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Check top:";
            // 
            // txtTop
            // 
            this.txtTop.Enabled = false;
            this.txtTop.Location = new System.Drawing.Point(684, 131);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(147, 20);
            this.txtTop.TabIndex = 53;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(587, 108);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(114, 17);
            this.chkAll.TabIndex = 52;
            this.chkAll.Text = "Check All Records";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // gridFieldsToCheck
            // 
            this.gridFieldsToCheck.AllowUserToAddRows = false;
            this.gridFieldsToCheck.AllowUserToDeleteRows = false;
            this.gridFieldsToCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldsToCheck.Location = new System.Drawing.Point(6, 43);
            this.gridFieldsToCheck.Name = "gridFieldsToCheck";
            this.gridFieldsToCheck.Size = new System.Drawing.Size(563, 391);
            this.gridFieldsToCheck.TabIndex = 31;
            this.gridFieldsToCheck.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFieldsToCheck_CellValueChanged);
            // 
            // butClearCompare
            // 
            this.butClearCompare.BackColor = System.Drawing.Color.Silver;
            this.butClearCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearCompare.Location = new System.Drawing.Point(322, 440);
            this.butClearCompare.Name = "butClearCompare";
            this.butClearCompare.Size = new System.Drawing.Size(75, 42);
            this.butClearCompare.TabIndex = 45;
            this.butClearCompare.Text = "Clear Compare";
            this.butClearCompare.UseVisualStyleBackColor = false;
            this.butClearCompare.Click += new System.EventHandler(this.butClearCompare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Fields in Entity";
            // 
            // butSelectCompareAll
            // 
            this.butSelectCompareAll.BackColor = System.Drawing.Color.Silver;
            this.butSelectCompareAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelectCompareAll.Location = new System.Drawing.Point(241, 440);
            this.butSelectCompareAll.Name = "butSelectCompareAll";
            this.butSelectCompareAll.Size = new System.Drawing.Size(75, 42);
            this.butSelectCompareAll.TabIndex = 44;
            this.butSelectCompareAll.Text = "Select All Compare";
            this.butSelectCompareAll.UseVisualStyleBackColor = false;
            this.butSelectCompareAll.Click += new System.EventHandler(this.butSelectCompareAll_Click);
            // 
            // butFieldClear
            // 
            this.butFieldClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butFieldClear.Location = new System.Drawing.Point(525, 15);
            this.butFieldClear.Name = "butFieldClear";
            this.butFieldClear.Size = new System.Drawing.Size(44, 23);
            this.butFieldClear.TabIndex = 40;
            this.butFieldClear.Text = "Clear";
            this.butFieldClear.UseVisualStyleBackColor = true;
            this.butFieldClear.Click += new System.EventHandler(this.butFieldClear_Click);
            // 
            // butClearSelect
            // 
            this.butClearSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butClearSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClearSelect.Location = new System.Drawing.Point(493, 440);
            this.butClearSelect.Name = "butClearSelect";
            this.butClearSelect.Size = new System.Drawing.Size(75, 42);
            this.butClearSelect.TabIndex = 43;
            this.butClearSelect.Text = "Clear Select";
            this.butClearSelect.UseVisualStyleBackColor = false;
            this.butClearSelect.Click += new System.EventHandler(this.butClearSelect_Click);
            // 
            // txtFieldFilter
            // 
            this.txtFieldFilter.Location = new System.Drawing.Point(127, 17);
            this.txtFieldFilter.Name = "txtFieldFilter";
            this.txtFieldFilter.Size = new System.Drawing.Size(392, 20);
            this.txtFieldFilter.TabIndex = 41;
            this.txtFieldFilter.TextChanged += new System.EventHandler(this.txtFieldFilter_TextChanged);
            // 
            // butSelectAll
            // 
            this.butSelectAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelectAll.Location = new System.Drawing.Point(412, 440);
            this.butSelectAll.Name = "butSelectAll";
            this.butSelectAll.Size = new System.Drawing.Size(75, 42);
            this.butSelectAll.TabIndex = 42;
            this.butSelectAll.Text = "Select All Select";
            this.butSelectAll.UseVisualStyleBackColor = false;
            this.butSelectAll.Click += new System.EventHandler(this.butSelectAll_Click);
            // 
            // butGetFields
            // 
            this.butGetFields.Enabled = false;
            this.butGetFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butGetFields.Location = new System.Drawing.Point(226, 452);
            this.butGetFields.Name = "butGetFields";
            this.butGetFields.Size = new System.Drawing.Size(151, 42);
            this.butGetFields.TabIndex = 51;
            this.butGetFields.Text = "Retrieving Entities...";
            this.butGetFields.UseVisualStyleBackColor = true;
            this.butGetFields.Click += new System.EventHandler(this.butGetFields_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Entities";
            // 
            // txtEntityFilter
            // 
            this.txtEntityFilter.Location = new System.Drawing.Point(78, 29);
            this.txtEntityFilter.Name = "txtEntityFilter";
            this.txtEntityFilter.Size = new System.Drawing.Size(249, 20);
            this.txtEntityFilter.TabIndex = 49;
            this.txtEntityFilter.TextChanged += new System.EventHandler(this.txtEntityFilter_TextChanged);
            // 
            // butEntityClear
            // 
            this.butEntityClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butEntityClear.Location = new System.Drawing.Point(333, 27);
            this.butEntityClear.Name = "butEntityClear";
            this.butEntityClear.Size = new System.Drawing.Size(44, 23);
            this.butEntityClear.TabIndex = 48;
            this.butEntityClear.Text = "Clear";
            this.butEntityClear.UseVisualStyleBackColor = true;
            this.butEntityClear.Click += new System.EventHandler(this.butEntityClear_Click);
            // 
            // gridEntities
            // 
            this.gridEntities.AllowUserToAddRows = false;
            this.gridEntities.AllowUserToDeleteRows = false;
            this.gridEntities.AllowUserToResizeColumns = false;
            this.gridEntities.AllowUserToResizeRows = false;
            this.gridEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEntities.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridEntities.Location = new System.Drawing.Point(12, 55);
            this.gridEntities.MultiSelect = false;
            this.gridEntities.Name = "gridEntities";
            this.gridEntities.RowHeadersVisible = false;
            this.gridEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEntities.Size = new System.Drawing.Size(365, 391);
            this.gridEntities.TabIndex = 47;
            this.gridEntities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEntitties_CellClick);
            // 
            // CompareRecords1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 515);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.butGetFields);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEntityFilter);
            this.Controls.Add(this.butEntityClear);
            this.Controls.Add(this.gridEntities);
            this.Name = "CompareRecords1";
            this.Text = "CompareRecords1";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldsToCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button butClearKey;
        private System.Windows.Forms.Button butSelectKeyAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboDirecction;
        private System.Windows.Forms.ComboBox comboOrderBy;
        private System.Windows.Forms.Button butCompare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridView gridFieldsToCheck;
        private System.Windows.Forms.Button butClearCompare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSelectCompareAll;
        private System.Windows.Forms.Button butFieldClear;
        private System.Windows.Forms.Button butClearSelect;
        private System.Windows.Forms.TextBox txtFieldFilter;
        private System.Windows.Forms.Button butSelectAll;
        private System.Windows.Forms.Button butGetFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntityFilter;
        private System.Windows.Forms.Button butEntityClear;
        private System.Windows.Forms.DataGridView gridEntities;
    }
}