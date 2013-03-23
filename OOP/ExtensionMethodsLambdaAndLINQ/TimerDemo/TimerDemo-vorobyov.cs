using System;
using System.Threading;

// Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace TimerDemo
{
    class TimerDemo
    {
        static void Main()
        {
            Timer.Timer timer = new Timer.Timer(1, 5, (x) =>
            {
                Console.WriteLine("Tick: {0}", x);
                Console.Beep();
            });

            timer.Run();

            while (true)
            {
                Thread.Sleep(250);
                Console.WriteLine("Main Thread!");
            }
        }
    }
}
