using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using EEG;

namespace EEGLog
{
    using ChannelPlotting;
    using OscHandling;
    using MidiHandling;
    using Channels;
    using Properties;

    public partial class EEGLogMain : Form
    {
        #region Constants
        
        // these two are used to identify OSC clients
        const string OscClientAudio = "AudioClient";
        const string OscClientLight = "LightClient";
        const string OscServerLight = "LightServer";

        private enum EEGLogMode
        {
            Record,
            Playback,
            Monitor,
            Demo,
            Idle
        }
        #endregion

        #region Delegates
        private delegate void AppendToSerialLogTextbox(char c);
        #endregion

        #region Fields
        bool isReplaying = false;
        bool isConnected = false;

        Dictionary<string, DataGridViewRow> dataRows = new Dictionary<string, DataGridViewRow>();

        EEGLogMode guiMode = EEGLogMode.Idle;
        int currentReplayedFileIndex = 0;

        Action<ThinkGearStateEventArgs> updateUI;

        SerialHandler SerialHandler = new SerialHandler();

        Stopwatch watch = new Stopwatch();
        EEGCore core = new EEGCore();
        EEGChannels channelsRaw = new EEGChannels(60 * 1);   // store 60 seconds at 1 fps
        EEGChannels channelsNormalized = new EEGChannels(60 * 1);   // store 60 seconds at 1 fps
       
        EEGChannelPlots channelPlotsRaw = new EEGChannelPlots();
        EEGChannelPlots channelPlotsNormalized = new EEGChannelPlots();
        EEGChannelPlots channelPlotsUsed = new EEGChannelPlots();
        
        OSCHandler oscHandler = OSCHandler.Instance;
        long lastArduinoOSCUpdateRequestTimestamp = 0;
        bool mSerialHostStarted = false;
        Timer mTimer = new Timer();

        #endregion

        #region Constructor

        // --------------------------------------------------------------------------------------------------------------------
        public EEGLogMain()
        {
            InitializeComponent();

            // frack frack frack
            btnMonitor.Click += btnMonitor_Click;
            btnDemo.Click += btnDemo_Click;
            btnPlayLog.Click += btnPlayLog_Click;
            btnRecord.Click += btnRecord_Click;

            btnSelectLogFile.Click += btnSelectLogFile_Click;
            btnSelectDataFolder.Click += btnSelectDataFolder_Click;

            btnAddComment.Click += btnAddComment_Click;

            btnStartSerialHost.Click += btnStartSerialHost_Click;

            trackBarAttentionVolume.Scroll += trackBarAttentionVolume_Scroll;
            trackBarMeditationVolume.Scroll += trackBarMeditationVolume_Scroll;
            trackBarMasterVolume.Scroll += trackBarMasterVolume_Scroll;

            trackBarTopLeftStrip.Scroll += trackBarTopLeftStrip_Scroll;
            trackBarBottomRightStrip.Scroll += trackBarBottomRightStrip_Scroll;
            trackBarBrightness.Scroll += trackBarBrightness_Scroll;
            trackBarCushionOutlineStrip.Scroll += trackBarCushionOutlineStrip_Scroll;

            trackBarFx1Param1.Scroll += trackBarFx1Param1_Scroll;
            trackBarFx1Param2.Scroll += trackBarFx1Param2_Scroll;
            trackBarFx1Param3.Scroll += trackBarFx1Param3_Scroll;
            trackBarFx2Param1.Scroll += trackBarFx2Param1_Scroll;
            trackBarFx2Param2.Scroll += trackBarFx2Param2_Scroll;
            trackBarFx2Param3.Scroll += trackBarFx2Param3_Scroll;
            trackBarFx3Param1.Scroll += trackBarFx3Param1_Scroll;
            trackBarFx3Param2.Scroll += trackBarFx3Param2_Scroll;

            trackBarOffsetAlphaL.Scroll += trackBarOffsetAlphaL_Scroll;
            trackBarOffsetAlphaH.Scroll += trackBarOffsetAlphaH_Scroll;
            trackBarOffsetBetaL.Scroll += trackBarOffsetBetaL_Scroll;
            trackBarOffsetBetaH.Scroll += trackBarOffsetBetaH_Scroll;
            trackBarOffsetGammaL.Scroll += trackBarOffsetGammaL_Scroll;
            trackBarOffsetGammaH.Scroll += trackBarOffsetGammaH_Scroll;

            trackBarOffsetDelta.Scroll += trackBarOffsetDelta_Scroll;
            trackBarOffsetTheta.Scroll += trackBarOffsetTheta_Scroll;

            trackBarOffsetMeditation.Scroll += trackBarOffsetMeditation_Scroll;
            trackBarOffsetAttention.Scroll += trackBarOffsetAttention_Scroll;

            mTimer.Interval = 1000;
            mTimer.Tick += timer_Tick;
            mTimer.Start();
        }
        
        #endregion

        #region Event handlers
        // ------------------------------------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isConnected && (guiMode == EEGLogMode.Idle)) { 
                _refreshUIAndSendOsc();
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            sendBrightnessOsc(trackBarBrightness.Value);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sendOscMessagesZero();

            SerialHandler.shutdown();
            core.Disconnect();
            oscHandler.shutdown();
            oscHandler = null;
            _saveSettings();
        }


        // --------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {

            core.SignalChanged += core_SignalChanged;
            core.DataReceived += core_DataReceived;


            updateUI = _updateUi;
            foreach (string port in SerialPort.GetPortNames())
            {
                cboPort.Items.Add(port);
                comboBoxComPort.Items.Add(port);
            }
            cboPort.SelectedItem = "COM4";
            comboBoxComPort.SelectedItem = "COM7";

            this.SuspendLayout();
            tabPlotsRaw.Controls.Add(channelPlotsRaw);
            channelPlotsRaw.Dock = DockStyle.Fill;

            tabPlotsNormalized.Controls.Add(channelPlotsNormalized);
            channelPlotsNormalized.Dock = DockStyle.Fill;

            tabPlotsUsed.Controls.Add(channelPlotsUsed);
            channelPlotsUsed.Dock = DockStyle.Fill;

            this.txtDataDir.Text = Environment.CurrentDirectory;
            this.ResumeLayout();

            _setupChannelPlots();

            List<EEGChannelBuffer> chlist = channelsRaw.ToList();

            foreach(EEGChannelBuffer ch in chlist)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = ch.Name;
                dataGridView1.Rows.Add(row);
                dataRows.Add(ch.Name, row);
            }

            oscHandler.initialize();

            String audioClientIp = "";
            String audioClientPort = "";
            String lightClientIp = "";
            String lightClientPort = "";
            String oscServerPort = "";
            String strMsg = "";
            try
            {
                audioClientIp = ConfigurationManager.AppSettings["AudioClientIp"];
                audioClientPort = ConfigurationManager.AppSettings["AudioClientPort"];
                lightClientIp = ConfigurationManager.AppSettings["LightClientIp"];
                lightClientPort = ConfigurationManager.AppSettings["LightClientPort"];
                oscServerPort = ConfigurationManager.AppSettings["OscServerPort"];
                oscHandler.createClient(OscClientAudio, IPAddress.Parse(audioClientIp), Int32.Parse(audioClientPort));
                oscHandler.createClient(OscClientLight, IPAddress.Parse(lightClientIp), Int32.Parse(lightClientPort));
                oscHandler.createServer(OscServerLight, Int32.Parse(oscServerPort));
            }
            catch (ConfigurationException exc)
            {
                strMsg = "Could not set up network connections. Please check the '.config' file contents!" + Environment.NewLine + Environment.NewLine;
                strMsg = strMsg + "Audio client ip: " + audioClientIp + Environment.NewLine;
                strMsg = strMsg + "Audio client port: " + audioClientPort + Environment.NewLine;
                strMsg = strMsg + "Light client ip: " + lightClientIp + Environment.NewLine;
                strMsg = strMsg + "Light client port: " + lightClientPort + Environment.NewLine;
                strMsg = strMsg + "Osc server port: " + oscServerPort + Environment.NewLine + Environment.NewLine;
                strMsg = strMsg + "Exception: " + exc.Message;
                MessageBox.Show(strMsg, "ERROR");
                Application.Exit();
            }

            SerialHandler.AppendTextToSerialLog += new AppendTextToSerialLogHandler(SerialHandler_AppendTextToSerialLog);

            tabPageMidi.Controls.Add(mMidiHandler);
            
            mMidiHandler.ChannelOffsetChanged+=new MidiHandler.ChannelOffsetChangedHandler(_onChannelOffsetChanged);
            mMidiHandler.MidiCC += new MidiHandler.MidiCCHandler(_onMidiCC);
            _loadSettings();

            _setGuiMode(EEGLogMode.Idle);

            // send settings to client(s)
          //  sendBrightnessOsc(trackBarBrightness.Value);
            sendCouchOutlineStripOsc( trackBarCushionOutlineStrip.Value * 1.0f / trackBarCushionOutlineStrip.Maximum);
            sendBottomRightStripOsc( trackBarBottomRightStrip.Value * 1.0f / trackBarBottomRightStrip.Maximum);
            sendTopLeftStripOsc(trackBarTopLeftStrip.Value * 1.0f / trackBarTopLeftStrip.Maximum);

            lblNumRecordings.Text = _getNumRecordingsInDataDir(txtDataDir.Text).ToString();
            labelMidiStatus.Text = mMidiHandler.MidiInState;

            base.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            bool developerMode = bool.Parse(ConfigurationManager.AppSettings["DeveloperMode"]);
            if (!developerMode)
            {
                tabControlDataVisualization.TabPages.Remove(tabPlotsRaw);
                tabControlDataVisualization.TabPages.Remove(tabPlotsNormalized);
            }
               
        }


        // --------------------------------------------------------------------------------------------------------------------
        private void btnSelectDataFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory;
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog();
            txtDataDir.Text = folderBrowserDialog1.SelectedPath;
            lblNumRecordings.Text = _getNumRecordingsInDataDir(txtDataDir.Text).ToString();
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void btnSelectLogFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Filter = "Log files (*.csv;*.txt;*.log;)|*.csv;*.txt;*.log;";
            openFileDialog1.Title = "Select log file";
            openFileDialog1.ShowDialog();
            txtLogFile.Text = openFileDialog1.FileName;
            lblLogLength.Text = _getLogFileLength(txtLogFile.Text);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void btnStartSerialHost_Click(object sender, EventArgs e)
        {
            if (!mSerialHostStarted)
            {
                SerialHandler.initialize(comboBoxComPort.SelectedItem.ToString(), 115200);
                mSerialHostStarted = true;
                btnStartSerialHost.Text = "Stop";
            }
            else
            {
                SerialHandler.shutdown();
                mSerialHostStarted = false;
                btnStartSerialHost.Text = "Start";
            }

        }

        // --------------------------------------------------------------------------------------------------------------------
        void core_LogReplayFinished(object sender, EventArgs e)
        {
            switch (guiMode)
            {
                case EEGLogMode.Demo:
                    currentReplayedFileIndex += 1;
                    if (currentReplayedFileIndex == _getNumRecordingsInDataDir(txtDataDir.Text))
                    {
                        currentReplayedFileIndex = 0;
                    }
                    _stopDemoMode();     // to prevent event listeners from piling up when calling _startFilePlayback repeatedly (e.g. core.LogReplayFinished += core_LogReplayFinished)
                    _startDemoMode();
                    break;
                default:
                    _stopFilePlayback();
                    //watch.Reset();
                    //core.LogReplayFinished -= core_LogReplayFinished;
                    break;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        void core_SignalChanged(object sender, SignalChangedEventArgs e)
        {
            if (e.NewSignal >= 0)
            {
                Invoke(new Action(() => progressBarEEGSignalStrength.Value = e.NewSignal));
                Invoke(new Action(() => labelConnectionStrength.Text = e.NewSignal.ToString()));
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        void core_DataReceived(object sender, ThinkGearStateEventArgs e)
        {
            try
            {
                Invoke(updateUI, e);
            }
            catch (Exception)
            {
                // can happen when object is disposed
            }
        }

        void core_LogCommentFound(object sender, CommentEventArgs e)
        {
            Action a = delegate()
            {
                string comment = string.Format("[{0}] {1}", TimeSpan.FromMilliseconds(e.Timestamp).ToString("hh\\:mm\\:ss"), e.Text);
                lstComments.Items.Add(comment);
                labelLastActivityMessage.Text = comment;
            };
            Invoke(a);
        }

        // --------------------------------------------------------------------------------------------------------------------
        void SerialHandler_AppendTextToSerialLog(char a)
        {
            if (this.InvokeRequired)
            {
                AppendToSerialLogTextbox d = new AppendToSerialLogTextbox(_appendToSerialLogTextbox);
                Invoke(d, a);
            }
            else
            {
                _appendToSerialLogTextbox(a);
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void btnRecord_Click(object sender, EventArgs e)
        {

            if (cboPort.SelectedItem == null)
            {
                _setLastActivity("Cannot connect to selected COM port!");
                return;
            }


            if (!isConnected)
            {
                core.SampleRateHz = 1;
                if (core.Connect(cboPort.SelectedItem.ToString()))
                {
                    isConnected = true;
                    string filename = Path.Combine(txtDataDir.Text, txtParticipant.Text + " " + _makeFilenamePostfix() + ".csv");
                    watch.Start();
                    core.StartLog(filename, true);
                    _setGuiMode(EEGLogMode.Record);
                    _setLastActivity("Connected to headset, started recording");
                }
                else
                {
                    isConnected = false;
                    progressBarEEGSignalStrength.Value = 0;
                    labelConnectionStrength.Text = "0";
                    _sendOscMessagesZero();
                    _setLastActivity("Cannot connect to headset");
                }
            }
            else
            {
                _setGuiMode(EEGLogMode.Idle);
                core.StopLog();
                core.Disconnect();
                watch.Reset();
                _sendOscMessagesZero();
                isConnected = false;
                labelElapsedTime.Text = "00:00";
                _setLastActivity("Disconnected from headset, stopped recording");
            }

            ToggleUIElements();

            lstComments.Items.Clear();
           channelPlotsRaw.ResetGraphs();
           channelPlotsNormalized.ResetGraphs();
           channelPlotsUsed.ResetGraphs();
           _setupChannelPlots();

        }

      
        // --------------------------------------------------------------------------------------------------------------------
        private void btnPlayLog_Click(object sender, EventArgs e)
        {
            if (isReplaying)
            {
                _setGuiMode(EEGLogMode.Idle);
                _stopFilePlayback();
                _setLastActivity("Stopped file playback");
                _sendOscMessagesZero();
            }
            else
            {
                if (!File.Exists(txtLogFile.Text))
                {
                    _setLastActivity("Cannot start file playback; file does not exist: " + txtLogFile.Text);
                }
                else
                {
                    _setGuiMode(EEGLogMode.Playback);
                    _startFilePlayback(txtLogFile.Text);
                    _setLastActivity("Started file playback: " + txtLogFile.Text);
                }
            }
            ToggleUIElements();

        }


        // ------------------------------------------------------------------------------------------------------
        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtComment.Text))
            {
                core.WriteLogComment(txtComment.Text);
                lstComments.Items.Add(string.Format("[{0}] {1}", watch.Elapsed.ToString("hh\\:mm\\:ss"), txtComment.Text));
                txtComment.Text = "";
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private void btnDemo_Click(object sender, EventArgs e)
        {
            switch (guiMode)
            {
                case EEGLogMode.Demo:
                    _stopDemoMode();
                    _sendOscMessagesZero();
                    break;
                case EEGLogMode.Idle:
                    currentReplayedFileIndex = 0;
                    _startDemoMode();
                    break;
            }

            ToggleUIElements();

        }

        // ------------------------------------------------------------------------------------------------------
        private void trackBarTopLeftStrip_Scroll(object sender, EventArgs e)
        {
            float val = trackBarTopLeftStrip.Value * 1.0f / trackBarTopLeftStrip.Maximum;
            _setLastActivity("Cushion outline strip division set to: " + val.ToString());
            sendTopLeftStripOsc(val);
        }

        // ------------------------------------------------------------------------------------------------------
        private void trackBarBottomRightStrip_Scroll(object sender, EventArgs e)
        {
            float val = trackBarBottomRightStrip.Value * 1.0f / trackBarBottomRightStrip.Maximum;
            _setLastActivity("Backboard outline strip division set to: " + val.ToString());
            sendBottomRightStripOsc(val);
        }

        // ------------------------------------------------------------------------------------------------------
        private void trackBarCushionOutlineStrip_Scroll(object sender, EventArgs e)
        {
            float val = trackBarCushionOutlineStrip.Value * 1.0f / trackBarCushionOutlineStrip.Maximum;
            _setLastActivity("Bottom strip division set to: " + val.ToString());
            sendCouchOutlineStripOsc(val);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetAlphaL_Scroll(object sender, EventArgs e)
        {
            channelsRaw.alpha1.Offset = (100 * trackBarOffsetAlphaL.Value * 1.0f / trackBarOffsetAlphaL.Maximum);
            channelsNormalized.alpha1.Offset = (100 * trackBarOffsetAlphaL.Value * 1.0f / trackBarOffsetAlphaL.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetAlphaH_Scroll(object sender, EventArgs e)
        {
            channelsRaw.alpha2.Offset = (100 * trackBarOffsetAlphaL.Value * 1.0f / trackBarOffsetAlphaL.Maximum);
            channelsNormalized.alpha2.Offset = (100 * trackBarOffsetAlphaL.Value * 1.0f / trackBarOffsetAlphaL.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetBetaL_Scroll(object sender, EventArgs e)
        {
            channelsRaw.beta1.Offset = (100 * trackBarOffsetBetaL.Value * 1.0f / trackBarOffsetBetaL.Maximum);
            channelsNormalized.beta1.Offset = (100 * trackBarOffsetBetaL.Value * 1.0f / trackBarOffsetBetaL.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetBetaH_Scroll(object sender, EventArgs e)
        {
            channelsRaw.beta2.Offset = (100 * trackBarOffsetBetaH.Value * 1.0f / trackBarOffsetBetaH.Maximum);
            channelsNormalized.beta2.Offset = (100 * trackBarOffsetBetaH.Value * 1.0f / trackBarOffsetBetaH.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetGammaL_Scroll(object sender, EventArgs e)
        {
            channelsRaw.gamma1.Offset = (100 * trackBarOffsetGammaL.Value * 1.0f / trackBarOffsetGammaL.Maximum);
            channelsNormalized.gamma1.Offset = (100 * trackBarOffsetGammaL.Value * 1.0f / trackBarOffsetGammaL.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetGammaH_Scroll(object sender, EventArgs e)
        {
            channelsRaw.gamma2.Offset = (100 * trackBarOffsetGammaH.Value * 1.0f / trackBarOffsetGammaH.Maximum);
            channelsNormalized.gamma2.Offset = (100 * trackBarOffsetGammaH.Value * 1.0f / trackBarOffsetGammaH.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetMeditation_Scroll(object sender, EventArgs e)
        {
            channelsRaw.meditation.Offset = (100 * trackBarOffsetMeditation.Value * 1.0f / trackBarOffsetMeditation.Maximum);
            channelsNormalized.meditation.Offset = (100 * trackBarOffsetMeditation.Value * 1.0f / trackBarOffsetMeditation.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetAttention_Scroll(object sender, EventArgs e)
        {
            channelsRaw.attention.Offset = (100 * trackBarOffsetAttention.Value * 1.0f / trackBarOffsetAttention.Maximum);
            channelsNormalized.attention.Offset = (100 * trackBarOffsetAttention.Value * 1.0f / trackBarOffsetAttention.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetTheta_Scroll(object sender, EventArgs e)
        {
            channelsRaw.theta.Offset = (100 * trackBarOffsetTheta.Value * 1.0f / trackBarOffsetTheta.Maximum);
            channelsNormalized.theta.Offset = (100 * trackBarOffsetTheta.Value * 1.0f / trackBarOffsetTheta.Maximum);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarOffsetDelta_Scroll(object sender, EventArgs e)
        {
            channelsRaw.delta.Offset = (100 * trackBarOffsetDelta.Value * 1.0f / trackBarOffsetDelta.Maximum);
            channelsNormalized.delta.Offset = (100 * trackBarOffsetDelta.Value * 1.0f / trackBarOffsetDelta.Maximum);
        }


        // --------------------------------------------------------------------------------------------------------------------
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            if (cboPort.SelectedItem == null)
            {
                _setLastActivity("Cannot connect to selected COM port!");
                return;
            }

            if (!isConnected)
            {
                core.SampleRateHz = 1;
                if (core.Connect(cboPort.SelectedItem.ToString()))
                {
                    _setLastActivity("Connected to headset, started monitoring");
                    isConnected = true;
                    watch.Start();
                    _setGuiMode(EEGLogMode.Monitor);
                }
                else
                {
                    isConnected = false;
                    progressBarEEGSignalStrength.Value = 0;
                    labelConnectionStrength.Text = "0";
                    _setLastActivity("Cannot connect to headset");
                    _sendOscMessagesZero();
                }
            }
            else
            {
                core.Disconnect();
                watch.Reset();
                isConnected = false;
                labelElapsedTime.Text = "00:00";
                labelLastActivityMessage.Text = "None";
                progressBarEEGSignalStrength.Value = 0;
                labelConnectionStrength.Text = "0";
                _sendOscMessagesZero();
                _setGuiMode(EEGLogMode.Idle);
                _setLastActivity("Disconnected from headset, stopped monitoring");
            }

            lstComments.Items.Clear();
            _setupChannelPlots();

            ToggleUIElements();

        }


        #endregion

        #region Private functions


        // ------------------------------------------------------------------------------------------------------
        private int _getNumRecordingsInDataDir(string folder)
        {
            int retval = 0;
            if (Directory.Exists(txtDataDir.Text))
            {
                retval = Directory.GetFiles(txtDataDir.Text, "*.csv", SearchOption.TopDirectoryOnly).Length;
            }
            return retval;
        }

        // --------------------------------------------------------------------------------------------------------------------
        private string _getLogFileLength(string file)
        {
            string retval = "";
            int length = 0;
            try
            {
                string line = null;
                using (StreamReader sr = new StreamReader(File.OpenRead(file)))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                    }
                }
                string[] sa = line.Split(',');
                length = Convert.ToInt32(sa[0]);
                TimeSpan ts = TimeSpan.FromMilliseconds(length);
                retval = ts.Minutes + " min, " + ts.Seconds + " sec";
            }
            catch (Exception)
            {
            }

            return retval;
        }
        // --------------------------------------------------------------------------------------------------------------------
        private delegate void StartFilePlaybackDelegate(string file);
        private void _startFilePlayback(string file)
        {
            if (this.InvokeRequired)
            {
                Invoke(new StartFilePlaybackDelegate(_startFilePlayback), file);
            }
            else
            {
                watch.Reset();

                lstComments.Items.Clear();
                _setupChannelPlots();

                core.LogReplayFinished += core_LogReplayFinished;
                core.LogCommentFound += core_LogCommentFound;

                watch.Start();

                core.ReplayLog(file);

                isReplaying = true;


            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        private delegate void StopFilePlaybackDelegate();
        private void _stopFilePlayback()
        {
            if (this.InvokeRequired)
            {
                Invoke(new StopFilePlaybackDelegate(_stopFilePlayback));
            }
            else
            {

                core.StopReplay();
                core.LogReplayFinished -= core_LogReplayFinished;
                core.LogCommentFound -= core_LogCommentFound;
                isReplaying = false;

                lstComments.Items.Clear();
               channelPlotsRaw.ResetGraphs();
                channelPlotsNormalized.ResetGraphs();
                progressBarEEGSignalStrength.Value = 0;
                labelConnectionStrength.Text = "0";

                _setupChannelPlots();
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private delegate void StartDemoModeDelegate();
        private void _startDemoMode()
        {
            if (this.InvokeRequired)
            {
                Invoke(new StartDemoModeDelegate(_startDemoMode));
            }
            else
            {
                if (Directory.Exists(txtDataDir.Text))
                {
                    string[] files = Directory.GetFiles(txtDataDir.Text, "*.csv", SearchOption.TopDirectoryOnly);

//                    foreach (string f in Directory.GetFiles(txtDataDir.Text, "*.csv", SearchOption.TopDirectoryOnly))
//                  {
//                    System.Diagnostics.Debug.WriteLine("Found file: " + f);
//              }
                    _setLastActivity("Started demo mode. Folder: " + txtDataDir + ", number of files: " + files.Length.ToString());
                    _startFilePlayback(files[currentReplayedFileIndex]);

                    lblCurrentLogPlaying.Text = Path.GetFileName(files[currentReplayedFileIndex]);
                    lblLogLength2.Text = _getLogFileLength(files[currentReplayedFileIndex]);

                    _setGuiMode(EEGLogMode.Demo);
                }
                else
                {
                    _setLastActivity("The folder: " + txtDataDir + " does not exist!");
                    _setGuiMode(EEGLogMode.Idle);
                }
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private delegate void StopDemoModeDelegate();
        private void _stopDemoMode()
        {
            if (this.InvokeRequired)
            {
                Invoke(new StopDemoModeDelegate(_stopDemoMode));
            }
            else
            {
                _setGuiMode(EEGLogMode.Idle);
                _stopFilePlayback();
                _setLastActivity("Stopped demo mode.");
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        private delegate void SetGuiModeDelegate(EEGLogMode mode);
        private void _setGuiMode(EEGLogMode mode)
        {
            if (this.InvokeRequired)
            {
                Invoke(new SetGuiModeDelegate(_setGuiMode), mode);
            }
            else
            {
                switch (mode)
                {
                    case EEGLogMode.Record:
                        panelLiveDataControls.Enabled = false;
                        panelDemoModeControls.Enabled = false;
                        panelReplayLogsControls.Enabled = false;
                        groupBoxHeadsetProperties.Enabled = false;
                        grpComments.Enabled = true;
                        btnRecord.Enabled = true;
                        btnPlayLog.Enabled = false;
                        btnMonitor.Enabled = false;
                        btnDemo.Enabled = false;
                        btnRecord.Text = "Stop";
                        break;
                    case EEGLogMode.Playback:
                        panelLiveDataControls.Enabled = false;
                        panelDemoModeControls.Enabled = false;
                        panelReplayLogsControls.Enabled = false;
                        groupBoxHeadsetProperties.Enabled = false;
                        grpComments.Enabled = false;
                        btnRecord.Enabled = false;
                        btnPlayLog.Enabled = true;
                        btnMonitor.Enabled = false;
                        btnDemo.Enabled = false;
                        btnPlayLog.Text = "Stop";
                        grpComments.Enabled = false;
                        panelReplayLogsControls.Enabled = false;
                        break;
                    case EEGLogMode.Monitor:
                        panelLiveDataControls.Enabled = false;
                        panelDemoModeControls.Enabled = false;
                        panelReplayLogsControls.Enabled = false;
                        groupBoxHeadsetProperties.Enabled = false;
                        grpComments.Enabled = false;
                        btnRecord.Enabled = false;
                        btnPlayLog.Enabled = false;
                        btnMonitor.Enabled = true;
                        btnDemo.Enabled = false;
                        btnMonitor.Text = "Stop";
                        panelLiveDataControls.Enabled = false;
                        break;
                    case EEGLogMode.Demo:
                        panelLiveDataControls.Enabled = false;
                        panelDemoModeControls.Enabled = false;
                        panelReplayLogsControls.Enabled = false;
                        groupBoxHeadsetProperties.Enabled = false;
                        grpComments.Enabled = false;
                        btnRecord.Enabled = false;
                        btnPlayLog.Enabled = false;
                        btnMonitor.Enabled = false;
                        btnDemo.Enabled = true;
                        btnDemo.Text = "Stop";
                        break;
                    case EEGLogMode.Idle:
                        panelLiveDataControls.Enabled = true;
                        panelReplayLogsControls.Enabled = true;
                        groupBoxHeadsetProperties.Enabled = true;
                        grpComments.Enabled = false;
                        btnRecord.Enabled = true;
                        btnPlayLog.Enabled = true;
                        btnMonitor.Enabled = true;
                        btnDemo.Enabled = true;
                        btnMonitor.Text = "Monitor";
                        btnRecord.Text = "Record";
                        btnPlayLog.Text = "Play";
                        panelLiveDataControls.Enabled = true;
                        grpComments.Enabled = true;
                        panelReplayLogsControls.Enabled = true;
                        panelDemoModeControls.Enabled = true;
                        btnDemo.Text = "Demo";
                        lblCurrentLogPlaying.Text = "-";
                        lblLogLength2.Text = "-";
                        break;
                }

                guiMode = mode;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void _loadSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;

            // load settings
            trackBarBottomRightStrip.Value = (int)settings["TrackbarBottomRightStrip"];
            trackBarTopLeftStrip.Value = (int)settings["TrackBarTopLeftStrip"];
            trackBarCushionOutlineStrip.Value = (int)settings["TrackBarCushionOutlineStrip"];
            trackBarBrightness.Value = (int)settings["TrackBarBrightness"];

            txtDataDir.Text = (string)settings["DataFolder"];
            lblNumRecordings.Text = _getNumRecordingsInDataDir(txtDataDir.Text).ToString();
    
            mMidiHandler.loadSettings(settings);
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void _saveSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;

            // save settings
            settings["TrackbarBottomRightStrip"] = trackBarBottomRightStrip.Value;
            settings["TrackBarTopLeftStrip"] = trackBarTopLeftStrip.Value;
            settings["TrackBarCushionOutlineStrip"] = trackBarCushionOutlineStrip.Value;
            settings["TrackBarBrightness"] = trackBarBrightness.Value;
            settings["DataFolder"] = txtDataDir.Text;

            mMidiHandler.saveSettings(settings);

            settings.Save();
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void _appendToSerialLogTextbox(char d)
        {
            textBoxSerialLog.AppendText(d.ToString());
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void ToggleUIElements()
        {
            if (isConnected)
            {
                labelHeadSetStatus.Text = "Connected!";
                labelMidiStatus.Text = "Connected!";
            }
            else
            {
                labelMidiStatus.Text = "Not connected";
                labelHeadSetStatus.Text = "Not connected";
                progressBarEEGSignalStrength.Value = 0;
                labelConnectionStrength.Text = "0";

            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        private float Clamp(float val, float min, float max)
        {
            float retval = val;
            if (val < min)
            {
                retval = min;
            }

            if (val > max)
            {
                retval = max;
            }
            return retval;
        }



        private void _sendOscMessagesZero()
        {

            // send osc messages for each channel to audio client
            foreach (EEGChannelBuffer ch in channelsRaw.ToList())
            {
                List<Int32> parameters = new List<Int32>();
                parameters.Add((Int32)ch.CurrentTime);
                parameters.Add((Int32)(0));
                parameters.Add((Int32)(0));
                parameters.Add((Int32)(0));
                parameters.Add((Int32)(0));
                parameters.Add((Int32)(0));
                parameters.Add((Int32)(0));
                parameters.Add((Int32)(0));
                oscHandler.sendMessageToClient<Int32>(OscClientAudio, "EEGHeadset/" + ch.Name + "/Raw", parameters);
            }

            // send osc messages for each channel to audio client
            foreach (EEGChannelBuffer ch in channelsNormalized.ToList())
            {
                List<Int32> parameters = new List<Int32>();
                parameters.Add((Int32)ch.CurrentTime);
                parameters.Add((Int32)Clamp(0, 0, 100));
                parameters.Add((Int32)Clamp(0, 0, 100));
                parameters.Add((Int32)Clamp(0, 0, 100));
                parameters.Add((Int32)Clamp(0, 0, 100));
                parameters.Add((Int32)Clamp(0, 0, 100));
                parameters.Add((Int32)Clamp(0, 0, 100));
                parameters.Add((Int32)Clamp(0, 0, 100));
                oscHandler.sendMessageToClient<Int32>(OscClientAudio, "EEGHeadset/" + ch.Name + "/Normalized", parameters);
            }


            // send osc message to light client
            List<EEGChannelBuffer> chans = channelsNormalized.ToList();
            List<Int32> parms = new List<Int32>();
            string statusUpdate = "Light client summary: ";
            Int32 v = 0;

            for (int i = 0; i < chans.Count; i++)
            {
                EEGChannelBuffer ch = chans[i];
                // skip meditation/attention channels; for those, add non-normalized values
                if ((ch.Name == "Meditation") || (ch.Name == "Attention"))
                {
                    continue;
                }

                if (i == 0)
                {
                    parms.Add((Int32)ch.CurrentTime);
                }

                v = (Int32)Clamp(0, 0, 100);
                parms.Add(v); // send average of last 15 secs
                
                statusUpdate = statusUpdate + (v.ToString() + ", ");
            }
            // now add meditation/attention, the non-normalized averages of the last 15 seconds
            v = (Int32)Clamp(0, 0, 100);
            parms.Add(v); // send average of last 15 secs
            statusUpdate = statusUpdate + (v.ToString() + ", ");
            v = (Int32)Clamp(0, 0, 100);
            parms.Add(v); // send average of last 15 secs
            statusUpdate = statusUpdate + (v.ToString() + ", ");

            //_setLastActivity(statusUpdate);
            System.Diagnostics.Debug.WriteLine(statusUpdate);

            if (cbWaitForUpdateFromArduino.Checked == false)
            {
                oscHandler.sendMessageToClient<Int32>(OscClientLight, "EEGHeadset/Summary", parms);
            }
            else
            {
                // if light client requests a status update, send it over osc
                OscHandling.Helpers.ServerLog sl = oscHandler.Servers[OscServerLight];
                OscHandling.Helpers.OSCPacket msg = sl.server.LastReceivedPacket;
                if (msg != null)
                {
                    if ((msg.Address.Equals("LC/C1/Req")) && (msg.TimeStamp != lastArduinoOSCUpdateRequestTimestamp))
                    {
                        textBoxOscLog.AppendText("Received request from Arduino: " + msg.Address + Environment.NewLine);

                        lastArduinoOSCUpdateRequestTimestamp = msg.TimeStamp;

                        oscHandler.sendMessageToClient<Int32>(OscClientLight, "EEGHeadset/Summary", parms);
                        oscHandler.sendMessageToClient<Int32>(OscClientLight, "EEGHeadset/Summary", parms);
                    }
                }
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void _sendOscMessages()
        {
            // if the signal strength is below the specified minimum, send all zero values to silence music and turn off (most) lights
            if (cbMinConnectionStrength.Checked && progressBarEEGSignalStrength.Value < nudMinConnectionStrength.Value)
            {
                _sendOscMessagesZero();
                return;
            }

            // send osc messages for each channel to audio client
            foreach (EEGChannelBuffer ch in channelsRaw.ToList())
            {
                List<Int32> parameters = new List<Int32>();
                parameters.Add((Int32)ch.CurrentTime);
                parameters.Add((Int32)(ch.CurrentValue + ch.Offset));
                parameters.Add((Int32)(ch.Average5 + ch.Offset));
                parameters.Add((Int32)(ch.Average15 + ch.Offset));
                parameters.Add((Int32)(ch.Average30 + ch.Offset));
                parameters.Add((Int32)(ch.Average60 + ch.Offset));
                parameters.Add((Int32)(ch.MinValue + ch.Offset));
                parameters.Add((Int32)(ch.MaxValue + ch.Offset));
                oscHandler.sendMessageToClient<Int32>(OscClientAudio, "EEGHeadset/" + ch.Name + "/Raw", parameters);
            }

            // send osc messages for each channel to audio client
            foreach (EEGChannelBuffer ch in channelsNormalized.ToList())
            {
                List<Int32> parameters = new List<Int32>();
                parameters.Add((Int32)ch.CurrentTime);
                parameters.Add((Int32)Clamp(ch.CurrentValue + ch.Offset, 0, 100));
                parameters.Add((Int32)Clamp(ch.Average5 + ch.Offset, 0, 100));
                parameters.Add((Int32)Clamp(ch.Average15 + ch.Offset, 0, 100));
                parameters.Add((Int32)Clamp(ch.Average30 + ch.Offset, 0, 100));
                parameters.Add((Int32)Clamp(ch.Average60 + ch.Offset, 0, 100));
                parameters.Add((Int32)Clamp(ch.MinValue + ch.Offset, 0, 100));
                parameters.Add((Int32)Clamp(ch.MaxValue + ch.Offset, 0, 100));

                oscHandler.sendMessageToClient<Int32>(OscClientAudio, "EEGHeadset/" + ch.Name + "/Normalized", parameters);
            }


            // send osc message to light client
            List<EEGChannelBuffer> chans = channelsNormalized.ToList();
            List<Int32> parms = new List<Int32>();
            string statusUpdate = "Light client summary: ";
            Int32 v = 0;

            for (int i = 0; i < chans.Count; i++)
            {
                EEGChannelBuffer ch = chans[i];
                // skip meditation/attention channels; for those, add non-normalized values
                if ((ch.Name == "Meditation") || (ch.Name == "Attention"))
                {
                    continue;
                }
                
                if (i == 0){
                    parms.Add((Int32)ch.CurrentTime);
                }

                v = (Int32)Clamp(ch.Average15 + ch.Offset, 0, 100);
                parms.Add(v); // send average of last 15 secs
                statusUpdate = statusUpdate + (v.ToString() + ", ");
            }
            // now add meditation/attention, the non-normalized averages of the last 15 seconds
            v = (Int32)Clamp(channelsRaw.meditation.Average15 + channelsRaw.meditation.Offset, 0, 100);
            parms.Add(v); // send average of last 15 secs
            statusUpdate = statusUpdate + (v.ToString() + ", ");
            v = (Int32)Clamp(channelsRaw.attention.Average15 + channelsRaw.attention.Offset, 0, 100);
            parms.Add(v); // send average of last 15 secs
            statusUpdate = statusUpdate + (v.ToString() + ", ");
         
            //_setLastActivity(statusUpdate);
            System.Diagnostics.Debug.WriteLine(statusUpdate);

            if (cbWaitForUpdateFromArduino.Checked == false){
                oscHandler.sendMessageToClient<Int32>(OscClientLight, "EEGHeadset/Summary", parms);
            } else {
                // if light client requests a status update, send it over osc
                OscHandling.Helpers.ServerLog sl = oscHandler.Servers[OscServerLight];
                OscHandling.Helpers.OSCPacket msg = sl.server.LastReceivedPacket;
                if (msg != null)
                {
                    if ((msg.Address.Equals("LC/C1/Req")) && (msg.TimeStamp != lastArduinoOSCUpdateRequestTimestamp))
                    {
                        textBoxOscLog.AppendText("Received request from Arduino: " + msg.Address + Environment.NewLine);

                        lastArduinoOSCUpdateRequestTimestamp = msg.TimeStamp;

                        oscHandler.sendMessageToClient<Int32>(OscClientLight, "EEGHeadset/Summary", parms);
                        oscHandler.sendMessageToClient<Int32>(OscClientLight, "EEGHeadset/Summary", parms);
                    }
                }
            }
        }


        // --------------------------------------------------------------------------------------------------------------------
        public void _updateOffsetUi()
        {
            labelMidiStatus.Text = mMidiHandler.MidiInState;

            List<EEGChannelBuffer> lst = channelsRaw.ToList();
            foreach (EEGChannelBuffer ch in lst)
            {
                dataRows[ch.Name].Cells[5].Value = ch.Offset.ToString("0.00");
            }

            _sendOscMessages();
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void _updateUi(ThinkGearStateEventArgs e)
        {
            txtRaw.Text = e.Data.Raw.ToString();
            txtSignal.Text = e.Data.Signal.ToString();

            labelElapsedTime.Text = watch.Elapsed.Minutes.ToString("00") + ":" + watch.Elapsed.Seconds.ToString("00");

            // update channel values. this also updates all measures like avg5, avg15, avg60
            float timeInSec = (float)(watch.Elapsed.TotalSeconds + watch.Elapsed.Milliseconds * 1.0f / 1000);

            channelsRaw.alpha1.addSample(timeInSec, e.Data.Alpha1);
            channelsRaw.alpha2.addSample(timeInSec, e.Data.Alpha2);
            channelsRaw.beta1.addSample(timeInSec, e.Data.Beta1);
            channelsRaw.beta2.addSample(timeInSec, e.Data.Beta2);
            channelsRaw.gamma1.addSample(timeInSec, e.Data.Gamma1);
            channelsRaw.gamma2.addSample(timeInSec, e.Data.Gamma2);
            channelsRaw.delta.addSample(timeInSec, e.Data.Delta);
            channelsRaw.theta.addSample(timeInSec, e.Data.Theta);
            channelsRaw.meditation.addSample(timeInSec, e.Data.Meditation);
            channelsRaw.attention.addSample(timeInSec, e.Data.Attention);

            List<EEGChannelBuffer> lst = channelsRaw.ToList();
            foreach (EEGChannelBuffer ch in lst)
            {
                dataRows[ch.Name].Cells[1].Value = ch.CurrentValue.ToString("0");
                dataRows[ch.Name].Cells[2].Value = ch.Average15.ToString("0.00");
            }

            // update normalized channel values. 
            channelsNormalized.alpha1.addSample(timeInSec,  channelsRaw.alpha1.CurrentValueNormalized);
            channelsNormalized.alpha2.addSample(timeInSec,  channelsRaw.alpha2.CurrentValueNormalized);
            channelsNormalized.beta1.addSample(timeInSec,   channelsRaw.beta1.CurrentValueNormalized);
            channelsNormalized.beta2.addSample(timeInSec,   channelsRaw.beta2.CurrentValueNormalized);
            channelsNormalized.gamma1.addSample(timeInSec,  channelsRaw.gamma1.CurrentValueNormalized);
            channelsNormalized.gamma2.addSample(timeInSec,  channelsRaw.gamma2.CurrentValueNormalized);
            channelsNormalized.delta.addSample(timeInSec,   channelsRaw.delta.CurrentValueNormalized);
            channelsNormalized.theta.addSample(timeInSec,   channelsRaw.theta.CurrentValueNormalized);
            channelsNormalized.meditation.addSample(timeInSec, channelsRaw.meditation.CurrentValueNormalized);
            channelsNormalized.attention.addSample(timeInSec, channelsRaw.attention.CurrentValueNormalized);

            lst = channelsNormalized.ToList();
            foreach (EEGChannelBuffer ch in lst)
            {
                dataRows[ch.Name].Cells[3].Value = ch.CurrentValue.ToString("0.00");
                dataRows[ch.Name].Cells[4].Value = ch.Average15.ToString("0.00");
            }

            _refreshUIAndSendOsc();
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void _refreshUIAndSendOsc()
        {
            // update channel plots
           channelPlotsRaw.RefreshGraphs();
           channelPlotsNormalized.RefreshGraphs();
           channelPlotsUsed.RefreshGraphs();

            _updateOffsetUi();

            SerialHandler.updateWithNormalizedData(channelsNormalized);
        }


        // --------------------------------------------------------------------------------------------------------------------
        private void _setupChannelPlots()
        {
            Debug.WriteLine("EEGLog._setupChannelPlots() Enter");

            channelPlotsRaw.ResetGraphs();
            channelPlotsNormalized.ResetGraphs();
            channelPlotsUsed.ResetGraphs();
 
            channelsRaw.clear();
            channelsNormalized.clear();

            this.SuspendLayout();

            // raw channels need auto scaling of y values. except attention/meditation, which are always in the range 0..100
            List<EEGChannelPlots.ChannelConfiguration> configs = new List<EEGChannelPlots.ChannelConfiguration>();
            foreach (EEGChannelBuffer buf in channelsRaw.ToList())
            {
                bool autoScaleY = true;
                if ((buf.Name == "Meditation") || (buf.Name == "Attention"))
                {
                    autoScaleY = false;
                }
                configs.Add(new EEGChannelPlots.ChannelConfiguration(buf, autoScaleY, 0, 100));
            }            
            channelPlotsRaw.initialize(configs);


            // normalized channels are always in the range 0..100.. so do not autoscale Y
            configs = new List< EEGChannelPlots.ChannelConfiguration>();
            foreach (EEGChannelBuffer buf in channelsNormalized.ToList())
            {
                configs.Add(new EEGChannelPlots.ChannelConfiguration(buf, false, 0, 100));
            }
            channelPlotsNormalized.initialize(configs);

            // for demo purpose, populate a tab with graphs that are used to drive the music/leds
            configs = new List<EEGChannelPlots.ChannelConfiguration>();
            configs.Add( new EEGChannelPlots.ChannelConfiguration(channelsNormalized.alpha1, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsNormalized.alpha2, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsNormalized.beta1, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsNormalized.beta2, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsNormalized.delta, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsNormalized.gamma1, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsNormalized.gamma2, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsNormalized.theta, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsRaw.meditation, false, 0, 100));
            configs.Add(new EEGChannelPlots.ChannelConfiguration(channelsRaw.attention, false, 0, 100));
            channelPlotsUsed.initialize(configs);


            this.ResumeLayout();
        }

        // --------------------------------------------------------------------------------------------------------------------
        private static string _makeFilenamePostfix()
        {
            // DateTime dt = DateTime.Now;
            // return dt.Date.Year.ToString() + "." + dt.Date.Month.ToString("D2") + "." + dt.Date.Day.ToString("D2") + "-" + dt.TimeOfDay.Hours.ToString("D2") + "." + dt.TimeOfDay.Minutes.ToString("D2") + "." + dt.TimeOfDay.Seconds.ToString("D2");
            return DateTime.Now.ToString("yyyy.MM.dd_hh.mm.ss");
        }

        #endregion

        #region Static functions

        // ------------------------------------------------------------------------------------------------------
        public static void sendTopLeftStripOsc(float divisionTopLeft)
        {
            List<float> parameters = new List<float>();
            parameters.Add((float)divisionTopLeft);
            OSCHandler.Instance.sendMessageToAllClients<float>("EEGHeadset/StripControl/TopLeft", parameters);
            System.Diagnostics.Debug.WriteLine("Strip division - top left - " + divisionTopLeft.ToString());
        }

        // ------------------------------------------------------------------------------------------------------
        public static void sendBottomRightStripOsc( float divisionBottomRight)
        {
            List<float> parameters = new List<float>();
            parameters.Add((float)divisionBottomRight);
            OSCHandler.Instance.sendMessageToAllClients<float>("EEGHeadset/StripControl/BottomRight", parameters);
            System.Diagnostics.Debug.WriteLine("Strip division - bottom right - " + divisionBottomRight.ToString());
        }

        // ------------------------------------------------------------------------------------------------------
        public static void sendCouchOutlineStripOsc( float divisionCushionOutline)
        {
            List<float> parameters = new List<float>();
            parameters.Add((float)divisionCushionOutline);
            OSCHandler.Instance.sendMessageToAllClients<float>("EEGHeadset/StripControl/CouchOutline", parameters);
            System.Diagnostics.Debug.WriteLine("Strip division - cushion outline - " + divisionCushionOutline.ToString());
        }

        // ------------------------------------------------------------------------------------------------------
        public static void sendBrightnessOsc(int brightness)
        {
            List<Int32> parameters = new List<Int32>();
            parameters.Add((Int32)brightness);
            OSCHandler.Instance.sendMessageToAllClients<Int32>("EEGHeadset/StripControl/Brightness", parameters);
        }

        #endregion

        // --------------------------------------------------------------------------------------------------------------------
        private void _setLastActivity(string activity)
        {
            labelLastActivityMessage.Text = activity;
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void _onMidiCC(string name, int value)
        {
            List<Int32> parameters = new List<Int32>();
            parameters.Add((Int32)value);
            OSCHandler.Instance.sendMessageToAllClients<Int32>("EEGHeadset/" + name, parameters);

            _setLastActivity("Effect " + name + " set to value " + value.ToString());
        }
    
        // --------------------------------------------------------------------------------------------------------------------
        private void _onChannelOffsetChanged(string name, int offset)
        {
//            System.Diagnostics.Debug.WriteLine("Changed offset for " + name + " to " + offset.ToString());

            List<EEGChannelBuffer> chans = channelsRaw.ToList();
            foreach (EEGChannelBuffer chan in chans)
            {
                if (chan.Name == name)
                {
                    chan.Offset = offset;
                }
            }
            
            chans = channelsNormalized.ToList();
            foreach (EEGChannelBuffer chan in chans)
            {
                if (chan.Name == name)
                {
                    chan.Offset = offset;
                }
            }

            _setLastActivity("Channel " + name + " offset value " + offset.ToString());
        }


        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx1Param1_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX1/Param1", (int) (trackBarFx1Param1.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx1Param2_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX1/Param2", (int)(trackBarFx1Param2.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx1Param3_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX1/Param3", (int)(trackBarFx1Param3.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx2Param1_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX2/Param1", (int)(trackBarFx2Param1.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx2Param2_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX2/Param2", (int)(trackBarFx2Param2.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx2Param3_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX2/Param3", (int)(trackBarFx2Param3.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx3Param1_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX3/Param1", (int)(trackBarFx3Param1.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarFx3Param2_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("FX3/Param2", (int)(trackBarFx3Param2.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarAttentionVolume_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("Mixer/AttentionLevel", (int)(this.trackBarAttentionVolume.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarMeditationVolume_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("Mixer/MeditationLevel", (int)(this.trackBarMeditationVolume.Value * 127.0f / 1000));
        }

        // --------------------------------------------------------------------------------------------------------------------
        private void trackBarMasterVolume_Scroll(object sender, EventArgs e)
        {
            _onMidiCC("Mixer/MasterLevel", (int)(this.trackBarMasterVolume.Value * 127.0f / 1000));
        }



    }
}
