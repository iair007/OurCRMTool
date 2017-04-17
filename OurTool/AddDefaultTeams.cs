using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;

namespace OurCRMTool
{
    public partial class AddDefaultTeams : Form
    {
        private BL bl;
        string CvsPath;
        EntityCollection teamsInCsvColl;

        public AddDefaultTeams(BL _bl, EntityCollection _teamsInCsvColl, string _csvPath)
        {
            InitializeComponent();
            bl = _bl;
            this.Text = "AddDefaultTeams - Connected to: " + bl.url;
            CvsPath = _csvPath;
            teamsInCsvColl = _teamsInCsvColl;
            SetTeams();
        }

        private void SetTeams()
        {
            try
            {
                gridTeams.Rows.Clear();
                EntityCollection businessUnits = bl.GetBusinessUnit();

                EntityCollection allTeams = bl.GetTeams(businessUnits.Entities.Select(a => a.Id).ToList<Guid>());
                foreach (Entity t in allTeams.Entities)
                {
                    bool isDefault = false;
                    foreach (Entity defaultTeam in teamsInCsvColl.Entities)
                    {
                        if (t.Id == defaultTeam.Id)
                        {
                            isDefault = true;
                            break;
                        }
                    }
                    gridTeams.Rows.Add(isDefault, t.Attributes["name"], t.Id);
                }
            }
            catch (Exception ex)
            {

            }
        }


        #region Events

        private void butTeamSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = true;
            }
        }

        private void butTeamInvert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = !(bool)gridTeams.Rows[i].Cells["TeamCheck"].Value;
            }
        }

        private void butTeamClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridTeams.Rows.Count; i++)
            {
                gridTeams.Rows[i].Cells["TeamCheck"].Value = false;
            }
        }

        private void gridTeams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewCell cellClicked = senderGridView.CurrentCell;
            if (senderGridView.CurrentRow != null)
            {
                senderGridView.CurrentRow.Cells["TeamCheck"].Value = !(bool)senderGridView.CurrentRow.Cells["TeamCheck"].Value;
            }
        }

        #endregion

        private void butUndo_Click(object sender, EventArgs e)
        {
            SetTeams();
        }

        private void butUpdate_Click_1(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("This action will update the file \"DefaultTeams.csv\", do you want to continue?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                using (CsvFileWriter writer = new CsvFileWriter(CvsPath))
                {
                    
                    //row.Add(string.Format("{0}", "Team Name"));
                    //writer.WriteRow(row);
                    foreach (DataGridViewRow r in gridTeams.Rows)
                    {
                        CsvRow row = new CsvRow();
                        if ((bool)r.Cells["TeamCheck"].Value == true)
                        {
                                row.Add(string.Format("{0}", r.Cells["TeamName"].Value));
                                writer.WriteRow(row);
                        }
                    }
                }
                this.Close();
            }
        }

        private void gridTeams_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewCell cellClicked = senderGridView.CurrentCell;
            if (senderGridView.CurrentRow != null)
            {
                senderGridView.CurrentRow.Cells["TeamCheck"].Value = !(bool)senderGridView.CurrentRow.Cells["TeamCheck"].Value;
            }
        }
    }
}
