using System;
using System.Collections.Generic;

namespace EEGLog.Channels
{
    public class EEGChannelBuffer
    {
        #region Structs, classes
        public class sample
        {
            public float time;
            public float value;

            public sample(float t, float v)
            {
                time = t;
                value = v;
            }
        }
        #endregion

        #region Fields
        private sample[] mBuffer = null;
        
        private string mName = "";

        private float mAverage5 = 0;
        private float mAverage15 = 0;
        private float mAverage30 = 0;
        private float mAverage60 = 0;

        private float mMinValue = float.MaxValue;
        private float mMaxValue = float.MinValue;
        private float mMinTime = float.MaxValue;
        private float mMaxTime = float.MinValue;

        private float mOffset = 0;
        private bool mIsEnabled = true;
        #endregion

        #region Properties
        public bool Enabled { get { return mIsEnabled; } set { mIsEnabled = value; } }
        public int Length { get { return mBuffer.Length; } }
        public float CurrentTime { get { return mBuffer[mBuffer.Length - 1].time; } }
        public float CurrentValue { get { return mBuffer[mBuffer.Length - 1].value; } }
        public float CurrentValueNormalized { get { return _getCurrentValueNormalized(); } }
        public float MinValue { get { return mMinValue; } }
        public float MaxValue { get { return mMaxValue; } }
        public float MinTime { get { return mMinTime; } }
        public float MaxTime { get { return mMaxTime; } }
        public float Average5 { get { return mAverage5; } }
        public float Average15 { get { return mAverage15; } }
        public float Average30 { get { return mAverage30; } }
        public float Average60 { get { return mAverage60; } }
        public float Offset { get { return mOffset; } set { mOffset = value; } }
        public string Name { get { return mName; } }
        public uint BufferSize { get { return (uint)mBuffer.Length; } }
        #endregion

        #region Private functions
        // ------------------------------------------------------------------------------------------------------
        private void _shiftBuffer()
        {
            for (uint i = 1; i < mBuffer.Length; i++)
            {
                mBuffer[i - 1] = mBuffer[i];
            }
        }

        // ------------------------------------------------------------------------------------------------------
        private float _calculateAverage(float window)
        {
            float avg = 0;
            int numSamples = 0;
        
            for (uint i = 0; i < mBuffer.Length; i++)
            {
                if ((i > 0) && (mBuffer[i].time>0) && ((CurrentTime - mBuffer[i].time) <= window))
                {
                    avg += mBuffer[i].value;
                    numSamples += 1;                   
                }
            }

            if (numSamples > 0)
            {
                avg = avg / numSamples;
            }
            else
            {
                avg = 0;
            }
            return avg;          
        }

        // ------------------------------------------------------------------------------------------------------
        private void _calculateMeasures()
        {

            mMinValue = float.MaxValue;
            mMaxValue = float.MinValue;
            mMinTime = float.MaxValue;
            mMaxTime = float.MinValue;

            for (uint i = 0; i < mBuffer.Length; i++)
            {
                if (mBuffer[i] == null)
                {
                    continue;
                }

                if (mBuffer[i].value < mMinValue)
                {
                    mMinValue = mBuffer[i].value;
                }
                if (mBuffer[i].value > mMaxValue)
                {
                    mMaxValue = mBuffer[i].value;
                }
                if (mBuffer[i].time < mMinTime)
                {
                    mMinTime = mBuffer[i].time;
                }
                if (mBuffer[i].time > mMaxTime)
                {
                    mMaxTime = mBuffer[i].time;
                }
            }

            mAverage5 = _calculateAverage(5);
            mAverage15 = _calculateAverage(15);
            mAverage30 = _calculateAverage(30);
            mAverage60 = _calculateAverage(60);
        }

        // ------------------------------------------------------------------------------------------------------
        private float _getCurrentValueNormalized()
        {

            float minValue = float.MaxValue;
            float maxValue = float.MinValue;

            float val = 0;

            for (uint i = 0; i < mBuffer.Length-2; i++)
            {
                if (mBuffer[i] == null)
                {
                    continue;
                }

                val = (mBuffer[i].value + mBuffer[i + 1].value + mBuffer[i+2].value)/3;

                if (val < minValue)
                {
                    minValue = val;
                }
                if (val > maxValue)
                {
                    maxValue = val;
                }
            }

            float rv = 0;
            if (maxValue != minValue)
            {
                rv = 100 * (val - minValue) / (maxValue - minValue);
            }

            return rv;
        }
        #endregion

        #region Public functions 
        // ------------------------------------------------------------------------------------------------------
        public sample getSample(uint index)
        {
            if(index>=mBuffer.Length){
                return null;
            }
            return mBuffer[index];
        }

        // ------------------------------------------------------------------------------------------------------
        public void addSample(float time, float data)
        {
         
            _shiftBuffer();

            mBuffer[mBuffer.Length - 1] = new sample(time, data);
          
            _calculateMeasures();
        }

        // ------------------------------------------------------------------------------------------------------
        public void clear()
        {
            mBuffer = new sample[50];

            for (uint i = 0; i < mBuffer.Length; i++)
            {
                mBuffer[i] = new sample(-mBuffer.Length+i, 0);
            }

            mAverage5 = 0;
            mAverage15 = 0;
            mAverage30 = 0;
            mAverage60 = 0;

            mMinValue = float.MaxValue;
            mMaxValue = float.MinValue;
            mMinTime = float.MaxValue;
            mMaxTime = float.MinValue;
        }
        #endregion

        #region Constructor
        // ------------------------------------------------------------------------------------------------------
        public EEGChannelBuffer(string name, uint size)
        {
            mName = name;
            mMinValue = 0;
            mMaxValue = 0;
            mBuffer = new sample[size];
            clear();
        }
        #endregion
    }
}
