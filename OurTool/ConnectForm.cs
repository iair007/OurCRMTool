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
using System.Reflection;

namespace OurCRMTool
{
    public partial class ConnectForm : Form
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
        public ILog log
        {
            get
            {
                log4net.Config.XmlConfigurator.Configure();
                return _log;
            }
        }

        private BL bl;
        string enviroment1Url;
        string enviroment2Url;
        IOrganizationService service1 = null;
        IOrganizationService service2 = null;
        string _ConnectionConfigPath;
        string[] _connectionConfig;
        LogUtils _logUtils = new LogUtils();


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
                log.Debug("will checl ConnectionConfig");
                //if (_connectionConfig == null)
                // {
                if (File.Exists(ConnectionConfigPath))
                {
                    log.Debug("pathExist");
                    _connectionConfig = File.ReadAllText(ConnectionConfigPath).Replace("\r\n", "").Split(',');
                    log.Debug("got ConnectionConfig");
                }
                else
                {
                    log.Debug("File did not exist, so create new file");
                    FileStream file = File.Create(ConnectionConfigPath);
                    file.Close();
                    log.Debug("File Created");
                    //      log.Error("Cant find file: " + ConnectionConfigPath);
                }
                //}
                return _connectionConfig;
            }
        }

        public ConnectForm()
        {
            log.Debug("empece");
            InitializeComponent();

            txtDom.Enabled = !chkDefaultCredentials.Checked;
            txtUserName.Enabled = !chkDefaultCredentials.Checked;
            txtPass.Enabled = !chkDefaultCredentials.Checked;
            txtTargetDom.Enabled = !chkTargetDefaultCredentials.Checked;
            txtTargetUserName.Enabled = !chkTargetDefaultCredentials.Checked;
            txtTargetPass.Enabled = !chkTargetDefaultCredentials.Checked;
            txtSourceDom.Enabled = !chkSourceDefaultCredentials.Checked;
            txtSourceUserName.Enabled = !chkSourceDefaultCredentials.Checked;
            txtSourcePass.Enabled = !chkSourceDefaultCredentials.Checked;
            log.Debug("Enable all textbox and checkbox");

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
                if (isOnline != string.Empty && isOnline != "false")
                {
                    chkOnline.Checked = true;
                    txtDom.Enabled = false;
                }
                string userDefaultCredentials = GetConfigParameter("UserDefaultCredentials").ToLower();
                if (userDefaultCredentials != string.Empty && userDefaultCredentials != "false")
                {
                    chkDefaultCredentials.Checked = true;
                }

                string uRI_source = GetConfigParameter("URI_source");
                if (uRI_source != string.Empty)
                {
                    txtSource.Text = uRI_source;
                }
                string domain_source = GetConfigParameter("Domain_source");
                if (domain_source != string.Empty)
                {
                    txtSourceDom.Text = domain_source;
                }
                string username_source = GetConfigParameter("Username_source");
                if (username_source != string.Empty)
                {
                    txtSourceUserName.Text = username_source;
                }
                string isSourceOnline = GetConfigParameter("IsSourceOnline").ToLower();
                if (isSourceOnline != string.Empty && isSourceOnline != "false")
                {
                    chkIsSourceOnline.Checked = true;
                }
                string userDefaultCredentialsSource = GetConfigParameter("UserDefaultCredentialsSource").ToLower();
                if (userDefaultCredentialsSource != string.Empty && userDefaultCredentialsSource != "false")
                {
                    chkSourceDefaultCredentials.Checked = true;
                }

                string uRI_target = GetConfigParameter("URI_target");
                if (uRI_target != string.Empty)
                {
                    txtTarget.Text = uRI_target;
                }
                string domain_target = GetConfigParameter("Domain_target");
                if (domain_target != string.Empty)
                {
                    txtTargetDom.Text = domain_target;
                }
                string username_target = GetConfigParameter("Username_target");
                if (username_target != string.Empty)
                {
                    txtTargetUserName.Text = username_target;
                }
                string isTargetOnline = GetConfigParameter("IsTargetOnline").ToLower();
                if (isTargetOnline != string.Empty && isTargetOnline != "false")
                {
                    chkIsTargetOnline.Checked = true;
                }
                string useDefaultCredentialsTarget = GetConfigParameter("UseDefaultCredentialsTarget").ToLower();
                if (useDefaultCredentialsTarget != string.Empty && useDefaultCredentialsTarget != "false")
                {
                    chkTargetDefaultCredentials.Checked = true;
                }
            }
            else
            {
                txtUrl.Text = ConfigurationManager.AppSettings["Url"];
                txtDom.Text = ConfigurationManager.AppSettings["Domain"];
                txtUserName.Text = ConfigurationManager.AppSettings["Username"];
                chkDefaultCredentials.Checked = ConfigurationManager.AppSettings["UserDefaultCredentials"] == "1" ? true : false;

                txtSource.Text = ConfigurationManager.AppSettings["URI_Dev"];
                txtSourceDom.Text = ConfigurationManager.AppSettings["Domain_Dev"];
                txtSourceUserName.Text = ConfigurationManager.AppSettings["Username_Dev"];
                chkSourceDefaultCredentials.Checked = ConfigurationManager.AppSettings["UserDefaultCredentials_DeV"] == "1" ? true : false;
                txtTarget.Text = ConfigurationManager.AppSettings["URI_QA"];
                txtTargetDom.Text = ConfigurationManager.AppSettings["Domain_QA"];
                txtTargetUserName.Text = ConfigurationManager.AppSettings["Username_QA"];
                chkTargetDefaultCredentials.Checked = ConfigurationManager.AppSettings["UserDefaultCredentials_QA"] == "1" ? true : false;
            }
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtUrl.Text != string.Empty && txtUserName.Text != string.Empty && txtPass.Text != string.Empty)
                //{
                Cursor.Current = Cursors.WaitCursor;
                updateConfigData();
                panel2.Enabled = false;
                string url = SetCRMUrl(txtUrl.Text, chkOnline.Checked);
                if (url != string.Empty)
                {
                    bl = new BL(url, txtDom.Text, txtUserName.Text, txtPass.Text, chkDefaultCredentials.Checked, log);
                    if (bl.service != null)
                    {
                        panel2.Enabled = true;
                        this.Text = "OurCRMTool - Connected to: " + txtUrl.Text;
                    }
                    else
                    {
                        MessageBox.Show("Could not connect to the service");
                    }
                    Cursor.Current = Cursors.Default;

                }
                else
                {
                    MessageBox.Show("Invalid URL");
                    if (GetConfigParameter("Url") != txtUrl.Text)
                    {
                        updateConfigParameter("Url", "");
                    }
                }
                //}
                //else
                //{
                //    MessageBox.Show("All the fields are mandatory");
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void updateConfigParameter(string parameterName, string parameterValue)
        {
            string[] aux = ConnectionConfig;
            for (int i = 0; i < ConnectionConfig.Length; i++)
            {
                if (ConnectionConfig[i].StartsWith(parameterName))
                {
                    string[] parameter = ConnectionConfig[i].Split(';');
                    parameter[1] = parameterValue;
                    aux[i] = string.Join(";", parameter);
                    break;
                }
            }
            File.WriteAllText(ConnectionConfigPath, string.Join(",", aux));

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
            //missing Parameter in connectionConfig, so add it:
            File.AppendAllText(ConnectionConfigPath, parameterName + ";," + Environment.NewLine);
            return string.Empty;
        }
        private void updateConfigData()
        {
            try
            {
                if (ConnectionConfig != null)
                {
                    //one connection
                    if (txtUrl.Text != string.Empty && GetConfigParameter("Url") != txtUrl.Text)
                    {
                        updateConfigParameter("Url", txtUrl.Text);
                    }
                    if (txtDom.Text != string.Empty && GetConfigParameter("Domain") != txtDom.Text)
                    {
                        updateConfigParameter("Domain", txtDom.Text);
                    }
                    if (txtUserName.Text != string.Empty && GetConfigParameter("Username") != txtUserName.Text)
                    {
                        updateConfigParameter("Username", txtUserName.Text);
                    }
                    if (GetConfigParameter("IsOnline").ToLower() != chkOnline.Checked.ToString().ToLower())
                    {
                        updateConfigParameter("IsOnline", chkOnline.Checked.ToString());
                    }
                    if (GetConfigParameter("UserDefaultCredentials").ToLower() != chkDefaultCredentials.Checked.ToString().ToLower())
                    {
                        updateConfigParameter("UserDefaultCredentials", chkDefaultCredentials.Checked.ToString());
                    }

                    //Source
                    if (txtSource.Text != string.Empty && GetConfigParameter("URI_source") != txtSource.Text)
                    {
                        updateConfigParameter("URI_source", txtSource.Text);
                    }
                    if (txtSourceDom.Text != string.Empty && GetConfigParameter("Domain_source") != txtSourceDom.Text)
                    {
                        updateConfigParameter("Domain_source", txtSourceDom.Text);
                    }
                    if (txtSourceUserName.Text != string.Empty && GetConfigParameter("Username_source") != txtSourceUserName.Text)
                    {
                        updateConfigParameter("Username_source", txtSourceUserName.Text);
                    }
                    if (GetConfigParameter("IsSourceOnline").ToLower() != chkIsSourceOnline.Checked.ToString().ToLower())
                    {
                        updateConfigParameter("IsSourceOnline", chkIsSourceOnline.Checked.ToString());
                    }
                    if (GetConfigParameter("UserDefaultCredentialsSource").ToLower() != chkSourceDefaultCredentials.Checked.ToString().ToLower())
                    {
                        updateConfigParameter("UserDefaultCredentialsSource", chkSourceDefaultCredentials.Checked.ToString());
                    }


                    //Target
                    if (txtTarget.Text != string.Empty && GetConfigParameter("URI_target") != txtTarget.Text)
                    {
                        updateConfigParameter("URI_target", txtTarget.Text);
                    }
                    if (txtTargetDom.Text != string.Empty && GetConfigParameter("Domain_target") != txtTargetDom.Text)
                    {
                        updateConfigParameter("Domain_target", txtTargetDom.Text);
                    }
                    if (txtTargetUserName.Text != string.Empty && GetConfigParameter("Username_target") != txtTargetUserName.Text)
                    {
                        updateConfigParameter("Username_target", txtTargetUserName.Text);
                    }
                    if (GetConfigParameter("IsTargetOnline").ToLower() != chkIsTargetOnline.Checked.ToString().ToLower())
                    {
                        updateConfigParameter("IsTargetOnline", chkIsTargetOnline.Checked.ToString());
                    }
                    if (GetConfigParameter("UseDefaultCredentialsTarget").ToLower() != chkTargetDefaultCredentials.Checked.ToString().ToLower())
                    {
                        updateConfigParameter("UseDefaultCredentialsTarget", chkTargetDefaultCredentials.Checked.ToString());
                    }

                }
                else
                {
                    Configuration MyConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    MyConfig.AppSettings.Settings["Url"].Value = txtUrl.Text;
                    MyConfig.AppSettings.Settings["Domain"].Value = txtDom.Text;
                    MyConfig.AppSettings.Settings["Username"].Value = txtUserName.Text;
                    MyConfig.AppSettings.Settings["UserDefaultCredentials"].Value = chkDefaultCredentials.Checked ? "1" : "0";

                    MyConfig.AppSettings.Settings["URI_Dev"].Value = txtSource.Text;
                    MyConfig.AppSettings.Settings["Domain_Dev"].Value = txtSourceDom.Text;
                    MyConfig.AppSettings.Settings["Username_Dev"].Value = txtSourceUserName.Text;
                    MyConfig.AppSettings.Settings["UserDefaultCredentials_DeV"].Value = chkSourceDefaultCredentials.Checked ? "1" : "0";
                    MyConfig.AppSettings.Settings["URI_QA"].Value = txtTarget.Text;
                    MyConfig.AppSettings.Settings["Domain_QA"].Value = txtTargetDom.Text;
                    MyConfig.AppSettings.Settings["Username_QA"].Value = txtTargetUserName.Text;
                    MyConfig.AppSettings.Settings["UserDefaultCredentials_QA"].Value = chkTargetDefaultCredentials.Checked ? "1" : "0";

                    MyConfig.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
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
            Cursor.Current = Cursors.WaitCursor;
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
            Cursor.Current = Cursors.WaitCursor;
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
            if ((sender as CheckBox).Checked)
            {
                txtDom.Text = string.Empty;
                txtDom.Enabled = false;
                chkDefaultCredentials.Checked = false;
                chkDefaultCredentials.Enabled = false;
            }
            else
            {
                txtDom.Enabled = true;
                chkDefaultCredentials.Enabled = true;
            }
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
            updateConfigData();

            CRMHelpper crmHelper = new CRMHelpper(log);
            try
            {
                enviroment1Url = SetCRMUrl(txtSource.Text, chkIsSourceOnline.Checked);
                if (chkSourceDefaultCredentials.Checked)
                {
                    service1 = crmHelper.GetCRMService(enviroment1Url);
                }
                else if (enviroment1Url != string.Empty && txtSourceDom.Text == string.Empty)
                {
                    service1 = crmHelper.GetCRMServiceOnline(txtSourceUserName.Text, txtSourcePass.Text, enviroment1Url);
                }
                else if (enviroment1Url != string.Empty)
                {
                    service1 = crmHelper.GetCRMService(enviroment1Url, txtSourceDom.Text, txtSourceUserName.Text, txtSourcePass.Text);
                }
                if (enviroment1Url == string.Empty || service1 == null)
                {
                    MessageBox.Show("Cannot connect to the source CRM");
                    Cursor.Current = Cursors.Default;
                    return;
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
                if (chkTargetDefaultCredentials.Checked)
                {
                    service2 = crmHelper.GetCRMService(enviroment2Url);
                }
                else if (enviroment2Url != string.Empty && txtTargetDom.Text == string.Empty)
                {
                    service2 = crmHelper.GetCRMServiceOnline(txtTargetUserName.Text, txtTargetPass.Text, enviroment2Url);
                }
                else if (enviroment2Url != string.Empty)
                {
                    service2 = crmHelper.GetCRMService(enviroment2Url, txtTargetDom.Text, txtTargetUserName.Text, txtTargetPass.Text);
                }
                if (enviroment2Url == string.Empty || service2 == null)
                {
                    MessageBox.Show("Cannot connect to the target CRM");
                    Cursor.Current = Cursors.Default;
                    return;
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

        private void chkIsSourceOnline_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                txtSourceDom.Text = string.Empty;
                txtSourceDom.Enabled = false;
                chkSourceDefaultCredentials.Checked = false;
                chkSourceDefaultCredentials.Enabled = false;
            }
            else
            {
                txtSourceDom.Enabled = true;
                chkSourceDefaultCredentials.Enabled = true;
            }
        }
        private void chkIsTargetOnline_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                txtTargetDom.Text = string.Empty;
                txtTargetDom.Enabled = false;
                chkTargetDefaultCredentials.Checked = false;
                chkTargetDefaultCredentials.Enabled = false;
            }
            else
            {
                txtTargetDom.Enabled = true;
                chkTargetDefaultCredentials.Enabled = true;
            }
        }

        #endregion

        private void butCompareRecordsInEnviroments_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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
            Cursor.Current = Cursors.WaitCursor;
            SerurityRoleAnalizerByUser form = new SerurityRoleAnalizerByUser(bl, log);
            form.ShowDialog();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.lblVersion.Text = String.Format(this.lblVersion.Text, version.Major, version.Minor, version.Build, version.Revision);
        }

        private void chkDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            txtDom.Enabled = !chkDefaultCredentials.Checked;
            txtUserName.Enabled = !chkDefaultCredentials.Checked;
            txtPass.Enabled = !chkDefaultCredentials.Checked;
        }

        private void chkTargetDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            txtTargetDom.Enabled = !chkTargetDefaultCredentials.Checked;
            txtTargetUserName.Enabled = !chkTargetDefaultCredentials.Checked;
            txtTargetPass.Enabled = !chkTargetDefaultCredentials.Checked;
        }

        private void chkSourceDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            txtSourceDom.Enabled = !chkSourceDefaultCredentials.Checked;
            txtSourceUserName.Enabled = !chkSourceDefaultCredentials.Checked;
            txtSourcePass.Enabled = !chkSourceDefaultCredentials.Checked;
        }

        private void butCompareUsersPrvAndTeam_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CompareUsersPrivAndTeam form = new CompareUsersPrivAndTeam(bl, log);
            form.ShowDialog();
        }
    }
}
