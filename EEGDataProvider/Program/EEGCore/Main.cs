using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using ThinkGearNET;

namespace EEG
{
    public class EEGCore
    {
        private ThinkGearWrapper thinkGear = new ThinkGearWrapper();
        private int sleepTime = 1000;
        private int lastSignal = 0;
        private int sampleRateHz = 1;
        private Stopwatch sw = new Stopwatch();
        private StreamWriter logWriter;

        public bool IsConnected { get; private set; }
        public bool IsLogging { get; private set; }
        public bool IsReplaying { get; private set; }
        public int BaudRate = 57600;
        public string LogDelimiter = ",";

        public int SampleRateHz
        {
            get { return sampleRateHz; }
            set
            {
                sampleRateHz = value;
                sleepTime = 1000 / value;
            }
        }

        public event EventHandler<ThinkGearStateEventArgs> DataReceived;
        public event EventHandler<SignalChangedEventArgs> SignalChanged;
        public event EventHandler<EventArgs> LogReplayFinished;
        public event EventHandler<CommentEventArgs> LogCommentFound;

        public bool Connect(string COMPort)
        {
            if (thinkGear.Connect(COMPort, BaudRate, true))
            {
                thinkGear.ThinkGearChanged += thinkGear_ThinkGearChanged;
                IsConnected = true;
                sw.Start();
            }
            else
                IsConnected = false;
            return IsConnected;
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                sw.Stop();
                thinkGear.Disconnect();
            }
        }

        public void StartLog(string filename, bool overwriteIfExists)
        {
            if (!IsLogging)
            {
                if (File.Exists(filename))
                {
                    if (overwriteIfExists)
                        File.Delete(filename);
                    else
                        throw new Exception("The specified file already exists");
                }

                logWriter = new StreamWriter(File.OpenWrite(filename));
                logWriter.WriteLine("Timestamp{0}Alpha1{0}Alpha2{0}Beta1{0}Beta2{0}Delta{0}Gamma1{0}Gamma2{0}Theta{0}Meditation{0}Attention{0}Raw{0}Signal", LogDelimiter);
                sw.Reset();
                sw.Start();
                IsLogging = true;
            }
            else
                throw new Exception("Logging already in progress");
        }

        public void StopLog()
        {
            if (IsLogging && logWriter != null)
            {
                logWriter.Flush();
                logWriter.Close();
                logWriter.Dispose();
                logWriter = null;
                IsLogging = false;
            }
            else
                throw new Exception("Logging is not in progress");
        }

        public void WriteLogComment(string message)
        {
            if (logWriter != null)
            {
                logWriter.WriteLine("# " + message);
            }
        }

        public void ReplayLog(string filename)
        {
            SortedDictionary<int, EEGState> log = new SortedDictionary<int, EEGState>();
            using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
            {
                int lastTimestamp = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (!line.StartsWith("Timestamp"))
                    {
                        if (line.StartsWith("#")) // Comment
                        {
                            if (log.ContainsKey(lastTimestamp))
                            {
                                log[lastTimestamp].Comment = line.Substring(1).Trim();
                            }
                        }
                        else
                        {
                            string[] sa = line.Split(',');
                            int timestamp = Convert.ToInt32(sa[0]);
                            EEGState state = new EEGState();
                            state.Alpha1 = Convert.ToInt32(sa[1]);
                            state.Alpha2 = Convert.ToInt32(sa[2]);
                            state.Beta1 = Convert.ToInt32(sa[3]);
                            state.Beta2 = Convert.ToInt32(sa[4]);
                            state.Delta = Convert.ToInt32(sa[5]);
                            state.Gamma1 = Convert.ToInt32(sa[6]);
                            state.Gamma2 = Convert.ToInt32(sa[7]);
                            state.Theta = Convert.ToInt32(sa[8]);
                            state.Meditation = Convert.ToInt32(sa[9]);
                            state.Attention = Convert.ToInt32(sa[10]);
                            state.Raw = Convert.ToInt32(sa[11]);
                            state.Signal = Convert.ToInt32(sa[12]);
                            log.Add(timestamp, state);
                            lastTimestamp = timestamp;
                        }
                    }
                }
            }
            List<long> intervals = new List<long>();
            for (int i = 1; i < log.Count; i++)
            {
                intervals.Add(log.Keys.ElementAt(i) - log.Keys.ElementAt(i - 1));
            }
            int interval = (int)intervals.Average();

            var obj = Tuple.Create<SortedDictionary<int, EEGState>, int>(log, interval);
            IsReplaying = true;
            ThreadPool.QueueUserWorkItem(ReplayLogAsync, obj);            
        }

        public void StopReplay()
        {
            IsReplaying = false;
        }

        private void ReplayLogAsync(object obj)
        {
            SortedDictionary<int, EEGState> log = ((Tuple<SortedDictionary<int, EEGState>,int>)obj).Item1;
            int interval = ((Tuple<SortedDictionary<int, EEGState>, int>)obj).Item2;
            foreach (KeyValuePair<int, EEGState> item in log)
            {
                if (!IsReplaying)
                    break;
                ThinkGearStateEventArgs args = new ThinkGearStateEventArgs();
                args.Data = item.Value;
                args.Timestamp = item.Key;
                OnDataReceived(args);
                if (!string.IsNullOrWhiteSpace(args.Data.Comment))
                    OnLogCommentFound(new CommentEventArgs(item.Key, args.Data.Comment));
                if ((int)item.Value.Signal != lastSignal)
                {
                    SignalChangedEventArgs signalArgs = new SignalChangedEventArgs();
                    signalArgs.NewSignal = (int)item.Value.Signal;
                    signalArgs.OldSignal = lastSignal;
                    lastSignal = (int)item.Value.Signal;
                    OnSignalChanged(signalArgs);
                }
                lastSignal = (int)item.Value.Signal;
                Thread.Sleep(interval);
            }
            OnLogReplayFinished(null);
        }

        private void thinkGear_ThinkGearChanged(object sender, ThinkGearChangedEventArgs e)
        {
            int signal = 100 - (int)e.ThinkGearState.PoorSignal;
            if (signal != lastSignal)
            {
                SignalChangedEventArgs signalArgs = new SignalChangedEventArgs();
                signalArgs.NewSignal = signal;
                signalArgs.OldSignal = lastSignal;
                lastSignal = signal;
                OnSignalChanged(signalArgs);
            }
            ThinkGearStateEventArgs args = new ThinkGearStateEventArgs();
            args.Data = new EEGState(e.ThinkGearState);
            args.Timestamp = sw.ElapsedMilliseconds;
            OnDataReceived(args);
            if (IsLogging && logWriter != null)
            {
                string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                    sw.ElapsedMilliseconds, e.ThinkGearState.Alpha1, e.ThinkGearState.Alpha2, e.ThinkGearState.Beta1, e.ThinkGearState.Beta2,
                    e.ThinkGearState.Delta, e.ThinkGearState.Gamma1, e.ThinkGearState.Gamma2, e.ThinkGearState.Theta, e.ThinkGearState.Meditation,
                    e.ThinkGearState.Attention, e.ThinkGearState.Raw, 100 - e.ThinkGearState.PoorSignal);
                logWriter.WriteLine(line);
            }
            Thread.Sleep(sleepTime);
        }

        protected virtual void OnDataReceived(ThinkGearStateEventArgs e)
        {
            EventHandler<ThinkGearStateEventArgs> handler = DataReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSignalChanged(SignalChangedEventArgs e)
        {
            EventHandler<SignalChangedEventArgs> handler = SignalChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLogReplayFinished(EventArgs e)
        {
            EventHandler<EventArgs> handler = LogReplayFinished;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnLogCommentFound(CommentEventArgs e)
        {
            EventHandler<CommentEventArgs> handler = LogCommentFound;
            if (handler != null)
            {
                handler(this, e);
            }
        }    
    }

    public class ThinkGearStateEventArgs : EventArgs
    {
        public long Timestamp { get; set; }
        public EEGState Data { get; set; }
    }

    public class SignalChangedEventArgs : EventArgs
    {
        public int NewSignal { get; set; }
        public int OldSignal { get; set; }
    }

    public class CommentEventArgs : EventArgs
    {
        public long Timestamp { get; set; }
        public string Text { get; set; }

        public CommentEventArgs(long timestamp, string text)
        {
            Timestamp = timestamp;
            Text = text;
        }
    }

    public class EEGState
    {
        public float Alpha1;
        public float Alpha2;
        public float Attention;
        public float Beta1;
        public float Beta2;
        public float BlinkStrength;
        public float Delta;
        public float Gamma1;
        public float Gamma2;
        public float Meditation;
        public float Signal;
        public float Raw;
        public float Theta;
        public string Comment;

        internal EEGState(ThinkGearState state)
        {
            Alpha1 = state.Alpha1;
            Alpha2 = state.Alpha2;
            Beta1 = state.Beta1;
            Beta2 = state.Beta2;
            Delta = state.Delta;
            Gamma1 = state.Gamma1;
            Gamma2 = state.Gamma2;
            Theta = state.Theta;
            Attention = state.Attention;
            Meditation = state.Meditation;
            Signal = 100 - state.PoorSignal;
            Raw = state.Raw;
            BlinkStrength = state.BlinkStrength;
        }

        public EEGState() { }
    }

    
}
