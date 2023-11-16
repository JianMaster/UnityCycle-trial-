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
        public float DeltaTime => deltaTime;
        float fixedDeltaTime;
        public float FixedDeltaTime => fixedDeltaTime;
        public void SetFixedDeltaTime(float dt) { fixedDeltaTime = dt; }

        public float Time => (float)stopwatch.Elapsed.TotalSeconds;

        public Timer()
        {
            stopwatch = new Stopwatch();
            fixedDeltaTime = GlobalConfig.FIXED_DELTA_TIME;
        }

        public void Start()
        {
            stopwatch.Start();
            lastTs = new TimeSpan();
        }

        public void Stop()
        {
            stopwatch.Stop();
            stopwatch.Reset();
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