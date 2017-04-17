namespace OurCRMTool
{
    partial class Error
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
            this.butOpenLog = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butOpenLog
            // 
            this.butOpenLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butOpenLog.Location = new System.Drawing.Point(402, 234);
            this.butOpenLog.Name = "butOpenLog";
            this.butOpenLog.Size = new System.Drawing.Size(75, 23);
            this.butOpenLog.TabIndex = 9;
            this.butOpenLog.Text = "Open Log";
            this.butOpenLog.UseVisualStyleBackColor = true;
            this.butOpenLog.Click += new System.EventHandler(this.butOpenLog_Click);
            // 
            // butClose
            // 
            this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butClose.Location = new System.Drawing.Point(483, 234);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 10;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(12, 12);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(543, 216);
            this.txtError.TabIndex = 11;
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 261);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butOpenLog);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Error";
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOpenLog;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.TextBox txtError;
    }
}