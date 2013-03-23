using System;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public class Timer
    {
        private int interval;
        private int ticks;
        private readonly TimerDelegate callback;

        public int RemainingTicks { get; private set; }

        public int Interval
        {
            get
            {
                return this.interval;
            }
            private set
            {
                ValueValidator(value);
                this.interval = value * 1000;
            }
        }

        public int Ticks
        {
            get
            {
                return this.ticks;
            }
            private set
            {
                ValueValidator(value);
                this.ticks = value;
            }
        }

        public Timer(int interval, int ticks, TimerDelegate callback)
        {
            this.Interval = interval;
            this.Ticks = ticks;
            this.callback = callback;
        }

        public void Run()
        {
            this.RemainingTicks = this.ticks;
            Task.Run(() =>
            {
                while (this.RemainingTicks > 0)
                {
                    Thread.Sleep(this.interval);
                    this.callback(this.RemainingTicks);
                    this.RemainingTicks--;
                }
            });
        }

        private void ValueValidator(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("The number must be a positive!");
            }
        }
    }
}


