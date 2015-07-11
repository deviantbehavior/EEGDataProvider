using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using EEGLog.Channels;

namespace EEGLog.ChannelPlotting
{
    class EEGChannelPlots : Panel
    {
        #region Fields
        private Dictionary<ChannelWrapper, EEGChannelGraph> mGraphs = new Dictionary<ChannelWrapper, EEGChannelGraph>();
        private Dictionary<ChannelWrapper, ChannelConfiguration> mGraphConfigs = new Dictionary<ChannelWrapper, ChannelConfiguration>();
        private List<ChannelWrapper> mChannelWrappers = new List<ChannelWrapper>();
        private Dictionary<string, CheckBox> mPlotCheckboxes = new Dictionary<string, CheckBox>();
        #endregion

        #region Classes, Structs
        
        // ------------------------------------------------------------------------------------------------------
        public class ChannelConfiguration
        {
            public bool autoUpdateYRange = true;
            public float yMin = 0;
            public float yMax = 100;
            public EEGChannelBuffer buffer = null;
            
            public ChannelConfiguration(EEGChannelBuffer buf, bool updateYR, float ymin, float ymax)
            {
                autoUpdateYRange = updateYR;
                yMin = ymin;
                yMax = ymax;
                buffer = buf;
            }
            
            public ChannelConfiguration()
            {
            }
        }
        // ------------------------------------------------------------------------------------------------------
        private struct ChannelWrapper
        {
            #region Fields
            private EEGChannelBuffer original;
            public EEGChannelBuffer data;
            public EEGChannelBuffer average5;
            public EEGChannelBuffer average15;
            public EEGChannelBuffer average30;
            public EEGChannelBuffer average60;
            #endregion

            #region Properties
            public float MinValue { get { return _getMinValue(); } }
            public float MaxValue { get { return _getMaxValue(); } }
            public string ChannelName { get { return original.Name; } }
            #endregion

            #region Private functions
            // ------------------------------------------------------------------------------------------------------
            private float _getMinValue()
            {
                float v = float.MaxValue;

                v = original.MinValue < v ? original.MinValue : v;
                v = average5.MinValue < v ? average5.MinValue : v;
                v = average15.MinValue < v ? average15.MinValue : v;
                v = average30.MinValue < v ? average30.MinValue : v;
                v = average60.MinValue < v ? average60.MinValue : v;

                return v;
            }

            // ------------------------------------------------------------------------------------------------------
            private float _getMaxValue()
            {
                float v = float.MinValue;

                v = original.MaxValue > v ? original.MaxValue : v;
                v = average5.MaxValue > v ? average5.MaxValue : v;
                v = average15.MaxValue > v ? average15.MaxValue : v;
                v = average30.MaxValue > v ? average30.MaxValue : v;
                v = average60.MaxValue > v ? average60.MaxValue : v;

                return v;
            }
            #endregion

            #region Public functions
            // ------------------------------------------------------------------------------------------------------
            public List<EEGChannelBuffer> getEnabledChannels()
            {
                List<EEGChannelBuffer> list = new List<EEGChannelBuffer>();
                if (data.Enabled) list.Add(data);
                if (average5.Enabled) list.Add(average5);
                if (average15.Enabled) list.Add(average15);
                if (average30.Enabled) list.Add(average30);
                if (average60.Enabled) list.Add(average60);
                return list;
            }

            // ------------------------------------------------------------------------------------------------------
            public List<EEGChannelBuffer> getAllChannels()
            {
                List<EEGChannelBuffer> list = new List<EEGChannelBuffer>();
                list.Add(data);
                list.Add(average5);
                list.Add(average15);
                list.Add(average30);
                list.Add(average60);
                return list;
            }

            // ------------------------------------------------------------------------------------------------------
            public void update()
            {
                data.addSample(original.CurrentTime, original.CurrentValue);
                average5.addSample(original.CurrentTime, original.Average5);
                average15.addSample(original.CurrentTime, original.Average15);
                average30.addSample(original.CurrentTime, original.Average30);
                average60.addSample(original.CurrentTime, original.Average60);
            }
            #endregion

            // ------------------------------------------------------------------------------------------------------
            public static List<string> getDefaultChannelNames()
            {
                List<string> lst = new List<string>();
                lst.Add("Data");
                lst.Add("Avg5");
                lst.Add("Avg15");
                lst.Add("Avg30");
                lst.Add("Avg60");
                return lst;
            }

            #region Constructor
            // ------------------------------------------------------------------------------------------------------
            public ChannelWrapper(EEGChannelBuffer org)
            {
                uint buffersize = org.BufferSize;
                original = org;
                data = new EEGChannelBuffer("Actual", buffersize);
                average5 = new EEGChannelBuffer("Avg5", buffersize);
                average15 = new EEGChannelBuffer("Avg15", buffersize);
                average30 = new EEGChannelBuffer("Avg30", buffersize);
                average60 = new EEGChannelBuffer("Avg60", buffersize);

                data.Enabled = true;
                average5.Enabled = true;
                average15.Enabled = true;
                average30.Enabled = true;
                average60.Enabled = true;
            }
            #endregion
        }
        #endregion
        
        #region Constructor
        // ------------------------------------------------------------------------------------------------------
        public EEGChannelPlots()
        {
//            InitializeComponent();
            this.BackColor = Color.White;
            Layout += _onLayout;
        }
        #endregion

        #region Private functions
        // ------------------------------------------------------------------------------------------------------
        private void _addChannelWrapper(ChannelConfiguration cfg)
        {
            ChannelWrapper wrapper = new ChannelWrapper(cfg.buffer);
            mChannelWrappers.Add(wrapper);
            EEGChannelGraph graph = new EEGChannelGraph();
            mGraphConfigs[wrapper] = cfg;
            mGraphs[wrapper] = graph;
            
            Controls.Add(graph);
        }

        // ------------------------------------------------------------------------------------------------------
        private void _onLayout(object sender, EventArgs e)
        {
            const int CHECKBOXROWHEIGHT = 20;
            const int NUMPANELSPERROW = 5;

            int panelWidth = (int)(this.ClientRectangle.Width / NUMPANELSPERROW);
            int panelHeight = (int)((this.ClientRectangle.Height-20) / 2);

            int numPanel = 0;
            foreach (KeyValuePair<ChannelWrapper, EEGChannelGraph> pair in mGraphs)
            {
                int x = numPanel%5;
                int y = (int)Math.Floor(numPanel *1.0f/ NUMPANELSPERROW);
                pair.Value.Location = new Point(x * panelWidth, CHECKBOXROWHEIGHT + y * panelHeight);
                pair.Value.Size = new Size(panelWidth, panelHeight);

                numPanel = numPanel + 1;
            }

            int numChk = 1;
            int chkWidth = (int)(this.ClientRectangle.Width / (mPlotCheckboxes.Count+2));
            foreach (KeyValuePair<string, CheckBox> chk in mPlotCheckboxes)
            {
                int x = numChk * chkWidth;
                int y = 0;
                chk.Value.Location = new Point(x, y);
                chk.Value.Size = new Size(chkWidth, CHECKBOXROWHEIGHT);
                numChk += 1;
            }
        }
        #endregion

        #region Public functions


        // ------------------------------------------------------------------------------------------------------
        public void initialize(List<ChannelConfiguration> configs)
        {
            this.SuspendLayout();
            mPlotCheckboxes.Clear();
            mGraphConfigs.Clear();
            mGraphs.Clear();
            mChannelWrappers.Clear();
            Controls.Clear();

            foreach (string s in ChannelWrapper.getDefaultChannelNames())
            {
                // do not show checkbox for data, plot is always visible
                if (s.ToLower() == "data")
                {
                    continue;
                }

                CheckBox chkb = new CheckBox();
                chkb.Text = s;

                // by default, only avg15 plot is shown
                chkb.CheckedChanged += new EventHandler(chkb_CheckedChanged);
                chkb.Checked = (s.ToLower() == "avg15");

                Controls.Add(chkb);
                this.mPlotCheckboxes.Add(chkb.Text, chkb);
            }

            foreach (ChannelConfiguration cfg in configs)
            {
                _addChannelWrapper(cfg);
            }

            this.ResumeLayout();

            _setupChannelGraphs();
        }

        // ------------------------------------------------------------------------------------------------------
        private void _setupChannelGraphs()
        {
            this.SuspendLayout();

            foreach (ChannelWrapper wrap in mChannelWrappers)
            {
                List<EEGChannelBuffer> channels = wrap.getAllChannels();

                foreach (EEGChannelBuffer ch in channels)
                {
                    if (mPlotCheckboxes.ContainsKey(ch.Name))
                    {
                        ch.Enabled = mPlotCheckboxes[ch.Name].Checked;
                    }
                    else
                    {
                        ch.Enabled = true;
                    }
                }

                // process 1st channel (alpha1, alpha2, beta1, beta2 and so on) using a standard checkbox name
//                channels[0].Enabled = mPlotCheckboxes["Data"].Checked;

                mGraphs[wrap].initialize(wrap.ChannelName, wrap.getEnabledChannels());
            }

            foreach (KeyValuePair<string, CheckBox> chk in mPlotCheckboxes)
            {
                Controls.Add(chk.Value);
            }
            this.ResumeLayout();
            RefreshGraphs();
        }

        // ------------------------------------------------------------------------------------------------------
        void chkb_CheckedChanged(object sender, EventArgs e)
        {
            _setupChannelGraphs();
        }

        // ------------------------------------------------------------------------------------------------------
        public void setColorScheme(EEGChannelGraph.ColorScheme cs)
        {
            foreach (KeyValuePair<ChannelWrapper, EEGChannelGraph> pair in mGraphs)
            {
                pair.Value.setColorScheme(cs);
            }
        }

        // ------------------------------------------------------------------------------------------------------
        public void RefreshGraphs()
        {
            foreach (KeyValuePair<ChannelWrapper, EEGChannelGraph> pair in mGraphs)
            {
                pair.Key.update();

                ChannelConfiguration cfg = mGraphConfigs.ContainsKey(pair.Key) ? mGraphConfigs[pair.Key] : new ChannelConfiguration();
                if (cfg.autoUpdateYRange)
                {
                    pair.Value.setGraphRange(pair.Key.MinValue, pair.Key.MaxValue);
                }
                else
                {
                    pair.Value.setGraphRange(cfg.yMin, cfg.yMax);
                }

                pair.Value.Refresh();
            }
        }

        public void ResetGraphs()
        {
            foreach (EEGChannelGraph graph in mGraphs.Values)
            {
                graph.ClearDisplay();
            }
            RefreshGraphs();
        }
        #endregion
    }
}
