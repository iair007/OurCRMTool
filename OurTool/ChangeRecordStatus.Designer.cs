namespace OurCRMTool
{
    partial class ChangeRecordStatus
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
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.txtStatusCode = new System.Windows.Forms.TextBox();
            this.txtStateCode = new System.Windows.Forms.TextBox();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.gridGuids = new System.Windows.Forms.DataGridView();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboEntities = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboStateCode = new System.Windows.Forms.ComboBox();
            this.comboStatusCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridGuids)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "EntityName";
            // 
            // txtGuid
            // 
            this.txtGuid.Location = new System.Drawing.Point(108, 290);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(313, 20);
            this.txtGuid.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(7, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "RecordId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(4, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "State Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(4, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Status Code";
            // 
            // txtEntityName
            // 
            this.txtEntityName.Location = new System.Drawing.Point(108, 50);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(357, 20);
            this.txtEntityName.TabIndex = 33;
            // 
            // txtStatusCode
            // 
            this.txtStatusCode.Location = new System.Drawing.Point(108, 214);
            this.txtStatusCode.Name = "txtStatusCode";
            this.txtStatusCode.Size = new System.Drawing.Size(144, 20);
            this.txtStatusCode.TabIndex = 34;
            // 
            // txtStateCode
            // 
            this.txtStateCode.Location = new System.Drawing.Point(108, 151);
            this.txtStateCode.Name = "txtStateCode";
            this.txtStateCode.Size = new System.Drawing.Size(144, 20);
            this.txtStateCode.TabIndex = 35;
            // 
            // butUpdate
            // 
            this.butUpdate.BackColor = System.Drawing.Color.SeaGreen;
            this.butUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUpdate.Location = new System.Drawing.Point(687, 334);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(123, 33);
            this.butUpdate.TabIndex = 36;
            this.butUpdate.Text = "Update";
            this.butUpdate.UseVisualStyleBackColor = false;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(427, 288);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(38, 23);
            this.butAdd.TabIndex = 38;
            this.butAdd.Text = ">>";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // gridGuids
            // 
            this.gridGuids.AllowUserToAddRows = false;
            this.gridGuids.AllowUserToDeleteRows = false;
            this.gridGuids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGuids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1});
            this.gridGuids.Location = new System.Drawing.Point(479, 12);
            this.gridGuids.Name = "gridGuids";
            this.gridGuids.ReadOnly = true;
            this.gridGuids.Size = new System.Drawing.Size(331, 308);
            this.gridGuids.TabIndex = 37;
            this.gridGuids.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridGuids_KeyUp);
            // 
            // column1
            // 
            this.column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column1.HeaderText = "Guid";
            this.column1.Name = "column1";
            this.column1.ReadOnly = true;
            // 
            // comboEntities
            // 
            this.comboEntities.FormattingEnabled = true;
            this.comboEntities.Location = new System.Drawing.Point(108, 9);
            this.comboEntities.Name = "comboEntities";
            this.comboEntities.Size = new System.Drawing.Size(357, 21);
            this.comboEntities.TabIndex = 44;
            this.comboEntities.Text = "Getting Entities...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(7, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "LogicalName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(34, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "OR";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(108, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 29);
            this.button1.TabIndex = 47;
            this.button1.Text = "Get State/Status Code ↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboStateCode
            // 
            this.comboStateCode.Enabled = false;
            this.comboStateCode.FormattingEnabled = true;
            this.comboStateCode.Location = new System.Drawing.Point(108, 124);
            this.comboStateCode.Name = "comboStateCode";
            this.comboStateCode.Size = new System.Drawing.Size(144, 21);
            this.comboStateCode.TabIndex = 48;
            // 
            // comboStatusCode
            // 
            this.comboStatusCode.Enabled = false;
            this.comboStatusCode.FormattingEnabled = true;
            this.comboStatusCode.Location = new System.Drawing.Point(108, 187);
            this.comboStatusCode.Name = "comboStatusCode";
            this.comboStatusCode.Size = new System.Drawing.Size(144, 21);
            this.comboStatusCode.TabIndex = 49;
            // 
            // ChangeRecordStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 379);
            this.Controls.Add(this.comboStatusCode);
            this.Controls.Add(this.comboStateCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboEntities);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.gridGuids);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.txtStateCode);
            this.Controls.Add(this.txtStatusCode);
            this.Controls.Add(this.txtEntityName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGuid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChangeRecordStatus";
            this.Text = "Check Default Team";
            ((System.ComponentModel.ISupportInitialize)(this.gridGuids)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEntityName;
        private System.Windows.Forms.TextBox txtStatusCode;
        private System.Windows.Forms.TextBox txtStateCode;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DataGridView gridGuids;
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;
        private System.Windows.Forms.ComboBox comboEntities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboStateCode;
        private System.Windows.Forms.ComboBox comboStatusCode;
    }
}