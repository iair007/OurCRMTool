namespace OurCRMTool
{
    partial class ExcelForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.butSaveAs = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.butSaveOpen = new System.Windows.Forms.Button();
            this.butOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // butSaveAs
            // 
            this.butSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSaveAs.Location = new System.Drawing.Point(17, 65);
            this.butSaveAs.Name = "butSaveAs";
            this.butSaveAs.Size = new System.Drawing.Size(82, 26);
            this.butSaveAs.TabIndex = 83;
            this.butSaveAs.Text = "Save As";
            this.butSaveAs.UseVisualStyleBackColor = true;
            this.butSaveAs.Click += new System.EventHandler(this.butSaveAs_Click);
            // 
            // butSaveOpen
            // 
            this.butSaveOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSaveOpen.Location = new System.Drawing.Point(120, 65);
            this.butSaveOpen.Name = "butSaveOpen";
            this.butSaveOpen.Size = new System.Drawing.Size(114, 26);
            this.butSaveOpen.TabIndex = 84;
            this.butSaveOpen.Text = "Save and Open";
            this.butSaveOpen.UseVisualStyleBackColor = true;
            this.butSaveOpen.Click += new System.EventHandler(this.butSaveOpen_Click);
            // 
            // butOpen
            // 
            this.butOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butOpen.Location = new System.Drawing.Point(251, 65);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(114, 26);
            this.butOpen.TabIndex = 85;
            this.butOpen.Text = "Open";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 17);
            this.label1.TabIndex = 86;
            this.label1.Text = "Select how you want to create the excel";
            // 
            // ExcerlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 103);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.butSaveOpen);
            this.Controls.Add(this.butSaveAs);
            this.Name = "ExcerlForm";
            this.Text = "Create Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button butSaveOpen;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Label label1;
    }
}