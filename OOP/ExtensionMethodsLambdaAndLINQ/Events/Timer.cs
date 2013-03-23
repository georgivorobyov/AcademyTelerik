using System;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    public class Timer
    {
        private int interval;
        private int ticks;

        public event TimerDelegate Event;

        public int RemaindingTicks { get; private set; }

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

        public Timer(int interval, int ticks)
        {
            this.Interval = interval;
            this.Ticks = ticks;
        }

        public void Run()
        {
            this.RemaindingTicks = this.ticks;
            Task.Run(() =>
            {
                while (this.RemaindingTicks > 0)
                {
                    OnTimeElapsed(this.RemaindingTicks);
                    Thread.Sleep(this.interval);
                    this.RemaindingTicks--;
                }
            });
        }

        private void OnTimeElapsed(int ticks)
        {
            if (this.Event != null)
            {
                var e = new TimeElapsedEventArgs(ticks);
                this.Event(this, e);
            }
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


