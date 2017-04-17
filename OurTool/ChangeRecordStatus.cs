using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using System.IO;
using System.Diagnostics;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace OurCRMTool
{
    public partial class ChangeRecordStatus : Form
    {
        private BL bl;
        RetrieveAllEntitiesResponse entityMetadata = null;
        Dictionary<string, string> entities = new Dictionary<string, string>();
        BackgroundWorker worker = new BackgroundWorker();

        public ChangeRecordStatus(BL _bl)
        {
            InitializeComponent();
            bl = _bl;
            comboEntities.Enabled = false;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();
        }

        #region Worker

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string message = GetEntitiesNames();
            e.Result = message;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() != string.Empty)
            {
                MessageBox.Show(e.Result.ToString());
            }
            else
            {
                entities.OrderBy(x => x.Value);
                comboEntities.DataSource = new BindingSource(entities, null);
                comboEntities.DisplayMember = "Value";
                comboEntities.ValueMember = "Key";
                comboEntities.Enabled = true;
            }
        }
        #endregion
        private void butAdd_Click(object sender, EventArgs e)
        {
            Guid validGuid;

            if (Guid.TryParse(txtGuid.Text, out validGuid))
            {
                gridGuids.Rows.Add(validGuid);
                txtGuid.Text = string.Empty;
            }
        }

        private void gridGuids_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell c in (sender as DataGridView).SelectedCells)
                {
                    int index = c.RowIndex;
                    gridGuids.Rows.Remove(gridGuids.Rows[index]);
                }
            }
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            int stateCode;
            bool hasStatecode = false;
            int statusCode;
            bool hasStatusCode = false;
            hasStatecode = int.TryParse(txtStateCode.Text, out stateCode);

            if (!hasStatecode)
            {
                if (comboStateCode.SelectedValue == null)
                {
                    MessageBox.Show("State Code not selected");
                    return;
                }
                else {
                    stateCode = (int)comboStateCode.SelectedValue;
                }
            }

            hasStatusCode= int.TryParse(txtStatusCode.Text, out statusCode);
            if (!hasStatusCode)
            {
                if (comboStatusCode.SelectedValue == null)
                {
                    MessageBox.Show("Status Code not selected");
                    return;
                }
                else {
                    statusCode = (int)comboStatusCode.SelectedItem;
                }
            }
            string selectedEntity = txtEntityName.Text.Trim() != string.Empty ? txtEntityName.Text : comboEntities.SelectedValue.ToString();

            if (gridGuids.Rows.Count == 0) {
                MessageBox.Show("Need to add at least one GUID");
                return;
            }
            foreach (DataGridViewRow r in gridGuids.Rows)
            {
                bl.ChangeRecordState(txtEntityName.Text, (Guid)r.Cells[0].Value, stateCode, statusCode);
            }

            //      MessageBox.Show("finished");
            gridGuids.Rows.Clear();
        }

        private string GetEntitiesNames()
        {
            try
            {
                if (entities.Count() == 0)
                {
                    entityMetadata = bl.GetEntities();

                    foreach (EntityMetadata currentEntity in entityMetadata.EntityMetadata)
                    {
                        if (currentEntity.DisplayName != null && currentEntity.DisplayName.UserLocalizedLabel != null)
                        {
                            entities.Add(currentEntity.LogicalName, currentEntity.DisplayName.UserLocalizedLabel.Label);
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void SetStateCodeCombo()
        {
            Dictionary<int, string> stateCodeDic = new Dictionary<int, string>();
            string selectedEntity = txtEntityName.Text.Trim() != string.Empty ? txtEntityName.Text : comboEntities.SelectedValue.ToString();

            RetrieveAttributeResponse responce = bl.GetAttributeMetadata(selectedEntity, "statecode");

            StateAttributeMetadata picklistAttributeMetadata = (StateAttributeMetadata)responce.AttributeMetadata;

            OptionSetMetadata optionsetMetadata = picklistAttributeMetadata.OptionSet;

            foreach (OptionMetadata optionMetadata in optionsetMetadata.Options)
            {
                stateCodeDic.Add(optionMetadata.Value.Value, optionMetadata.Label.UserLocalizedLabel.Label);
            }

            comboStateCode.DataSource = new BindingSource(stateCodeDic, null);
            comboStateCode.DisplayMember = "Value";
            comboStateCode.ValueMember = "Key";
            comboStateCode.Enabled = true;
        }

        private void SetStatusCodeCombo()
        {
            Dictionary<int, string> statusCodeDic = new Dictionary<int, string>();
            string selectedEntity = txtEntityName.Text.Trim() != string.Empty ? txtEntityName.Text : comboEntities.SelectedValue.ToString();

            RetrieveAttributeResponse responce = bl.GetAttributeMetadata(selectedEntity, "statuscode");

            StatusAttributeMetadata picklistAttributeMetadata = (StatusAttributeMetadata)responce.AttributeMetadata;

            OptionSetMetadata optionsetMetadata = picklistAttributeMetadata.OptionSet;

            foreach (OptionMetadata optionMetadata in optionsetMetadata.Options)
            {
                statusCodeDic.Add(optionMetadata.Value.Value, optionMetadata.Label.UserLocalizedLabel.Label);
            }

            comboStatusCode.DataSource = new BindingSource(statusCodeDic, null);
            comboStatusCode.DisplayMember = "Value";
            comboStatusCode.ValueMember = "Key";
            comboStatusCode.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetStateCodeCombo();
            SetStatusCodeCombo();
        }
    }
}
