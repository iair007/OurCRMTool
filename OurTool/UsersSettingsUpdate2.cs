using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;

namespace OurCRMTool
{
    public partial class UsersSettingsUpdate2 : Form
    {
        private BL bl;
        private LogUtils log;
        private EntityCollection systemCurrencies;
        private int[] languagesColl;
        private EntityCollection timeZoneCol;
        private DataTable dtUsers = new DataTable();
        Dictionary<int, string> _languagesDic = new Dictionary<int, string>();
        string orgDateSeparator = "/";
        string orgCurrencySymbol = "$";
        string orgTimeSeparator = ":";
        string orgDecimalSymbol = ".";
        string orgNumberSeparator = ",";
        string orgNumberGroupFormat = "3";

        Dictionary<string, string> groupingOptions = new Dictionary<string, string>();
        private Dictionary<int, string> LanguageDic
        {
            get
            {
                if (_languagesDic == null)
                {
                    SetLanguageDictionary();
                }
                return _languagesDic;
            }
        }

        #region Constructor
        public UsersSettingsUpdate2(BL _bl)
        {
            InitializeComponent();
            bl = _bl;
            this.Text = "Users Settings Update - Connected to: " + bl.url;
            Entity organizationSettings = bl.GetOrganizationSettings();
            SetLanguageDictionary();
            GetDashBoards();
            SetStartEndCombosItems();
            SetShortDateFormatCombosItems();
            SetLongDateFormatCombosItems();
            SetDateSeparatorCombosItems();
            SetTimeFormatCombosItems();
            SetTimeSeparatorCombosItems();
            if (organizationSettings != null)
            {
                orgDateSeparator = organizationSettings.GetAttributeValue<string>("dateseparator");
                orgCurrencySymbol = organizationSettings.GetAttributeValue<string>("currencysymbol");
                orgTimeSeparator = organizationSettings.GetAttributeValue<string>("timeseparator");
                orgDecimalSymbol = organizationSettings.GetAttributeValue<string>("decimalsymbol");
                orgNumberSeparator = organizationSettings.GetAttributeValue<string>("numberseparator");
                orgNumberGroupFormat = organizationSettings.GetAttributeValue<string>("numbergroupformat");
            }
            groupingOptions.Add("0", "‪123456789" + orgDecimalSymbol + "00‬");
            groupingOptions.Add("3", "123" + orgNumberSeparator + "456" + orgNumberSeparator + "789" + orgDecimalSymbol + "00");
            groupingOptions.Add("3,2", "12" + orgNumberSeparator + "34" + orgNumberSeparator + "56" + orgNumberSeparator + "789" + orgDecimalSymbol + "00‬");
            groupingOptions.Add("3,0", "‪123456" + orgNumberSeparator + "789" + orgDecimalSymbol + "00‬");
            groupingOptions.Add("3,2,0", "‪1234" + orgNumberSeparator + "56" + orgNumberSeparator + "789" + orgDecimalSymbol + "00‬");
            groupingOptions.Add("3,3,0", "‪123" + orgNumberSeparator + "456" + orgNumberSeparator + "789" + orgDecimalSymbol + "00‬");

            SetCurrencyFormatCombosItems();
            SetNegativeCurFormatCombosItems();
            SetNegativeFormatCombosItems();
            SetDigitGroupCombosItems();
            SetDecimalSymbolCombosItems();
            SetGroupingSymbolCombosItems();
        }

        private void CreatedtUsersColumns()
        {
            dtUsers.Columns.Add("UserCheck", typeof(bool));
            dtUsers.Columns.Add("UserName", typeof(string));
            dtUsers.Columns.Add("UserId", typeof(string));

            dtUsers.PrimaryKey = new DataColumn[] { dtUsers.Columns["UserId"] };
        }
        #endregion

        #region Dashboard

        private void butGetDB_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GetDashBoards();
            Cursor.Current = Cursors.Default;
            gridDashboards.Focus();
        }

        private void GetDashBoards()
        {
            try
            {
                gridDashboards.Rows.Clear();

                //get the User's form
                EntityCollection dbs = bl.GetUserDashBoards();
                if (dbs.Entities.Count() == 0)
                {
                    // MessageBox.Show("Didn't find any Dashboard for the selected user, check if the user Domain name is correct");
                }
                foreach (Entity d in dbs.Entities)
                {
                    gridDashboards.Rows.Add(false, d.Attributes["name"], d.Id, d.GetAttributeValue<AliasedValue>("user.fullname").Value);
                }

                //Get the system's form (publics)
                dbs = bl.GetSystemDashBoards();

                foreach (Entity d in dbs.Entities)
                {
                    gridDashboards.Rows.Add(false, d.Attributes["name"], d.Id, "SYSTEM");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EnableButAssign()
        {
            //     butUpdate.Enabled = GetCheckedRow(gridUsers) != null;
        }

        private void gridDashboards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
            }
        }

        #endregion

        #region Other user's settings

        private void chkWorkingTime_CheckedChanged(object sender, EventArgs e)
        {
            comboEnd.Enabled = (sender as CheckBox).Checked == true;
            comboStart.Enabled = (sender as CheckBox).Checked == true;
        }

        private void chkPagingLimit_CheckedChanged(object sender, EventArgs e)
        {
            comboPagingLimit.Enabled = (sender as CheckBox).Checked == true;
        }

        private void chkCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                gridCurrency.Enabled = true;
                if (systemCurrencies == null)
                {
                    systemCurrencies = bl.GetSystemCurrencies();
                }
                foreach (Entity c in systemCurrencies.Entities)
                {
                    gridCurrency.Rows.Add(false, c.Id, c.Attributes["currencyname"], c.Attributes["currencysymbol"]);
                }
                gridCurrency.Focus();
            }
            else
            {
                gridCurrency.Rows.Clear();
                gridCurrency.Enabled = false;
            }

        }

        private void chkLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                gridLanguage.Enabled = true;

                if (languagesColl == null || languagesColl.Length == 0)
                {
                    languagesColl = bl.GetSystemLanguages();
                }
                if (languagesColl.Length == 0)
                {
                    MessageBox.Show("Didn't find any language in the system :/ ");
                }
                else
                {
                    for (int i = 0; i < languagesColl.Length; i++)
                    {
                        gridLanguage.Rows.Add(false, LanguageDic[languagesColl[i]], languagesColl[i]);
                    }
                }
                gridLanguage.Focus();
            }
            else
            {
                gridLanguage.Rows.Clear();
                gridLanguage.Enabled = false;
            }
        }

        private void checkTimeZone_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                gridTimeZone.Enabled = true;

                if (timeZoneCol == null)
                {
                    timeZoneCol = bl.GetSystemsTimeZones();
                }
                if (timeZoneCol.Entities.Count == 0)
                {
                    MessageBox.Show("Didn't find any language in the system :/ ");
                }
                else
                {
                    foreach (Entity tz in timeZoneCol.Entities)
                    {
                        gridTimeZone.Rows.Add(false, tz.Id, tz.GetAttributeValue<int>("timezonecode").ToString(), tz.GetAttributeValue<string>("userinterfacename"));
                    }
                }
                gridTimeZone.Focus();
            }
            else
            {
                gridTimeZone.Rows.Clear();
                gridTimeZone.Enabled = false;
            }
        }

        private void chkUpdateReportScript_CheckedChanged(object sender, EventArgs e)
        {
            rdbReportScriptErrors1.Enabled = (sender as CheckBox).Checked == true;
            rdbReportScriptErrors2.Enabled = (sender as CheckBox).Checked == true;
            rdbReportScriptErrors3.Enabled = (sender as CheckBox).Checked == true;
        }

        private void chkUpdateStartedPanes_CheckedChanged(object sender, EventArgs e)
        {
            chkStartedPanes.Enabled = (sender as CheckBox).Checked == true;
        }

        private void chkUpdateIsSendAsAllowed_CheckedChanged(object sender, EventArgs e)
        {
            chkIsSendAsAllowed.Enabled = (sender as CheckBox).Checked == true;
        }

        private void chkUpdateModeViewForms_CheckedChanged(object sender, EventArgs e)
        {
            rdbDefault.Enabled = (sender as CheckBox).Checked == true;
            rdbRead.Enabled = (sender as CheckBox).Checked == true;
            rdbEdit.Enabled = (sender as CheckBox).Checked == true;
        }

        private void chkUpdateModeAdvanceFind_CheckedChanged(object sender, EventArgs e)
        {
            rdbSimple.Enabled = (sender as CheckBox).Checked == true;
            rdbDetailed.Enabled = (sender as CheckBox).Checked == true;
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

        private void gridUpdateUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGridView = (sender as DataGridView);
            DataGridViewRow rowClicked = senderGridView.CurrentRow;
            if (senderGridView.CurrentRow != null)
            {
                MakeOnlyOneSelection(senderGridView, rowClicked);
            }
        }

        private void SetStartEndCombosItems()
        {
            for (int i = 0; i < 24; i++)
            {
                comboStart.Items.Add(i.ToString().PadLeft(2, '0') + ":00");
                comboStart.Items.Add(i.ToString().PadLeft(2, '0') + ":30");

                comboEnd.Items.Add(i.ToString().PadLeft(2, '0') + ":00");
                comboEnd.Items.Add(i.ToString().PadLeft(2, '0') + ":30");
            }
        }

        #endregion

        #region Format tab
      
        #region CurrentFormat
        private void chkCurrrentFormat_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                comboCurrentFormat.Enabled = true;
                SetCurrentFormatComboItems();
                panel11.Enabled = false;
                panel12.Enabled = false;
                panel13.Enabled = false;
                panel14.Enabled = false;
                panel15.Enabled = false;
            }
            else
            {
                comboCurrentFormat.SelectedIndex = -1;
                panel11.Enabled = true;
                panel12.Enabled = true;
                panel13.Enabled = true;
                panel14.Enabled = true;
                panel15.Enabled = true;
            }
        }

        private void SetCurrentFormatComboItems() {

            comboCurrentFormat.DataSource = new BindingSource(LanguageDic, null);
            comboCurrentFormat.DisplayMember = "Value";
            comboCurrentFormat.ValueMember = "Key";
        }

        #endregion

        #region Date
        private void chkShortDateFormat_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                comboShortDateForm.Enabled = true;
                comboShortDateSeparator.Enabled = true;
            }
            else
            {
                comboShortDateForm.Enabled = false;
                comboShortDateSeparator.Enabled = false;
                comboShortDateForm.SelectedIndex = -1;
                comboShortDateSeparator.SelectedIndex = -1;
                txtshortDatePrev.Text = string.Empty;
            }
        }
        private void chkLongtDateFormat_CheckedChanged(object sender, EventArgs e)
        {
            comboLongDateForm.Enabled = (sender as CheckBox).Checked == true;
            comboLongDateForm.SelectedIndex = -1;
            txtLongDatePrev.Text = string.Empty;
        }
        private void SetShortDateFormatCombosItems()
        {
            comboShortDateForm.Items.Add("dd" + orgDateSeparator + "MM" + orgDateSeparator + "yy");
            comboShortDateForm.Items.Add("dd" + orgDateSeparator + "MM" + orgDateSeparator + "yyyy");
            comboShortDateForm.Items.Add("dd" + orgDateSeparator + "MMM" + orgDateSeparator + "yy");
            comboShortDateForm.Items.Add("dd" + orgDateSeparator + "MMMM" + orgDateSeparator + "yyyy");
            comboShortDateForm.Items.Add("dd" + orgDateSeparator + "'ב'MMMM" + orgDateSeparator + "yyyy");
            comboShortDateForm.Items.Add("yyyy" + orgDateSeparator + "MM" + orgDateSeparator + "dd");
        }
        private void SetDateSeparatorCombosItems()
        {
            comboShortDateSeparator.Items.Add("/");
            comboShortDateSeparator.Items.Add("-");
            comboShortDateSeparator.Items.Add(".");
        }
        private void SetLongDateFormatCombosItems()
        {
            comboLongDateForm.Items.Add("d' de 'MMMM' de 'yyyy");
            comboLongDateForm.Items.Add("dddd d' de 'MMMM' de 'yyyy");
            comboLongDateForm.Items.Add("dddd, dd' de 'MMMM' de 'yyyy");
        }
        private void comboShortDateForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            showShortDatePreview();
        }
        private void comboShortDateSeparator_SelectedIndexChanged(object sender, EventArgs e)
        {
            showShortDatePreview();
        }
        private void showShortDatePreview()
        {
            DateTime previewDate = new DateTime(2016, 05, 23);
            object dateSeparator = comboShortDateSeparator.SelectedItem;
            object format = comboShortDateForm.SelectedItem;
            if (format != null && dateSeparator != null)
            {
                format = format.ToString().Replace('/', char.Parse(dateSeparator.ToString()));
                txtshortDatePrev.Text = previewDate.ToString(format.ToString());
            }
        }
        private void comboLongDateForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            showLongDatePreview();
        }
        private void showLongDatePreview()
        {
            DateTime previewDate = new DateTime(2016, 05, 23);
            object format = comboLongDateForm.SelectedItem;
            if (format != null)
            {
                txtLongDatePrev.Text = previewDate.ToString(format.ToString());
            }
        }

        #endregion Date

        #region Time

        private void SetTimeFormatCombosItems()
        {
            comboTimeFormat.Items.Add("H:mm");
            comboTimeFormat.Items.Add("HH:mm");
            comboTimeFormat.Items.Add("hh:mm tt");
            comboTimeFormat.Items.Add("h:mm tt");
        }

        private void SetTimeSeparatorCombosItems()
        {
            comboTimeSeparator.Items.Add(":");
            comboTimeSeparator.Items.Add(".");
        }

        private void chkTimeFormat_CheckedChanged(object sender, EventArgs e)
        {
            comboTimeFormat.Enabled = (sender as CheckBox).Checked == true;
            comboTimeSeparator.Enabled = (sender as CheckBox).Checked == true;
            comboTimeFormat.SelectedIndex = -1;
            comboTimeSeparator.SelectedIndex = -1;
            txtTimePreview.Text = string.Empty;
        }
        private void comboTimeSeparator_SelectedIndexChanged(object sender, EventArgs e)
        {
            showTimePreview();
        }
        private void comboTimeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            showTimePreview();
        }

        private void showTimePreview()
        {
            DateTime previewTime = new DateTime(2016, 05, 23, 2, 23, 45);
            object format = comboTimeFormat.SelectedItem;
            object timeSeparator = comboTimeSeparator.SelectedItem;
            if (format != null && timeSeparator != null)
            {
                format = format.ToString().Replace(':', char.Parse(timeSeparator.ToString()));
                txtTimePreview.Text = previewTime.ToString(format.ToString());
            }
        }
        #endregion Time

        #region Currency

        private void chkCurrencyFormat_CheckedChanged(object sender, EventArgs e)
        {
            comboCurrencyFormat.Enabled = (sender as CheckBox).Checked == true;
            comboNegativeCurFormat.Enabled = (sender as CheckBox).Checked == true;
            comboCurrencyFormat.SelectedIndex = -1;
            comboNegativeCurFormat.SelectedIndex = -1;
            txtCurrencyPreview.Text = string.Empty;
            txtNegativeCurPreview.Text = string.Empty;
        }
        private void SetCurrencyFormatCombosItems()
        {
            comboCurrencyFormat.Items.Add(orgCurrencySymbol + "‭123456789");
            comboCurrencyFormat.Items.Add("123456789" + orgCurrencySymbol);
            comboCurrencyFormat.Items.Add(orgCurrencySymbol + " ‭123456789");
            comboCurrencyFormat.Items.Add("123456789 " + orgCurrencySymbol);
        }
        private void SetNegativeCurFormatCombosItems()
        {
            comboNegativeCurFormat.Items.Add("‭(" + orgCurrencySymbol + "123456789)‬");
            comboNegativeCurFormat.Items.Add("-" + orgCurrencySymbol + "123456789");
            comboNegativeCurFormat.Items.Add(orgCurrencySymbol + "-‭123456789");
            comboNegativeCurFormat.Items.Add(orgCurrencySymbol + "123456789-");
            comboNegativeCurFormat.Items.Add("‭(123456789" + orgCurrencySymbol + ")‬");
            comboNegativeCurFormat.Items.Add("-123456789" + orgCurrencySymbol);
            comboNegativeCurFormat.Items.Add("123456789-" + orgCurrencySymbol);
            comboNegativeCurFormat.Items.Add("123456789" + orgCurrencySymbol + "-");
            comboNegativeCurFormat.Items.Add("-123456789 " + orgCurrencySymbol);
            comboNegativeCurFormat.Items.Add("-" + orgCurrencySymbol + " 123456789");
            comboNegativeCurFormat.Items.Add("123456789 " + orgCurrencySymbol + "-");
            comboNegativeCurFormat.Items.Add(orgCurrencySymbol + " 123456789-");
            comboNegativeCurFormat.Items.Add(orgCurrencySymbol + " -‭123456789");
            comboNegativeCurFormat.Items.Add("123456789- " + orgCurrencySymbol);
            comboNegativeCurFormat.Items.Add("‭(" + orgCurrencySymbol + " 123456789)‬");
            comboNegativeCurFormat.Items.Add("‭(123456789 " + orgCurrencySymbol + ")‬");
        }

        private void comboCurrencyFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            showCurrencyPreview();
        }
        private void comboNegativeCurFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            showNegativeCurPreview();
        }

        private void showCurrencyPreview()
        {
            object format = comboCurrencyFormat.SelectedItem;
            if (format != null)
            {
                format = format.ToString().Replace("123456789", groupingOptions[orgNumberGroupFormat]);
                txtCurrencyPreview.Text = format.ToString();
            }
        }
        private void showNegativeCurPreview()
        {
            object format = comboNegativeCurFormat.SelectedItem;
            if (format != null)
            {
                format = format.ToString().Replace("123456789", groupingOptions[orgNumberGroupFormat]);
                txtNegativeCurPreview.Text = format.ToString();
            }
        }

        #endregion Currency

        #region Number

        private void chkNumberFormat_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                comboGroupingSymbol.Enabled = true;
                comboDigitGrouping.Enabled = true;
                comboDecimalSymbol.Enabled = true;
                comboNegativeFormat.Enabled = true;
            }
            else
            {
                comboGroupingSymbol.Enabled = false;
                comboDigitGrouping.Enabled = false;
                comboDecimalSymbol.Enabled = false;
                comboNegativeFormat.Enabled = false;

                comboGroupingSymbol.SelectedIndex = -1;
                comboDigitGrouping.SelectedIndex = -1;
                comboDecimalSymbol.SelectedIndex = -1;
                comboNegativeFormat.SelectedIndex = -1;
                txtPositivePreview.Text = string.Empty;
                txtNegativePreview.Text = string.Empty;
            }
        }
        private void SetDecimalSymbolCombosItems()
        {
            comboDecimalSymbol.Items.Add(".");
            comboDecimalSymbol.Items.Add(",");
            comboDecimalSymbol.Items.Add("/");
        }
        private void SetGroupingSymbolCombosItems()
        {
            comboGroupingSymbol.Items.Add(",");
            comboGroupingSymbol.Items.Add(".");
            comboGroupingSymbol.Items.Add(" ");
            comboGroupingSymbol.Items.Add("'");
        }
        private void SetDigitGroupCombosItems()
        {
            foreach (string g in groupingOptions.Values)
            {
                comboDigitGrouping.Items.Add(g);
            }
        }
        private void SetNegativeFormatCombosItems()
        {
            comboNegativeFormat.Items.Add("‪(123456789)‬");
            comboNegativeFormat.Items.Add("‪‪-123456789‬");
            comboNegativeFormat.Items.Add("‪‪‪- 123456789‬‬");
            comboNegativeFormat.Items.Add("123456789-‬");
            comboNegativeFormat.Items.Add("‪‪123456789 -‬");
        }

        private void comboDecimalSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNegativePreview();
            ShowPositivePreview();
        }
        private void comboGroupingSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNegativePreview();
            ShowPositivePreview();
        }
        private void comboDigitGrouping_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNegativePreview();
            ShowPositivePreview();
        }
        private void comboNegativeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNegativePreview();
            ShowPositivePreview();
        }

        private void ShowNegativePreview()
        {
            object negativeFormat = comboNegativeFormat.SelectedItem;
            if (negativeFormat != null)
            {
                string decimalSymbol = comboDecimalSymbol.SelectedItem != null ? comboDecimalSymbol.SelectedItem.ToString() : orgDecimalSymbol;
                string groupingSymbol = comboGroupingSymbol.SelectedItem != null ? comboGroupingSymbol.SelectedItem.ToString() : orgNumberSeparator;
                string digitGroup = comboDigitGrouping.SelectedItem != null ? comboDigitGrouping.SelectedItem.ToString() : orgNumberGroupFormat;
                string format = string.Empty;
                format = digitGroup.Replace(orgDecimalSymbol, decimalSymbol);
                format = format.Replace(orgNumberSeparator, groupingSymbol);
                format = negativeFormat.ToString().Replace("123456789", format);
                txtNegativePreview.Text = format;
            }
        }
        private void ShowPositivePreview()
        {
            string decimalSymbol = comboDecimalSymbol.SelectedItem != null ? comboDecimalSymbol.SelectedItem.ToString() : orgDecimalSymbol;
            string groupingSymbol = comboGroupingSymbol.SelectedItem != null ? comboGroupingSymbol.SelectedItem.ToString() : orgNumberSeparator;
            string digitGroup = comboDigitGrouping.SelectedItem != null ? comboDigitGrouping.SelectedItem.ToString() : groupingOptions[orgNumberGroupFormat];
            object negativeFormat = comboNegativeFormat.SelectedItem;
            string format = string.Empty;
            format = digitGroup.Replace(orgDecimalSymbol, decimalSymbol);
            format = format.Replace(orgNumberSeparator, groupingSymbol);
            txtPositivePreview.Text = format;
        }
        #endregion Number

        #endregion Format Tab

        private void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<Guid> UsersIds = (this.Owner as UsersSettingsUpdate).UsersSelected;
                if (UsersIds.Count() > 0)
                {
                    #region GeneralTab

                    Guid? currencyId = null;
                    if (chkCurrency.Checked)
                    {
                        DataGridViewRow checkedRow = GetCheckedRow(gridCurrency);
                        if (checkedRow == null)
                        {
                            MessageBox.Show("Have to select a Default Currency for the users");
                            return;
                        }
                        else
                        {
                            currencyId = new Guid(checkedRow.Cells["CurrId"].Value.ToString());
                        }
                    }

                    int? PagingLimit = null;
                    if (chkPagingLimit.Checked)
                    {
                        if (comboPagingLimit.SelectedItem.ToString() == string.Empty)
                        {
                            MessageBox.Show("Have to select Paging Limit");
                            return;
                        }
                        PagingLimit = int.Parse(comboPagingLimit.SelectedItem.ToString());
                    }

                    int? reportErrors = null;
                    if (chkUpdateReportScript.Checked)
                    {
                        foreach (Control c in panel7.Controls)
                        {
                            if (reportErrors != null) break;
                            if (c is RadioButton)
                            {
                                if ((c as RadioButton).Checked)
                                {
                                    switch (c.Name)
                                    {
                                        case "rdbReportScriptErrors1":
                                            reportErrors = 1;
                                            break;
                                        case "rdbReportScriptErrors2":
                                            reportErrors = 2;
                                            break;
                                        case "rdbReportScriptErrors3":
                                            reportErrors = 3;
                                            break;
                                    }
                                }
                            }
                        }
                        if (reportErrors == null)
                        {
                            MessageBox.Show("Need to select one option for Report Script Errors");
                            return;
                        }
                    }

                    bool? IsSendAsAllowed = null;
                    if (chkUpdateIsSendAsAllowed.Checked)
                    {
                        IsSendAsAllowed = chkIsSendAsAllowed.Checked;
                    }

                    bool? IsStartedPanes = null;
                    if (chkUpdateStartedPanes.Checked)
                    {
                        IsStartedPanes = chkStartedPanes.Checked;
                    }

                    int? modeViewForm = null;
                    if (chkUpdateModeViewForms.Checked)
                    {
                        foreach (Control c in panel9.Controls)
                        {
                            if (modeViewForm != null) break;
                            if (c is RadioButton)
                            {
                                if ((c as RadioButton).Checked)
                                {
                                    switch (c.Name)
                                    {
                                        case "rdbDefault":
                                            modeViewForm = 0;
                                            break;
                                        case "rdbRead":
                                            modeViewForm = 1;
                                            break;
                                        case "rdbEdit":
                                            modeViewForm = 2;
                                            break;
                                    }
                                }
                            }
                        }
                        if (modeViewForm == null)
                        {
                            MessageBox.Show("Need to select one option for Mode View Form");
                            return;
                        }
                    }

                    int? modeAdvanceFind = null;
                    if (chkUpdateModeAdvanceFind.Checked)
                    {
                        foreach (Control c in panel10.Controls)
                        {
                            if (modeAdvanceFind != null) break;
                            if (c is RadioButton)
                            {
                                if ((c as RadioButton).Checked)
                                {
                                    switch (c.Name)
                                    {
                                        case "rdbSimple":
                                            modeAdvanceFind = 1;
                                            break;
                                        case "rdbDetailed":
                                            modeAdvanceFind = 2;
                                            break;
                                    }
                                }
                            }
                        }
                        if (modeAdvanceFind == null)
                        {
                            MessageBox.Show("Need to select one option for Mode Advance Find");
                            return;
                        }
                    }

                    #endregion GeneralTab

                    #region LanguageTimeTab

                    int? languageCode = null;
                    if (chkLanguage.Checked)
                    {
                        DataGridViewRow checkedRow = GetCheckedRow(gridLanguage);
                        if (checkedRow == null)
                        {
                            MessageBox.Show("Have to select a Default Language for the users");
                            return;
                        }
                        else
                        {
                            languageCode = (int?)checkedRow.Cells["LanguageCode"].Value;
                        }
                    }

                    int? TimeZoneCode = null;
                    if (checkTimeZone.Checked)
                    {
                        DataGridViewRow checkedRow = GetCheckedRow(gridTimeZone);
                        if (checkedRow == null)
                        {
                            MessageBox.Show("Have to select a Default Language for the users");
                            return;
                        }
                        else
                        {
                            TimeZoneCode = int.Parse(checkedRow.Cells["TimeZoneCode"].Value.ToString());
                        }
                    }

                    string start = string.Empty;
                    string end = string.Empty;
                    if (chkWorkingTime.Checked)
                    {
                        start = comboStart.SelectedItem.ToString();
                        end = comboEnd.SelectedItem.ToString();

                        if (start == string.Empty)
                        {
                            MessageBox.Show("Have to select START for Working Time");
                            return;
                        }
                        else if (end == string.Empty)
                        {
                            MessageBox.Show("Have to select END for Working Time");
                            return;
                        }
                    }

                    #endregion LanguageTimeTab

                    #region DashboardTab

                    Guid? dashboardId = null;
                    DataGridViewRow checkedDashboardRow = GetCheckedRow(gridDashboards);
                    if (checkedDashboardRow != null)
                    {
                        dashboardId = (Guid)checkedDashboardRow.Cells["DBid"].Value;
                    }

                    bool setDefaultHomePageSubArea = chkDashBoardDefault.Checked;

                    #endregion DashboardTab

                    #region formatTab

                    object currentFormat = null;
                    if (chkCurrrentFormat.Checked)
                    {
                        currentFormat = comboCurrentFormat.SelectedValue;
                    }

                    int? shortDateFormat = -1;
                    object dateSeparator = null;
                    object dateFormatString = null;
                    if (chkShortDateFormat.Checked)
                    {
                        dateSeparator = comboShortDateSeparator.SelectedItem;
                        dateFormatString = comboShortDateForm.SelectedItem;
                        shortDateFormat = comboShortDateForm.SelectedIndex;
                    }

                    int? longDateFormat = -1;
                    if (chkLongtDateFormat.Checked)
                    {
                        longDateFormat = comboLongDateForm.SelectedIndex;
                    }
                    int? timeFormat = -1;
                    object timeSeparator = null;
                    if (chkTimeFormat.Checked)
                    {
                        timeSeparator = comboTimeSeparator.SelectedItem;
                        timeFormat = comboTimeFormat.SelectedIndex;
                    }
                    int? currencyFormat = -1;
                    int? negativeCurFormat = -1;
                    if (chkCurrencyFormat.Checked)
                    {
                        currencyFormat = comboCurrencyFormat.SelectedIndex;
                        negativeCurFormat = comboNegativeCurFormat.SelectedIndex;
                    }
                    object decimalSymbol = null;
                    object groupingSymbol = null;
                    object digitGroup = null;
                    object negativeFormat = null;
                    if (chkNumberFormat.Checked)
                    {
                        decimalSymbol = comboDecimalSymbol.SelectedItem;
                        groupingSymbol = comboGroupingSymbol.SelectedItem;
                        digitGroup = comboDigitGrouping.SelectedItem;
                        negativeFormat = comboNegativeFormat.SelectedItem;
                    }

                    #endregion
                    string retMessage = bl.UpdateUserSettings(UsersIds, dashboardId, setDefaultHomePageSubArea
                        , start
                        , end
                        , currencyId
                        , PagingLimit
                        , languageCode
                        , TimeZoneCode
                        , IsSendAsAllowed
                        , IsStartedPanes
                        , reportErrors
                        , modeViewForm
                        , modeAdvanceFind
                        , currentFormat
                        , shortDateFormat
                        , dateFormatString
                        , dateSeparator
                        , longDateFormat
                        , timeFormat
                        , timeSeparator
                        , currencyFormat
                        , negativeCurFormat
                        , decimalSymbol
                        , groupingSymbol
                        , digitGroup
                        , negativeFormat
                       );

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(retMessage);
                }
                else
                {
                    MessageBox.Show("Did not select any user to Update");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataGridViewRow GetCheckedRow(DataGridView grid)
        {
            DataGridViewRow checkedRow = null;
            foreach (DataGridViewRow r in grid.Rows)
            {
                if ((bool)r.Cells[0].Value == true)
                {
                    checkedRow = r;
                    break;
                }
            }

            return checkedRow;
        }

        private void SetLanguageDictionary()
        {
            string LanguagesCsvPath = bl.ResourcesPath + "\\Languages.csv";

            _languagesDic.Clear();
            using (CsvFileReader reader = new CsvFileReader(LanguagesCsvPath))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    if (row[0] != "LanguageName")
                    {
                        _languagesDic.Add(int.Parse(row[1]), row[0]);
                    }
                }
            }
        }

       
    }
}
