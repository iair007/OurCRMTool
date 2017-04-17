using Microsoft.Xrm.Sdk;
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
    public partial class ChangeAttendees : Form
    {
        private BL bl;

        public ChangeAttendees(BL _bl)
        {
            InitializeComponent();
            bl = _bl;
            SetCombosItems();
        }

        private void gridAttendeesFrom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
            }
        }

        private void gridAttendeesTo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
            }
        }


        /// <summary>
        /// If the row was already selected, will make it false, if it was not, will make sure is the only row selected
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        private void MakeOnlyOneSelection(DataGridView grid, DataGridViewRow row)
        {
            if ((bool)row.Cells[0].Value == true)
            {
                row.Cells[0].Value = false;
            }
            else
            {
                foreach (DataGridViewRow r in grid.Rows)
                {
                    if (r.Equals(row))
                    {
                        r.Cells[0].Value = true;
                    }
                    else
                    {
                        r.Cells[0].Value = false;
                    }
                }
            }
        }

        private void cmbAttendeesTypeFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetCombosItems()
        {
            cmbAttendeesTypeFrom.Items.Add("User");
            cmbAttendeesTypeFrom.Items.Add("Contact");
            cmbAttendeesTypeFrom.Items.Add("Account");
            cmbAttendeesTypeFrom.Items.Add("Lead");

            cmbAttendeesTypeTo.Items.Add("User");
            cmbAttendeesTypeTo.Items.Add("Contact");
            cmbAttendeesTypeTo.Items.Add("Account");
            cmbAttendeesTypeTo.Items.Add("Lead");
        }

        private void SetGrid(DataGridView grid, int typeOfAtteendes) {

            EntityCollection records = new EntityCollection();

            switch (typeOfAtteendes) { 
                case 0:  //users
                    records = bl.GetAllUsers();
                    break;
                case 1:  //contact
                    records = bl.GetAllContacts();
                    break;
                case 2:  //account
                    records = bl.GetAllAccounts();
                    break;
                case 3:  //lead
                    records = bl.GetAllLeads();
                    break;
            
            }
        }
    }
}
