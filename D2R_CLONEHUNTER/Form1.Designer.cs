
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnBuildExclusion = new System.Windows.Forms.Button();
            this.lstActiveIPs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstExcludedIPs = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentIP = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApplicationLogs = new System.Windows.Forms.TextBox();
            this.chkShowTicks = new System.Windows.Forms.CheckBox();
            this.chkAutoTrimLogs = new System.Windows.Forms.CheckBox();
            this.btnSaveSessionToDisk = new System.Windows.Forms.Button();
            this.gvLoggedIPs = new System.Windows.Forms.DataGridView();
            this.txtDesiredIPAddress = new System.Windows.Forms.TextBox();
            this.chkRingOnFound = new System.Windows.Forms.CheckBox();
            this.btnTestChaching = new System.Windows.Forms.Button();
            this.trackVolumeChaching = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblStatisticsTotalUniqueIPs = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStatisticsStartedOn = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblStatisticsMostSeenIP = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblStatisticsDuration = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblPingReply = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBlizzardPingReply = new System.Windows.Forms.Label();
            this.lblBlizzardPingReplyLabel = new System.Windows.Forms.Label();
            this.lblStatisticsTotalGames = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tmrBlizzardPing = new System.Windows.Forms.Timer(this.components);
            this.iPAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occurenceCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d2RIpAddressCountEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvLoggedIPs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolumeChaching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2RIpAddressCountEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnBuildExclusion
            // 
            this.btnBuildExclusion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuildExclusion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuildExclusion.Location = new System.Drawing.Point(209, 369);
            this.btnBuildExclusion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuildExclusion.Name = "btnBuildExclusion";
            this.btnBuildExclusion.Size = new System.Drawing.Size(149, 38);
            this.btnBuildExclusion.TabIndex = 2;
            this.btnBuildExclusion.Text = "Build Exclusion List";
            this.btnBuildExclusion.UseVisualStyleBackColor = false;
            this.btnBuildExclusion.Click += new System.EventHandler(this.btnBuildExclusion_Click);
            // 
            // lstActiveIPs
            // 
            this.lstActiveIPs.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstActiveIPs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lstActiveIPs.FormattingEnabled = true;
            this.lstActiveIPs.ItemHeight = 21;
            this.lstActiveIPs.Location = new System.Drawing.Point(19, 183);
            this.lstActiveIPs.Name = "lstActiveIPs";
            this.lstActiveIPs.ScrollAlwaysVisible = true;
            this.lstActiveIPs.Size = new System.Drawing.Size(169, 88);
            this.lstActiveIPs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(15, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Active IPs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(15, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Excluded IPs";
            // 
            // lstExcludedIPs
            // 
            this.lstExcludedIPs.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstExcludedIPs.ForeColor = System.Drawing.Color.Maroon;
            this.lstExcludedIPs.FormattingEnabled = true;
            this.lstExcludedIPs.ItemHeight = 21;
            this.lstExcludedIPs.Location = new System.Drawing.Point(19, 298);
            this.lstExcludedIPs.Name = "lstExcludedIPs";
            this.lstExcludedIPs.ScrollAlwaysVisible = true;
            this.lstExcludedIPs.Size = new System.Drawing.Size(169, 109);
            this.lstExcludedIPs.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "In-Game IP :";
            // 
            // lblCurrentIP
            // 
            this.lblCurrentIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentIP.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentIP.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentIP.Location = new System.Drawing.Point(181, 101);
            this.lblCurrentIP.Name = "lblCurrentIP";
            this.lblCurrentIP.Size = new System.Drawing.Size(197, 38);
            this.lblCurrentIP.TabIndex = 8;
            this.lblCurrentIP.Text = "255.255.255.255";
            this.lblCurrentIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(556, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Logged IPs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Application Logs";
            // 
            // txtApplicationLogs
            // 
            this.txtApplicationLogs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationLogs.Location = new System.Drawing.Point(19, 441);
            this.txtApplicationLogs.Multiline = true;
            this.txtApplicationLogs.Name = "txtApplicationLogs";
            this.txtApplicationLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApplicationLogs.Size = new System.Drawing.Size(844, 158);
            this.txtApplicationLogs.TabIndex = 12;
            // 
            // chkShowTicks
            // 
            this.chkShowTicks.AutoSize = true;
            this.chkShowTicks.Location = new System.Drawing.Point(214, 185);
            this.chkShowTicks.Name = "chkShowTicks";
            this.chkShowTicks.Size = new System.Drawing.Size(150, 25);
            this.chkShowTicks.TabIndex = 13;
            this.chkShowTicks.Text = "Show Timer Ticks";
            this.chkShowTicks.UseVisualStyleBackColor = true;
            this.chkShowTicks.CheckedChanged += new System.EventHandler(this.chkShowTicks_CheckedChanged);
            // 
            // chkAutoTrimLogs
            // 
            this.chkAutoTrimLogs.AutoSize = true;
            this.chkAutoTrimLogs.Checked = true;
            this.chkAutoTrimLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoTrimLogs.Location = new System.Drawing.Point(214, 222);
            this.chkAutoTrimLogs.Name = "chkAutoTrimLogs";
            this.chkAutoTrimLogs.Size = new System.Drawing.Size(134, 25);
            this.chkAutoTrimLogs.TabIndex = 14;
            this.chkAutoTrimLogs.Text = "Auto Trim Logs";
            this.chkAutoTrimLogs.UseVisualStyleBackColor = true;
            // 
            // btnSaveSessionToDisk
            // 
            this.btnSaveSessionToDisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSaveSessionToDisk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSessionToDisk.Location = new System.Drawing.Point(366, 369);
            this.btnSaveSessionToDisk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveSessionToDisk.Name = "btnSaveSessionToDisk";
            this.btnSaveSessionToDisk.Size = new System.Drawing.Size(143, 38);
            this.btnSaveSessionToDisk.TabIndex = 15;
            this.btnSaveSessionToDisk.Text = "Save Report to Disk";
            this.btnSaveSessionToDisk.UseVisualStyleBackColor = false;
            this.btnSaveSessionToDisk.Click += new System.EventHandler(this.btnSaveSessionToDisk_Click);
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
            this.gvLoggedIPs.Location = new System.Drawing.Point(560, 39);
            this.gvLoggedIPs.MultiSelect = false;
            this.gvLoggedIPs.Name = "gvLoggedIPs";
            this.gvLoggedIPs.ReadOnly = true;
            this.gvLoggedIPs.RowHeadersVisible = false;
            this.gvLoggedIPs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLoggedIPs.Size = new System.Drawing.Size(303, 368);
            this.gvLoggedIPs.TabIndex = 16;
            this.gvLoggedIPs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvLoggedIPs_ColumnHeaderMouseClick);
            // 
            // txtDesiredIPAddress
            // 
            this.txtDesiredIPAddress.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesiredIPAddress.Location = new System.Drawing.Point(181, 36);
            this.txtDesiredIPAddress.Name = "txtDesiredIPAddress";
            this.txtDesiredIPAddress.Size = new System.Drawing.Size(197, 39);
            this.txtDesiredIPAddress.TabIndex = 20;
            this.txtDesiredIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkRingOnFound
            // 
            this.chkRingOnFound.AutoSize = true;
            this.chkRingOnFound.Checked = true;
            this.chkRingOnFound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRingOnFound.Location = new System.Drawing.Point(214, 259);
            this.chkRingOnFound.Name = "chkRingOnFound";
            this.chkRingOnFound.Size = new System.Drawing.Size(228, 25);
            this.chkRingOnFound.TabIndex = 22;
            this.chkRingOnFound.Text = "Ring when Game IP is Found";
            this.chkRingOnFound.UseVisualStyleBackColor = true;
            // 
            // btnTestChaching
            // 
            this.btnTestChaching.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestChaching.Location = new System.Drawing.Point(448, 257);
            this.btnTestChaching.Name = "btnTestChaching";
            this.btnTestChaching.Size = new System.Drawing.Size(41, 27);
            this.btnTestChaching.TabIndex = 23;
            this.btnTestChaching.Text = "Test";
            this.btnTestChaching.UseVisualStyleBackColor = true;
            this.btnTestChaching.Click += new System.EventHandler(this.btnTestChaching_Click);
            // 
            // trackVolumeChaching
            // 
            this.trackVolumeChaching.LargeChange = 20;
            this.trackVolumeChaching.Location = new System.Drawing.Point(279, 299);
            this.trackVolumeChaching.Maximum = 100;
            this.trackVolumeChaching.Name = "trackVolumeChaching";
            this.trackVolumeChaching.Size = new System.Drawing.Size(210, 45);
            this.trackVolumeChaching.SmallChange = 10;
            this.trackVolumeChaching.TabIndex = 24;
            this.trackVolumeChaching.TickFrequency = 10;
            this.trackVolumeChaching.Value = 50;
            this.trackVolumeChaching.Scroll += new System.EventHandler(this.trackVolumeChaching_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Volume";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 32);
            this.label10.TabIndex = 26;
            this.label10.Text = "Desired IP :";
            // 
            // lblStatisticsTotalUniqueIPs
            // 
            this.lblStatisticsTotalUniqueIPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsTotalUniqueIPs.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsTotalUniqueIPs.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsTotalUniqueIPs.Location = new System.Drawing.Point(1040, 72);
            this.lblStatisticsTotalUniqueIPs.Name = "lblStatisticsTotalUniqueIPs";
            this.lblStatisticsTotalUniqueIPs.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsTotalUniqueIPs.TabIndex = 31;
            this.lblStatisticsTotalUniqueIPs.Text = "0";
            this.lblStatisticsTotalUniqueIPs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(891, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 30);
            this.label12.TabIndex = 30;
            this.label12.Text = "Total Unique IP";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsStartedOn
            // 
            this.lblStatisticsStartedOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsStartedOn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsStartedOn.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsStartedOn.Location = new System.Drawing.Point(1040, 152);
            this.lblStatisticsStartedOn.Name = "lblStatisticsStartedOn";
            this.lblStatisticsStartedOn.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsStartedOn.TabIndex = 35;
            this.lblStatisticsStartedOn.Text = "0";
            this.lblStatisticsStartedOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(891, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 30);
            this.label14.TabIndex = 34;
            this.label14.Text = "Session Started On";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsMostSeenIP
            // 
            this.lblStatisticsMostSeenIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsMostSeenIP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsMostSeenIP.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsMostSeenIP.Location = new System.Drawing.Point(1040, 104);
            this.lblStatisticsMostSeenIP.Name = "lblStatisticsMostSeenIP";
            this.lblStatisticsMostSeenIP.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsMostSeenIP.TabIndex = 33;
            this.lblStatisticsMostSeenIP.Text = "0";
            this.lblStatisticsMostSeenIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(891, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 30);
            this.label16.TabIndex = 32;
            this.label16.Text = "Most Seen IP";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsDuration
            // 
            this.lblStatisticsDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsDuration.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsDuration.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsDuration.Location = new System.Drawing.Point(1040, 184);
            this.lblStatisticsDuration.Name = "lblStatisticsDuration";
            this.lblStatisticsDuration.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsDuration.TabIndex = 37;
            this.lblStatisticsDuration.Text = "0";
            this.lblStatisticsDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(891, 184);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 30);
            this.label17.TabIndex = 36;
            this.label17.Text = "Duration";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPingReply
            // 
            this.lblPingReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPingReply.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPingReply.ForeColor = System.Drawing.Color.Navy;
            this.lblPingReply.Location = new System.Drawing.Point(384, 101);
            this.lblPingReply.Name = "lblPingReply";
            this.lblPingReply.Size = new System.Drawing.Size(142, 38);
            this.lblPingReply.TabIndex = 38;
            this.lblPingReply.Text = "N/A";
            this.lblPingReply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(384, 139);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(142, 15);
            this.label19.TabIndex = 39;
            this.label19.Text = "Latency";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(181, 142);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(197, 15);
            this.label20.TabIndex = 40;
            this.label20.Text = "IP Address";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(181, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "IP Address";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBlizzardPingReply
            // 
            this.lblBlizzardPingReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBlizzardPingReply.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlizzardPingReply.ForeColor = System.Drawing.Color.Navy;
            this.lblBlizzardPingReply.Location = new System.Drawing.Point(1040, 280);
            this.lblBlizzardPingReply.Name = "lblBlizzardPingReply";
            this.lblBlizzardPingReply.Size = new System.Drawing.Size(186, 30);
            this.lblBlizzardPingReply.TabIndex = 46;
            this.lblBlizzardPingReply.Text = "0";
            this.lblBlizzardPingReply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBlizzardPingReplyLabel
            // 
            this.lblBlizzardPingReplyLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlizzardPingReplyLabel.Location = new System.Drawing.Point(891, 280);
            this.lblBlizzardPingReplyLabel.Name = "lblBlizzardPingReplyLabel";
            this.lblBlizzardPingReplyLabel.Size = new System.Drawing.Size(143, 30);
            this.lblBlizzardPingReplyLabel.TabIndex = 45;
            this.lblBlizzardPingReplyLabel.Text = "Blizzard.com Ping";
            this.lblBlizzardPingReplyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatisticsTotalGames
            // 
            this.lblStatisticsTotalGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatisticsTotalGames.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatisticsTotalGames.ForeColor = System.Drawing.Color.Navy;
            this.lblStatisticsTotalGames.Location = new System.Drawing.Point(1040, 40);
            this.lblStatisticsTotalGames.Name = "lblStatisticsTotalGames";
            this.lblStatisticsTotalGames.Size = new System.Drawing.Size(186, 30);
            this.lblStatisticsTotalGames.TabIndex = 48;
            this.lblStatisticsTotalGames.Text = "0";
            this.lblStatisticsTotalGames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(891, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(143, 30);
            this.label25.TabIndex = 47;
            this.label25.Text = "Total Games";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrBlizzardPing
            // 
            this.tmrBlizzardPing.Enabled = true;
            this.tmrBlizzardPing.Interval = 30000;
            this.tmrBlizzardPing.Tick += new System.EventHandler(this.tmrBlizzardPing_Tick);
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
            this.occurenceCountDataGridViewTextBoxColumn.Width = 65;
            // 
            // d2RIpAddressCountEntityBindingSource
            // 
            this.d2RIpAddressCountEntityBindingSource.DataSource = typeof(D2R_CLONEHUNTER.D2R_IpAddressCountEntity);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 611);
            this.Controls.Add(this.lblStatisticsTotalGames);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblBlizzardPingReply);
            this.Controls.Add(this.lblBlizzardPingReplyLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblPingReply);
            this.Controls.Add(this.lblStatisticsDuration);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblStatisticsStartedOn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblStatisticsMostSeenIP);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblStatisticsTotalUniqueIPs);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackVolumeChaching);
            this.Controls.Add(this.btnTestChaching);
            this.Controls.Add(this.chkRingOnFound);
            this.Controls.Add(this.txtDesiredIPAddress);
            this.Controls.Add(this.gvLoggedIPs);
            this.Controls.Add(this.btnSaveSessionToDisk);
            this.Controls.Add(this.chkAutoTrimLogs);
            this.Controls.Add(this.chkShowTicks);
            this.Controls.Add(this.txtApplicationLogs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCurrentIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstExcludedIPs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstActiveIPs);
            this.Controls.Add(this.btnBuildExclusion);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiabloClone.ORG Active D2R Connections Viewer - Join Our Discord Server @ https:/" +
    "/discord.gg/FQrpzV8Smv";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvLoggedIPs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolumeChaching)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2RIpAddressCountEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnBuildExclusion;
        private System.Windows.Forms.ListBox lstActiveIPs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstExcludedIPs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApplicationLogs;
        private System.Windows.Forms.CheckBox chkShowTicks;
        private System.Windows.Forms.CheckBox chkAutoTrimLogs;
        private System.Windows.Forms.Button btnSaveSessionToDisk;
        private System.Windows.Forms.DataGridView gvLoggedIPs;
        private System.Windows.Forms.TextBox txtDesiredIPAddress;
        private System.Windows.Forms.CheckBox chkRingOnFound;
        private System.Windows.Forms.Button btnTestChaching;
        private System.Windows.Forms.TrackBar trackVolumeChaching;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource d2RIpAddressCountEntityBindingSource;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn occurenceCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblStatisticsTotalUniqueIPs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStatisticsStartedOn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStatisticsMostSeenIP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblStatisticsDuration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblPingReply;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBlizzardPingReply;
        private System.Windows.Forms.Label lblBlizzardPingReplyLabel;
        private System.Windows.Forms.Label lblStatisticsTotalGames;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Timer tmrBlizzardPing;
    }
}

