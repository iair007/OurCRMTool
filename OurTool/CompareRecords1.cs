using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
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
    public partial class CompareRecords1 : Form
    {
        BackgroundWorker worker = new BackgroundWorker();
        DataTable dtEntities = new DataTable();
        public DataTable dtFields = new DataTable();
        private RetrieveAllEntitiesResponse response;
        Dictionary<string, string> recordKeyList = new Dictionary<string, string>();   //key to set what are the records to compare with
        Dictionary<string, string> compareList = new Dictionary<string, string>();  //attribute name, attribute type
        Dictionary<string, string> selectList = new Dictionary<string, string>();
        private BL2Enviroments bl;
        log4net.ILog log;
        string primatyField;

        #region Contructor

        public CompareRecords1(IOrganizationService service1, IOrganizationService service2, string _url1, string _url2, log4net.ILog _log)
        {
            InitializeComponent();
            log = _log;
            bl = new BL2Enviroments(service1, service2, _url1, _url2);

            CreatedtdtEntitiesColumns();
            CreatedtdtFieldsColumns();
            txtEntityFilter.Select();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();
        }

        #endregion

        #region Workers

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            butGetFields.Enabled = false;

            string message = SetEntityGrid();
            e.Result = message;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() != string.Empty)
            {
                MessageBox.Show(e.Result.ToString());
                butGetFields.Text = "Error getting Entity list";
            }
            else
            {
                gridEntities.DataSource = dtEntities;
                SetGridEntitiesProperties();
                butGetFields.Text = "Get Entity's fields";
            }
        }

        #endregion

        #region table

        private void CreatedtdtEntitiesColumns()
        {
            dtEntities.Columns.Add("Check", typeof(bool));
            dtEntities.Columns.Add("EntityName", typeof(string));
            dtEntities.Columns.Add("ObjectTypeCode", typeof(string));
            dtEntities.Columns.Add("EntityLogicalName", typeof(string));
        }

        private void SetGridEntitiesProperties()
        {
            //set Columns properties
            gridEntities.Columns["Check"].Width = 50;
            gridEntities.Columns["Check"].HeaderText = "";
            gridEntities.Columns["Check"].ReadOnly = false;

            gridEntities.Columns["EntityName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridEntities.Columns["EntityName"].HeaderText = "Entity Display Name";
            gridEntities.Columns["EntityName"].ReadOnly = true;

            gridEntities.Columns["ObjectTypeCode"].Width = 100;
            gridEntities.Columns["ObjectTypeCode"].HeaderText = "Object Type Code";
            gridEntities.Columns["ObjectTypeCode"].ReadOnly = true;

            gridEntities.Columns["EntityLogicalName"].Width = 100;
            gridEntities.Columns["EntityLogicalName"].HeaderText = "Logical Name";
            gridEntities.Columns["EntityLogicalName"].ReadOnly = true;
            gridEntities.Columns["EntityLogicalName"].Visible = false;

            gridEntities.Sort(gridEntities.Columns["EntityName"], ListSortDirection.Ascending);
        }

        private void CreatedtdtFieldsColumns()
        {
            dtFields.Columns.Add("Type", typeof(string));
            dtFields.Columns.Add("LocigalName", typeof(string));
            dtFields.Columns.Add("DisplayName", typeof(string));
            dtFields.Columns.Add("CheckRecordKey", typeof(bool));
            dtFields.Columns.Add("CheckCompare", typeof(bool));
            dtFields.Columns.Add("CheckSelect", typeof(bool));
        }

        private void SetGridFieldsProperties()
        {
            //set Columns properties
            gridFieldsToCheck.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridFieldsToCheck.Columns["Type"].HeaderText = "Type";
            gridFieldsToCheck.Columns["Type"].ReadOnly = true;
            gridFieldsToCheck.Columns["Type"].Visible = false;

            gridFieldsToCheck.Columns["LocigalName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridFieldsToCheck.Columns["LocigalName"].HeaderText = "Logical Name";
            gridFieldsToCheck.Columns["LocigalName"].ReadOnly = true;

            gridFieldsToCheck.Columns["DisplayName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridFieldsToCheck.Columns["DisplayName"].HeaderText = "Display Name";
            gridFieldsToCheck.Columns["DisplayName"].ReadOnly = true;

            gridFieldsToCheck.Columns["CheckRecordKey"].Width = 50;
            gridFieldsToCheck.Columns["CheckRecordKey"].HeaderText = "Key";
            gridFieldsToCheck.Columns["CheckRecordKey"].ReadOnly = false;

            gridFieldsToCheck.Columns["CheckCompare"].Width = 50;
            gridFieldsToCheck.Columns["CheckCompare"].HeaderText = "Compare";
            gridFieldsToCheck.Columns["CheckCompare"].ReadOnly = false;

            gridFieldsToCheck.Columns["CheckSelect"].Width = 50;
            gridFieldsToCheck.Columns["CheckSelect"].HeaderText = "Select";
            gridFieldsToCheck.Columns["CheckSelect"].ReadOnly = false;
        }

        #endregion table

        #region grid

        private string SetEntityGrid()
        {
            try
            {
                dtEntities.Rows.Clear();
                if (response == null)
                {
                    response = bl.GetEntities();
                }

                foreach (EntityMetadata currentEntity in response.EntityMetadata)
                {
                    if (currentEntity.DisplayName != null && currentEntity.DisplayName.UserLocalizedLabel != null)
                    {
                        dtEntities.Rows.Add(false, currentEntity.DisplayName.UserLocalizedLabel.Label, (int)currentEntity.ObjectTypeCode, currentEntity.LogicalName);
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void SetFieldGrid(string entityName)
        {
            dtFields.Clear();

            RetrieveEntityResponse EntityFields = bl.GetEntityFields(entityName);

            foreach (AttributeMetadata a in EntityFields.EntityMetadata.Attributes)
            {
                if (a.DisplayName != null && a.DisplayName.LocalizedLabels.Count > 0)
                {
                    dtFields.Rows.Add(a.AttributeType, a.LogicalName, a.DisplayName.UserLocalizedLabel.Label, false, false, false);
                    if (a.IsPrimaryName == true)
                    {
                        primatyField = a.LogicalName;
                    }
                }
            }

            gridFieldsToCheck.DataSource = dtFields;
            SetGridFieldsProperties();

            gridFieldsToCheck.CurrentCellDirtyStateChanged += new EventHandler(gridFieldsToCheck_CurrentCellDirtyStateChanged);

        }

        private void gridFieldsToCheck_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridFieldsToCheck.CurrentCell is DataGridViewCheckBoxCell)
                gridFieldsToCheck.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        #endregion

        private void SetComboOrderBy()
        {
            comboOrderBy.SelectedIndex = -1;
            comboOrderBy.Items.Clear();
            foreach (DataRow r in dtFields.Rows)
            {
                comboOrderBy.Items.Add(r["LocigalName"].ToString());
            }
            comboOrderBy.Sorted = true;
            comboOrderBy.SelectedIndex = comboOrderBy.Items.IndexOf(primatyField);
        }

        private void SetComboDirecction()
        {
            comboDirecction.Items.Clear();
            comboDirecction.Items.Add("Ascending");
            comboDirecction.Items.Add("Descending");
            comboDirecction.SelectedIndex = 0;
        }

        private void butGetFields_Click(object sender, EventArgs e)
        {
            string entityName = GetEntitySelected();
            if (entityName != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                groupBox.Enabled = true;
                SetFieldGrid(entityName);
                SetComboOrderBy();
                SetComboDirecction();
                txtFieldFilter.Select();
            }
            else
            {
                MessageBox.Show("No Entity selected");
            }
            this.Cursor = Cursors.Default;
        }

        private void gridEntitties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
            }
            dtFields.Clear();
            comboOrderBy.Items.Clear();
            groupBox.Enabled = false;
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
                butGetFields.Enabled = false;
                butGetFields.BackColor = Color.Gray;
            }
            else
            {
                butGetFields.Enabled = true;
                butGetFields.BackColor = Color.YellowGreen;
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

        private bool ValidateCompareButton()
        {
            string message = string.Empty;

            if (GetEntitySelected() == string.Empty)
            {
                message = "Entity no selected";
            }
            message = IsFieldToCheckEntered();

            if (message == string.Empty && comboOrderBy.SelectedIndex == -1)
            {
                message = "Need to select and value for OrderBy";
            }

            else if (message == string.Empty && !chkAll.Checked && (txtTop.Text == string.Empty))
            {
                message = "Missing value in \"Top\" field";
            }

            if (message != string.Empty)
            {
                MessageBox.Show(message);
            }
            return message == string.Empty;
        }

        private string GetEntitySelected()
        {
            string entitySelected = string.Empty;
            foreach (DataGridViewRow r in gridEntities.Rows)
            {
                if ((bool)r.Cells["Check"].Value == true)
                {
                    entitySelected = r.Cells["EntityLogicalName"].Value.ToString();
                    break;
                }
            }

            return entitySelected;
        }

        private string IsFieldToCheckEntered()
        {
            bool isComapreSelected = false;
            bool isSelectSelected = false;
            bool isKeySelected = false;

            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                if (r.Cells["CheckRecordKey"].Value != null && (bool)r.Cells["CheckRecordKey"].Value == true)
                {
                    isKeySelected = true;
                }
                if (r.Cells["CheckCompare"].Value != null && (bool)r.Cells["CheckCompare"].Value == true)
                {
                    isComapreSelected = true;
                }
                if (r.Cells["CheckSelect"].Value != null && (bool)r.Cells["CheckSelect"].Value == true)
                {
                    isSelectSelected = true;
                }
                if (isComapreSelected && isSelectSelected && isKeySelected)
                {
                    break;
                }
            }

            if (!isKeySelected)
            {
                return "Need to select at least one field as a record Key";
            }
            if (!isComapreSelected)
            {
                return "Need to select at least one field to compare";
            }
            else if (!isSelectSelected)
            {
                return "Need to select at least one field to show in the result";
            }

            return string.Empty;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                txtTop.Enabled = false;
                txtTop.Text = string.Empty;
            }
            else
            {
                txtTop.Enabled = true;
            }
        }

        private void butCompare_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCompareButton())
                {
                    SetCompareAndSelectList();
                    OrderType direcction = comboDirecction.SelectedIndex == 0 ? OrderType.Ascending : OrderType.Descending;
                    CompareRecords2 comapreForm = new CompareRecords2(bl, log, GetEntitySelected(), dtFields, compareList, selectList, recordKeyList, comboOrderBy.SelectedItem.ToString(), direcction, txtTop.Text);
                    comapreForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("CompareRecords1.butRun_Click: " + ex.Message);
            }
        }

        private void SetCompareAndSelectList()
        {
            compareList.Clear();
            selectList.Clear();
            recordKeyList.Clear();
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                if (r.Cells["CheckCompare"].Value != null && (bool)r.Cells["CheckCompare"].Value == true)
                {
                    compareList.Add(r.Cells["LocigalName"].Value.ToString(), r.Cells["Type"].Value.ToString());
                }
                if (r.Cells["CheckSelect"].Value != null && (bool)r.Cells["CheckSelect"].Value == true)
                {
                    selectList.Add(r.Cells["LocigalName"].Value.ToString(), r.Cells["Type"].Value.ToString());
                }
                if (r.Cells["CheckRecordKey"].Value != null && (bool)r.Cells["CheckRecordKey"].Value == true)
                {
                    recordKeyList.Add(r.Cells["LocigalName"].Value.ToString(), r.Cells["Type"].Value.ToString());
                }
            }
        }

        #region Filters

        private void txtFieldFilter_TextChanged(object sender, EventArgs e)
        {
            dtFields.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%' OR [{2}] LIKE '%{3}%'", "DisplayName", txtFieldFilter.Text, "LocigalName", txtFieldFilter.Text);
            txtFieldFilter.Focus();
        }

        private void txtEntityFilter_TextChanged(object sender, EventArgs e)
        {
            dtEntities.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "EntityName", txtEntityFilter.Text);
            txtEntityFilter.Focus();
        }

        private void butFieldClear_Click(object sender, EventArgs e)
        {
            txtFieldFilter.Text = string.Empty;
        }

        private void butEntityClear_Click(object sender, EventArgs e)
        {
            txtEntityFilter.Text = string.Empty;
        }

        private void butSelectCompareAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                r.Cells["CheckCompare"].Value = true;
            }
        }

        private void butClearCompare_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                r.Cells["CheckCompare"].Value = false;
            }
        }

        private void butSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                r.Cells["CheckSelect"].Value = true;
            }
        }

        private void butClearSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                r.Cells["CheckSelect"].Value = false;
            }
        }

        private void butSelectKeyAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                r.Cells["CheckRecordKey"].Value = true;
            }
        }

        private void butClearKey_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                r.Cells["CheckRecordKey"].Value = false;
            }
        }

        #endregion Filters

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "^[0-9]+$"))
            {
                e.Handled = true;

            }
        }

        private void gridFieldsToCheck_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewCell cellClicked = senderGridView.CurrentCell;
            DataGridViewRow rowClicked = senderGridView.CurrentRow;

            if (cellClicked != null && rowClicked != null)
            {
                if (senderGridView.Columns[senderGridView.CurrentCell.ColumnIndex].Name == "CheckCompare" || senderGridView.Columns[senderGridView.CurrentCell.ColumnIndex].Name == "CheckRecordKey")
                {
                    if ((bool)rowClicked.Cells["CheckCompare"].Value == true || (bool)rowClicked.Cells["CheckRecordKey"].Value == true)
                    {
                        rowClicked.Cells["CheckSelect"].Value = true;
                    }
                }
            }
        }
    }
}
