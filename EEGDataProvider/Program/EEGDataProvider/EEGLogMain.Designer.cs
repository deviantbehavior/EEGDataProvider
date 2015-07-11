namespace EEGLog
{
    partial class EEGLogMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EEGLogMain));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.splitContainerStatus = new System.Windows.Forms.SplitContainer();
            this.labelConnectionStrength = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelLastActivity = new System.Windows.Forms.Label();
            this.labelMidiStatus = new System.Windows.Forms.Label();
            this.labelHeadSetStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelHeadSetState = new System.Windows.Forms.Label();
            this.progressBarEEGSignalStrength = new System.Windows.Forms.ProgressBar();
            this.labelLastActivityMessage = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRecordLog = new System.Windows.Forms.TabPage();
            this.grpComments = new System.Windows.Forms.GroupBox();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lstComments = new System.Windows.Forms.ListBox();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.nudMinConnectionStrength = new System.Windows.Forms.NumericUpDown();
            this.cbMinConnectionStrength = new System.Windows.Forms.CheckBox();
            this.panelDemoModeControls = new System.Windows.Forms.Panel();
            this.lblLogLength2 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblCurrentLogPlaying = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblNumRecordings = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnDemo = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnPlayLog = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.panelLiveDataControls = new System.Windows.Forms.Panel();
            this.txtParticipant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelReplayLogsControls = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSelectLogFile = new System.Windows.Forms.Button();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.lblLogLength = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxHeadsetProperties = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectDataFolder = new System.Windows.Forms.Button();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.txtDataDir = new System.Windows.Forms.TextBox();
            this.tabPageMonitorData = new System.Windows.Forms.TabPage();
            this.tabControlDataVisualization = new System.Windows.Forms.TabControl();
            this.tabPlotsRaw = new System.Windows.Forms.TabPage();
            this.tabPlotsNormalized = new System.Windows.Forms.TabPage();
            this.tabPlotsUsed = new System.Windows.Forms.TabPage();
            this.tabNumeric = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridColumnRaw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridColumnAvg15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridColumnNormalized = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridColumnNormalizedAverage15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridColumnOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRaw = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSignal = new System.Windows.Forms.TextBox();
            this.tabPagePeripherals = new System.Windows.Forms.TabPage();
            this.tabControl123 = new System.Windows.Forms.TabControl();
            this.tabPageMidi = new System.Windows.Forms.TabPage();
            this.mMidiHandler = new EEGLog.MidiHandling.MidiHandler();
            this.tabPagSerial = new System.Windows.Forms.TabPage();
            this.textBoxSerialLog = new System.Windows.Forms.TextBox();
            this.panelSerialHostBtns = new System.Windows.Forms.Panel();
            this.btnStartSerialHost = new System.Windows.Forms.Button();
            this.labelComPort = new System.Windows.Forms.Label();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.tabPageOsc = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbWaitForUpdateFromArduino = new System.Windows.Forms.CheckBox();
            this.textBoxOscLog = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelControl = new System.Windows.Forms.Panel();
            this.label46 = new System.Windows.Forms.Label();
            this.trackBarMasterVolume = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.trackBarMeditationVolume = new System.Windows.Forms.TrackBar();
            this.label37 = new System.Windows.Forms.Label();
            this.trackBarAttentionVolume = new System.Windows.Forms.TrackBar();
            this.label38 = new System.Windows.Forms.Label();
            this.trackBarFx3Param2 = new System.Windows.Forms.TrackBar();
            this.label39 = new System.Windows.Forms.Label();
            this.trackBarFx3Param1 = new System.Windows.Forms.TrackBar();
            this.label40 = new System.Windows.Forms.Label();
            this.trackBarFx2Param3 = new System.Windows.Forms.TrackBar();
            this.label41 = new System.Windows.Forms.Label();
            this.trackBarFx2Param2 = new System.Windows.Forms.TrackBar();
            this.label42 = new System.Windows.Forms.Label();
            this.trackBarFx2Param1 = new System.Windows.Forms.TrackBar();
            this.label43 = new System.Windows.Forms.Label();
            this.trackBarFx1Param3 = new System.Windows.Forms.TrackBar();
            this.label44 = new System.Windows.Forms.Label();
            this.trackBarFx1Param2 = new System.Windows.Forms.TrackBar();
            this.label45 = new System.Windows.Forms.Label();
            this.trackBarFx1Param1 = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.trackBarOffsetDelta = new System.Windows.Forms.TrackBar();
            this.label29 = new System.Windows.Forms.Label();
            this.trackBarOffsetTheta = new System.Windows.Forms.TrackBar();
            this.label26 = new System.Windows.Forms.Label();
            this.trackBarOffsetAttention = new System.Windows.Forms.TrackBar();
            this.label27 = new System.Windows.Forms.Label();
            this.trackBarOffsetMeditation = new System.Windows.Forms.TrackBar();
            this.label24 = new System.Windows.Forms.Label();
            this.trackBarOffsetGammaH = new System.Windows.Forms.TrackBar();
            this.label25 = new System.Windows.Forms.Label();
            this.trackBarOffsetGammaL = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarOffsetBetaH = new System.Windows.Forms.TrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.trackBarOffsetBetaL = new System.Windows.Forms.TrackBar();
            this.label20 = new System.Windows.Forms.Label();
            this.trackBarOffsetAlphaH = new System.Windows.Forms.TrackBar();
            this.label23 = new System.Windows.Forms.Label();
            this.trackBarOffsetAlphaL = new System.Windows.Forms.TrackBar();
            this.groupBoxStripConfig = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCushionOutline = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.trackBarCushionOutlineStrip = new System.Windows.Forms.TrackBar();
            this.labelBottomRightStrip = new System.Windows.Forms.Label();
            this.trackBarBottomRightStrip = new System.Windows.Forms.TrackBar();
            this.labelTopLeftStrip = new System.Windows.Forms.Label();
            this.trackBarTopLeftStrip = new System.Windows.Forms.TrackBar();
            this.groupBoxStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).BeginInit();
            this.splitContainerStatus.Panel1.SuspendLayout();
            this.splitContainerStatus.Panel2.SuspendLayout();
            this.splitContainerStatus.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageRecordLog.SuspendLayout();
            this.grpComments.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinConnectionStrength)).BeginInit();
            this.panelDemoModeControls.SuspendLayout();
            this.panelLiveDataControls.SuspendLayout();
            this.panelReplayLogsControls.SuspendLayout();
            this.groupBoxHeadsetProperties.SuspendLayout();
            this.tabPageMonitorData.SuspendLayout();
            this.tabControlDataVisualization.SuspendLayout();
            this.tabNumeric.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPagePeripherals.SuspendLayout();
            this.tabControl123.SuspendLayout();
            this.tabPageMidi.SuspendLayout();
            this.tabPagSerial.SuspendLayout();
            this.panelSerialHostBtns.SuspendLayout();
            this.tabPageOsc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMeditationVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAttentionVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx3Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx3Param1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx2Param3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx2Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx2Param1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx1Param3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx1Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx1Param1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetDelta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetTheta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetAttention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetMeditation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetGammaH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetGammaL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetBetaH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetBetaL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetAlphaH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetAlphaL)).BeginInit();
            this.groupBoxStripConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCushionOutlineStrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBottomRightStrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTopLeftStrip)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.splitContainerStatus);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxStatus.Location = new System.Drawing.Point(0, 388);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(986, 95);
            this.groupBoxStatus.TabIndex = 28;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // splitContainerStatus
            // 
            this.splitContainerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStatus.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerStatus.IsSplitterFixed = true;
            this.splitContainerStatus.Location = new System.Drawing.Point(3, 16);
            this.splitContainerStatus.Name = "splitContainerStatus";
            // 
            // splitContainerStatus.Panel1
            // 
            this.splitContainerStatus.Panel1.Controls.Add(this.labelConnectionStrength);
            this.splitContainerStatus.Panel1.Controls.Add(this.label7);
            this.splitContainerStatus.Panel1.Controls.Add(this.labelElapsedTime);
            this.splitContainerStatus.Panel1.Controls.Add(this.labelTime);
            this.splitContainerStatus.Panel1.Controls.Add(this.labelLastActivity);
            this.splitContainerStatus.Panel1.Controls.Add(this.labelMidiStatus);
            this.splitContainerStatus.Panel1.Controls.Add(this.labelHeadSetStatus);
            this.splitContainerStatus.Panel1.Controls.Add(this.label4);
            this.splitContainerStatus.Panel1.Controls.Add(this.labelHeadSetState);
            // 
            // splitContainerStatus.Panel2
            // 
            this.splitContainerStatus.Panel2.Controls.Add(this.progressBarEEGSignalStrength);
            this.splitContainerStatus.Panel2.Controls.Add(this.labelLastActivityMessage);
            this.splitContainerStatus.Size = new System.Drawing.Size(980, 76);
            this.splitContainerStatus.SplitterDistance = 198;
            this.splitContainerStatus.TabIndex = 8;
            // 
            // labelConnectionStrength
            // 
            this.labelConnectionStrength.Location = new System.Drawing.Point(109, 18);
            this.labelConnectionStrength.Name = "labelConnectionStrength";
            this.labelConnectionStrength.Size = new System.Drawing.Size(87, 13);
            this.labelConnectionStrength.TabIndex = 15;
            this.labelConnectionStrength.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Headset strength:";
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.Location = new System.Drawing.Point(109, 48);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(87, 13);
            this.labelElapsedTime.TabIndex = 13;
            this.labelElapsedTime.Text = "00:00";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(2, 48);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(33, 13);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "Time:";
            // 
            // labelLastActivity
            // 
            this.labelLastActivity.AutoSize = true;
            this.labelLastActivity.Location = new System.Drawing.Point(2, 61);
            this.labelLastActivity.Name = "labelLastActivity";
            this.labelLastActivity.Size = new System.Drawing.Size(66, 13);
            this.labelLastActivity.TabIndex = 11;
            this.labelLastActivity.Text = "Last activity:";
            // 
            // labelMidiStatus
            // 
            this.labelMidiStatus.Location = new System.Drawing.Point(109, 33);
            this.labelMidiStatus.Name = "labelMidiStatus";
            this.labelMidiStatus.Size = new System.Drawing.Size(87, 13);
            this.labelMidiStatus.TabIndex = 10;
            this.labelMidiStatus.Text = "Not connected";
            // 
            // labelHeadSetStatus
            // 
            this.labelHeadSetStatus.Location = new System.Drawing.Point(109, 3);
            this.labelHeadSetStatus.Name = "labelHeadSetStatus";
            this.labelHeadSetStatus.Size = new System.Drawing.Size(87, 13);
            this.labelHeadSetStatus.TabIndex = 9;
            this.labelHeadSetStatus.Text = "Not connected";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Midi in peripheral:";
            // 
            // labelHeadSetState
            // 
            this.labelHeadSetState.AutoSize = true;
            this.labelHeadSetState.Location = new System.Drawing.Point(2, 3);
            this.labelHeadSetState.Name = "labelHeadSetState";
            this.labelHeadSetState.Size = new System.Drawing.Size(76, 13);
            this.labelHeadSetState.TabIndex = 7;
            this.labelHeadSetState.Text = "Headset state:";
            // 
            // progressBarEEGSignalStrength
            // 
            this.progressBarEEGSignalStrength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarEEGSignalStrength.Location = new System.Drawing.Point(0, 0);
            this.progressBarEEGSignalStrength.Name = "progressBarEEGSignalStrength";
            this.progressBarEEGSignalStrength.Size = new System.Drawing.Size(778, 63);
            this.progressBarEEGSignalStrength.Step = 1;
            this.progressBarEEGSignalStrength.TabIndex = 11;
            // 
            // labelLastActivityMessage
            // 
            this.labelLastActivityMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelLastActivityMessage.Location = new System.Drawing.Point(0, 63);
            this.labelLastActivityMessage.Name = "labelLastActivityMessage";
            this.labelLastActivityMessage.Size = new System.Drawing.Size(778, 13);
            this.labelLastActivityMessage.TabIndex = 10;
            this.labelLastActivityMessage.Text = "None";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageRecordLog);
            this.tabControl.Controls.Add(this.tabPageMonitorData);
            this.tabControl.Controls.Add(this.tabPagePeripherals);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(986, 388);
            this.tabControl.TabIndex = 29;
            // 
            // tabPageRecordLog
            // 
            this.tabPageRecordLog.Controls.Add(this.grpComments);
            this.tabPageRecordLog.Controls.Add(this.groupBoxMode);
            this.tabPageRecordLog.Controls.Add(this.groupBoxHeadsetProperties);
            this.tabPageRecordLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecordLog.Name = "tabPageRecordLog";
            this.tabPageRecordLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecordLog.Size = new System.Drawing.Size(978, 362);
            this.tabPageRecordLog.TabIndex = 0;
            this.tabPageRecordLog.Text = "Data Acquisition";
            this.tabPageRecordLog.UseVisualStyleBackColor = true;
            // 
            // grpComments
            // 
            this.grpComments.Controls.Add(this.btnAddComment);
            this.grpComments.Controls.Add(this.txtComment);
            this.grpComments.Controls.Add(this.lstComments);
            this.grpComments.Location = new System.Drawing.Point(443, 6);
            this.grpComments.Name = "grpComments";
            this.grpComments.Size = new System.Drawing.Size(535, 378);
            this.grpComments.TabIndex = 35;
            this.grpComments.TabStop = false;
            this.grpComments.Text = "Activity Notes";
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(6, 15);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(101, 23);
            this.btnAddComment.TabIndex = 2;
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.UseVisualStyleBackColor = true;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(113, 17);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(414, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lstComments
            // 
            this.lstComments.FormattingEnabled = true;
            this.lstComments.Location = new System.Drawing.Point(6, 49);
            this.lstComments.Name = "lstComments";
            this.lstComments.Size = new System.Drawing.Size(521, 316);
            this.lstComments.TabIndex = 0;
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.nudMinConnectionStrength);
            this.groupBoxMode.Controls.Add(this.cbMinConnectionStrength);
            this.groupBoxMode.Controls.Add(this.panelDemoModeControls);
            this.groupBoxMode.Controls.Add(this.btnDemo);
            this.groupBoxMode.Controls.Add(this.btnRecord);
            this.groupBoxMode.Controls.Add(this.btnPlayLog);
            this.groupBoxMode.Controls.Add(this.btnMonitor);
            this.groupBoxMode.Controls.Add(this.panelLiveDataControls);
            this.groupBoxMode.Controls.Add(this.panelReplayLogsControls);
            this.groupBoxMode.Location = new System.Drawing.Point(8, 86);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(429, 236);
            this.groupBoxMode.TabIndex = 38;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // nudMinConnectionStrength
            // 
            this.nudMinConnectionStrength.Location = new System.Drawing.Point(226, 212);
            this.nudMinConnectionStrength.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.nudMinConnectionStrength.Name = "nudMinConnectionStrength";
            this.nudMinConnectionStrength.Size = new System.Drawing.Size(50, 20);
            this.nudMinConnectionStrength.TabIndex = 39;
            // 
            // cbMinConnectionStrength
            // 
            this.cbMinConnectionStrength.AutoSize = true;
            this.cbMinConnectionStrength.Location = new System.Drawing.Point(11, 213);
            this.cbMinConnectionStrength.Name = "cbMinConnectionStrength";
            this.cbMinConnectionStrength.Size = new System.Drawing.Size(216, 17);
            this.cbMinConnectionStrength.TabIndex = 38;
            this.cbMinConnectionStrength.Text = "Must have minimum connection strength";
            this.cbMinConnectionStrength.UseVisualStyleBackColor = true;
            // 
            // panelDemoModeControls
            // 
            this.panelDemoModeControls.Controls.Add(this.lblLogLength2);
            this.panelDemoModeControls.Controls.Add(this.label32);
            this.panelDemoModeControls.Controls.Add(this.lblCurrentLogPlaying);
            this.panelDemoModeControls.Controls.Add(this.label30);
            this.panelDemoModeControls.Controls.Add(this.lblNumRecordings);
            this.panelDemoModeControls.Controls.Add(this.label31);
            this.panelDemoModeControls.Location = new System.Drawing.Point(69, 144);
            this.panelDemoModeControls.Name = "panelDemoModeControls";
            this.panelDemoModeControls.Size = new System.Drawing.Size(360, 54);
            this.panelDemoModeControls.TabIndex = 37;
            // 
            // lblLogLength2
            // 
            this.lblLogLength2.AutoSize = true;
            this.lblLogLength2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogLength2.Location = new System.Drawing.Point(120, 36);
            this.lblLogLength2.Name = "lblLogLength2";
            this.lblLogLength2.Size = new System.Drawing.Size(10, 13);
            this.lblLogLength2.TabIndex = 31;
            this.lblLogLength2.Text = "-";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(3, 35);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(102, 13);
            this.label32.TabIndex = 30;
            this.label32.Text = "Length of recording:";
            // 
            // lblCurrentLogPlaying
            // 
            this.lblCurrentLogPlaying.AutoSize = true;
            this.lblCurrentLogPlaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLogPlaying.Location = new System.Drawing.Point(120, 21);
            this.lblCurrentLogPlaying.Name = "lblCurrentLogPlaying";
            this.lblCurrentLogPlaying.Size = new System.Drawing.Size(10, 13);
            this.lblCurrentLogPlaying.TabIndex = 29;
            this.lblCurrentLogPlaying.Text = "-";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(3, 20);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(87, 13);
            this.label30.TabIndex = 28;
            this.label30.Text = "Currently playing:";
            // 
            // lblNumRecordings
            // 
            this.lblNumRecordings.AutoSize = true;
            this.lblNumRecordings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordings.Location = new System.Drawing.Point(120, 7);
            this.lblNumRecordings.Name = "lblNumRecordings";
            this.lblNumRecordings.Size = new System.Drawing.Size(10, 13);
            this.lblNumRecordings.TabIndex = 27;
            this.lblNumRecordings.Text = "-";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(3, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(111, 13);
            this.label31.TabIndex = 26;
            this.label31.Text = "Number of recordings:";
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(7, 144);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(57, 23);
            this.btnDemo.TabIndex = 36;
            this.btnDemo.Text = "Demo";
            this.btnDemo.UseVisualStyleBackColor = true;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(6, 16);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(57, 22);
            this.btnRecord.TabIndex = 23;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            // 
            // btnPlayLog
            // 
            this.btnPlayLog.Location = new System.Drawing.Point(6, 56);
            this.btnPlayLog.Name = "btnPlayLog";
            this.btnPlayLog.Size = new System.Drawing.Size(57, 23);
            this.btnPlayLog.TabIndex = 25;
            this.btnPlayLog.Text = "Play";
            this.btnPlayLog.UseVisualStyleBackColor = true;
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(7, 115);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(57, 23);
            this.btnMonitor.TabIndex = 26;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            // 
            // panelLiveDataControls
            // 
            this.panelLiveDataControls.Controls.Add(this.txtParticipant);
            this.panelLiveDataControls.Controls.Add(this.label3);
            this.panelLiveDataControls.Location = new System.Drawing.Point(69, 16);
            this.panelLiveDataControls.Name = "panelLiveDataControls";
            this.panelLiveDataControls.Size = new System.Drawing.Size(360, 32);
            this.panelLiveDataControls.TabIndex = 35;
            // 
            // txtParticipant
            // 
            this.txtParticipant.Location = new System.Drawing.Point(77, 3);
            this.txtParticipant.Name = "txtParticipant";
            this.txtParticipant.Size = new System.Drawing.Size(242, 20);
            this.txtParticipant.TabIndex = 36;
            this.txtParticipant.Text = "Test";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Participant:";
            // 
            // panelReplayLogsControls
            // 
            this.panelReplayLogsControls.Controls.Add(this.label15);
            this.panelReplayLogsControls.Controls.Add(this.btnSelectLogFile);
            this.panelReplayLogsControls.Controls.Add(this.txtLogFile);
            this.panelReplayLogsControls.Controls.Add(this.lblLogLength);
            this.panelReplayLogsControls.Controls.Add(this.label16);
            this.panelReplayLogsControls.Location = new System.Drawing.Point(69, 56);
            this.panelReplayLogsControls.Name = "panelReplayLogsControls";
            this.panelReplayLogsControls.Size = new System.Drawing.Size(360, 51);
            this.panelReplayLogsControls.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Log File";
            // 
            // btnSelectLogFile
            // 
            this.btnSelectLogFile.Location = new System.Drawing.Point(325, 4);
            this.btnSelectLogFile.Name = "btnSelectLogFile";
            this.btnSelectLogFile.Size = new System.Drawing.Size(29, 19);
            this.btnSelectLogFile.TabIndex = 24;
            this.btnSelectLogFile.Text = "...";
            this.btnSelectLogFile.UseVisualStyleBackColor = true;
            // 
            // txtLogFile
            // 
            this.txtLogFile.Location = new System.Drawing.Point(77, 4);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(242, 20);
            this.txtLogFile.TabIndex = 23;
            // 
            // lblLogLength
            // 
            this.lblLogLength.AutoSize = true;
            this.lblLogLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogLength.Location = new System.Drawing.Point(120, 31);
            this.lblLogLength.Name = "lblLogLength";
            this.lblLogLength.Size = new System.Drawing.Size(10, 13);
            this.lblLogLength.TabIndex = 27;
            this.lblLogLength.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Length of recording:";
            // 
            // groupBoxHeadsetProperties
            // 
            this.groupBoxHeadsetProperties.Controls.Add(this.label2);
            this.groupBoxHeadsetProperties.Controls.Add(this.label1);
            this.groupBoxHeadsetProperties.Controls.Add(this.btnSelectDataFolder);
            this.groupBoxHeadsetProperties.Controls.Add(this.cboPort);
            this.groupBoxHeadsetProperties.Controls.Add(this.txtDataDir);
            this.groupBoxHeadsetProperties.Location = new System.Drawing.Point(8, 6);
            this.groupBoxHeadsetProperties.Name = "groupBoxHeadsetProperties";
            this.groupBoxHeadsetProperties.Size = new System.Drawing.Size(429, 73);
            this.groupBoxHeadsetProperties.TabIndex = 37;
            this.groupBoxHeadsetProperties.TabStop = false;
            this.groupBoxHeadsetProperties.Text = "Headset properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Data Directory:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Headset COM Port:";
            // 
            // btnSelectDataFolder
            // 
            this.btnSelectDataFolder.Location = new System.Drawing.Point(394, 45);
            this.btnSelectDataFolder.Name = "btnSelectDataFolder";
            this.btnSelectDataFolder.Size = new System.Drawing.Size(29, 19);
            this.btnSelectDataFolder.TabIndex = 34;
            this.btnSelectDataFolder.Text = "...";
            this.btnSelectDataFolder.UseVisualStyleBackColor = true;
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(114, 17);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(65, 21);
            this.cboPort.TabIndex = 30;
            // 
            // txtDataDir
            // 
            this.txtDataDir.Location = new System.Drawing.Point(114, 44);
            this.txtDataDir.Name = "txtDataDir";
            this.txtDataDir.Size = new System.Drawing.Size(274, 20);
            this.txtDataDir.TabIndex = 33;
            this.txtDataDir.Text = "C:\\Temp";
            // 
            // tabPageMonitorData
            // 
            this.tabPageMonitorData.Controls.Add(this.tabControlDataVisualization);
            this.tabPageMonitorData.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonitorData.Name = "tabPageMonitorData";
            this.tabPageMonitorData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonitorData.Size = new System.Drawing.Size(978, 362);
            this.tabPageMonitorData.TabIndex = 2;
            this.tabPageMonitorData.Text = "Data Visualization";
            this.tabPageMonitorData.UseVisualStyleBackColor = true;
            // 
            // tabControlDataVisualization
            // 
            this.tabControlDataVisualization.Controls.Add(this.tabPlotsRaw);
            this.tabControlDataVisualization.Controls.Add(this.tabPlotsNormalized);
            this.tabControlDataVisualization.Controls.Add(this.tabPlotsUsed);
            this.tabControlDataVisualization.Controls.Add(this.tabNumeric);
            this.tabControlDataVisualization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDataVisualization.Location = new System.Drawing.Point(3, 3);
            this.tabControlDataVisualization.Name = "tabControlDataVisualization";
            this.tabControlDataVisualization.SelectedIndex = 0;
            this.tabControlDataVisualization.Size = new System.Drawing.Size(972, 356);
            this.tabControlDataVisualization.TabIndex = 38;
            // 
            // tabPlotsRaw
            // 
            this.tabPlotsRaw.Location = new System.Drawing.Point(4, 22);
            this.tabPlotsRaw.Name = "tabPlotsRaw";
            this.tabPlotsRaw.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlotsRaw.Size = new System.Drawing.Size(964, 330);
            this.tabPlotsRaw.TabIndex = 0;
            this.tabPlotsRaw.Text = "Plots (Raw)";
            this.tabPlotsRaw.UseVisualStyleBackColor = true;
            // 
            // tabPlotsNormalized
            // 
            this.tabPlotsNormalized.Location = new System.Drawing.Point(4, 22);
            this.tabPlotsNormalized.Name = "tabPlotsNormalized";
            this.tabPlotsNormalized.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlotsNormalized.Size = new System.Drawing.Size(964, 330);
            this.tabPlotsNormalized.TabIndex = 1;
            this.tabPlotsNormalized.Text = "Plots (Normalized)";
            this.tabPlotsNormalized.UseVisualStyleBackColor = true;
            // 
            // tabPlotsUsed
            // 
            this.tabPlotsUsed.Location = new System.Drawing.Point(4, 22);
            this.tabPlotsUsed.Name = "tabPlotsUsed";
            this.tabPlotsUsed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlotsUsed.Size = new System.Drawing.Size(964, 330);
            this.tabPlotsUsed.TabIndex = 3;
            this.tabPlotsUsed.Text = "Plots (Used)";
            this.tabPlotsUsed.UseVisualStyleBackColor = true;
            // 
            // tabNumeric
            // 
            this.tabNumeric.Controls.Add(this.groupBox1);
            this.tabNumeric.Controls.Add(this.groupBox4);
            this.tabNumeric.Location = new System.Drawing.Point(4, 22);
            this.tabNumeric.Name = "tabNumeric";
            this.tabNumeric.Padding = new System.Windows.Forms.Padding(3);
            this.tabNumeric.Size = new System.Drawing.Size(964, 330);
            this.tabNumeric.TabIndex = 2;
            this.tabNumeric.Text = "Numeric";
            this.tabNumeric.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 287);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EEG Bands";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridColumnName,
            this.dataGridColumnRaw,
            this.dataGridColumnAvg15,
            this.dataGridColumnNormalized,
            this.dataGridColumnNormalizedAverage15,
            this.dataGridColumnOffset});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(952, 268);
            this.dataGridView1.TabIndex = 70;
            // 
            // dataGridColumnName
            // 
            this.dataGridColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridColumnName.HeaderText = "Name";
            this.dataGridColumnName.Name = "dataGridColumnName";
            this.dataGridColumnName.ReadOnly = true;
            this.dataGridColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridColumnName.Width = 41;
            // 
            // dataGridColumnRaw
            // 
            this.dataGridColumnRaw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridColumnRaw.HeaderText = "Raw";
            this.dataGridColumnRaw.Name = "dataGridColumnRaw";
            this.dataGridColumnRaw.ReadOnly = true;
            this.dataGridColumnRaw.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridColumnRaw.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridColumnRaw.Width = 60;
            // 
            // dataGridColumnAvg15
            // 
            this.dataGridColumnAvg15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridColumnAvg15.HeaderText = "RawAvg15";
            this.dataGridColumnAvg15.Name = "dataGridColumnAvg15";
            this.dataGridColumnAvg15.ReadOnly = true;
            this.dataGridColumnAvg15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridColumnAvg15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridColumnAvg15.Width = 70;
            // 
            // dataGridColumnNormalized
            // 
            this.dataGridColumnNormalized.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridColumnNormalized.HeaderText = "Normalized";
            this.dataGridColumnNormalized.Name = "dataGridColumnNormalized";
            this.dataGridColumnNormalized.ReadOnly = true;
            this.dataGridColumnNormalized.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridColumnNormalized.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridColumnNormalized.Width = 65;
            // 
            // dataGridColumnNormalizedAverage15
            // 
            this.dataGridColumnNormalizedAverage15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridColumnNormalizedAverage15.HeaderText = "NormalizedAvg15";
            this.dataGridColumnNormalizedAverage15.Name = "dataGridColumnNormalizedAverage15";
            this.dataGridColumnNormalizedAverage15.ReadOnly = true;
            this.dataGridColumnNormalizedAverage15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridColumnNormalizedAverage15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridColumnNormalizedAverage15.Width = 96;
            // 
            // dataGridColumnOffset
            // 
            this.dataGridColumnOffset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridColumnOffset.HeaderText = "Offset";
            this.dataGridColumnOffset.Name = "dataGridColumnOffset";
            this.dataGridColumnOffset.ReadOnly = true;
            this.dataGridColumnOffset.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridColumnOffset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridColumnOffset.Width = 41;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtRaw);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txtSignal);
            this.groupBox4.Location = new System.Drawing.Point(6, 296);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 50);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Raw";
            // 
            // txtRaw
            // 
            this.txtRaw.Enabled = false;
            this.txtRaw.Location = new System.Drawing.Point(64, 19);
            this.txtRaw.Name = "txtRaw";
            this.txtRaw.Size = new System.Drawing.Size(49, 20);
            this.txtRaw.TabIndex = 33;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(169, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(36, 13);
            this.label22.TabIndex = 24;
            this.label22.Text = "Signal";
            // 
            // txtSignal
            // 
            this.txtSignal.Enabled = false;
            this.txtSignal.Location = new System.Drawing.Point(217, 19);
            this.txtSignal.Name = "txtSignal";
            this.txtSignal.Size = new System.Drawing.Size(49, 20);
            this.txtSignal.TabIndex = 25;
            // 
            // tabPagePeripherals
            // 
            this.tabPagePeripherals.Controls.Add(this.tabControl123);
            this.tabPagePeripherals.Location = new System.Drawing.Point(4, 22);
            this.tabPagePeripherals.Name = "tabPagePeripherals";
            this.tabPagePeripherals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePeripherals.Size = new System.Drawing.Size(978, 362);
            this.tabPagePeripherals.TabIndex = 4;
            this.tabPagePeripherals.Text = "Peripherals";
            this.tabPagePeripherals.UseVisualStyleBackColor = true;
            // 
            // tabControl123
            // 
            this.tabControl123.Controls.Add(this.tabPageMidi);
            this.tabControl123.Controls.Add(this.tabPagSerial);
            this.tabControl123.Controls.Add(this.tabPageOsc);
            this.tabControl123.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl123.Location = new System.Drawing.Point(3, 3);
            this.tabControl123.Name = "tabControl123";
            this.tabControl123.SelectedIndex = 0;
            this.tabControl123.Size = new System.Drawing.Size(972, 356);
            this.tabControl123.TabIndex = 0;
            // 
            // tabPageMidi
            // 
            this.tabPageMidi.Controls.Add(this.mMidiHandler);
            this.tabPageMidi.Location = new System.Drawing.Point(4, 22);
            this.tabPageMidi.Name = "tabPageMidi";
            this.tabPageMidi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMidi.Size = new System.Drawing.Size(964, 330);
            this.tabPageMidi.TabIndex = 0;
            this.tabPageMidi.Text = "Midi";
            this.tabPageMidi.UseVisualStyleBackColor = true;
            // 
            // mMidiHandler
            // 
            this.mMidiHandler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mMidiHandler.Location = new System.Drawing.Point(3, 3);
            this.mMidiHandler.Name = "mMidiHandler";
            this.mMidiHandler.Size = new System.Drawing.Size(958, 324);
            this.mMidiHandler.TabIndex = 0;
            // 
            // tabPagSerial
            // 
            this.tabPagSerial.Controls.Add(this.textBoxSerialLog);
            this.tabPagSerial.Controls.Add(this.panelSerialHostBtns);
            this.tabPagSerial.Location = new System.Drawing.Point(4, 22);
            this.tabPagSerial.Name = "tabPagSerial";
            this.tabPagSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagSerial.Size = new System.Drawing.Size(964, 330);
            this.tabPagSerial.TabIndex = 1;
            this.tabPagSerial.Text = "Serial";
            this.tabPagSerial.UseVisualStyleBackColor = true;
            // 
            // textBoxSerialLog
            // 
            this.textBoxSerialLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSerialLog.Location = new System.Drawing.Point(3, 42);
            this.textBoxSerialLog.Multiline = true;
            this.textBoxSerialLog.Name = "textBoxSerialLog";
            this.textBoxSerialLog.ReadOnly = true;
            this.textBoxSerialLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSerialLog.Size = new System.Drawing.Size(958, 285);
            this.textBoxSerialLog.TabIndex = 2;
            // 
            // panelSerialHostBtns
            // 
            this.panelSerialHostBtns.Controls.Add(this.btnStartSerialHost);
            this.panelSerialHostBtns.Controls.Add(this.labelComPort);
            this.panelSerialHostBtns.Controls.Add(this.comboBoxComPort);
            this.panelSerialHostBtns.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSerialHostBtns.Location = new System.Drawing.Point(3, 3);
            this.panelSerialHostBtns.Name = "panelSerialHostBtns";
            this.panelSerialHostBtns.Size = new System.Drawing.Size(958, 39);
            this.panelSerialHostBtns.TabIndex = 1;
            // 
            // btnStartSerialHost
            // 
            this.btnStartSerialHost.Location = new System.Drawing.Point(171, 7);
            this.btnStartSerialHost.Name = "btnStartSerialHost";
            this.btnStartSerialHost.Size = new System.Drawing.Size(54, 23);
            this.btnStartSerialHost.TabIndex = 2;
            this.btnStartSerialHost.Text = "Start";
            this.btnStartSerialHost.UseVisualStyleBackColor = true;
            // 
            // labelComPort
            // 
            this.labelComPort.AutoSize = true;
            this.labelComPort.Location = new System.Drawing.Point(7, 11);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(56, 13);
            this.labelComPort.TabIndex = 1;
            this.labelComPort.Text = "COM Port:";
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(69, 8);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(90, 21);
            this.comboBoxComPort.TabIndex = 0;
            // 
            // tabPageOsc
            // 
            this.tabPageOsc.Controls.Add(this.panel1);
            this.tabPageOsc.Controls.Add(this.textBoxOscLog);
            this.tabPageOsc.Location = new System.Drawing.Point(4, 22);
            this.tabPageOsc.Name = "tabPageOsc";
            this.tabPageOsc.Size = new System.Drawing.Size(964, 330);
            this.tabPageOsc.TabIndex = 2;
            this.tabPageOsc.Text = "OSC";
            this.tabPageOsc.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbWaitForUpdateFromArduino);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 39);
            this.panel1.TabIndex = 4;
            // 
            // cbWaitForUpdateFromArduino
            // 
            this.cbWaitForUpdateFromArduino.AutoSize = true;
            this.cbWaitForUpdateFromArduino.Location = new System.Drawing.Point(11, 11);
            this.cbWaitForUpdateFromArduino.Name = "cbWaitForUpdateFromArduino";
            this.cbWaitForUpdateFromArduino.Size = new System.Drawing.Size(199, 17);
            this.cbWaitForUpdateFromArduino.TabIndex = 0;
            this.cbWaitForUpdateFromArduino.Text = "Wait for update request from Arduino";
            this.cbWaitForUpdateFromArduino.UseVisualStyleBackColor = true;
            // 
            // textBoxOscLog
            // 
            this.textBoxOscLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOscLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxOscLog.Multiline = true;
            this.textBoxOscLog.Name = "textBoxOscLog";
            this.textBoxOscLog.ReadOnly = true;
            this.textBoxOscLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOscLog.Size = new System.Drawing.Size(964, 330);
            this.textBoxOscLog.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(978, 362);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Control";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.label46);
            this.panelControl.Controls.Add(this.trackBarMasterVolume);
            this.panelControl.Controls.Add(this.groupBox2);
            this.panelControl.Controls.Add(this.groupBox5);
            this.panelControl.Controls.Add(this.groupBoxStripConfig);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(3, 3);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(972, 356);
            this.panelControl.TabIndex = 0;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(447, 248);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(79, 13);
            this.label46.TabIndex = 26;
            this.label46.Text = "Master volume:";
            // 
            // trackBarMasterVolume
            // 
            this.trackBarMasterVolume.AutoSize = false;
            this.trackBarMasterVolume.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarMasterVolume.Location = new System.Drawing.Point(597, 242);
            this.trackBarMasterVolume.Maximum = 1000;
            this.trackBarMasterVolume.Name = "trackBarMasterVolume";
            this.trackBarMasterVolume.Size = new System.Drawing.Size(253, 24);
            this.trackBarMasterVolume.TabIndex = 25;
            this.trackBarMasterVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.trackBarMeditationVolume);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.trackBarAttentionVolume);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.trackBarFx3Param2);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.trackBarFx3Param1);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.trackBarFx2Param3);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.trackBarFx2Param2);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.trackBarFx2Param1);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.trackBarFx1Param3);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.trackBarFx1Param2);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.trackBarFx1Param1);
            this.groupBox2.Location = new System.Drawing.Point(439, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 269);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Effect parameters";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(8, 220);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(96, 13);
            this.label36.TabIndex = 24;
            this.label36.Text = "Meditation volume:";
            // 
            // trackBarMeditationVolume
            // 
            this.trackBarMeditationVolume.AutoSize = false;
            this.trackBarMeditationVolume.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarMeditationVolume.Location = new System.Drawing.Point(158, 214);
            this.trackBarMeditationVolume.Maximum = 1000;
            this.trackBarMeditationVolume.Name = "trackBarMeditationVolume";
            this.trackBarMeditationVolume.Size = new System.Drawing.Size(253, 24);
            this.trackBarMeditationVolume.TabIndex = 23;
            this.trackBarMeditationVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(8, 199);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(89, 13);
            this.label37.TabIndex = 22;
            this.label37.Text = "Attention volume:";
            // 
            // trackBarAttentionVolume
            // 
            this.trackBarAttentionVolume.AutoSize = false;
            this.trackBarAttentionVolume.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarAttentionVolume.Location = new System.Drawing.Point(158, 193);
            this.trackBarAttentionVolume.Maximum = 1000;
            this.trackBarAttentionVolume.Name = "trackBarAttentionVolume";
            this.trackBarAttentionVolume.Size = new System.Drawing.Size(253, 30);
            this.trackBarAttentionVolume.TabIndex = 21;
            this.trackBarAttentionVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 178);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(69, 13);
            this.label38.TabIndex = 20;
            this.label38.Text = "Fx3 Param 2:";
            // 
            // trackBarFx3Param2
            // 
            this.trackBarFx3Param2.AutoSize = false;
            this.trackBarFx3Param2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx3Param2.Location = new System.Drawing.Point(158, 172);
            this.trackBarFx3Param2.Maximum = 1000;
            this.trackBarFx3Param2.Name = "trackBarFx3Param2";
            this.trackBarFx3Param2.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx3Param2.TabIndex = 19;
            this.trackBarFx3Param2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(8, 157);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(69, 13);
            this.label39.TabIndex = 18;
            this.label39.Text = "Fx3 Param 1:";
            // 
            // trackBarFx3Param1
            // 
            this.trackBarFx3Param1.AutoSize = false;
            this.trackBarFx3Param1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx3Param1.Location = new System.Drawing.Point(158, 151);
            this.trackBarFx3Param1.Maximum = 1000;
            this.trackBarFx3Param1.Name = "trackBarFx3Param1";
            this.trackBarFx3Param1.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx3Param1.TabIndex = 17;
            this.trackBarFx3Param1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(7, 135);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(69, 13);
            this.label40.TabIndex = 16;
            this.label40.Text = "Fx2 Param 3:";
            // 
            // trackBarFx2Param3
            // 
            this.trackBarFx2Param3.AutoSize = false;
            this.trackBarFx2Param3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx2Param3.Location = new System.Drawing.Point(157, 129);
            this.trackBarFx2Param3.Maximum = 1000;
            this.trackBarFx2Param3.Name = "trackBarFx2Param3";
            this.trackBarFx2Param3.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx2Param3.TabIndex = 15;
            this.trackBarFx2Param3.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(7, 114);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 13);
            this.label41.TabIndex = 14;
            this.label41.Text = "Fx2 Param 2:";
            // 
            // trackBarFx2Param2
            // 
            this.trackBarFx2Param2.AutoSize = false;
            this.trackBarFx2Param2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx2Param2.Location = new System.Drawing.Point(157, 108);
            this.trackBarFx2Param2.Maximum = 1000;
            this.trackBarFx2Param2.Name = "trackBarFx2Param2";
            this.trackBarFx2Param2.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx2Param2.TabIndex = 13;
            this.trackBarFx2Param2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(7, 90);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 13);
            this.label42.TabIndex = 12;
            this.label42.Text = "Fx2 Param 1:";
            // 
            // trackBarFx2Param1
            // 
            this.trackBarFx2Param1.AutoSize = false;
            this.trackBarFx2Param1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx2Param1.Location = new System.Drawing.Point(157, 84);
            this.trackBarFx2Param1.Maximum = 1000;
            this.trackBarFx2Param1.Name = "trackBarFx2Param1";
            this.trackBarFx2Param1.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx2Param1.TabIndex = 11;
            this.trackBarFx2Param1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(7, 69);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(69, 13);
            this.label43.TabIndex = 10;
            this.label43.Text = "Fx1 Param 3:";
            // 
            // trackBarFx1Param3
            // 
            this.trackBarFx1Param3.AutoSize = false;
            this.trackBarFx1Param3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx1Param3.Location = new System.Drawing.Point(157, 63);
            this.trackBarFx1Param3.Maximum = 1000;
            this.trackBarFx1Param3.Name = "trackBarFx1Param3";
            this.trackBarFx1Param3.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx1Param3.TabIndex = 9;
            this.trackBarFx1Param3.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 46);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(69, 13);
            this.label44.TabIndex = 8;
            this.label44.Text = "Fx1 Param 2:";
            // 
            // trackBarFx1Param2
            // 
            this.trackBarFx1Param2.AutoSize = false;
            this.trackBarFx1Param2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx1Param2.Location = new System.Drawing.Point(156, 40);
            this.trackBarFx1Param2.Maximum = 1000;
            this.trackBarFx1Param2.Name = "trackBarFx1Param2";
            this.trackBarFx1Param2.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx1Param2.TabIndex = 7;
            this.trackBarFx1Param2.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 25);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 13);
            this.label45.TabIndex = 6;
            this.label45.Text = "Fx1 Param 1:";
            // 
            // trackBarFx1Param1
            // 
            this.trackBarFx1Param1.AutoSize = false;
            this.trackBarFx1Param1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarFx1Param1.Location = new System.Drawing.Point(156, 19);
            this.trackBarFx1Param1.Maximum = 1000;
            this.trackBarFx1Param1.Name = "trackBarFx1Param1";
            this.trackBarFx1Param1.Size = new System.Drawing.Size(253, 30);
            this.trackBarFx1Param1.TabIndex = 5;
            this.trackBarFx1Param1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.trackBarOffsetDelta);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.trackBarOffsetTheta);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.trackBarOffsetAttention);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.trackBarOffsetMeditation);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.trackBarOffsetGammaH);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.trackBarOffsetGammaL);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.trackBarOffsetBetaH);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.trackBarOffsetBetaL);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.trackBarOffsetAlphaH);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.trackBarOffsetAlphaL);
            this.groupBox5.Location = new System.Drawing.Point(16, 128);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(417, 248);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Channel offset";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 220);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 13);
            this.label28.TabIndex = 24;
            this.label28.Text = "Delta:";
            // 
            // trackBarOffsetDelta
            // 
            this.trackBarOffsetDelta.AutoSize = false;
            this.trackBarOffsetDelta.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetDelta.Location = new System.Drawing.Point(158, 214);
            this.trackBarOffsetDelta.Maximum = 1000;
            this.trackBarOffsetDelta.Name = "trackBarOffsetDelta";
            this.trackBarOffsetDelta.Size = new System.Drawing.Size(253, 24);
            this.trackBarOffsetDelta.TabIndex = 23;
            this.trackBarOffsetDelta.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 199);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 13);
            this.label29.TabIndex = 22;
            this.label29.Text = "Theta:";
            // 
            // trackBarOffsetTheta
            // 
            this.trackBarOffsetTheta.AutoSize = false;
            this.trackBarOffsetTheta.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetTheta.Location = new System.Drawing.Point(158, 193);
            this.trackBarOffsetTheta.Maximum = 1000;
            this.trackBarOffsetTheta.Name = "trackBarOffsetTheta";
            this.trackBarOffsetTheta.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetTheta.TabIndex = 21;
            this.trackBarOffsetTheta.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 178);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 13);
            this.label26.TabIndex = 20;
            this.label26.Text = "Attention:";
            // 
            // trackBarOffsetAttention
            // 
            this.trackBarOffsetAttention.AutoSize = false;
            this.trackBarOffsetAttention.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetAttention.Location = new System.Drawing.Point(158, 172);
            this.trackBarOffsetAttention.Maximum = 1000;
            this.trackBarOffsetAttention.Name = "trackBarOffsetAttention";
            this.trackBarOffsetAttention.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetAttention.TabIndex = 19;
            this.trackBarOffsetAttention.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 157);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 13);
            this.label27.TabIndex = 18;
            this.label27.Text = "Meditation:";
            // 
            // trackBarOffsetMeditation
            // 
            this.trackBarOffsetMeditation.AutoSize = false;
            this.trackBarOffsetMeditation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetMeditation.Location = new System.Drawing.Point(158, 151);
            this.trackBarOffsetMeditation.Maximum = 1000;
            this.trackBarOffsetMeditation.Name = "trackBarOffsetMeditation";
            this.trackBarOffsetMeditation.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetMeditation.TabIndex = 17;
            this.trackBarOffsetMeditation.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 135);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(57, 13);
            this.label24.TabIndex = 16;
            this.label24.Text = "Gamma H:";
            // 
            // trackBarOffsetGammaH
            // 
            this.trackBarOffsetGammaH.AutoSize = false;
            this.trackBarOffsetGammaH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetGammaH.Location = new System.Drawing.Point(157, 129);
            this.trackBarOffsetGammaH.Maximum = 1000;
            this.trackBarOffsetGammaH.Name = "trackBarOffsetGammaH";
            this.trackBarOffsetGammaH.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetGammaH.TabIndex = 15;
            this.trackBarOffsetGammaH.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 13);
            this.label25.TabIndex = 14;
            this.label25.Text = "Gamma L:";
            // 
            // trackBarOffsetGammaL
            // 
            this.trackBarOffsetGammaL.AutoSize = false;
            this.trackBarOffsetGammaL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetGammaL.Location = new System.Drawing.Point(157, 108);
            this.trackBarOffsetGammaL.Maximum = 1000;
            this.trackBarOffsetGammaL.Name = "trackBarOffsetGammaL";
            this.trackBarOffsetGammaL.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetGammaL.TabIndex = 13;
            this.trackBarOffsetGammaL.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Beta H:";
            // 
            // trackBarOffsetBetaH
            // 
            this.trackBarOffsetBetaH.AutoSize = false;
            this.trackBarOffsetBetaH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetBetaH.Location = new System.Drawing.Point(157, 84);
            this.trackBarOffsetBetaH.Maximum = 1000;
            this.trackBarOffsetBetaH.Name = "trackBarOffsetBetaH";
            this.trackBarOffsetBetaH.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetBetaH.TabIndex = 11;
            this.trackBarOffsetBetaH.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Beta L:";
            // 
            // trackBarOffsetBetaL
            // 
            this.trackBarOffsetBetaL.AutoSize = false;
            this.trackBarOffsetBetaL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetBetaL.Location = new System.Drawing.Point(157, 63);
            this.trackBarOffsetBetaL.Maximum = 1000;
            this.trackBarOffsetBetaL.Name = "trackBarOffsetBetaL";
            this.trackBarOffsetBetaL.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetBetaL.TabIndex = 9;
            this.trackBarOffsetBetaL.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "Alpha H:";
            // 
            // trackBarOffsetAlphaH
            // 
            this.trackBarOffsetAlphaH.AutoSize = false;
            this.trackBarOffsetAlphaH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetAlphaH.Location = new System.Drawing.Point(156, 40);
            this.trackBarOffsetAlphaH.Maximum = 1000;
            this.trackBarOffsetAlphaH.Name = "trackBarOffsetAlphaH";
            this.trackBarOffsetAlphaH.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetAlphaH.TabIndex = 7;
            this.trackBarOffsetAlphaH.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 6;
            this.label23.Text = "Alpha L:";
            // 
            // trackBarOffsetAlphaL
            // 
            this.trackBarOffsetAlphaL.AutoSize = false;
            this.trackBarOffsetAlphaL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarOffsetAlphaL.Location = new System.Drawing.Point(156, 19);
            this.trackBarOffsetAlphaL.Maximum = 1000;
            this.trackBarOffsetAlphaL.Name = "trackBarOffsetAlphaL";
            this.trackBarOffsetAlphaL.Size = new System.Drawing.Size(253, 30);
            this.trackBarOffsetAlphaL.TabIndex = 5;
            this.trackBarOffsetAlphaL.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // groupBoxStripConfig
            // 
            this.groupBoxStripConfig.Controls.Add(this.label5);
            this.groupBoxStripConfig.Controls.Add(this.labelCushionOutline);
            this.groupBoxStripConfig.Controls.Add(this.trackBarBrightness);
            this.groupBoxStripConfig.Controls.Add(this.trackBarCushionOutlineStrip);
            this.groupBoxStripConfig.Controls.Add(this.labelBottomRightStrip);
            this.groupBoxStripConfig.Controls.Add(this.trackBarBottomRightStrip);
            this.groupBoxStripConfig.Controls.Add(this.labelTopLeftStrip);
            this.groupBoxStripConfig.Controls.Add(this.trackBarTopLeftStrip);
            this.groupBoxStripConfig.Location = new System.Drawing.Point(16, 3);
            this.groupBoxStripConfig.Name = "groupBoxStripConfig";
            this.groupBoxStripConfig.Size = new System.Drawing.Size(417, 119);
            this.groupBoxStripConfig.TabIndex = 1;
            this.groupBoxStripConfig.TabStop = false;
            this.groupBoxStripConfig.Text = "Strip configuration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "LED brightness:";
            // 
            // labelCushionOutline
            // 
            this.labelCushionOutline.AutoSize = true;
            this.labelCushionOutline.Location = new System.Drawing.Point(6, 64);
            this.labelCushionOutline.Name = "labelCushionOutline";
            this.labelCushionOutline.Size = new System.Drawing.Size(103, 13);
            this.labelCushionOutline.TabIndex = 10;
            this.labelCushionOutline.Text = "Bottom strip division:";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.AutoSize = false;
            this.trackBarBrightness.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarBrightness.Location = new System.Drawing.Point(156, 86);
            this.trackBarBrightness.Maximum = 127;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(255, 30);
            this.trackBarBrightness.TabIndex = 3;
            this.trackBarBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBrightness.Value = 127;
            // 
            // trackBarCushionOutlineStrip
            // 
            this.trackBarCushionOutlineStrip.AutoSize = false;
            this.trackBarCushionOutlineStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarCushionOutlineStrip.Location = new System.Drawing.Point(156, 64);
            this.trackBarCushionOutlineStrip.Maximum = 1000;
            this.trackBarCushionOutlineStrip.Name = "trackBarCushionOutlineStrip";
            this.trackBarCushionOutlineStrip.Size = new System.Drawing.Size(255, 30);
            this.trackBarCushionOutlineStrip.TabIndex = 9;
            this.trackBarCushionOutlineStrip.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarCushionOutlineStrip.Value = 500;
            // 
            // labelBottomRightStrip
            // 
            this.labelBottomRightStrip.AutoSize = true;
            this.labelBottomRightStrip.Location = new System.Drawing.Point(6, 44);
            this.labelBottomRightStrip.Name = "labelBottomRightStrip";
            this.labelBottomRightStrip.Size = new System.Drawing.Size(156, 13);
            this.labelBottomRightStrip.TabIndex = 8;
            this.labelBottomRightStrip.Text = "Backboard outline strip division:";
            // 
            // trackBarBottomRightStrip
            // 
            this.trackBarBottomRightStrip.AutoSize = false;
            this.trackBarBottomRightStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarBottomRightStrip.Location = new System.Drawing.Point(156, 43);
            this.trackBarBottomRightStrip.Maximum = 1000;
            this.trackBarBottomRightStrip.Name = "trackBarBottomRightStrip";
            this.trackBarBottomRightStrip.Size = new System.Drawing.Size(255, 30);
            this.trackBarBottomRightStrip.TabIndex = 7;
            this.trackBarBottomRightStrip.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBottomRightStrip.Value = 500;
            // 
            // labelTopLeftStrip
            // 
            this.labelTopLeftStrip.AutoSize = true;
            this.labelTopLeftStrip.Location = new System.Drawing.Point(6, 25);
            this.labelTopLeftStrip.Name = "labelTopLeftStrip";
            this.labelTopLeftStrip.Size = new System.Drawing.Size(142, 13);
            this.labelTopLeftStrip.TabIndex = 6;
            this.labelTopLeftStrip.Text = "Cushion outline strip division:";
            // 
            // trackBarTopLeftStrip
            // 
            this.trackBarTopLeftStrip.AutoSize = false;
            this.trackBarTopLeftStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarTopLeftStrip.Location = new System.Drawing.Point(156, 23);
            this.trackBarTopLeftStrip.Maximum = 1000;
            this.trackBarTopLeftStrip.Name = "trackBarTopLeftStrip";
            this.trackBarTopLeftStrip.Size = new System.Drawing.Size(255, 30);
            this.trackBarTopLeftStrip.TabIndex = 5;
            this.trackBarTopLeftStrip.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTopLeftStrip.Value = 500;
            // 
            // EEGLogMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 483);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBoxStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EEGLogMain";
            this.Text = "EEG Log";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxStatus.ResumeLayout(false);
            this.splitContainerStatus.Panel1.ResumeLayout(false);
            this.splitContainerStatus.Panel1.PerformLayout();
            this.splitContainerStatus.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).EndInit();
            this.splitContainerStatus.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageRecordLog.ResumeLayout(false);
            this.grpComments.ResumeLayout(false);
            this.grpComments.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinConnectionStrength)).EndInit();
            this.panelDemoModeControls.ResumeLayout(false);
            this.panelDemoModeControls.PerformLayout();
            this.panelLiveDataControls.ResumeLayout(false);
            this.panelLiveDataControls.PerformLayout();
            this.panelReplayLogsControls.ResumeLayout(false);
            this.panelReplayLogsControls.PerformLayout();
            this.groupBoxHeadsetProperties.ResumeLayout(false);
            this.groupBoxHeadsetProperties.PerformLayout();
            this.tabPageMonitorData.ResumeLayout(false);
            this.tabControlDataVisualization.ResumeLayout(false);
            this.tabNumeric.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPagePeripherals.ResumeLayout(false);
            this.tabControl123.ResumeLayout(false);
            this.tabPageMidi.ResumeLayout(false);
            this.tabPagSerial.ResumeLayout(false);
            this.tabPagSerial.PerformLayout();
            this.panelSerialHostBtns.ResumeLayout(false);
            this.panelSerialHostBtns.PerformLayout();
            this.tabPageOsc.ResumeLayout(false);
            this.tabPageOsc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMeditationVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAttentionVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx3Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx3Param1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx2Param3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx2Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx2Param1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx1Param3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx1Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFx1Param1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetDelta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetTheta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetAttention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetMeditation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetGammaH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetGammaL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetBetaH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetBetaL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetAlphaH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOffsetAlphaL)).EndInit();
            this.groupBoxStripConfig.ResumeLayout(false);
            this.groupBoxStripConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCushionOutlineStrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBottomRightStrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTopLeftStrip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnRaw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnAvg15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnNormalized;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnNormalizedAverage15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnOffset;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageRecordLog;
        private System.Windows.Forms.GroupBox grpComments;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.ListBox lstComments;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.Panel panelDemoModeControls;
        private System.Windows.Forms.Label lblLogLength2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblCurrentLogPlaying;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblNumRecordings;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnPlayLog;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Panel panelLiveDataControls;
        private System.Windows.Forms.TextBox txtParticipant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelReplayLogsControls;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSelectLogFile;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.Label lblLogLength;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBoxHeadsetProperties;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectDataFolder;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.TextBox txtDataDir;
        private System.Windows.Forms.TabPage tabPageMonitorData;
        private System.Windows.Forms.TabControl tabControlDataVisualization;
        private System.Windows.Forms.TabPage tabPlotsRaw;
        private System.Windows.Forms.TabPage tabPlotsNormalized;
        private System.Windows.Forms.TabPage tabNumeric;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRaw;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSignal;
        private System.Windows.Forms.TabPage tabPagePeripherals;
        private System.Windows.Forms.TabControl tabControl123;
        private System.Windows.Forms.TabPage tabPageMidi;
        private MidiHandling.MidiHandler mMidiHandler;
        private System.Windows.Forms.TabPage tabPagSerial;
        private System.Windows.Forms.TextBox textBoxSerialLog;
        private System.Windows.Forms.Panel panelSerialHostBtns;
        private System.Windows.Forms.Button btnStartSerialHost;
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.TabPage tabPageOsc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbWaitForUpdateFromArduino;
        private System.Windows.Forms.TextBox textBoxOscLog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TrackBar trackBarMasterVolume;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TrackBar trackBarMeditationVolume;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TrackBar trackBarAttentionVolume;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TrackBar trackBarFx3Param2;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TrackBar trackBarFx3Param1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TrackBar trackBarFx2Param3;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TrackBar trackBarFx2Param2;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TrackBar trackBarFx2Param1;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TrackBar trackBarFx1Param3;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TrackBar trackBarFx1Param2;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TrackBar trackBarFx1Param1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TrackBar trackBarOffsetDelta;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TrackBar trackBarOffsetTheta;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TrackBar trackBarOffsetAttention;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TrackBar trackBarOffsetMeditation;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TrackBar trackBarOffsetGammaH;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TrackBar trackBarOffsetGammaL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarOffsetBetaH;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TrackBar trackBarOffsetBetaL;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TrackBar trackBarOffsetAlphaH;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TrackBar trackBarOffsetAlphaL;
        private System.Windows.Forms.GroupBox groupBoxStripConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCushionOutline;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarCushionOutlineStrip;
        private System.Windows.Forms.Label labelBottomRightStrip;
        private System.Windows.Forms.TrackBar trackBarBottomRightStrip;
        private System.Windows.Forms.Label labelTopLeftStrip;
        private System.Windows.Forms.TrackBar trackBarTopLeftStrip;
        private System.Windows.Forms.SplitContainer splitContainerStatus;
        private System.Windows.Forms.Label labelElapsedTime;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelLastActivity;
        private System.Windows.Forms.Label labelMidiStatus;
        private System.Windows.Forms.Label labelHeadSetStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelHeadSetState;
        private System.Windows.Forms.ProgressBar progressBarEEGSignalStrength;
        private System.Windows.Forms.Label labelLastActivityMessage;
        private System.Windows.Forms.TabPage tabPlotsUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridColumnRaw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridColumnAvg15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridColumnNormalized;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridColumnNormalizedAverage15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridColumnOffset;
        private System.Windows.Forms.CheckBox cbMinConnectionStrength;
        private System.Windows.Forms.Label labelConnectionStrength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudMinConnectionStrength;
    }
}

