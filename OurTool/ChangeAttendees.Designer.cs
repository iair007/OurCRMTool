namespace OurCRMTool
{
    partial class ChangeAttendees
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
            this.txtFromFilter = new System.Windows.Forms.TextBox();
            this.butFromClear = new System.Windows.Forms.Button();
            this.gridAttendeesFrom = new System.Windows.Forms.DataGridView();
            this.txtToFilter = new System.Windows.Forms.TextBox();
            this.butToCLear = new System.Windows.Forms.Button();
            this.gridAttendeesTo = new System.Windows.Forms.DataGridView();
            this.cmbAttendeesTypeFrom = new System.Windows.Forms.ComboBox();
            this.cmbAttendeesTypeTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendeesFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendeesTo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFromFilter
            // 
            this.txtFromFilter.Location = new System.Drawing.Point(36, 108);
            this.txtFromFilter.Name = "txtFromFilter";
            this.txtFromFilter.Size = new System.Drawing.Size(258, 20);
            this.txtFromFilter.TabIndex = 24;
            // 
            // butFromClear
            // 
            this.butFromClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butFromClear.Location = new System.Drawing.Point(300, 105);
            this.butFromClear.Name = "butFromClear";
            this.butFromClear.Size = new System.Drawing.Size(44, 23);
            this.butFromClear.TabIndex = 23;
            this.butFromClear.Text = "Clear";
            this.butFromClear.UseVisualStyleBackColor = true;
            // 
            // gridAttendeesFrom
            // 
            this.gridAttendeesFrom.AllowUserToAddRows = false;
            this.gridAttendeesFrom.AllowUserToDeleteRows = false;
            this.gridAttendeesFrom.AllowUserToResizeRows = false;
            this.gridAttendeesFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAttendeesFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridAttendeesFrom.Location = new System.Drawing.Point(36, 134);
            this.gridAttendeesFrom.Name = "gridAttendeesFrom";
            this.gridAttendeesFrom.RowHeadersVisible = false;
            this.gridAttendeesFrom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttendeesFrom.Size = new System.Drawing.Size(308, 425);
            this.gridAttendeesFrom.TabIndex = 22;
            this.gridAttendeesFrom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAttendeesFrom_CellClick);
            // 
            // txtToFilter
            // 
            this.txtToFilter.Location = new System.Drawing.Point(513, 108);
            this.txtToFilter.Name = "txtToFilter";
            this.txtToFilter.Size = new System.Drawing.Size(258, 20);
            this.txtToFilter.TabIndex = 27;
            // 
            // butToCLear
            // 
            this.butToCLear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butToCLear.Location = new System.Drawing.Point(777, 105);
            this.butToCLear.Name = "butToCLear";
            this.butToCLear.Size = new System.Drawing.Size(44, 23);
            this.butToCLear.TabIndex = 26;
            this.butToCLear.Text = "Clear";
            this.butToCLear.UseVisualStyleBackColor = true;
            // 
            // gridAttendeesTo
            // 
            this.gridAttendeesTo.AllowUserToAddRows = false;
            this.gridAttendeesTo.AllowUserToDeleteRows = false;
            this.gridAttendeesTo.AllowUserToResizeRows = false;
            this.gridAttendeesTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAttendeesTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridAttendeesTo.Location = new System.Drawing.Point(513, 134);
            this.gridAttendeesTo.Name = "gridAttendeesTo";
            this.gridAttendeesTo.RowHeadersVisible = false;
            this.gridAttendeesTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttendeesTo.Size = new System.Drawing.Size(307, 425);
            this.gridAttendeesTo.TabIndex = 25;
            this.gridAttendeesTo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAttendeesTo_CellClick);
            // 
            // cmbAttendeesTypeFrom
            // 
            this.cmbAttendeesTypeFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbAttendeesTypeFrom.FormattingEnabled = true;
            this.cmbAttendeesTypeFrom.Location = new System.Drawing.Point(250, 66);
            this.cmbAttendeesTypeFrom.Name = "cmbAttendeesTypeFrom";
            this.cmbAttendeesTypeFrom.Size = new System.Drawing.Size(94, 21);
            this.cmbAttendeesTypeFrom.TabIndex = 28;
            this.cmbAttendeesTypeFrom.SelectedIndexChanged += new System.EventHandler(this.cmbAttendeesTypeFrom_SelectedIndexChanged);
            // 
            // cmbAttendeesTypeTo
            // 
            this.cmbAttendeesTypeTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbAttendeesTypeTo.FormattingEnabled = true;
            this.cmbAttendeesTypeTo.Location = new System.Drawing.Point(700, 66);
            this.cmbAttendeesTypeTo.Name = "cmbAttendeesTypeTo";
            this.cmbAttendeesTypeTo.Size = new System.Drawing.Size(121, 21);
            this.cmbAttendeesTypeTo.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(33, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Type of attendees to change";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(521, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Type of new attendees";
            // 
            // ChangeAttendees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 665);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAttendeesTypeTo);
            this.Controls.Add(this.cmbAttendeesTypeFrom);
            this.Controls.Add(this.txtToFilter);
            this.Controls.Add(this.butToCLear);
            this.Controls.Add(this.gridAttendeesTo);
            this.Controls.Add(this.txtFromFilter);
            this.Controls.Add(this.butFromClear);
            this.Controls.Add(this.gridAttendeesFrom);
            this.Name = "ChangeAttendees";
            this.Text = "ChangeAttendees";
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendeesFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendeesTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFromFilter;
        private System.Windows.Forms.Button butFromClear;
        private System.Windows.Forms.DataGridView gridAttendeesFrom;
        private System.Windows.Forms.TextBox txtToFilter;
        private System.Windows.Forms.Button butToCLear;
        private System.Windows.Forms.DataGridView gridAttendeesTo;
        private System.Windows.Forms.ComboBox cmbAttendeesTypeFrom;
        private System.Windows.Forms.ComboBox cmbAttendeesTypeTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}