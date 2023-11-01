using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Client
{
    public class Timer
    {
        Stopwatch stopwatch;
        TimeSpan lastTs;
        float deltaTime;
        float fixedDeltaTime;
        public void SetFixedDeltaTime(float dt) { fixedDeltaTime = dt; }

        static Timer _time;
        public static float DeltaTime => _time.deltaTime;
        public static float FixedDeltaTime => _time.fixedDeltaTime;
        public static float Time => (float)_time.stopwatch.Elapsed.TotalSeconds;

        public Timer()
        {
            stopwatch = new Stopwatch();
            fixedDeltaTime = GlobalConfig.FIXED_DELTA_TIME;
        }

        public void Start()
        {
            if (_time != null)
            {
                return;
            }
            stopwatch.Start();
            lastTs = new TimeSpan();
            _time = this;
        }

        public void Stop()
        {
            stopwatch.Stop();
            stopwatch.Reset();
            _time = null;
        }

        public void Record()
        {
            TimeSpan curSpan = stopwatch.Elapsed;
            TimeSpan interval = curSpan - lastTs;
            deltaTime = (float)interval.TotalSeconds;
            lastTs = curSpan;
        }

        public float CurFrameTime => (float)(stopwatch.Elapsed - lastTs).TotalSeconds;

    }
}