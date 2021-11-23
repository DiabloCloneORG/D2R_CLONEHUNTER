
namespace D2R_CLONEHUNTER
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrBlizzardPing = new System.Windows.Forms.Timer(this.components);
            this.tabPages = new System.Windows.Forms.TabControl();
            this.tabPageIPSettings = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuildExclusionHelp = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDesiredIPAddress = new System.Windows.Forms.TextBox();
            this.lblCurrentIP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstExcludedIPs = new System.Windows.Forms.ListBox();
            this.lstActiveIPs = new System.Windows.Forms.ListBox();
            this.btnBuildExclusion = new System.Windows.Forms.Button();
            this.tabPageIPLogs = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.gvLoggedIPs = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.txtD2RLauncherPath = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkQuickRestartD2R = new System.Windows.Forms.CheckBox();
            this.chkSaveLoggedIPAddressesAccrossRestart = new System.Windows.Forms.CheckBox();
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart = new System.Windows.Forms.CheckBox();
            this.chkBlizzardPing = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackVolumeChaching = new System.Windows.Forms.TrackBar();
            this.btnTestChaching = new System.Windows.Forms.Button();
            this.chkRingOnFound = new System.Windows.Forms.CheckBox();
            this.chkAutoTrimLogs = new System.Windows.Forms.CheckBox();
            this.chkShowTicks = new System.Windows.Forms.CheckBox();
            this.tabPageStreaming = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.ddStreamInfoTimerDelay = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkWriteTxtTotalTime = new System.Windows.Forms.CheckBox();
            this.chkWriteTxtGameTime = new System.Windows.Forms.CheckBox();
            this.chkWriteTxtTotalGameJoined = new System.Windows.Forms.CheckBox();
            this.tabPageApplicationLogs = new System.Windows.Forms.TabPage();
            this.txtApplicationLogs = new System.Windows.Forms.TextBox();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();
            this.lblStatisticsTotalGames = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblBlizzardPingReply = new System.Windows.Forms.Label();
            this.lblBlizzardPingReplyLabel = new System.Windows.Forms.Label();
            this.lblStatisticsDuration = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblStatisticsStartedOn = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStatisticsMostSeenIP = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblStatisticsTotalUniqueIPs = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabFirewall = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.btnFirewallAllowIPAddressRange = new System.Windows.Forms.Button();
            this.btnFirewallBlockIPAddressRange = new System.Windows.Forms.Button();
            this.lblFirewallHints = new System.Windows.Forms.Label();
            this.linkCidrCalculator = new System.Windows.Forms.LinkLabel();
            this.btnFirewallAllowIPAddressCIDR = new System.Windows.Forms.Button();
            this.btnFirewallBlockIPAddressCIDR = new System.Windows.Forms.Button();
            this.btnFirewallClearAllowedSelectedSubnet = new System.Windows.Forms.Button();
            this.btnFirewallClearAllowedSubnets = new System.Windows.Forms.Button();
            this.lstFirewallAllowedSubnet = new System.Windows.Forms.ListBox();
            this.chkWindowsFirewallBlocking = new System.Windows.Forms.CheckBox();
            this.btnFirewallClearBlockedSelectedSubnet = new System.Windows.Forms.Button();
            this.btnFirewallClearBlockedSubnets = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lstFirewallBlockedSubnets = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnSaveSessionToDisk = new System.Windows.Forms.Button();
            this.tmrTextFileCreations = new System.Windows.Forms.Timer(this.components);
            this.btnResetConfiguration = new System.Windows.Forms.Button();
            this.btnKillAndRestartD2R = new System.Windows.Forms.Button();
            this.chkKeepOnTop = new System.Windows.Forms.CheckBox();
            this.iPAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occurenceCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d2RIpAddressCountEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPages.SuspendLayout();
            this.tabPageIPSettings.SuspendLayout();
            this.tabPageIPLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoggedIPs)).BeginInit();
            this.tabPageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolumeChaching)).BeginInit();
            this.tabPageStreaming.SuspendLayout();
            this.tabPageApplicationLogs.SuspendLayout();
            this.tabPageStatistics.SuspendLayout();
            this.tabFirewall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d2RIpAddressCountEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrBlizzardPing
            // 
            this.tmrBlizzardPing.Enabled = true;
            this.tmrBlizzardPing.Interval = 30000;
            this.tmrBlizzardPing.Tick += new System.EventHandler(this.tmrBlizzardPing_Tick);
            // 
            // tabPages
            // 
            this.tabPages.Controls.Add(this.tabPageIPSettings);
            this.tabPages.Controls.Add(this.tabPageIPLogs);
            this.tabPages.Controls.Add(this.tabPageOptions);
            this.tabPages.Controls.Add(this.tabPageStreaming);
            this.tabPages.Controls.Add(this.tabPageApplicationLogs);
            this.tabPages.Controls.Add(this.tabPageStatistics);
            this.tabPages.Controls.Add(this.tabFirewall);
            this.tabPages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPages.Location = new System.Drawing.Point(8, 8);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(736, 448);
            this.tabPages.TabIndex = 0;
            // 
            // tabPageIPSettings
            // 
            this.tabPageIPSettings.BackColor = System.Drawing.Color.Transparent;
            this.tabPageIPSettings.Controls.Add(this.label1);
            this.tabPageIPSettings.Controls.Add(this.label5);
            this.tabPageIPSettings.Controls.Add(this.btnBuildExclusionHelp);
            this.tabPageIPSettings.Controls.Add(this.label10);
            this.tabPageIPSettings.Controls.Add(this.txtDesiredIPAddress);
            this.tabPageIPSettings.Controls.Add(this.lblCurrentIP);
            this.tabPageIPSettings.Controls.Add(this.label3);
            this.tabPageIPSettings.Controls.Add(this.lstExcludedIPs);
            this.tabPageIPSettings.Controls.Add(this.lstActiveIPs);
            this.tabPageIPSettings.Controls.Add(this.btnBuildExclusion);
            this.tabPageIPSettings.Location = new System.Drawing.Point(4, 30);
            this.tabPageIPSettings.Name = "tabPageIPSettings";
            this.tabPageIPSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIPSettings.Size = new System.Drawing.Size(728, 414);
            this.tabPageIPSettings.TabIndex = 0;
            this.tabPageIPSettings.Text = "IP Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 32);
            this.label1.TabIndex = 87;
            this.label1.Text = "Excluded IPs :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 32);
            this.label5.TabIndex = 86;
            this.label5.Text = "Active IPs :";
            // 
            // btnBuildExclusionHelp
            // 
            this.btnBuildExclusionHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuildExclusionHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuildExclusionHelp.Location = new System.Drawing.Point(392, 320);
            this.btnBuildExclusionHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuildExclusionHelp.Name = "btnBuildExclusionHelp";
            this.btnBuildExclusionHelp.Size = new System.Drawing.Size(56, 38);
            this.btnBuildExclusionHelp.TabIndex = 85;
            this.btnBuildExclusionHelp.Text = "???";
            this.btnBuildExclusionHelp.UseVisualStyleBackColor = false;
            this.btnBuildExclusionHelp.Click += new System.EventHandler(this.btnBuildExclusionHelp_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 32);
            this.label10.TabIndex = 68;
            this.label10.Text = "Desired IP :";
            // 
            // txtDesiredIPAddress
            // 
            this.txtDesiredIPAddress.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesiredIPAddress.Location = new System.Drawing.Point(208, 29);
            this.txtDesiredIPAddress.Name = "txtDesiredIPAddress";
            this.txtDesiredIPAddress.Size = new System.Drawing.Size(197, 39);
            this.txtDesiredIPAddress.TabIndex = 63;
            this.txtDesiredIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCurrentIP
            // 
            this.lblCurrentIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentIP.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentIP.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentIP.Location = new System.Drawing.Point(208, 80);
            this.lblCurrentIP.Name = "lblCurrentIP";
            this.lblCurrentIP.Size = new System.Drawing.Size(197, 38);
            this.lblCurrentIP.TabIndex = 55;
            this.lblCurrentIP.Text = "255.255.255.255";
            this.lblCurrentIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 32);
            this.label3.TabIndex = 54;
            this.label3.Text = "In-Game IP :";
            // 
            // lstExcludedIPs
            // 
            this.lstExcludedIPs.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstExcludedIPs.ForeColor = System.Drawing.Color.Maroon;
            this.lstExcludedIPs.FormattingEnabled = true;
            this.lstExcludedIPs.ItemHeight = 21;
            this.lstExcludedIPs.Location = new System.Drawing.Point(208, 224);
            this.lstExcludedIPs.Name = "lstExcludedIPs";
            this.lstExcludedIPs.ScrollAlwaysVisible = true;
            this.lstExcludedIPs.Size = new System.Drawing.Size(240, 88);
            this.lstExcludedIPs.TabIndex = 52;
            // 
            // lstActiveIPs
            // 
            this.lstActiveIPs.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstActiveIPs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lstActiveIPs.FormattingEnabled = true;
            this.lstActiveIPs.ItemHeight = 21;
            this.lstActiveIPs.Location = new System.Drawing.Point(208, 128);
            this.lstActiveIPs.Name = "lstActiveIPs";
            this.lstActiveIPs.ScrollAlwaysVisible = true;
            this.lstActiveIPs.Size = new System.Drawing.Size(240, 88);
            this.lstActiveIPs.TabIndex = 50;
            // 
            // btnBuildExclusion
            // 
            this.btnBuildExclusion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuildExclusion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuildExclusion.Location = new System.Drawing.Point(232, 320);
            this.btnBuildExclusion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuildExclusion.Name = "btnBuildExclusion";
            this.btnBuildExclusion.Size = new System.Drawing.Size(149, 38);
            this.btnBuildExclusion.TabIndex = 49;
            this.btnBuildExclusion.Text = "Build Exclusion List";
            this.btnBuildExclusion.UseVisualStyleBackColor = false;
            this.btnBuildExclusion.Click += new System.EventHandler(this.btnBuildExclusion_Click);
            // 
            // tabPageIPLogs
            // 
            this.tabPageIPLogs.Controls.Add(this.label13);
            this.tabPageIPLogs.Controls.Add(this.gvLoggedIPs);
            this.tabPageIPLogs.Controls.Add(this.label4);
            this.tabPageIPLogs.Location = new System.Drawing.Point(4, 30);
            this.tabPageIPLogs.Name = "tabPageIPLogs";
            this.tabPageIPLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIPLogs.Size = new System.Drawing.Size(728, 414);
            this.tabPageIPLogs.TabIndex = 1;
            this.tabPageIPLogs.Text = "IP Logs";
            this.tabPageIPLogs.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(16, 376);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(368, 24);
            this.label13.TabIndex = 65;
            this.label13.Text = "Tip: You can sort the results by clicking the column header.";
            // 
            // gvLoggedIPs
            // 
            this.gvLoggedIPs.AllowUserToAddRows = false;
            this.gvLoggedIPs.AllowUserToDeleteRows = false;
            this.gvLoggedIPs.AutoGenerateColumns = false;
            this.gvLoggedIPs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLoggedIPs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iPAddressDataGridViewTextBoxColumn,
            this.occurenceCountDataGridViewTextBoxColumn});
            this.gvLoggedIPs.DataSource = this.d2RIpAddressCountEntityBindingSource;
            this.gvLoggedIPs.Location = new System.Drawing.Point(20, 40);
            this.gvLoggedIPs.MultiSelect = false;
            this.gvLoggedIPs.Name = "gvLoggedIPs";
            this.gvLoggedIPs.ReadOnly = true;
            this.gvLoggedIPs.RowHeadersVisible = false;
            this.gvLoggedIPs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLoggedIPs.Size = new System.Drawing.Size(356, 336);
            this.gvLoggedIPs.TabIndex = 64;
            this.gvLoggedIPs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvLoggedIPs_ColumnHeaderMouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 21);
            this.label4.TabIndex = 63;
            this.label4.Text = "Logged IPs";
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Controls.Add(this.chkKeepOnTop);
            this.tabPageOptions.Controls.Add(this.txtD2RLauncherPath);
            this.tabPageOptions.Controls.Add(this.label20);
            this.tabPageOptions.Controls.Add(this.chkQuickRestartD2R);
            this.tabPageOptions.Controls.Add(this.chkSaveLoggedIPAddressesAccrossRestart);
            this.tabPageOptions.Controls.Add(this.chkSaveTotalGamesAndTotalTimeAcrossRestart);
            this.tabPageOptions.Controls.Add(this.chkBlizzardPing);
            this.tabPageOptions.Controls.Add(this.label11);
            this.tabPageOptions.Controls.Add(this.label8);
            this.tabPageOptions.Controls.Add(this.label6);
            this.tabPageOptions.Controls.Add(this.label9);
            this.tabPageOptions.Controls.Add(this.trackVolumeChaching);
            this.tabPageOptions.Controls.Add(this.btnTestChaching);
            this.tabPageOptions.Controls.Add(this.chkRingOnFound);
            this.tabPageOptions.Controls.Add(this.chkAutoTrimLogs);
            this.tabPageOptions.Controls.Add(this.chkShowTicks);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 30);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOptions.Size = new System.Drawing.Size(728, 414);
            this.tabPageOptions.TabIndex = 2;
            this.tabPageOptions.Text = "Options";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // txtD2RLauncherPath
            // 
            this.txtD2RLauncherPath.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD2RLauncherPath.Location = new System.Drawing.Point(160, 352);
            this.txtD2RLauncherPath.Name = "txtD2RLauncherPath";
            this.txtD2RLauncherPath.Size = new System.Drawing.Size(536, 25);
            this.txtD2RLauncherPath.TabIndex = 82;
            this.txtD2RLauncherPath.TextChanged += new System.EventHandler(this.txtD2RLauncherPath_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(24, 356);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 17);
            this.label20.TabIndex = 81;
            this.label20.Text = "D2R Launcher Path";
            // 
            // chkQuickRestartD2R
            // 
            this.chkQuickRestartD2R.AutoSize = true;
            this.chkQuickRestartD2R.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkQuickRestartD2R.Location = new System.Drawing.Point(24, 326);
            this.chkQuickRestartD2R.Name = "chkQuickRestartD2R";
            this.chkQuickRestartD2R.Size = new System.Drawing.Size(266, 21);
            this.chkQuickRestartD2R.TabIndex = 80;
            this.chkQuickRestartD2R.Text = "Experimental: Enable Quick D2R Restart";
            this.chkQuickRestartD2R.UseVisualStyleBackColor = true;
            this.chkQuickRestartD2R.CheckedChanged += new System.EventHandler(this.chkQuickRestartD2R_CheckedChanged);
            // 
            // chkSaveLoggedIPAddressesAccrossRestart
            // 
            this.chkSaveLoggedIPAddressesAccrossRestart.AutoSize = true;
            this.chkSaveLoggedIPAddressesAccrossRestart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveLoggedIPAddressesAccrossRestart.Location = new System.Drawing.Point(24, 296);
            this.chkSaveLoggedIPAddressesAccrossRestart.Name = "chkSaveLoggedIPAddressesAccrossRestart";
            this.chkSaveLoggedIPAddressesAccrossRestart.Size = new System.Drawing.Size(482, 21);
            this.chkSaveLoggedIPAddressesAccrossRestart.TabIndex = 79;
            this.chkSaveLoggedIPAddressesAccrossRestart.Text = "Save the Logged IP Addresses across Application Restart (Not working yet)";
            this.chkSaveLoggedIPAddressesAccrossRestart.UseVisualStyleBackColor = true;
            this.chkSaveLoggedIPAddressesAccrossRestart.CheckedChanged += new System.EventHandler(this.chkSaveLoggedIPAddressesAccrossRestart_CheckedChanged);
            // 
            // chkSaveTotalGamesAndTotalTimeAcrossRestart
            // 
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.AutoSize = true;
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.Location = new System.Drawing.Point(24, 264);
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.Name = "chkSaveTotalGamesAndTotalTimeAcrossRestart";
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.Size = new System.Drawing.Size(471, 21);
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.TabIndex = 78;
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.Text = "Save the Total Time && the Amount of Runs across CLONEHUNTER Restart";
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.UseVisualStyleBackColor = true;
            this.chkSaveTotalGamesAndTotalTimeAcrossRestart.CheckedChanged += new System.EventHandler(this.chkSaveTotalGamesAndTotalTimeAcrossRestart_CheckedChanged);
            // 
            // chkBlizzardPing
            // 
            this.chkBlizzardPing.AutoSize = true;
            this.chkBlizzardPing.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBlizzardPing.Location = new System.Drawing.Point(24, 232);
            this.chkBlizzardPing.Name = "chkBlizzardPing";
            this.chkBlizzardPing.Size = new System.Drawing.Size(300, 21);
            this.chkBlizzardPing.TabIndex = 77;
            this.chkBlizzardPing.Text = "Verify your ping with Blizzard.com for latency";
            this.chkBlizzardPing.UseVisualStyleBackColor = true;
            this.chkBlizzardPing.CheckedChanged += new System.EventHandler(this.chkBlizzardPing_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(248, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 17);
            this.label11.TabIndex = 76;
            this.label11.Text = "50%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(408, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 75;
            this.label8.Text = "100%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 74;
            this.label6.Text = "0%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 73;
            this.label9.Text = "Volume";
            // 
            // trackVolumeChaching
            // 
            this.trackVolumeChaching.LargeChange = 20;
            this.trackVolumeChaching.Location = new System.Drawing.Point(88, 144);
            this.trackVolumeChaching.Maximum = 100;
            this.trackVolumeChaching.Name = "trackVolumeChaching";
            this.trackVolumeChaching.Size = new System.Drawing.Size(351, 45);
            this.trackVolumeChaching.SmallChange = 10;
            this.trackVolumeChaching.TabIndex = 72;
            this.trackVolumeChaching.TickFrequency = 10;
            this.trackVolumeChaching.Value = 50;
            this.trackVolumeChaching.ValueChanged += new System.EventHandler(this.trackVolumeChaching_ValueChanged);
            // 
            // btnTestChaching
            // 
            this.btnTestChaching.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestChaching.Location = new System.Drawing.Point(368, 104);
            this.btnTestChaching.Name = "btnTestChaching";
            this.btnTestChaching.Size = new System.Drawing.Size(72, 27);
            this.btnTestChaching.TabIndex = 71;
            this.btnTestChaching.Text = "Test";
            this.btnTestChaching.UseVisualStyleBackColor = true;
            this.btnTestChaching.Click += new System.EventHandler(this.btnTestChaching_Click);
            // 
            // chkRingOnFound
            // 
            this.chkRingOnFound.AutoSize = true;
            this.chkRingOnFound.Checked = true;
            this.chkRingOnFound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRingOnFound.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRingOnFound.Location = new System.Drawing.Point(24, 107);
            this.chkRingOnFound.Name = "chkRingOnFound";
            this.chkRingOnFound.Size = new System.Drawing.Size(328, 21);
            this.chkRingOnFound.TabIndex = 70;
            this.chkRingOnFound.Text = "Ring when the Desired Game IP Address is Found";
            this.chkRingOnFound.UseVisualStyleBackColor = true;
            this.chkRingOnFound.CheckedChanged += new System.EventHandler(this.chkRingOnFound_CheckedChanged);
            // 
            // chkAutoTrimLogs
            // 
            this.chkAutoTrimLogs.Checked = true;
            this.chkAutoTrimLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoTrimLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoTrimLogs.Location = new System.Drawing.Point(24, 56);
            this.chkAutoTrimLogs.Name = "chkAutoTrimLogs";
            this.chkAutoTrimLogs.Size = new System.Drawing.Size(464, 40);
            this.chkAutoTrimLogs.TabIndex = 69;
            this.chkAutoTrimLogs.Text = "Auto Trim Application Logs making sure that the application never run out of memo" +
    "ry if you leave the application running for days.";
            this.chkAutoTrimLogs.UseVisualStyleBackColor = true;
            this.chkAutoTrimLogs.CheckedChanged += new System.EventHandler(this.chkAutoTrimLogs_CheckedChanged);
            // 
            // chkShowTicks
            // 
            this.chkShowTicks.AutoSize = true;
            this.chkShowTicks.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowTicks.Location = new System.Drawing.Point(24, 24);
            this.chkShowTicks.Name = "chkShowTicks";
            this.chkShowTicks.Size = new System.Drawing.Size(415, 21);
            this.chkShowTicks.TabIndex = 68;
            this.chkShowTicks.Text = "Show Timer Ticks in the Application logs (Every Execution Cycle)";
            this.chkShowTicks.UseVisualStyleBackColor = true;
            this.chkShowTicks.CheckedChanged += new System.EventHandler(this.chkShowTicks_CheckedChanged_1);
            // 
            // tabPageStreaming
            // 
            this.tabPageStreaming.Controls.Add(this.label2);
            this.tabPageStreaming.Controls.Add(this.ddStreamInfoTimerDelay);
            this.tabPageStreaming.Controls.Add(this.label18);
            this.tabPageStreaming.Controls.Add(this.chkWriteTxtTotalTime);
            this.tabPageStreaming.Controls.Add(this.chkWriteTxtGameTime);
            this.tabPageStreaming.Controls.Add(this.chkWriteTxtTotalGameJoined);
            this.tabPageStreaming.Location = new System.Drawing.Point(4, 30);
            this.tabPageStreaming.Name = "tabPageStreaming";
            this.tabPageStreaming.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStreaming.Size = new System.Drawing.Size(728, 414);
            this.tabPageStreaming.TabIndex = 5;
            this.tabPageStreaming.Text = "Streaming";
            this.tabPageStreaming.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 21);
            this.label2.TabIndex = 84;
            this.label2.Text = "ms";
            // 
            // ddStreamInfoTimerDelay
            // 
            this.ddStreamInfoTimerDelay.FormattingEnabled = true;
            this.ddStreamInfoTimerDelay.Items.AddRange(new object[] {
            "50",
            "100",
            "150",
            "200",
            "250",
            "300",
            "350",
            "400",
            "450",
            "500"});
            this.ddStreamInfoTimerDelay.Location = new System.Drawing.Point(160, 172);
            this.ddStreamInfoTimerDelay.Name = "ddStreamInfoTimerDelay";
            this.ddStreamInfoTimerDelay.Size = new System.Drawing.Size(80, 29);
            this.ddStreamInfoTimerDelay.TabIndex = 83;
            this.ddStreamInfoTimerDelay.SelectedIndexChanged += new System.EventHandler(this.ddStreamInfoTimerDelay_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 176);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(137, 21);
            this.label18.TabIndex = 82;
            this.label18.Text = "Write Task Delay";
            // 
            // chkWriteTxtTotalTime
            // 
            this.chkWriteTxtTotalTime.AutoSize = true;
            this.chkWriteTxtTotalTime.Checked = true;
            this.chkWriteTxtTotalTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWriteTxtTotalTime.Location = new System.Drawing.Point(24, 120);
            this.chkWriteTxtTotalTime.Name = "chkWriteTxtTotalTime";
            this.chkWriteTxtTotalTime.Size = new System.Drawing.Size(543, 25);
            this.chkWriteTxtTotalTime.TabIndex = 80;
            this.chkWriteTxtTotalTime.Text = "Generate a TXT file with the amount of total time of application run";
            this.chkWriteTxtTotalTime.UseVisualStyleBackColor = true;
            this.chkWriteTxtTotalTime.CheckedChanged += new System.EventHandler(this.chkWriteTxtTotalTime_CheckedChanged);
            // 
            // chkWriteTxtGameTime
            // 
            this.chkWriteTxtGameTime.AutoSize = true;
            this.chkWriteTxtGameTime.Checked = true;
            this.chkWriteTxtGameTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWriteTxtGameTime.Location = new System.Drawing.Point(24, 72);
            this.chkWriteTxtGameTime.Name = "chkWriteTxtGameTime";
            this.chkWriteTxtGameTime.Size = new System.Drawing.Size(516, 25);
            this.chkWriteTxtGameTime.TabIndex = 79;
            this.chkWriteTxtGameTime.Text = "Generate a TXT file with the amount of time in the current game";
            this.chkWriteTxtGameTime.UseVisualStyleBackColor = true;
            this.chkWriteTxtGameTime.CheckedChanged += new System.EventHandler(this.chkWriteTxtGameTime_CheckedChanged);
            // 
            // chkWriteTxtTotalGameJoined
            // 
            this.chkWriteTxtTotalGameJoined.AutoSize = true;
            this.chkWriteTxtTotalGameJoined.Checked = true;
            this.chkWriteTxtTotalGameJoined.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWriteTxtTotalGameJoined.Location = new System.Drawing.Point(24, 24);
            this.chkWriteTxtTotalGameJoined.Name = "chkWriteTxtTotalGameJoined";
            this.chkWriteTxtTotalGameJoined.Size = new System.Drawing.Size(512, 25);
            this.chkWriteTxtTotalGameJoined.TabIndex = 78;
            this.chkWriteTxtTotalGameJoined.Text = "Generate a TXT file with the amount of games joined (# of runs)";
            this.chkWriteTxtTotalGameJoined.UseVisualStyleBackColor = true;
            this.chkWriteTxtTotalGameJoined.CheckedChanged += new System.EventHandler(this.chkWriteTxtTotalGameJoined_CheckedChanged);
            // 
            // tabPageApplicationLogs
            // 
            this.tabPageApplicationLogs.Controls.Add(this.txtApplicationLogs);
            this.tabPageApplicationLogs.Location = new System.Drawing.Point(4, 30);
            this.tabPageApplicationLogs.Name = "tabPageApplicationLogs";
            this.tabPageApplicationLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApplicationLogs.Size = new System.Drawing.Size(728, 414);
            this.tabPageApplicationLogs.TabIndex = 3;
            this.tabPageApplicationLogs.Text = "Application Logs";
            this.tabPageApplicationLogs.UseVisualStyleBackColor = true;
            this.tabPageApplicationLogs.Click += new System.EventHandler(this.tabPageApplicationLogs_Click);
            // 
            // txtApplicationLogs
            // 
            this.txtApplicationLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationLogs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationLogs.Location = new System.Drawing.Point(8, 8);
            this.txtApplicationLogs.Multiline = true;
            this.txtApplicationLogs.Name = "txtApplicationLogs";
            this.txtApplicationLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApplicationLogs.Size = new System.Drawing.Size(712, 400);
            this.txtApplicationLogs.TabIndex = 60;
            // 
            // tabPageStatistics
            // 
            this.tabPageStatistics.Controls.Add(this.lblStatisticsTotalGames);
            this.tabPageStatistics.Controls.Add(this.label25);
            this.tabPageStatistics.Controls.Add(this.lblBlizzardPingReply);
            this.tabPageStatistics.Controls.Add(this.lblBlizzardPingReplyLabel);
            this.tabPageStatistics.Controls.Add(this.lblStatisticsDuration);
            this.tabPageStatistics.Controls.Add(this.label17);
            this.tabPageStatistics.Controls.Add(this.lblStatisticsStartedOn);
            this.tabPageStatistics.Controls.Add(this.label14);
            this.tabPageStatistics.Controls.Add(this.lblStatisticsMostSeenIP);
            this.tabPageStatistics.Controls.Add(this.label16);
            this.tabPageStatistics.Controls.Add(this.lblStatisticsTotalUniqueIPs);
            this.tabPageStatistics.Controls.Add(this.label12);
            this.tabPageStatistics.Location = new System.Drawing.Point(4, 30);
            this.tabPageStatistics.Name = "tabPageStatistics";
            this.tabPageStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistics.Size = new System.Drawing.Size(728, 414);
            this.tabPageStatistics.TabIndex = 4;
            this.tabPageStatistics.Text = "Statistics";
            this.tabPageStatistics.UseVisualStyleBackColor = true;
            // 
            // lblStatisticsTotalGames
            // 
            this.lblStatisticsTotalGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsTotalGames.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsTotalGames.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsTotalGames.Location = new System.Drawing.Point(173, 24);
            this.lblStatisticsTotalGames.Name = "lblStatisticsTotalGames";
            this.lblStatisticsTotalGames.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsTotalGames.TabIndex = 96;
            this.lblStatisticsTotalGames.Text = "0";
            this.lblStatisticsTotalGames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(24, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(143, 30);
            this.label25.TabIndex = 95;
            this.label25.Text = "Total Games";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBlizzardPingReply
            // 
            this.lblBlizzardPingReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBlizzardPingReply.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlizzardPingReply.ForeColor = System.Drawing.Color.Navy;
            this.lblBlizzardPingReply.Location = new System.Drawing.Point(173, 264);
            this.lblBlizzardPingReply.Name = "lblBlizzardPingReply";
            this.lblBlizzardPingReply.Size = new System.Drawing.Size(186, 30);
            this.lblBlizzardPingReply.TabIndex = 94;
            this.lblBlizzardPingReply.Text = "0";
            this.lblBlizzardPingReply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBlizzardPingReplyLabel
            // 
            this.lblBlizzardPingReplyLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlizzardPingReplyLabel.Location = new System.Drawing.Point(24, 264);
            this.lblBlizzardPingReplyLabel.Name = "lblBlizzardPingReplyLabel";
            this.lblBlizzardPingReplyLabel.Size = new System.Drawing.Size(143, 30);
            this.lblBlizzardPingReplyLabel.TabIndex = 93;
            this.lblBlizzardPingReplyLabel.Text = "Blizzard.com Ping";
            this.lblBlizzardPingReplyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsDuration
            // 
            this.lblStatisticsDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsDuration.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsDuration.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsDuration.Location = new System.Drawing.Point(173, 168);
            this.lblStatisticsDuration.Name = "lblStatisticsDuration";
            this.lblStatisticsDuration.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsDuration.TabIndex = 92;
            this.lblStatisticsDuration.Text = "0";
            this.lblStatisticsDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(24, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 30);
            this.label17.TabIndex = 91;
            this.label17.Text = "Duration";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsStartedOn
            // 
            this.lblStatisticsStartedOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsStartedOn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsStartedOn.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsStartedOn.Location = new System.Drawing.Point(173, 136);
            this.lblStatisticsStartedOn.Name = "lblStatisticsStartedOn";
            this.lblStatisticsStartedOn.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsStartedOn.TabIndex = 90;
            this.lblStatisticsStartedOn.Text = "0";
            this.lblStatisticsStartedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 30);
            this.label14.TabIndex = 89;
            this.label14.Text = "Session Started On";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsMostSeenIP
            // 
            this.lblStatisticsMostSeenIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsMostSeenIP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsMostSeenIP.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsMostSeenIP.Location = new System.Drawing.Point(173, 88);
            this.lblStatisticsMostSeenIP.Name = "lblStatisticsMostSeenIP";
            this.lblStatisticsMostSeenIP.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsMostSeenIP.TabIndex = 88;
            this.lblStatisticsMostSeenIP.Text = "0";
            this.lblStatisticsMostSeenIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(24, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 30);
            this.label16.TabIndex = 87;
            this.label16.Text = "Most Seen IP";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsTotalUniqueIPs
            // 
            this.lblStatisticsTotalUniqueIPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsTotalUniqueIPs.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsTotalUniqueIPs.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsTotalUniqueIPs.Location = new System.Drawing.Point(173, 56);
            this.lblStatisticsTotalUniqueIPs.Name = "lblStatisticsTotalUniqueIPs";
            this.lblStatisticsTotalUniqueIPs.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsTotalUniqueIPs.TabIndex = 86;
            this.lblStatisticsTotalUniqueIPs.Text = "0";
            this.lblStatisticsTotalUniqueIPs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 30);
            this.label12.TabIndex = 85;
            this.label12.Text = "Total Unique IP";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabFirewall
            // 
            this.tabFirewall.Controls.Add(this.label19);
            this.tabFirewall.Controls.Add(this.btnFirewallAllowIPAddressRange);
            this.tabFirewall.Controls.Add(this.btnFirewallBlockIPAddressRange);
            this.tabFirewall.Controls.Add(this.lblFirewallHints);
            this.tabFirewall.Controls.Add(this.linkCidrCalculator);
            this.tabFirewall.Controls.Add(this.btnFirewallAllowIPAddressCIDR);
            this.tabFirewall.Controls.Add(this.btnFirewallBlockIPAddressCIDR);
            this.tabFirewall.Controls.Add(this.btnFirewallClearAllowedSelectedSubnet);
            this.tabFirewall.Controls.Add(this.btnFirewallClearAllowedSubnets);
            this.tabFirewall.Controls.Add(this.lstFirewallAllowedSubnet);
            this.tabFirewall.Controls.Add(this.chkWindowsFirewallBlocking);
            this.tabFirewall.Controls.Add(this.btnFirewallClearBlockedSelectedSubnet);
            this.tabFirewall.Controls.Add(this.btnFirewallClearBlockedSubnets);
            this.tabFirewall.Controls.Add(this.label15);
            this.tabFirewall.Controls.Add(this.lstFirewallBlockedSubnets);
            this.tabFirewall.Controls.Add(this.label7);
            this.tabFirewall.Controls.Add(this.label21);
            this.tabFirewall.Location = new System.Drawing.Point(4, 30);
            this.tabFirewall.Name = "tabFirewall";
            this.tabFirewall.Size = new System.Drawing.Size(728, 414);
            this.tabFirewall.TabIndex = 6;
            this.tabFirewall.Text = "Windows Firewall";
            this.tabFirewall.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Maroon;
            this.label19.Location = new System.Drawing.Point(16, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(696, 21);
            this.label19.TabIndex = 111;
            this.label19.Text = "Keep in mind that Windows Firewall DO NOT support overlapsing allow rule over blo" +
    "cking rules (*)\r\n";
            // 
            // btnFirewallAllowIPAddressRange
            // 
            this.btnFirewallAllowIPAddressRange.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallAllowIPAddressRange.Location = new System.Drawing.Point(568, 168);
            this.btnFirewallAllowIPAddressRange.Name = "btnFirewallAllowIPAddressRange";
            this.btnFirewallAllowIPAddressRange.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallAllowIPAddressRange.TabIndex = 110;
            this.btnFirewallAllowIPAddressRange.Text = "Allow IP Range";
            this.btnFirewallAllowIPAddressRange.UseVisualStyleBackColor = true;
            this.btnFirewallAllowIPAddressRange.Click += new System.EventHandler(this.btnFirewallAllowIPAddressRange_Click);
            // 
            // btnFirewallBlockIPAddressRange
            // 
            this.btnFirewallBlockIPAddressRange.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallBlockIPAddressRange.Location = new System.Drawing.Point(208, 168);
            this.btnFirewallBlockIPAddressRange.Name = "btnFirewallBlockIPAddressRange";
            this.btnFirewallBlockIPAddressRange.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallBlockIPAddressRange.TabIndex = 109;
            this.btnFirewallBlockIPAddressRange.Text = "Block IP Range";
            this.btnFirewallBlockIPAddressRange.UseVisualStyleBackColor = true;
            this.btnFirewallBlockIPAddressRange.Click += new System.EventHandler(this.btnFirewallBlockIPAddressRange_Click);
            // 
            // lblFirewallHints
            // 
            this.lblFirewallHints.AutoSize = true;
            this.lblFirewallHints.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirewallHints.Location = new System.Drawing.Point(16, 368);
            this.lblFirewallHints.Name = "lblFirewallHints";
            this.lblFirewallHints.Size = new System.Drawing.Size(135, 21);
            this.lblFirewallHints.TabIndex = 107;
            this.lblFirewallHints.Text = "CIDR Calculator : ";
            // 
            // linkCidrCalculator
            // 
            this.linkCidrCalculator.AutoSize = true;
            this.linkCidrCalculator.Location = new System.Drawing.Point(160, 368);
            this.linkCidrCalculator.Name = "linkCidrCalculator";
            this.linkCidrCalculator.Size = new System.Drawing.Size(360, 21);
            this.linkCidrCalculator.TabIndex = 106;
            this.linkCidrCalculator.TabStop = true;
            this.linkCidrCalculator.Text = "https://account.arin.net/public/cidrCalculator";
            this.linkCidrCalculator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCidrCalculator_LinkClicked);
            // 
            // btnFirewallAllowIPAddressCIDR
            // 
            this.btnFirewallAllowIPAddressCIDR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallAllowIPAddressCIDR.Location = new System.Drawing.Point(568, 136);
            this.btnFirewallAllowIPAddressCIDR.Name = "btnFirewallAllowIPAddressCIDR";
            this.btnFirewallAllowIPAddressCIDR.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallAllowIPAddressCIDR.TabIndex = 105;
            this.btnFirewallAllowIPAddressCIDR.Text = "Allow IP CIDR";
            this.btnFirewallAllowIPAddressCIDR.UseVisualStyleBackColor = true;
            this.btnFirewallAllowIPAddressCIDR.Click += new System.EventHandler(this.btnFirewallAllowIPAddressCIDR_Click);
            // 
            // btnFirewallBlockIPAddressCIDR
            // 
            this.btnFirewallBlockIPAddressCIDR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallBlockIPAddressCIDR.Location = new System.Drawing.Point(208, 136);
            this.btnFirewallBlockIPAddressCIDR.Name = "btnFirewallBlockIPAddressCIDR";
            this.btnFirewallBlockIPAddressCIDR.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallBlockIPAddressCIDR.TabIndex = 104;
            this.btnFirewallBlockIPAddressCIDR.Text = "Block IP CIDR";
            this.btnFirewallBlockIPAddressCIDR.UseVisualStyleBackColor = true;
            this.btnFirewallBlockIPAddressCIDR.Click += new System.EventHandler(this.btnFirewallBlockIPAddressCIDR_Click);
            // 
            // btnFirewallClearAllowedSelectedSubnet
            // 
            this.btnFirewallClearAllowedSelectedSubnet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallClearAllowedSelectedSubnet.Location = new System.Drawing.Point(568, 248);
            this.btnFirewallClearAllowedSelectedSubnet.Name = "btnFirewallClearAllowedSelectedSubnet";
            this.btnFirewallClearAllowedSelectedSubnet.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallClearAllowedSelectedSubnet.TabIndex = 101;
            this.btnFirewallClearAllowedSelectedSubnet.Text = "Unallow Subnet";
            this.btnFirewallClearAllowedSelectedSubnet.UseVisualStyleBackColor = true;
            this.btnFirewallClearAllowedSelectedSubnet.Click += new System.EventHandler(this.btnFirewallClearAllowedSelectedSubnet_Click);
            // 
            // btnFirewallClearAllowedSubnets
            // 
            this.btnFirewallClearAllowedSubnets.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallClearAllowedSubnets.Location = new System.Drawing.Point(568, 216);
            this.btnFirewallClearAllowedSubnets.Name = "btnFirewallClearAllowedSubnets";
            this.btnFirewallClearAllowedSubnets.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallClearAllowedSubnets.TabIndex = 100;
            this.btnFirewallClearAllowedSubnets.Text = "Unallow All";
            this.btnFirewallClearAllowedSubnets.UseVisualStyleBackColor = true;
            this.btnFirewallClearAllowedSubnets.Click += new System.EventHandler(this.btnFirewallClearAllowedSubnets_Click);
            // 
            // lstFirewallAllowedSubnet
            // 
            this.lstFirewallAllowedSubnet.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFirewallAllowedSubnet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lstFirewallAllowedSubnet.FormattingEnabled = true;
            this.lstFirewallAllowedSubnet.ItemHeight = 21;
            this.lstFirewallAllowedSubnet.Location = new System.Drawing.Point(376, 136);
            this.lstFirewallAllowedSubnet.Name = "lstFirewallAllowedSubnet";
            this.lstFirewallAllowedSubnet.ScrollAlwaysVisible = true;
            this.lstFirewallAllowedSubnet.Size = new System.Drawing.Size(184, 214);
            this.lstFirewallAllowedSubnet.TabIndex = 98;
            // 
            // chkWindowsFirewallBlocking
            // 
            this.chkWindowsFirewallBlocking.AutoSize = true;
            this.chkWindowsFirewallBlocking.Location = new System.Drawing.Point(16, 16);
            this.chkWindowsFirewallBlocking.Name = "chkWindowsFirewallBlocking";
            this.chkWindowsFirewallBlocking.Size = new System.Drawing.Size(668, 25);
            this.chkWindowsFirewallBlocking.TabIndex = 97;
            this.chkWindowsFirewallBlocking.Text = "Use the Windows Firewall Blocking Feature (Only work if you use Windows Firewall)" +
    "";
            this.chkWindowsFirewallBlocking.UseVisualStyleBackColor = true;
            this.chkWindowsFirewallBlocking.CheckedChanged += new System.EventHandler(this.chkWindowsFirewallBlocking_CheckedChanged);
            // 
            // btnFirewallClearBlockedSelectedSubnet
            // 
            this.btnFirewallClearBlockedSelectedSubnet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallClearBlockedSelectedSubnet.Location = new System.Drawing.Point(208, 256);
            this.btnFirewallClearBlockedSelectedSubnet.Name = "btnFirewallClearBlockedSelectedSubnet";
            this.btnFirewallClearBlockedSelectedSubnet.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallClearBlockedSelectedSubnet.TabIndex = 92;
            this.btnFirewallClearBlockedSelectedSubnet.Text = "Unblock Subnet";
            this.btnFirewallClearBlockedSelectedSubnet.UseVisualStyleBackColor = true;
            this.btnFirewallClearBlockedSelectedSubnet.Click += new System.EventHandler(this.btnFirewallClearBlockedSelectedSubnet_Click);
            // 
            // btnFirewallClearBlockedSubnets
            // 
            this.btnFirewallClearBlockedSubnets.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallClearBlockedSubnets.Location = new System.Drawing.Point(208, 224);
            this.btnFirewallClearBlockedSubnets.Name = "btnFirewallClearBlockedSubnets";
            this.btnFirewallClearBlockedSubnets.Size = new System.Drawing.Size(136, 32);
            this.btnFirewallClearBlockedSubnets.TabIndex = 90;
            this.btnFirewallClearBlockedSubnets.Text = "Unblock All";
            this.btnFirewallClearBlockedSubnets.UseVisualStyleBackColor = true;
            this.btnFirewallClearBlockedSubnets.Click += new System.EventHandler(this.btnFirewallClearBlockedSubnets_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(696, 40);
            this.label15.TabIndex = 89;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // lstFirewallBlockedSubnets
            // 
            this.lstFirewallBlockedSubnets.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFirewallBlockedSubnets.ForeColor = System.Drawing.Color.Maroon;
            this.lstFirewallBlockedSubnets.FormattingEnabled = true;
            this.lstFirewallBlockedSubnets.ItemHeight = 21;
            this.lstFirewallBlockedSubnets.Location = new System.Drawing.Point(16, 136);
            this.lstFirewallBlockedSubnets.Name = "lstFirewallBlockedSubnets";
            this.lstFirewallBlockedSubnets.ScrollAlwaysVisible = true;
            this.lstFirewallBlockedSubnets.Size = new System.Drawing.Size(184, 214);
            this.lstFirewallBlockedSubnets.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 17);
            this.label7.TabIndex = 88;
            this.label7.Text = "Blocked IP Addresses Subnet";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(376, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(187, 17);
            this.label21.TabIndex = 99;
            this.label21.Text = "Allowed IP Addresses Subnet";
            // 
            // btnSaveSessionToDisk
            // 
            this.btnSaveSessionToDisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveSessionToDisk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSessionToDisk.Location = new System.Drawing.Point(592, 464);
            this.btnSaveSessionToDisk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveSessionToDisk.Name = "btnSaveSessionToDisk";
            this.btnSaveSessionToDisk.Size = new System.Drawing.Size(151, 32);
            this.btnSaveSessionToDisk.TabIndex = 62;
            this.btnSaveSessionToDisk.Text = "Save Report to Disk";
            this.btnSaveSessionToDisk.UseVisualStyleBackColor = false;
            // 
            // tmrTextFileCreations
            // 
            this.tmrTextFileCreations.Enabled = true;
            this.tmrTextFileCreations.Interval = 50;
            this.tmrTextFileCreations.Tick += new System.EventHandler(this.tmrTextFileCreations_Tick);
            // 
            // btnResetConfiguration
            // 
            this.btnResetConfiguration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetConfiguration.Location = new System.Drawing.Point(8, 464);
            this.btnResetConfiguration.Name = "btnResetConfiguration";
            this.btnResetConfiguration.Size = new System.Drawing.Size(216, 32);
            this.btnResetConfiguration.TabIndex = 63;
            this.btnResetConfiguration.Text = "Delete && Reset Configuration";
            this.btnResetConfiguration.UseVisualStyleBackColor = true;
            this.btnResetConfiguration.Click += new System.EventHandler(this.btnResetConfiguration_Click);
            // 
            // btnKillAndRestartD2R
            // 
            this.btnKillAndRestartD2R.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnKillAndRestartD2R.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKillAndRestartD2R.Location = new System.Drawing.Point(280, 464);
            this.btnKillAndRestartD2R.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKillAndRestartD2R.Name = "btnKillAndRestartD2R";
            this.btnKillAndRestartD2R.Size = new System.Drawing.Size(252, 32);
            this.btnKillAndRestartD2R.TabIndex = 88;
            this.btnKillAndRestartD2R.Text = "Kill D2R && Restart after 6 seconds";
            this.btnKillAndRestartD2R.UseVisualStyleBackColor = false;
            this.btnKillAndRestartD2R.Click += new System.EventHandler(this.btnKillAndRestartD2R_Click);
            // 
            // chkKeepOnTop
            // 
            this.chkKeepOnTop.AutoSize = true;
            this.chkKeepOnTop.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKeepOnTop.Location = new System.Drawing.Point(520, 24);
            this.chkKeepOnTop.Name = "chkKeepOnTop";
            this.chkKeepOnTop.Size = new System.Drawing.Size(180, 21);
            this.chkKeepOnTop.TabIndex = 83;
            this.chkKeepOnTop.Text = "Keep this window on-top";
            this.chkKeepOnTop.UseVisualStyleBackColor = true;
            this.chkKeepOnTop.CheckedChanged += new System.EventHandler(this.chkKeepOnTop_CheckedChanged);
            // 
            // iPAddressDataGridViewTextBoxColumn
            // 
            this.iPAddressDataGridViewTextBoxColumn.DataPropertyName = "IPAddress";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.iPAddressDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.iPAddressDataGridViewTextBoxColumn.HeaderText = "IP Address";
            this.iPAddressDataGridViewTextBoxColumn.Name = "iPAddressDataGridViewTextBoxColumn";
            this.iPAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.iPAddressDataGridViewTextBoxColumn.Width = 200;
            // 
            // occurenceCountDataGridViewTextBoxColumn
            // 
            this.occurenceCountDataGridViewTextBoxColumn.DataPropertyName = "OccurenceCount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.occurenceCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.occurenceCountDataGridViewTextBoxColumn.HeaderText = "Count";
            this.occurenceCountDataGridViewTextBoxColumn.Name = "occurenceCountDataGridViewTextBoxColumn";
            this.occurenceCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // d2RIpAddressCountEntityBindingSource
            // 
            this.d2RIpAddressCountEntityBindingSource.DataSource = typeof(D2R_CLONEHUNTER.D2R_IpAddressCountEntity);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(753, 503);
            this.Controls.Add(this.btnKillAndRestartD2R);
            this.Controls.Add(this.btnResetConfiguration);
            this.Controls.Add(this.btnSaveSessionToDisk);
            this.Controls.Add(this.tabPages);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiabloClone.ORG CLONEHUNTER - Discord Server @ https://discord.gg/FQrpzV8Smv";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPages.ResumeLayout(false);
            this.tabPageIPSettings.ResumeLayout(false);
            this.tabPageIPSettings.PerformLayout();
            this.tabPageIPLogs.ResumeLayout(false);
            this.tabPageIPLogs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLoggedIPs)).EndInit();
            this.tabPageOptions.ResumeLayout(false);
            this.tabPageOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolumeChaching)).EndInit();
            this.tabPageStreaming.ResumeLayout(false);
            this.tabPageStreaming.PerformLayout();
            this.tabPageApplicationLogs.ResumeLayout(false);
            this.tabPageApplicationLogs.PerformLayout();
            this.tabPageStatistics.ResumeLayout(false);
            this.tabFirewall.ResumeLayout(false);
            this.tabFirewall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d2RIpAddressCountEntityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource d2RIpAddressCountEntityBindingSource;
        private System.Windows.Forms.Timer tmrBlizzardPing;
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.TabPage tabPageIPSettings;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDesiredIPAddress;
        private System.Windows.Forms.Label lblCurrentIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstExcludedIPs;
        private System.Windows.Forms.ListBox lstActiveIPs;
        private System.Windows.Forms.Button btnBuildExclusion;
        private System.Windows.Forms.TabPage tabPageIPLogs;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView gvLoggedIPs;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn occurenceCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackVolumeChaching;
        private System.Windows.Forms.Button btnTestChaching;
        private System.Windows.Forms.CheckBox chkRingOnFound;
        private System.Windows.Forms.CheckBox chkAutoTrimLogs;
        private System.Windows.Forms.CheckBox chkShowTicks;
        private System.Windows.Forms.TabPage tabPageApplicationLogs;
        private System.Windows.Forms.Button btnBuildExclusionHelp;
        private System.Windows.Forms.TextBox txtApplicationLogs;
        private System.Windows.Forms.TabPage tabPageStatistics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBlizzardPing;
        private System.Windows.Forms.TabPage tabPageStreaming;
        private System.Windows.Forms.CheckBox chkWriteTxtTotalTime;
        private System.Windows.Forms.CheckBox chkWriteTxtGameTime;
        private System.Windows.Forms.CheckBox chkWriteTxtTotalGameJoined;
        private System.Windows.Forms.Label lblStatisticsTotalGames;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblBlizzardPingReply;
        private System.Windows.Forms.Label lblBlizzardPingReplyLabel;
        private System.Windows.Forms.Label lblStatisticsDuration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblStatisticsStartedOn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStatisticsMostSeenIP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblStatisticsTotalUniqueIPs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSaveSessionToDisk;
        private System.Windows.Forms.Timer tmrTextFileCreations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddStreamInfoTimerDelay;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnResetConfiguration;
        private System.Windows.Forms.CheckBox chkSaveLoggedIPAddressesAccrossRestart;
        private System.Windows.Forms.CheckBox chkSaveTotalGamesAndTotalTimeAcrossRestart;
        private System.Windows.Forms.TabPage tabFirewall;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstFirewallBlockedSubnets;
        private System.Windows.Forms.Button btnFirewallClearBlockedSelectedSubnet;
        private System.Windows.Forms.Button btnFirewallClearBlockedSubnets;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkWindowsFirewallBlocking;
        private System.Windows.Forms.Button btnFirewallAllowIPAddressCIDR;
        private System.Windows.Forms.Button btnFirewallBlockIPAddressCIDR;
        private System.Windows.Forms.Button btnFirewallClearAllowedSelectedSubnet;
        private System.Windows.Forms.Button btnFirewallClearAllowedSubnets;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListBox lstFirewallAllowedSubnet;
        private System.Windows.Forms.Label lblFirewallHints;
        private System.Windows.Forms.LinkLabel linkCidrCalculator;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnFirewallAllowIPAddressRange;
        private System.Windows.Forms.Button btnFirewallBlockIPAddressRange;
        private System.Windows.Forms.CheckBox chkQuickRestartD2R;
        private System.Windows.Forms.TextBox txtD2RLauncherPath;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnKillAndRestartD2R;
        private System.Windows.Forms.CheckBox chkKeepOnTop;
    }
}

