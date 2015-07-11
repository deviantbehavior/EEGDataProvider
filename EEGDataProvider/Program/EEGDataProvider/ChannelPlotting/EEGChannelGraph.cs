using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

using EEGLog.Channels;

namespace EEGLog.ChannelPlotting
{
    using GraphLib;

    public class EEGChannelGraph : Panel
    {
        #region Fields
        List<ChannelGraph> channelGraphs = new List<ChannelGraph>();
        PlotterDisplayEx display = new PlotterDisplayEx();
        private string plotName = "";
        #endregion

        #region Structs


        // ------------------------------------------------------------------------------------------------------
        public enum ColorScheme
        {
            DARK_GREEN,
            WHITE,
            BLUE,
            GRAY,
            RED,
            LIGHT_BLUE,
            BLACK,
            SACHA
        }

        // ------------------------------------------------------------------------------------------------------
        struct ChannelGraph
        {
            public DataSource dataSource;
            public EEGChannelBuffer EEGChannelBuffer;
            public ChannelGraph(DataSource ds, EEGChannelBuffer bf){
                EEGChannelBuffer = bf;
                dataSource = ds;
            }
        }
        #endregion

        #region Constructor
        // ------------------------------------------------------------------------------------------------------
        public EEGChannelGraph(){
            _initializeGUI();
        }
        #endregion

        #region Public methods
        // ------------------------------------------------------------------------------------------------------
        public override void Refresh()
        {
            _updateAllDataSources();
            base.Refresh();
        }

        // ------------------------------------------------------------------------------------------------------
        public void setGraphRange(float min, float max)
        {
            foreach (DataSource ds in display.DataSources)
            {
                ds.SetDisplayRangeY(min, max);
            }
        }

        // ------------------------------------------------------------------------------------------------------
        public void initialize(string name, List<EEGChannelBuffer> c)
        {
            plotName = name;
            display.DataSources.Clear();
            channelGraphs.Clear();

            foreach (EEGChannelBuffer buf in c)
            {
                _addChannelGraph(buf);
            }
            setColorScheme(ColorScheme.SACHA);
        }

        // ------------------------------------------------------------------------------------------------------
        public void setColorScheme(ColorScheme cs)
        {
            switch (cs)
            {
                case ColorScheme.DARK_GREEN:
                    {
                        Color[] cols = { Color.FromArgb(0,255,0), 
                                         Color.FromArgb(0,255,0),
                                         Color.FromArgb(0,255,0), 
                                         Color.FromArgb(0,255,0), 
                                         Color.FromArgb(0,255,0) ,
                                         Color.FromArgb(0,255,0),                              
                                         Color.FromArgb(0,255,0) };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % 7];
                        }

                        display.BackgroundColorTop = Color.FromArgb(0, 64, 0);
                        display.BackgroundColorBot = Color.FromArgb(0, 64, 0);
                        display.SolidGridColor = Color.FromArgb(0, 128, 0);
                        display.DashedGridColor = Color.FromArgb(0, 128, 0);
                    }
                    break;
                case ColorScheme.WHITE:
                    {
                        Color[] cols = { Color.DarkRed, 
                                         Color.DarkSlateGray,
                                         Color.DarkCyan, 
                                         Color.DarkGreen, 
                                         Color.DarkBlue ,
                                         Color.DarkMagenta,                              
                                         Color.DeepPink };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % 7];
                        }

                        display.BackgroundColorTop = Color.White;
                        display.BackgroundColorBot = Color.White;
                        display.SolidGridColor = Color.LightGray;
                        display.DashedGridColor = Color.LightGray;
                    }
                    break;

                case ColorScheme.BLUE:
                    {
                        Color[] cols = { Color.Red, 
                                         Color.Orange,
                                         Color.Yellow, 
                                         Color.LightGreen, 
                                         Color.Blue ,
                                         Color.DarkSalmon,                              
                                         Color.LightPink };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % 7];
                        }

                        display.BackgroundColorTop = Color.Navy;
                        display.BackgroundColorBot = Color.FromArgb(0, 0, 64);
                        display.SolidGridColor = Color.Blue;
                        display.DashedGridColor = Color.Blue;
                    }
                    break;

                case ColorScheme.GRAY:
                    {
                        Color[] cols = { Color.DarkRed, 
                                         Color.DarkSlateGray,
                                         Color.DarkCyan, 
                                         Color.DarkGreen, 
                                         Color.DarkBlue ,
                                         Color.DarkMagenta,                              
                                         Color.DeepPink };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % 7];
                        }

                        display.BackgroundColorTop = Color.White;
                        display.BackgroundColorBot = Color.LightGray;
                        display.SolidGridColor = Color.LightGray;
                        display.DashedGridColor = Color.LightGray;
                    }
                    break;

                case ColorScheme.RED:
                    {
                        Color[] cols = { Color.DarkCyan, 
                                         Color.Yellow,
                                         Color.DarkCyan, 
                                         Color.DarkGreen, 
                                         Color.DarkBlue ,
                                         Color.DarkMagenta,                              
                                         Color.DeepPink };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % 7];
                        }

                        display.BackgroundColorTop = Color.DarkRed;
                        display.BackgroundColorBot = Color.Black;
                        display.SolidGridColor = Color.Red;
                        display.DashedGridColor = Color.Red;
                    }
                    break;

                case ColorScheme.LIGHT_BLUE:
                    {
                        Color[] cols = { Color.DarkRed, 
                                         Color.DarkSlateGray,
                                         Color.DarkCyan, 
                                         Color.DarkGreen, 
                                         Color.DarkBlue ,
                                         Color.DarkMagenta,                              
                                         Color.DeepPink };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % 7];
                        }

                        display.BackgroundColorTop = Color.White;
                        display.BackgroundColorBot = Color.FromArgb(183, 183, 255);
                        display.SolidGridColor = Color.Blue;
                        display.DashedGridColor = Color.Blue;
                    }
                    break;

                case ColorScheme.BLACK:
                    {
                        Color[] cols = { Color.FromArgb(255,0,0), 
                                         Color.FromArgb(0,255,0),
                                         Color.FromArgb(255,255,0), 
                                         Color.FromArgb(64,64,255), 
                                         Color.FromArgb(0,255,255) ,
                                         Color.FromArgb(255,0,255),                              
                                         Color.FromArgb(255,128,0) };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % 7];
                        }

                        display.BackgroundColorTop = Color.Black;
                        display.BackgroundColorBot = Color.Black;
                        display.SolidGridColor = Color.DarkGray;
                        display.DashedGridColor = Color.DarkGray;
                    }
                    break;

                case ColorScheme.SACHA:
                    {
                        Color[] cols = {    Color.Black,
                                            Color.Red,
                                            Color.LightGreen,
                                            Color.Yellow,
                                            Color.Magenta
                                       };

                        for (int j = 0; j < display.DataSources.Count; j++)
                        {
                            display.DataSources[j].GraphColor = cols[j % cols.Length];
                        }

                        display.GraphBoxColor = Color.Black;
                        display.BackgroundColorTop = Color.White;
                        display.BackgroundColorBot = Color.White;
                        display.SolidGridColor = Color.DarkGray;
                        display.DashedGridColor = Color.DarkGray;
                    }
                    break;
            }

        }

        public void ClearDisplay()
        {
            display.DataSources.Clear();
        }

        #endregion

        #region Private methods
        // ------------------------------------------------------------------------------------------------------
        private String _onRenderXLabel(DataSource s, int idx)
        {
            //            return "Time";
            return plotName;
        }

        // ------------------------------------------------------------------------------------------------------
        private String _onRenderYLabel(DataSource s, float value)
        {
            return String.Format("{0:0.0}", value);
        }

        // ------------------------------------------------------------------------------------------------------
        private void _updateDataSource(DataSource ds, EEGChannelBuffer buf)
        {
            cPoint[] dest = ds.Samples;
            for (uint i = 0; i < buf.BufferSize; i++)
            {
                EEGChannelBuffer.sample s = buf.getSample(i);
                dest[i].x = s.time;
                dest[i].y = s.value;
            }

        }

        // ------------------------------------------------------------------------------------------------------
        private void _updateAllDataSources()
        {
            foreach (ChannelGraph graph in channelGraphs)
            {
                _updateDataSource(graph.dataSource, graph.EEGChannelBuffer);
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private void _addChannelGraph(EEGChannelBuffer buf)
        {
            DataSource ds = new DataSource();
            display.DataSources.Add(ds);
            ds.OnRenderXAxisLabel += _onRenderXLabel;
            ds.OnRenderYAxisLabel = _onRenderYLabel;
            ds.Name = buf.Name;
            ds.Length = (int)buf.Length;
            ds.XAutoScaleOffset = 0;

            ds.AutoScaleX = true;
            ds.AutoScaleY = false;

            ds.SetDisplayRangeY(-300, 300);
            ds.SetGridDistanceY(100);

            channelGraphs.Add(new ChannelGraph(ds, buf));
        }

        // ------------------------------------------------------------------------------------------------------
        private void _initializeGUI()
        {
            SuspendLayout();

            display.DataSources.Clear();
            display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;

            display.BackColor = System.Drawing.Color.White;
            display.BackgroundColorBot = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            display.BackgroundColorTop = System.Drawing.Color.Navy;
            display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            display.DashedGridColor = System.Drawing.Color.Blue;
            display.Dock = System.Windows.Forms.DockStyle.Fill;
            display.DoubleBuffering = true;
            display.Location = new System.Drawing.Point(0, 24);
            display.Name = "display";
            display.PlaySpeed = 0.5F;
            display.Size = new System.Drawing.Size(620, 472);
            display.SolidGridColor = System.Drawing.Color.Blue;
            display.TabIndex = 1;
            display.ToolbarVisible = false;
            display.SetMaxTileCount(2, 2);
            display.SetLabelsVisible(true, false);
            
            display.SetGridVisible(false);

            Controls.Add(display);



            ResumeLayout();
            display.Refresh();
        }

        #endregion
    }
}
