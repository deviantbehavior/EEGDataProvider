using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace EEGLog
{
    using Channels;

    delegate void AppendTextToSerialLogHandler(char a);

    class SerialHandler
    {
        private SerialPort serialPort = null;
        private volatile bool exitWorkerThread = false;
        private Thread workerThread = null;
        private Object syncObject = new Object();

        public event AppendTextToSerialLogHandler AppendTextToSerialLog;

        private struct ChannelData
        {
            public byte currentValue;
            public byte average5;
            public byte average15;
            public byte average30;
            public byte average60;

        };

        private ChannelData[] channelData = new ChannelData[10];

        public SerialHandler()
        {
            for (int index = 0; index != channelData.Length; index++)
            {
                channelData[index].currentValue = 0;
                channelData[index].average5 = 0;
                channelData[index].average15 = 0;
                channelData[index].average30 = 0;
                channelData[index].average60 = 0;
                index += 1;
            }
     
        }

        public void initialize(string portId, int baudrate)
        {
            shutdown();

            try
            {
                serialPort = new SerialPort(portId, baudrate);
                serialPort.Open();
                exitWorkerThread = false;
                workerThread = new Thread(this._workerThreadEntry);
                workerThread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: could not open com port " + portId + " at baudrate " + baudrate.ToString() + ". Error message " + e.Message);
            }
        }

        public void shutdown()
        {
            if (serialPort != null)
            {
                exitWorkerThread = true;
                workerThread.Join();
                serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }
        }

        public void updateWithNormalizedData(EEGChannels channels)
        {
            lock (syncObject)
            {
                int index = 0;
                foreach (EEGChannelBuffer buf in channels.ToList())
                {
                    channelData[index].currentValue = (byte)buf.CurrentValue;
                    channelData[index].average5 = (byte)buf.Average5;
                    channelData[index].average15 = (byte)buf.Average15;
                    channelData[index].average30 = (byte)buf.Average30;
                    channelData[index].average60 = (byte)buf.Average60;
                    index += 1;
                }
            }
        }

        private void _workerThreadEntry()
        {
            while (!exitWorkerThread)
            {
                // loop until exit requested
                while ((!exitWorkerThread) &&(serialPort.BytesToRead!=0))
                {
                    Byte[] b = new Byte[1];

                    // read a single byte
                    serialPort.Read(b, 0, 1);

                    // if it was a request for updated channel data, send a response
                    // otherwise, just echo the received byte to the log
                    switch (b[0])
                    {
                        case 0xf0:
                          lock (syncObject)
                            {
                                byte[] bout = new byte[1];
                                bout[0] = 0xff;
                                serialPort.Write(bout, 0, 1);

                                for (int i = 0; i < channelData.Length; i++)
                                {
                                    bout[0] = channelData[i].average15;
                                    serialPort.Write(bout, 0, 1);
                                }
                            }
                            break;
                        default:
                            if (AppendTextToSerialLog != null)
                            {
                                AppendTextToSerialLog((char)b[0]);
                            }
                            break;
                    }
                    

                }
            }
        }
    }
}
