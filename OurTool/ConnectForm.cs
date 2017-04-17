using System;
using System.Windows.Forms;
using System.ServiceModel.Security;
using System.Configuration;
using Microsoft.Xrm.Sdk;
using log4net;
using System.Security.Principal;
using System.Diagnostics;
using System.Xml;
using System.Security.Permissions;
using System.IO;

namespace OurCRMTool
{
    public partial class ConnectForm : Form
    {
        private BL bl;
        string enviroment1Url;
        string enviroment2Url;
        IOrganizationService service1 = null;
        IOrganizationService service2 = null;
        string _ConnectionConfigPath;
        string[] _connectionConfig;
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        public ILog log
        {
            get
            {
                return _log;
            }
        }

        private string ConnectionConfigPath
        {
            get
            {
                if (_ConnectionConfigPath == null)
                {
                    _ConnectionConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\connectionConfig.txt";
                }
                return _ConnectionConfigPath;
            }
        }
        public string[] ConnectionConfig
        {
            get
            {
                if (_connectionConfig == null)
                {
                    if (File.Exists(ConnectionConfigPath))
                    {
                        _connectionConfig = File.ReadAllText(ConnectionConfigPath).Replace("\r\n","").Split(',');
                    }
                    else
                    {
                        log.Error("Cant find file: " + ConnectionConfigPath);
                    }
                }
                return _connectionConfig;
            }
        }

        public ConnectForm()
        {
            InitializeComponent();
            if (ConnectionConfig != null)
            {
                string url = GetConfigParameter("Url");
                if (url != string.Empty)
                {
                    txtUrl.Text = url;
                }
                string domain = GetConfigParameter("Domain");
                if (domain != string.Empty)
                {
                    txtDom.Text = domain;
                }
                string username = GetConfigParameter("Username");
                if (username != string.Empty)
                {
                    txtUserName.Text = username;
                }
                string isOnline = GetConfigParameter("IsOnline").ToLower();
                if(isOnline != string.Empty && isOnline != "false"){
                    chkOnline.Checked = true;
                }
            }
            log4net.Config.XmlConfigurator.Configure();

            //txtSource.Text = ConfigurationManager.AppSettings["URI_Dev"];
            //txtSourceDom.Text = ConfigurationManager.AppSettings["Domain_Dev"];
            //txtSourceUserName.Text = ConfigurationManager.AppSettings["Username_Dev"];
            //txtTarget.Text = ConfigurationManager.AppSettings["URI_QA"];
            //txtTargetDom.Text = ConfigurationManager.AppSettings["Domain_QA"];
            //txtTargetUserName.Text = ConfigurationManager.AppSettings["Username_QA"];
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrl.Text != string.Empty && txtUserName.Text != string.Empty && txtPass.Text != string.Empty)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    updateConfigData();
                    panel2.Enabled = false;
                    string url = SetCRMUrl(txtUrl.Text, chkOnline.Checked);
                    if (url != string.Empty)
                    {
                        log.Info("URL: " + url);
                        bl = new BL(url, txtDom.Text, txtUserName.Text, txtPass.Text, log);
                        if (bl.service != null)
                        {
                            panel2.Enabled = true;
                            this.Text = "OurCRMTool - Connected to: " + txtUrl.Text;
                        }
                        else {
                            MessageBox.Show("Could not connect to the service");
                        }
                        Cursor.Current = Cursors.Default;
                        
                    }
                    else {
                        MessageBox.Show("Invalid URL");
                        updateConfigParameter("Url", "");
                    }
                }
                else
                {
                    MessageBox.Show("All the fields are mandatory");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void updateConfigParameter(string parameterName, string parameterValue)
        {

            for (int i = 0; i < ConnectionConfig.Length; i++)
            {
                if (ConnectionConfig[i].StartsWith(parameterName))
                {
                    string[] parameter = ConnectionConfig[i].Split(';');
                    parameter[1] = parameterValue;
                    ConnectionConfig[i] = string.Join(";", parameter);
                    break;
                }
            }
            File.WriteAllText(ConnectionConfigPath, string.Join(",", ConnectionConfig));

        }
        private string GetConfigParameter(string parameterName)
        {
            for (int i = 0; i < ConnectionConfig.Length; i++)
            {
                if (ConnectionConfig[i].StartsWith(parameterName))
                {
                    string[] parameter = ConnectionConfig[i].Split(';');
                    return parameter[1];
                }
            }
            return string.Empty;
        }
        private void updateConfigData()
        {
            try
            {
                if (ConnectionConfig != null)
                {
                    if (GetConfigParameter("Url") != txtUrl.Text)
                    {
                        updateConfigParameter("Url", txtUrl.Text);
                    }
                    if (GetConfigParameter("Domain") != txtDom.Text)
                    {
                        updateConfigParameter("Domain", txtDom.Text);
                    }
                    if (GetConfigParameter("Username") != txtUserName.Text)
                    {
                        updateConfigParameter("Username", txtUserName.Text);
                    }
                    if (GetConfigParameter("IsOnline").ToLower() != chkOnline.Checked.ToString().ToLower())
                    {
                        updateConfigParameter("IsOnline", chkOnline.Checked.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.Message);
            }
        }
       
        private string SetCRMUrl(string _url, bool isOnline)
        {
            string url = string.Empty;
            try
            {
                string[] urlParts = _url.Split('/');
                //part 0 is the http:
                //part 1 is empty
                //part 2 is the server address
                //part 3 is the organization
                if (_url.Contains("XRMServices/2011/Organization.svc"))
                {
                    url = _url;
                }
                else if (isOnline)
                {
                    url = urlParts[0] + "//" + urlParts[2] + "/XRMServices/2011/Organization.svc";
                }
                else
                {
                    url = urlParts[0] + "//" + urlParts[2] + "/" + urlParts[3] + "/XRMServices/2011/Organization.svc";
                }
            }
            catch (Exception ex)
            {
                log.Error("SetCRMurl: " + ex.Message);
            }
            return url;
        }

        private void butUserSettingsUpdate_Click(object sender, EventArgs e)
        {
            UsersSettingsUpdate usersSettingsUpdate = new UsersSettingsUpdate(bl, log);
            usersSettingsUpdate.ShowDialog();
        }

        private void butDefaultTeamSelector_Click(object sender, EventArgs e)
        {
            SetDefaultTeam setDefaultTeam = new SetDefaultTeam(bl, log);
            setDefaultTeam.ShowDialog();
        }

        private void butPrimaryTeam_Click(object sender, EventArgs e)
        {
            //SetPrimaryTeam setPrimaryTeam = new SetPrimaryTeam(bl, log);
            //setPrimaryTeam.ShowDialog();
        }

        private void butCheckDefault_Click(object sender, EventArgs e)
        {
            CheckDefaultTeam checkDefaultTeam = new CheckDefaultTeam(bl);
            checkDefaultTeam.ShowDialog();
        }

        #region Tooltip

        private void butUserSettingsUpdate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(butUserSettingsUpdate, "Tool to update defaults settings for users");
        }

        private void butDefaultTeamSelector_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(butDefaultTeamSelector, "Tool to add defaults teams to users");
        }

        private void butCheckDefault_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(butCheckDefault, "Tool to Check the Default teams for the Users");
        }

        private void butSecurityRolesAnalizer_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(butCheckDefault, "Analize user privilege to Entities");
        }

        #endregion

        private void butSecurityRolesAnalizer_Click(object sender, EventArgs e)
        {
            SecurityRolesAnalizer securityRolesAnalizer = new SecurityRolesAnalizer(bl, log);
            securityRolesAnalizer.ShowDialog();
        }

        private void butSetPrimaryTeam_Click(object sender, EventArgs e)
        {
            SetPrimaryTeam assignRoles = new SetPrimaryTeam(bl, log);
            assignRoles.ShowDialog();
        }

        private void butUnusedRoles_Click(object sender, EventArgs e)
        {
            RolesNotUsed rolesNotUsed = new RolesNotUsed(bl, log);
            rolesNotUsed.ShowDialog();
        }

        private void butRoleCompare_Click(object sender, EventArgs e)
        {
            SecurityRolesCompare securityRolesCompare = new SecurityRolesCompare(bl, log);
            securityRolesCompare.ShowDialog();
        }

        private void butResetDef_Click(object sender, EventArgs e)
        {
            ResetDefaultTeam resetDefaultTeam = new ResetDefaultTeam(bl, log);
            resetDefaultTeam.ShowDialog();
        }

        private void buChangeAttendees_Click(object sender, EventArgs e)
        {
            ChangeAttendees resetDefaultTeam = new ChangeAttendees(bl);
            resetDefaultTeam.ShowDialog();
        }

        private void chkOnline_CheckedChanged(object sender, EventArgs e)
        {
            txtDom.Text = string.Empty;
            txtDom.Enabled = !(sender as CheckBox).Checked;
        }

        #region 2 enviroments
        private void btnConnect2Enviroment_Click(object sender, EventArgs e)
        {
            if (ValidateAllTextBoxFilled() == false)
            {
                MessageBox.Show("All the fields are mandatory");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Configuration MyConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            MyConfig.AppSettings.Settings["URI_Dev"].Value = txtSource.Text;
            MyConfig.AppSettings.Settings["Domain_Dev"].Value = txtSourceDom.Text;
            MyConfig.AppSettings.Settings["Username_Dev"].Value = txtSourceUserName.Text;
            MyConfig.AppSettings.Settings["URI_QA"].Value = txtTarget.Text;
            MyConfig.AppSettings.Settings["Domain_QA"].Value = txtTargetDom.Text;
            MyConfig.AppSettings.Settings["Username_QA"].Value = txtTargetUserName.Text;
            MyConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");


            CRMHelpper crmHelper = new CRMHelpper(log);
            try
            {
                enviroment1Url = SetCRMUrl(txtSource.Text, chkIsSourceOnline.Checked);
                if (enviroment1Url != string.Empty && txtSourceDom.Text == string.Empty)
                {
                    service1 = crmHelper.GetCRMServiceOnline(txtSourceUserName.Text, txtSourcePass.Text, enviroment1Url);
                }
                else if (enviroment1Url != string.Empty)
                {
                    service1 = crmHelper.GetCRMService(enviroment1Url, txtSourceDom.Text, txtSourceUserName.Text, txtSourcePass.Text);
                }
            }
            catch (Exception s)
            {
                Cursor.Current = Cursors.Default;
                log.Error("Credential in Enviroment 1 are not correct, please check and try again: " + s.Message);

            }
            try
            {
                enviroment2Url = SetCRMUrl(txtTarget.Text, chkIsTargetOnline.Checked);
                if (enviroment2Url != string.Empty && txtTargetDom.Text == string.Empty)
                {
                    service2 = crmHelper.GetCRMServiceOnline(txtTargetUserName.Text, txtTargetPass.Text, enviroment2Url);
                }
                else if (enviroment2Url != string.Empty)
                {
                    service2 = crmHelper.GetCRMService(enviroment2Url, txtTargetDom.Text, txtTargetUserName.Text, txtTargetPass.Text);
                }
            }
            catch (Exception s)
            {
                Cursor.Current = Cursors.Default;
                log.Error("Credential in Enviroment 2 are not correct, please check and try again: " + s.Message);
            }

            if (service1 != null && service2 != null)
            {
                panel6.Enabled = true;
            }
            Cursor.Current = Cursors.Default;
        }

        public bool ValidateAllTextBoxFilled()
        {

            bool isValid = true;

            foreach (Control c in this.Controls)
            {
                if (isValid == false)
                {
                    break;
                }
                if (c is Panel)
                {
                    foreach (Control chiledC in c.Controls)
                    {
                        if (chiledC is TextBox && chiledC.Enabled == true)
                        {
                            TextBox textbox = chiledC as TextBox;
                            if (textbox.Text.Trim() == string.Empty)
                            {
                                isValid = false;
                                break;
                            }
                        }
                    }
                }
                else if (c is TextBox && c.Enabled == true)
                {
                    TextBox textbox = c as TextBox;
                    if (textbox.Text.Trim() == string.Empty)
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }
        #endregion

        private void butCompareRecordsInEnviroments_Click(object sender, EventArgs e)
        {
            CompareRecords1 form1 = new CompareRecords1(service1, service2, enviroment1Url, enviroment2Url, log);
            form1.ShowDialog(this);
        }

        private void butChangeRecordStatus_Click(object sender, EventArgs e)
        {
            ChangeRecordStatus form = new ChangeRecordStatus(bl);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SerurityRoleAnalizerByUser form = new SerurityRoleAnalizerByUser(bl, log);
            form.ShowDialog();
        }
    }
}
