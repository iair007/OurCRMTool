using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OurCRMTool
{
    public partial class DefaultTeamsMessageStatus : Form
    {
        public DefaultTeamsMessageStatus(string message)
        {
            InitializeComponent();
            txtMessage.Text = message;
        }
    }
}
