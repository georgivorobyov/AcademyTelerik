using System;
using System.Threading;
using Events;

/*
 * * Read in MSDN about the keyword event in C# and how to publish events.
 * Re-implement the above using .NET events and following the best practices.
 */

namespace EventsDemo
{
    class TimerDemo
    {
        static void Main()
        {
            Timer timer = new Timer(1, 5);
            timer.Event += (s, e) => Console.WriteLine("Tick: {0}", e.Tick);
            timer.Run();

            while (true)
            {
                Console.WriteLine("Main Thread.");
                Thread.Sleep(250);
            }
        }
    }
}
