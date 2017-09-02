using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OurCRMTool
{
    public partial class Error : Form
    {
        string logPath;
        public Error(string message, string m_LogFileName, string title = null)
        {
            InitializeComponent();
            logPath = m_LogFileName;
            txtError.Text = message;
            if (title != null)
            {
                this.Text = title;
            }
        }

        private void butOpenLog_Click(object sender, EventArgs e)
        {
            if (logPath != null && logPath != string.Empty)
            {
                System.Diagnostics.Process.Start(logPath);
            }
            else
            {
                MessageBox.Show("Log doesn't not exist");
            }

        }
    }
}
