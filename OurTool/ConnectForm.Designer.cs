namespace OurCRMTool
{
    partial class ConnectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.butConnectOneEnviroment = new System.Windows.Forms.Button();
            this.txtDom = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lab4 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.chkOnline = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butCompareUsersPrvAndTeam = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.butChangeRecordStatus = new System.Windows.Forms.Button();
            this.buChangeAttendees = new System.Windows.Forms.Button();
            this.butResetDef = new System.Windows.Forms.Button();
            this.butRoleCompare = new System.Windows.Forms.Button();
            this.butUnusedRoles = new System.Windows.Forms.Button();
            this.butSecurityRolesAnalizer = new System.Windows.Forms.Button();
            this.butCheckDefault = new System.Windows.Forms.Button();
            this.butUserSettingsUpdate = new System.Windows.Forms.Button();
            this.butDefaultTeamSelector = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tab = new System.Windows.Forms.TabControl();
            this.tabOneEnviroment = new System.Windows.Forms.TabPage();
            this.lblVersion = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabTwoEnviroment = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.butCompareRecordsInEnviroments = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkTargetDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.chkIsTargetOnline = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTargetDom = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTargetPass = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.txtTargetUserName = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkSourceDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.chkIsSourceOnline = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSourceDom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSourcePass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSourceUserName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabOneEnviroment.SuspendLayout();
            this.tabTwoEnviroment.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Organization URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(148, 9);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(499, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // butConnectOneEnviroment
            // 
            this.butConnectOneEnviroment.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.butConnectOneEnviroment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butConnectOneEnviroment.Location = new System.Drawing.Point(711, 84);
            this.butConnectOneEnviroment.Name = "butConnectOneEnviroment";
            this.butConnectOneEnviroment.Size = new System.Drawing.Size(108, 36);
            this.butConnectOneEnviroment.TabIndex = 2;
            this.butConnectOneEnviroment.Text = "Connect";
            this.butConnectOneEnviroment.UseVisualStyleBackColor = false;
            this.butConnectOneEnviroment.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // txtDom
            // 
            this.txtDom.Location = new System.Drawing.Point(147, 38);
            this.txtDom.Name = "txtDom";
            this.txtDom.Size = new System.Drawing.Size(287, 20);
            this.txtDom.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(147, 64);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(287, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(147, 90);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(287, 20);
            this.txtPass.TabIndex = 5;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domain:";
            // 
            // lab4
            // 
            this.lab4.AutoSize = true;
            this.lab4.Location = new System.Drawing.Point(8, 67);
            this.lab4.Name = "lab4";
            this.lab4.Size = new System.Drawing.Size(73, 13);
            this.lab4.TabIndex = 7;
            this.lab4.Text = "User Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkDefaultCredentials);
            this.panel1.Controls.Add(this.chkOnline);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lab4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.txtDom);
            this.panel1.Controls.Add(this.butConnectOneEnviroment);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 125);
            this.panel1.TabIndex = 9;
            // 
            // chkDefaultCredentials
            // 
            this.chkDefaultCredentials.AutoSize = true;
            this.chkDefaultCredentials.Checked = true;
            this.chkDefaultCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultCredentials.Location = new System.Drawing.Point(658, 10);
            this.chkDefaultCredentials.Name = "chkDefaultCredentials";
            this.chkDefaultCredentials.Size = new System.Drawing.Size(164, 17);
            this.chkDefaultCredentials.TabIndex = 10;
            this.chkDefaultCredentials.Text = "User Default Credentials";
            this.chkDefaultCredentials.UseVisualStyleBackColor = true;
            this.chkDefaultCredentials.CheckedChanged += new System.EventHandler(this.chkDefaultCredentials_CheckedChanged);
            // 
            // chkOnline
            // 
            this.chkOnline.AutoSize = true;
            this.chkOnline.Location = new System.Drawing.Point(440, 38);
            this.chkOnline.Name = "chkOnline";
            this.chkOnline.Size = new System.Drawing.Size(107, 17);
            this.chkOnline.TabIndex = 9;
            this.chkOnline.Text = "Is Online CRM";
            this.chkOnline.UseVisualStyleBackColor = true;
            this.chkOnline.CheckedChanged += new System.EventHandler(this.chkOnline_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butCompareUsersPrvAndTeam);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.butChangeRecordStatus);
            this.panel2.Controls.Add(this.buChangeAttendees);
            this.panel2.Controls.Add(this.butResetDef);
            this.panel2.Controls.Add(this.butRoleCompare);
            this.panel2.Controls.Add(this.butUnusedRoles);
            this.panel2.Controls.Add(this.butSecurityRolesAnalizer);
            this.panel2.Controls.Add(this.butCheckDefault);
            this.panel2.Controls.Add(this.butUserSettingsUpdate);
            this.panel2.Controls.Add(this.butDefaultTeamSelector);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(7, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 166);
            this.panel2.TabIndex = 11;
            // 
            // butCompareUsersPrvAndTeam
            // 
            this.butCompareUsersPrvAndTeam.BackColor = System.Drawing.SystemColors.Control;
            this.butCompareUsersPrvAndTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.butCompareUsersPrvAndTeam.Location = new System.Drawing.Point(295, 131);
            this.butCompareUsersPrvAndTeam.Name = "butCompareUsersPrvAndTeam";
            this.butCompareUsersPrvAndTeam.Size = new System.Drawing.Size(222, 23);
            this.butCompareUsersPrvAndTeam.TabIndex = 66;
            this.butCompareUsersPrvAndTeam.Text = "Compare User\'s Teams and Privilege Roles";
            this.butCompareUsersPrvAndTeam.UseVisualStyleBackColor = false;
            this.butCompareUsersPrvAndTeam.Click += new System.EventHandler(this.butCompareUsersPrvAndTeam_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button2.Location = new System.Drawing.Point(295, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 23);
            this.button2.TabIndex = 61;
            this.button2.Text = "Security Roles Analyzer by User";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // butChangeRecordStatus
            // 
            this.butChangeRecordStatus.BackColor = System.Drawing.SystemColors.Control;
            this.butChangeRecordStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.butChangeRecordStatus.Location = new System.Drawing.Point(7, 43);
            this.butChangeRecordStatus.Name = "butChangeRecordStatus";
            this.butChangeRecordStatus.Size = new System.Drawing.Size(195, 23);
            this.butChangeRecordStatus.TabIndex = 65;
            this.butChangeRecordStatus.Text = "Change Record Status";
            this.butChangeRecordStatus.UseVisualStyleBackColor = false;
            this.butChangeRecordStatus.Click += new System.EventHandler(this.butChangeRecordStatus_Click);
            // 
            // buChangeAttendees
            // 
            this.buChangeAttendees.BackColor = System.Drawing.SystemColors.Control;
            this.buChangeAttendees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.buChangeAttendees.Location = new System.Drawing.Point(7, 72);
            this.buChangeAttendees.Name = "buChangeAttendees";
            this.buChangeAttendees.Size = new System.Drawing.Size(195, 23);
            this.buChangeAttendees.TabIndex = 64;
            this.buChangeAttendees.Text = "Appointment Change Attendees";
            this.buChangeAttendees.UseVisualStyleBackColor = false;
            this.buChangeAttendees.Visible = false;
            this.buChangeAttendees.Click += new System.EventHandler(this.buChangeAttendees_Click);
            // 
            // butResetDef
            // 
            this.butResetDef.BackColor = System.Drawing.SystemColors.Control;
            this.butResetDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butResetDef.Location = new System.Drawing.Point(618, 72);
            this.butResetDef.Name = "butResetDef";
            this.butResetDef.Size = new System.Drawing.Size(195, 23);
            this.butResetDef.TabIndex = 63;
            this.butResetDef.Text = "Re-Set Default Teams";
            this.butResetDef.UseVisualStyleBackColor = false;
            this.butResetDef.Visible = false;
            this.butResetDef.Click += new System.EventHandler(this.butResetDef_Click);
            // 
            // butRoleCompare
            // 
            this.butRoleCompare.BackColor = System.Drawing.SystemColors.Control;
            this.butRoleCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.butRoleCompare.Location = new System.Drawing.Point(295, 102);
            this.butRoleCompare.Name = "butRoleCompare";
            this.butRoleCompare.Size = new System.Drawing.Size(222, 23);
            this.butRoleCompare.TabIndex = 62;
            this.butRoleCompare.Text = "Compare Roles";
            this.butRoleCompare.UseVisualStyleBackColor = false;
            this.butRoleCompare.Click += new System.EventHandler(this.butRoleCompare_Click);
            // 
            // butUnusedRoles
            // 
            this.butUnusedRoles.BackColor = System.Drawing.SystemColors.Control;
            this.butUnusedRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.butUnusedRoles.Location = new System.Drawing.Point(295, 73);
            this.butUnusedRoles.Name = "butUnusedRoles";
            this.butUnusedRoles.Size = new System.Drawing.Size(222, 23);
            this.butUnusedRoles.TabIndex = 61;
            this.butUnusedRoles.Text = "Roles Not Assigned";
            this.butUnusedRoles.UseVisualStyleBackColor = false;
            this.butUnusedRoles.Click += new System.EventHandler(this.butUnusedRoles_Click);
            // 
            // butSecurityRolesAnalizer
            // 
            this.butSecurityRolesAnalizer.BackColor = System.Drawing.SystemColors.Control;
            this.butSecurityRolesAnalizer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butSecurityRolesAnalizer.Location = new System.Drawing.Point(295, 14);
            this.butSecurityRolesAnalizer.Name = "butSecurityRolesAnalizer";
            this.butSecurityRolesAnalizer.Size = new System.Drawing.Size(222, 23);
            this.butSecurityRolesAnalizer.TabIndex = 60;
            this.butSecurityRolesAnalizer.Text = "Security Roles Analyzer by Entity";
            this.butSecurityRolesAnalizer.UseVisualStyleBackColor = false;
            this.butSecurityRolesAnalizer.Click += new System.EventHandler(this.butSecurityRolesAnalizer_Click);
            // 
            // butCheckDefault
            // 
            this.butCheckDefault.BackColor = System.Drawing.SystemColors.Control;
            this.butCheckDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butCheckDefault.Location = new System.Drawing.Point(617, 12);
            this.butCheckDefault.Name = "butCheckDefault";
            this.butCheckDefault.Size = new System.Drawing.Size(195, 23);
            this.butCheckDefault.TabIndex = 59;
            this.butCheckDefault.Text = "Check Default Teams";
            this.butCheckDefault.UseVisualStyleBackColor = false;
            this.butCheckDefault.Visible = false;
            this.butCheckDefault.Click += new System.EventHandler(this.butCheckDefault_Click);
            // 
            // butUserSettingsUpdate
            // 
            this.butUserSettingsUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.butUserSettingsUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butUserSettingsUpdate.Location = new System.Drawing.Point(7, 12);
            this.butUserSettingsUpdate.Name = "butUserSettingsUpdate";
            this.butUserSettingsUpdate.Size = new System.Drawing.Size(195, 23);
            this.butUserSettingsUpdate.TabIndex = 57;
            this.butUserSettingsUpdate.Text = "Users Settings Update";
            this.butUserSettingsUpdate.UseVisualStyleBackColor = false;
            this.butUserSettingsUpdate.Click += new System.EventHandler(this.butUserSettingsUpdate_Click);
            // 
            // butDefaultTeamSelector
            // 
            this.butDefaultTeamSelector.BackColor = System.Drawing.SystemColors.Control;
            this.butDefaultTeamSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butDefaultTeamSelector.Location = new System.Drawing.Point(618, 43);
            this.butDefaultTeamSelector.Name = "butDefaultTeamSelector";
            this.butDefaultTeamSelector.Size = new System.Drawing.Size(195, 23);
            this.butDefaultTeamSelector.TabIndex = 58;
            this.butDefaultTeamSelector.Text = "Default Team Selector";
            this.butDefaultTeamSelector.UseVisualStyleBackColor = false;
            this.butDefaultTeamSelector.Visible = false;
            this.butDefaultTeamSelector.Click += new System.EventHandler(this.butDefaultTeamSelector_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabOneEnviroment);
            this.tab.Controls.Add(this.tabTwoEnviroment);
            this.tab.Location = new System.Drawing.Point(1, 3);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(845, 482);
            this.tab.TabIndex = 12;
            // 
            // tabOneEnviroment
            // 
            this.tabOneEnviroment.Controls.Add(this.lblVersion);
            this.tabOneEnviroment.Controls.Add(this.button1);
            this.tabOneEnviroment.Controls.Add(this.panel1);
            this.tabOneEnviroment.Controls.Add(this.panel2);
            this.tabOneEnviroment.Location = new System.Drawing.Point(4, 22);
            this.tabOneEnviroment.Name = "tabOneEnviroment";
            this.tabOneEnviroment.Padding = new System.Windows.Forms.Padding(3);
            this.tabOneEnviroment.Size = new System.Drawing.Size(837, 456);
            this.tabOneEnviroment.TabIndex = 0;
            this.tabOneEnviroment.Text = "One Enviroment Connection";
            this.tabOneEnviroment.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(715, 440);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(137, 13);
            this.lblVersion.TabIndex = 60;
            this.lblVersion.Text = "Version: {0}.{1}.{2}.{3}";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(7, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Default Team Selector";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.butSetPrimaryTeam_Click);
            // 
            // tabTwoEnviroment
            // 
            this.tabTwoEnviroment.Controls.Add(this.panel6);
            this.tabTwoEnviroment.Controls.Add(this.panel3);
            this.tabTwoEnviroment.Location = new System.Drawing.Point(4, 22);
            this.tabTwoEnviroment.Name = "tabTwoEnviroment";
            this.tabTwoEnviroment.Padding = new System.Windows.Forms.Padding(3);
            this.tabTwoEnviroment.Size = new System.Drawing.Size(837, 456);
            this.tabTwoEnviroment.TabIndex = 1;
            this.tabTwoEnviroment.Text = "Two Enviroment Connection";
            this.tabTwoEnviroment.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.butCompareRecordsInEnviroments);
            this.panel6.Enabled = false;
            this.panel6.Location = new System.Drawing.Point(3, 337);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(827, 113);
            this.panel6.TabIndex = 12;
            // 
            // butCompareRecordsInEnviroments
            // 
            this.butCompareRecordsInEnviroments.BackColor = System.Drawing.SystemColors.Control;
            this.butCompareRecordsInEnviroments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.butCompareRecordsInEnviroments.Location = new System.Drawing.Point(12, 12);
            this.butCompareRecordsInEnviroments.Name = "butCompareRecordsInEnviroments";
            this.butCompareRecordsInEnviroments.Size = new System.Drawing.Size(195, 37);
            this.butCompareRecordsInEnviroments.TabIndex = 58;
            this.butCompareRecordsInEnviroments.Text = "Compare Records In Enviroments";
            this.butCompareRecordsInEnviroments.UseVisualStyleBackColor = false;
            this.butCompareRecordsInEnviroments.Click += new System.EventHandler(this.butCompareRecordsInEnviroments_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnConnect);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(5, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(827, 325);
            this.panel3.TabIndex = 10;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnConnect.Location = new System.Drawing.Point(711, 285);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(109, 35);
            this.btnConnect.TabIndex = 31;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect2Enviroment_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkTargetDefaultCredentials);
            this.panel5.Controls.Add(this.chkIsTargetOnline);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.txtTargetDom);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.txtTargetPass);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.txtTarget);
            this.panel5.Controls.Add(this.txtTargetUserName);
            this.panel5.Location = new System.Drawing.Point(3, 144);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(817, 135);
            this.panel5.TabIndex = 30;
            this.panel5.Tag = "";
            // 
            // chkTargetDefaultCredentials
            // 
            this.chkTargetDefaultCredentials.AutoSize = true;
            this.chkTargetDefaultCredentials.Checked = true;
            this.chkTargetDefaultCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTargetDefaultCredentials.Location = new System.Drawing.Point(650, 27);
            this.chkTargetDefaultCredentials.Name = "chkTargetDefaultCredentials";
            this.chkTargetDefaultCredentials.Size = new System.Drawing.Size(164, 17);
            this.chkTargetDefaultCredentials.TabIndex = 31;
            this.chkTargetDefaultCredentials.Text = "User Default Credentials";
            this.chkTargetDefaultCredentials.UseVisualStyleBackColor = true;
            this.chkTargetDefaultCredentials.CheckedChanged += new System.EventHandler(this.chkTargetDefaultCredentials_CheckedChanged);
            // 
            // chkIsTargetOnline
            // 
            this.chkIsTargetOnline.AutoSize = true;
            this.chkIsTargetOnline.Location = new System.Drawing.Point(321, 53);
            this.chkIsTargetOnline.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsTargetOnline.Name = "chkIsTargetOnline";
            this.chkIsTargetOnline.Size = new System.Drawing.Size(76, 17);
            this.chkIsTargetOnline.TabIndex = 30;
            this.chkIsTargetOnline.Text = "Is Online";
            this.chkIsTargetOnline.UseVisualStyleBackColor = true;
            this.chkIsTargetOnline.CheckedChanged += new System.EventHandler(this.chkIsTargetOnline_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(3, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Target";
            // 
            // txtTargetDom
            // 
            this.txtTargetDom.Location = new System.Drawing.Point(134, 51);
            this.txtTargetDom.Name = "txtTargetDom";
            this.txtTargetDom.Size = new System.Drawing.Size(172, 20);
            this.txtTargetDom.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Password:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "User Name:";
            // 
            // txtTargetPass
            // 
            this.txtTargetPass.Location = new System.Drawing.Point(134, 103);
            this.txtTargetPass.Name = "txtTargetPass";
            this.txtTargetPass.Size = new System.Drawing.Size(172, 20);
            this.txtTargetPass.TabIndex = 25;
            this.txtTargetPass.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Target URL:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Domain:";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(134, 27);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(510, 20);
            this.txtTarget.TabIndex = 10;
            // 
            // txtTargetUserName
            // 
            this.txtTargetUserName.Location = new System.Drawing.Point(134, 77);
            this.txtTargetUserName.Name = "txtTargetUserName";
            this.txtTargetUserName.Size = new System.Drawing.Size(172, 20);
            this.txtTargetUserName.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkSourceDefaultCredentials);
            this.panel4.Controls.Add(this.chkIsSourceOnline);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtSourceDom);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtSource);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtSourcePass);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtSourceUserName);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(817, 135);
            this.panel4.TabIndex = 29;
            this.panel4.Tag = "";
            // 
            // chkSourceDefaultCredentials
            // 
            this.chkSourceDefaultCredentials.AutoSize = true;
            this.chkSourceDefaultCredentials.Checked = true;
            this.chkSourceDefaultCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSourceDefaultCredentials.Location = new System.Drawing.Point(650, 24);
            this.chkSourceDefaultCredentials.Name = "chkSourceDefaultCredentials";
            this.chkSourceDefaultCredentials.Size = new System.Drawing.Size(164, 17);
            this.chkSourceDefaultCredentials.TabIndex = 30;
            this.chkSourceDefaultCredentials.Text = "User Default Credentials";
            this.chkSourceDefaultCredentials.UseVisualStyleBackColor = true;
            this.chkSourceDefaultCredentials.CheckedChanged += new System.EventHandler(this.chkSourceDefaultCredentials_CheckedChanged);
            // 
            // chkIsSourceOnline
            // 
            this.chkIsSourceOnline.AutoSize = true;
            this.chkIsSourceOnline.Location = new System.Drawing.Point(343, 47);
            this.chkIsSourceOnline.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsSourceOnline.Name = "chkIsSourceOnline";
            this.chkIsSourceOnline.Size = new System.Drawing.Size(76, 17);
            this.chkIsSourceOnline.TabIndex = 29;
            this.chkIsSourceOnline.Text = "Is Online";
            this.chkIsSourceOnline.UseVisualStyleBackColor = true;
            this.chkIsSourceOnline.CheckedChanged += new System.EventHandler(this.chkIsSourceOnline_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(3, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Source";
            // 
            // txtSourceDom
            // 
            this.txtSourceDom.Location = new System.Drawing.Point(134, 47);
            this.txtSourceDom.Name = "txtSourceDom";
            this.txtSourceDom.Size = new System.Drawing.Size(172, 20);
            this.txtSourceDom.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Password:";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(134, 22);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(510, 20);
            this.txtSource.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Source URL:";
            // 
            // txtSourcePass
            // 
            this.txtSourcePass.Location = new System.Drawing.Point(134, 103);
            this.txtSourcePass.Name = "txtSourcePass";
            this.txtSourcePass.Size = new System.Drawing.Size(172, 20);
            this.txtSourcePass.TabIndex = 25;
            this.txtSourcePass.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Domain:";
            // 
            // txtSourceUserName
            // 
            this.txtSourceUserName.Location = new System.Drawing.Point(134, 77);
            this.txtSourceUserName.Name = "txtSourceUserName";
            this.txtSourceUserName.Size = new System.Drawing.Size(172, 20);
            this.txtSourceUserName.TabIndex = 24;
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.butConnectOneEnviroment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 488);
            this.Controls.Add(this.tab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnectForm";
            this.Text = "OurCRMTool";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabOneEnviroment.ResumeLayout(false);
            this.tabOneEnviroment.PerformLayout();
            this.tabTwoEnviroment.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button butConnectOneEnviroment;
        private System.Windows.Forms.TextBox txtDom;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkOnline;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabOneEnviroment;
        private System.Windows.Forms.TabPage tabTwoEnviroment;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkIsTargetOnline;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTargetDom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTargetPass;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.TextBox txtTargetUserName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkIsSourceOnline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSourceDom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSourcePass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSourceUserName;
        private System.Windows.Forms.Button buChangeAttendees;
        private System.Windows.Forms.Button butResetDef;
        private System.Windows.Forms.Button butRoleCompare;
        private System.Windows.Forms.Button butUnusedRoles;
        private System.Windows.Forms.Button butSecurityRolesAnalizer;
        private System.Windows.Forms.Button butCheckDefault;
        private System.Windows.Forms.Button butUserSettingsUpdate;
        private System.Windows.Forms.Button butDefaultTeamSelector;
        private System.Windows.Forms.Button butCompareRecordsInEnviroments;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butChangeRecordStatus;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox chkDefaultCredentials;
        private System.Windows.Forms.CheckBox chkTargetDefaultCredentials;
        private System.Windows.Forms.CheckBox chkSourceDefaultCredentials;
        private System.Windows.Forms.Button butCompareUsersPrvAndTeam;
    }
}

