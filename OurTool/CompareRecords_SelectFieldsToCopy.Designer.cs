namespace OurCRMTool
{
    partial class CompareRecords_SelectFieldsToCopy
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
            this.butCompare = new System.Windows.Forms.Button();
            this.gridFieldsToCheck = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.butFieldClear = new System.Windows.Forms.Button();
            this.butClearSelect = new System.Windows.Forms.Button();
            this.txtFieldFilter = new System.Windows.Forms.TextBox();
            this.butSelectAll = new System.Windows.Forms.Button();
            this.lblEntity = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldsToCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lblEntity);
            this.groupBox.Controls.Add(this.butCompare);
            this.groupBox.Controls.Add(this.gridFieldsToCheck);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.butFieldClear);
            this.groupBox.Controls.Add(this.butClearSelect);
            this.groupBox.Controls.Add(this.txtFieldFilter);
            this.groupBox.Controls.Add(this.butSelectAll);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(584, 535);
            this.groupBox.TabIndex = 52;
            this.groupBox.TabStop = false;
            // 
            // butCompare
            // 
            this.butCompare.BackColor = System.Drawing.Color.SeaGreen;
            this.butCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butCompare.Location = new System.Drawing.Point(358, 473);
            this.butCompare.Name = "butCompare";
            this.butCompare.Size = new System.Drawing.Size(211, 58);
            this.butCompare.TabIndex = 56;
            this.butCompare.Text = "Create/Update records";
            this.butCompare.UseVisualStyleBackColor = false;
            this.butCompare.Click += new System.EventHandler(this.butRun_Click);
            // 
            // gridFieldsToCheck
            // 
            this.gridFieldsToCheck.AllowUserToAddRows = false;
            this.gridFieldsToCheck.AllowUserToDeleteRows = false;
            this.gridFieldsToCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldsToCheck.Location = new System.Drawing.Point(6, 72);
            this.gridFieldsToCheck.Name = "gridFieldsToCheck";
            this.gridFieldsToCheck.Size = new System.Drawing.Size(563, 391);
            this.gridFieldsToCheck.TabIndex = 31;
            this.gridFieldsToCheck.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFieldsToCheck_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Fields in Entity";
            // 
            // butFieldClear
            // 
            this.butFieldClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butFieldClear.Location = new System.Drawing.Point(525, 44);
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
            this.butClearSelect.Location = new System.Drawing.Point(92, 475);
            this.butClearSelect.Name = "butClearSelect";
            this.butClearSelect.Size = new System.Drawing.Size(83, 54);
            this.butClearSelect.TabIndex = 43;
            this.butClearSelect.Text = "Clear All";
            this.butClearSelect.UseVisualStyleBackColor = false;
            this.butClearSelect.Click += new System.EventHandler(this.butClearSelect_Click);
            // 
            // txtFieldFilter
            // 
            this.txtFieldFilter.Location = new System.Drawing.Point(127, 46);
            this.txtFieldFilter.Name = "txtFieldFilter";
            this.txtFieldFilter.Size = new System.Drawing.Size(392, 20);
            this.txtFieldFilter.TabIndex = 41;
            this.txtFieldFilter.TextChanged += new System.EventHandler(this.txtFieldFilter_TextChanged);
            // 
            // butSelectAll
            // 
            this.butSelectAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.butSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSelectAll.Location = new System.Drawing.Point(6, 475);
            this.butSelectAll.Name = "butSelectAll";
            this.butSelectAll.Size = new System.Drawing.Size(80, 54);
            this.butSelectAll.TabIndex = 42;
            this.butSelectAll.Text = "Select All";
            this.butSelectAll.UseVisualStyleBackColor = false;
            this.butSelectAll.Click += new System.EventHandler(this.butSelectAll_Click);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblEntity.Location = new System.Drawing.Point(6, 16);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(127, 17);
            this.lblEntity.TabIndex = 57;
            this.lblEntity.Text = "Entity Selected: ";
            // 
            // CompareRecords_SelectFieldsToCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 559);
            this.Controls.Add(this.groupBox);
            this.MaximizeBox = false;
            this.Name = "CompareRecords_SelectFieldsToCopy";
            this.Text = "Select Fields to Copy/Create";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldsToCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button butCompare;
        private System.Windows.Forms.DataGridView gridFieldsToCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butFieldClear;
        private System.Windows.Forms.Button butClearSelect;
        private System.Windows.Forms.TextBox txtFieldFilter;
        private System.Windows.Forms.Button butSelectAll;
        private System.Windows.Forms.Label lblEntity;
    }
}