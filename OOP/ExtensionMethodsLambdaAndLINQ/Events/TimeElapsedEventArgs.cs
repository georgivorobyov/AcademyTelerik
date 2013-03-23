using System;

namespace Events
{
    public class TimeElapsedEventArgs : EventArgs
    {
        public int Tick { get; private set; }

        public TimeElapsedEventArgs(int tick)
        {
            this.Tick = tick;
        }
    }
}
