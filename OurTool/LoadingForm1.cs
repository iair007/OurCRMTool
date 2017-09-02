using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurCRMTool
{
    public partial class LoadingForm1 : Form
    {
        public LoadingForm1(string message)
        {
            InitializeComponent();
            label1.Text = message;
            this.Text = message;
            setPicture();

        }

        private void setPicture()
        {
            BL bl = new BL();
            Random rand = new Random(DateTime.UtcNow.Millisecond);
            int i = rand.Next(1, 7);
            string pictureName = string.Concat("loading", i, ".gif");
            Image image = bl.GetImage(pictureName);
            if (image != null)
            {
                pictureBox1.Image = image;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
