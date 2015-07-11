using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EEGLog.Channels
{
    public class EEGChannels
    {
        #region Fields
        public EEGChannelBuffer alpha1 = null;
        public EEGChannelBuffer alpha2 = null;
        public EEGChannelBuffer beta1 = null;
        public EEGChannelBuffer beta2 = null;
        public EEGChannelBuffer delta = null;
        public EEGChannelBuffer gamma1 = null;
        public EEGChannelBuffer gamma2 = null;
        public EEGChannelBuffer theta = null;
        public EEGChannelBuffer meditation = null;
        public EEGChannelBuffer attention = null;
        #endregion

        #region Public functions
        // ------------------------------------------------------------------------------------------------------
        public List<EEGChannelBuffer> ToList()
        {
            List<EEGChannelBuffer> list = new List<EEGChannelBuffer>();
            if (alpha1.Enabled) list.Add(alpha1);
            if (alpha2.Enabled) list.Add(alpha2);
            if (beta1.Enabled) list.Add(beta1);
            if (beta2.Enabled) list.Add(beta2);
            if (delta.Enabled) list.Add(delta);
            if (gamma1.Enabled) list.Add(gamma1);
            if (gamma2.Enabled) list.Add(gamma2);
            if (theta.Enabled) list.Add(theta);
            if (meditation.Enabled) list.Add(meditation);
            if (attention.Enabled) list.Add(attention);
            return list;
        }

        // ------------------------------------------------------------------------------------------------------
        public void clear()
        {
            foreach (EEGChannelBuffer chan in ToList())
            {
                chan.clear();
            }
        }
        #endregion

        #region Constructor
        // ------------------------------------------------------------------------------------------------------
        public EEGChannels(uint buffersize)
        {
            alpha1 = new EEGChannelBuffer("AlphaL", buffersize);
            alpha2 = new EEGChannelBuffer("AlphaH", buffersize);
            beta1 = new EEGChannelBuffer("BetaL", buffersize);
            beta2 = new EEGChannelBuffer("BetaH", buffersize);
            delta = new EEGChannelBuffer("Delta", buffersize);
            gamma1 = new EEGChannelBuffer("GammaL", buffersize);
            gamma2 = new EEGChannelBuffer("GammaH", buffersize);
            theta = new EEGChannelBuffer("Theta", buffersize);
            meditation = new EEGChannelBuffer("Meditation", buffersize);
            attention = new EEGChannelBuffer("Attention", buffersize);

            alpha1.Enabled = true;
            alpha2.Enabled = true;
            beta1.Enabled = true;
            beta2.Enabled = true;
            gamma1.Enabled = true;
            gamma2.Enabled = true;
            delta.Enabled = true;
            theta.Enabled = true;
            meditation.Enabled = true;
            attention.Enabled = true;
        }
        #endregion
    }
}
