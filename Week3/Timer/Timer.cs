using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Timer
{
    class Timer
    {
        private int seconds;
        private int times;

        // Delegate
        private delegate void TimerTicker();

        public int Times
        {
            get { return this.times; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Except");
                }
                this.times = value;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Enter correct time");
                }
                this.seconds = value;
            }
        }

        public Timer(int seconds, int times)
        {
            this.Seconds = seconds;
            this.Times = times;
        }


        public void Invoke()
        {
            var watch = new Stopwatch();
            watch.Start();

            // Passing method
            var myTimer = new TimerTicker(PrintTime);
            var times = 0;

            while (true)
            {
                if (watch.Elapsed.Seconds != this.Seconds)
                {
                    continue;
                }

                times++;
                myTimer.Invoke();

                if (times == this.Times)
                {
                    break;
                }

                watch.Restart();
            }
        }


        public void PrintTime()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
