using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Timer
    {
        Stopwatch sw = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;

        private float deltaTime = 0.005f;

        public float Seconds
        {
            get { return sw.ElapsedMilliseconds / 1000.0f; }

        }
        public Timer()
        {
            sw.Start();
        }
        public void Reset()
        {
            sw.Reset();
        }

        public float GetDeltaTime()
        {
            lastTime = currentTime;
            currentTime = sw.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            return deltaTime;

        }
    }
}
