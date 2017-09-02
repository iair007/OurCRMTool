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
    public partial class CompareRecords_SelectFieldsToCopy : Form
    {
        public DataTable dtFields = new DataTable();
        Dictionary<string, string> selectList = new Dictionary<string, string>();  //LocigalName, Type
        private BL2Enviroments bl;
        log4net.ILog log;
        string entityName;
        List<Guid> recordsToCreate = new List<Guid>();
        bool from1To2;
        bool isAvtivity;
        Dictionary<Guid, Entity> recordsToUpdate = new Dictionary<Guid, Entity>();   //Entity = is the record that want to copy TO the other environment, Guid is the guis of the record to update

        #region Contructor

        public CompareRecords_SelectFieldsToCopy(BL2Enviroments _bl, bool _From1To2, string _entityName, bool _isAvtivity, DataTable _dtFields, List<Guid> _recordsToCreate, Dictionary<Guid, Entity> _recordsToUpdate, log4net.ILog _log)
        {
            InitializeComponent();
            log = _log;
            bl = _bl;
            lblEntity.Text = lblEntity.Text + " " + _entityName;
            entityName = _entityName;
            isAvtivity = _isAvtivity;
            dtFields = _dtFields;
            setFiledsValidToUpdate();  //will remove fields that cannot be update/created
            recordsToCreate = _recordsToCreate;
            recordsToUpdate = _recordsToUpdate;
            from1To2 = _From1To2;  //set dirrection from enviroment 1 to 2 or the opposite
            SetFieldGrid();
        }

        #endregion

        #region table

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

            gridFieldsToCheck.Columns["CheckSelect"].Width = 50;
            gridFieldsToCheck.Columns["CheckSelect"].HeaderText = "Select";
            gridFieldsToCheck.Columns["CheckSelect"].ReadOnly = false;

            gridFieldsToCheck.Columns["isValidForUpdate"].HeaderText = "is valid for update";
            gridFieldsToCheck.Columns["isValidForUpdate"].ReadOnly = true;
            gridFieldsToCheck.Columns["isValidForUpdate"].Visible = false;

            gridFieldsToCheck.Columns["IsValidForCreate"].HeaderText = "is valid for Create";
            gridFieldsToCheck.Columns["IsValidForCreate"].ReadOnly = true;
            gridFieldsToCheck.Columns["IsValidForCreate"].Visible = false;
        }

        #endregion table

        #region grid

        private void SetFieldGrid()
        {
            if (dtFields.Columns.Contains("CheckRecordKey"))
            {
                dtFields.Columns.Remove("CheckRecordKey");
            }
            if (dtFields.Columns.Contains("CheckCompare"))
            {
                dtFields.Columns.Remove("CheckCompare");
            }
            gridFieldsToCheck.DataSource = dtFields;
            SetGridFieldsProperties();
        }

        private void setFiledsValidToUpdate()
        {
            for (int i = dtFields.Rows.Count - 1; i >= 0; i--)
            {
                DataRow r = dtFields.Rows[i];
                if ((bool)r["isValidForUpdate"] == false)
                {
                    r.Delete();
                }
            }
        }

        #endregion

        private bool ValidateCopyCreate()
        {
            string message = string.Empty;

            message = IsFieldToCopyEntered();

            if (message != string.Empty)
            {
                MessageBox.Show(message);
            }
            return message == string.Empty;
        }

        private string IsFieldToCopyEntered()
        {
            bool isSelectSelected = false;

            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                if (r.Cells["CheckSelect"].Value != null && (bool)r.Cells["CheckSelect"].Value == true)
                {
                    isSelectSelected = true;
                }
                if (isSelectSelected)
                {
                    break;
                }
            }

            if (!isSelectSelected)
            {
                return "Need to select at least one field to Copy";
            }

            return string.Empty;
        }

        private void butRun_Click(object sender, EventArgs e)
        {
            try
            {
                bool closeFormWhenFinish = true;
                string message = string.Empty;
                List<EntityReference> recordsToOpen = new List<EntityReference>();
                if (ValidateCopyCreate())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (recordsToCreate.Count() > 0)
                    {
                        SetSelectList(true);
                        EntityCollection records = bl.GetAllColumnsForRecords(from1To2, entityName, isAvtivity, recordsToCreate, selectList);
                        message += bl.CreateRecordInEnviroment(from1To2, records, entityName, ref closeFormWhenFinish, ref recordsToOpen);
                    }

                    if (recordsToUpdate.Count() > 0)
                    {
                        SetSelectList(false);
                        recordsToUpdate = bl.GetAllRecordsToUpdate(from1To2, entityName, recordsToUpdate, selectList);
                        message += bl.UpdateRecordInEnviroment(from1To2, recordsToUpdate, entityName, selectList, ref closeFormWhenFinish, ref recordsToOpen);
                    }

                    if (recordsToCreate.Count() == 0 && recordsToUpdate.Count() == 0)
                    {
                        message = "No field Selected";
                    }

                    Cursor.Current = Cursors.Default;
                    if (recordsToOpen.Count() > 0)
                    {
                        message += Environment.NewLine + "Do you want to open the records in Target";
                        DialogResult result = MessageBox.Show(message, "Open Records in Target", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            foreach (EntityReference rec in recordsToOpen)
                            {
                                bl.OpenWithArguments(rec.Id.ToString(), rec.LogicalName, !from1To2);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(message);
                    }
                    if (closeFormWhenFinish)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                int indexColumn = ex.Message.IndexOf("Column : ") + 9;
                int indexAfterWordSpace = ex.Message.IndexOf(" ", indexColumn);
                string columnName = ex.Message.Substring(indexColumn, indexAfterWordSpace - indexColumn);
                string title = string.Format("Cannot copy Column {0}", columnName);

                log.Error("CompareRecords_SelectFieldsToCopy.butRun_Click: " + ex.Message);
            }
        }

        /// <summary>
        /// if is creating will set the selectedList only the checked fields that are allowed to create
        /// if is not creating is updating
        /// </summary>
        /// <param name="creating"></param>
        private void SetSelectList(bool creating)
        {
            selectList.Clear();
            foreach (DataGridViewRow r in gridFieldsToCheck.Rows)
            {
                if (((creating == true && (bool)r.Cells["IsValidForCreate"].Value)
                    || (creating == false && (bool)r.Cells["isValidForUpdate"].Value)
                    ) && r.Cells["CheckSelect"].Value != null && (bool)r.Cells["CheckSelect"].Value == true)
                {
                    selectList.Add(r.Cells["LocigalName"].Value.ToString(), r.Cells["Type"].Value.ToString());
                }
            }
        }

        #region Filters

        private void txtFieldFilter_TextChanged(object sender, EventArgs e)
        {
            dtFields.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%' OR [{2}] LIKE '%{3}%'", "DisplayName", txtFieldFilter.Text, "LocigalName", txtFieldFilter.Text);
            txtFieldFilter.Focus();
        }

        private void butFieldClear_Click(object sender, EventArgs e)
        {
            txtFieldFilter.Text = string.Empty;
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


        #endregion Filters

        private void gridFieldsToCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;

            rowClicked.Cells["CheckSelect"].Value = !(bool)rowClicked.Cells["CheckSelect"].Value;
        }
    }
}
