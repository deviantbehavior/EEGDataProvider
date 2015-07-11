using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EEGLog.OscHandling;
using PureMidi.CoreMmSystem.MidiIO;
using PureMidi.CoreMmSystem.MidiIO.Data;
using PureMidi.CoreMmSystem.MidiIO.Definitions;
using PureMidi.CoreMmSystem.MidiIO.DeviceInfo;


namespace EEGLog.MidiHandling
{
    public partial class MidiHandler : UserControl
    {

        #region Fields
        private InputDevice mInputDevice = null;
        private bool mIsMonitoringMidi = false;
        #endregion

        #region Properties
        public string MidiInState { get { return mIsMonitoringMidi ? "Connected" : "Not connected"; } }
        #endregion

        #region Delegates
        private delegate void appendTextDelegate(string msg);
        #endregion

#region public functions
        internal void loadSettings(Properties.Settings settings)
        {
            string selectedDevice = "";

            try
            {
                // load settings
                nudOffsetBetaH.Value = (int)settings["OffsetBetaH"];
                nudOffsetBetaL.Value = (int)settings["OffsetBetaL"];
                nudOffsetGammaH.Value = (int)settings["OffsetGammaH"];
                nudOffsetGammaL.Value = (int)settings["OffsetGammaL"];
                nudOffsetAlphaH.Value = (int)settings["OffsetAlphaH"];
                nudOffsetAlphaL.Value = (int)settings["OffsetAlphaL"];
                nudOffsetMeditation.Value = (int)settings["OffsetMeditation"];
                nudOffsetAttention.Value = (int)settings["OffsetAttention"];
                nudOffsetTheta.Value = (int)settings["OffsetTheta"];
                nudOffsetDelta.Value = (int)settings["OffsetDelta"];


                nudFx1Param1.Value = (int)settings["Fx1Param1"];
                nudFx1Param2.Value = (int)settings["Fx1Param2"];
                nudFx1Param3.Value = (int)settings["Fx1Param3"];
                nudFx2Param1.Value = (int)settings["Fx2Param1"];
                nudFx2Param2.Value = (int)settings["Fx2Param2"];
                nudFx2Param3.Value = (int)settings["Fx2Param3"];
                nudFx3Param1.Value = (int)settings["Fx3Param1"];
                nudFx3Param2.Value = (int)settings["Fx3Param2"];

                nudMeditationVolume.Value = (int)settings["MeditationVolume"];
                nudAttentionVolume.Value = (int)settings["AttentionVolume"];
                nudMasterVolume.Value = (int)settings["MasterVolume"];

                selectedDevice = (string)settings["SelectedMidiInDevice"];
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error while restoring the application settings: " + e.Message);
            }

            if (selectedDevice.Length > 0)
            {
                int index = -1;
                int selectedIndex = -1;
                foreach (string s in comboBoxInputDevices.Items)
                {
                    index += 1;
                    if (s == selectedDevice)
                    {
                        selectedIndex = index;
                    }
                }

                if (selectedIndex > 0)
                {
                    comboBoxInputDevices.SelectedIndex = selectedIndex;
                    _startMonitoring();
                }
            }

        }

        internal void saveSettings(Properties.Settings settings)
        {
            settings["SelectedMidiInDevice"] = (string) (comboBoxInputDevices.SelectedItem==null?"None":comboBoxInputDevices.SelectedItem);
            settings["OffsetBetaH"] = (int)nudOffsetBetaH.Value;
            settings["OffsetBetaL"] = (int)nudOffsetBetaL.Value;
            settings["OffsetGammaH"] = (int)nudOffsetGammaH.Value;
            settings["OffsetGammaL"] = (int)nudOffsetGammaL.Value;
            settings["OffsetAlphaH"] = (int)nudOffsetAlphaH.Value;
            settings["OffsetAlphaL"] = (int)nudOffsetAlphaL.Value;
            settings["OffsetMeditation"] = (int)nudOffsetMeditation.Value;
            settings["OffsetAttention"] = (int)nudOffsetAttention.Value;
            settings["OffsetTheta"] = (int)nudOffsetTheta.Value;
            settings["OffsetDelta"] = (int)nudOffsetDelta.Value;

            settings["Fx1Param1"] = (int)nudFx1Param1.Value;
            settings["Fx1Param2"] = (int)nudFx1Param2.Value;
            settings["Fx1Param3"] = (int)nudFx1Param3.Value;
            settings["Fx2Param1"] = (int)nudFx2Param1.Value;
            settings["Fx2Param2"] = (int)nudFx2Param2.Value;
            settings["Fx2Param3"] = (int)nudFx2Param3.Value;
            settings["Fx3Param1"] = (int)nudFx3Param1.Value;
            settings["Fx3Param2"] = (int)nudFx3Param2.Value;

            settings["MeditationVolume"] = (int)nudMeditationVolume.Value;
            settings["AttentionVolume"] = (int)nudAttentionVolume.Value;
            settings["MasterVolume"] = (int)nudMasterVolume.Value;

        }
#endregion

        public delegate void ChannelOffsetChangedHandler(string name, int offset);
        public event ChannelOffsetChangedHandler ChannelOffsetChanged;

        public delegate void MidiCCHandler(string name, int offset);
        public event MidiCCHandler MidiCC;

        #region Private functions
        // ------------------------------------------------------------------------------------------------------
        private void _sendMidiCC(string name, int value)
        {
            if (MidiCC != null)
            {
                MidiCC(name, value);
            }
        }
        // ------------------------------------------------------------------------------------------------------
        private void _sendChannelOffsetChanged(string name, int offset)
        {
            if (ChannelOffsetChanged != null)
            {
                ChannelOffsetChanged(name, offset);
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private void _onMidiEvent(MidiEvent ev)
        {
            try
            {
                string msg = _midiEventToLog(ev);

                _appendText(msg + Environment.NewLine);

                int shortType = ev.Status & 0xF0;
                int cc = ev.AllData[1];
                if ((shortType == 0xb0))
                {

                    if (cc == nudBrightness.Value)
                    {
                        EEGLogMain.sendBrightnessOsc(ev.AllData[2]);
                    }

                    if (cc == this.nudOffsetAlphaL.Value)
                    {
                        _sendChannelOffsetChanged("AlphaL", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetAlphaH.Value)
                    {
                        _sendChannelOffsetChanged("AlphaH", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetBetaL.Value)
                    {
                        _sendChannelOffsetChanged("BetaL", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetBetaH.Value)
                    {
                        _sendChannelOffsetChanged("BetaH", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetGammaL.Value)
                    {
                        _sendChannelOffsetChanged("GammaL", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetGammaH.Value)
                    {
                        _sendChannelOffsetChanged("GammaH", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetMeditation.Value)
                    {
                        _sendChannelOffsetChanged("Meditation", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetAttention.Value)
                    {
                        _sendChannelOffsetChanged("Attention", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetTheta.Value)
                    {
                        _sendChannelOffsetChanged("Theta", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }
                    if (cc == this.nudOffsetDelta.Value)
                    {
                        _sendChannelOffsetChanged("Delta", (int)(100 * ev.AllData[2] * 1.0f / 127));
                    }

                    if (cc == this.nudFx1Param1.Value)
                    {
                        _sendMidiCC("FX1/Param1", ev.AllData[2]);
                    }
                    if (cc == this.nudFx1Param2.Value)
                    {
                        _sendMidiCC("FX1/Param2", ev.AllData[2]);
                    }
                    if (cc == this.nudFx1Param3.Value)
                    {
                        _sendMidiCC("FX1/Param3", ev.AllData[2]);
                    }
                    if (cc == this.nudFx2Param1.Value)
                    {
                        _sendMidiCC("FX2/Param1", ev.AllData[2]);
                    }
                    if (cc == this.nudFx2Param2.Value)
                    {
                        _sendMidiCC("FX2/Param2", ev.AllData[2]);
                    }
                    if (cc == this.nudFx2Param3.Value)
                    {
                        _sendMidiCC("FX2/Param3", ev.AllData[2]);
                    }
                    if (cc == this.nudFx3Param1.Value)
                    {
                        _sendMidiCC("FX3/Param1", ev.AllData[2]);
                    }
                    if (cc == this.nudFx3Param2.Value)
                    {
                        _sendMidiCC("FX3/Param2", ev.AllData[2]);

                    }
                    if (cc == this.nudAttentionVolume.Value)
                    {
                        _sendMidiCC("Mixer/AttentionLevel", ev.AllData[2]);
                    }
                    if (cc == this.nudMeditationVolume.Value)
                    {
                        _sendMidiCC("Mixer/MeditationLevel", ev.AllData[2]);
                    }
                    if (cc == this.nudMasterVolume.Value)
                    {
                        _sendMidiCC("Mixer/MasterLevel", ev.AllData[2]);
                    }

                }
            }
            catch (Exception)
            {
                _stopMonitoring();
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private void _appendText(string text)
        {
            if (this.InvokeRequired)
            {
                appendTextDelegate del = new appendTextDelegate(_appendText);
                this.Invoke(del, text);
            }
            else
            {
                textBoxMessages.AppendText(text);
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private static string _getShortMessageDescription(MidiEvent ev)
        {
            string retVal;
            var shortType = ev.Status & 0xF0;
            switch (shortType)
            {
                case 0x80:
                    retVal = "NoteOff " + ev.AllData[1] + " Velo=" + ev.AllData[2];
                    break;
                case 0x90:
                    retVal = "NoteOn " + ev.AllData[1] + " Velo=" + ev.AllData[2];
                    break;
                case 0xA0:
                    retVal = "PollyAftertouch " + ev.AllData[1] + " Val=" + ev.AllData[2];
                    break;
                case 0xB0:
                    retVal = "CC " + ev.AllData[1] + " Val=" + ev.AllData[2];
                    break;
                case 0xC0:
                    retVal = "ProgramChange";
                    break;
                default:
                    retVal = "unknown/invalid";
                    break;
            }

            return retVal;
        }

        // ------------------------------------------------------------------------------------------------------
        private static string _midiEventToLog(MidiEvent ev)
        {
            if (ev.MidiEventType == EMidiEventType.Short)
            {
                return ev.Hex + "|  "
                       + ev.Status.ToString("X2").ToUpper() + "  |  " +
                       (ev.Status & 0xF0).ToString("X2").ToUpper() + " | " +
                       ((ev.Status & 0x0F) + 1).ToString("X2").ToUpper() + " |  " +
                       ev.AllData[1].ToString("X2").ToUpper() + "   |  " +
                       ev.AllData[2].ToString("X2").ToUpper() + "   | " +
                       _getShortMessageDescription(ev);
            }
            return ev.Hex + "|  SYSEX";
        }

        // ------------------------------------------------------------------------------------------------------
        private void _startMonitoring()
        {
            _stopMonitoring();

            try
            {
                if (comboBoxInputDevices.SelectedIndex > 0)
                {
                    mInputDevice = new InputDevice(comboBoxInputDevices.SelectedIndex - 1);
                    mInputDevice.OnMidiEvent += _onMidiEvent;
                    mInputDevice.Start();

                    buttonStartStopMonitoring.Text = "Stop";
                    comboBoxInputDevices.Enabled = false;

                    mIsMonitoringMidi = true;
                }
            }
            catch (Exception e)
            {
                //the midi library is kind of flaky, but ok
                MessageBox.Show(e.Message.ToString(), "Error opening midi device");
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());

                mInputDevice = null;
                buttonStartStopMonitoring.Text = "Start";
                comboBoxInputDevices.Enabled = true;

                mIsMonitoringMidi = false;
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private void _stopMonitoring()
        {
            try
            {
                if (mInputDevice != null)
                {
                    mInputDevice.Stop();
                    mInputDevice.Dispose();
                    mInputDevice = null;
                }
            }
            catch (Exception)
            {
                //the midi library is kind of flaky, but ok
            }

            mIsMonitoringMidi = false;

            mInputDevice = null;
            buttonStartStopMonitoring.Text = "Start";
            comboBoxInputDevices.Enabled = true;
        }

        #endregion

        #region Constructor

        // ------------------------------------------------------------------------------------------------------
        public MidiHandler()
        {
            InitializeComponent();

            comboBoxInputDevices.Items.Add("Select a device");
            IEnumerable<MidiInInfo> inp = MidiInInfo.Informations;
            foreach (MidiInInfo midiInInfo in inp)
            {
                comboBoxInputDevices.Items.Add(midiInInfo.ToString());
            }
            comboBoxInputDevices.SelectedIndex = 0;

            textBoxMessages.ReadOnly = true;
        }

        #endregion

        #region Event handlers
        // ------------------------------------------------------------------------------------------------------
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.ParentForm != null)
            {
                // need to properly close the midi input device on application exit, otherwise it will cause an exception            
                this.ParentForm.FormClosing += new FormClosingEventHandler(parentForm_FormClosing);
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private void parentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // need to properly close the midi input device on application exit, otherwise it will cause an exception
            _stopMonitoring();
        }

        // ------------------------------------------------------------------------------------------------------
        private void buttonStartStopMonitoring_Click(object sender, EventArgs e)
        {
            if (!mIsMonitoringMidi)
            {
                _startMonitoring();
            }
            else
            {
                _stopMonitoring();
            }
        }
        #endregion

       
    }
}
