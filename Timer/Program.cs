using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer1 = new Timer(new TimerCallback(OnTimer), 1, 0, 2000);
            Timer timer2 = new Timer(new TimerCallback(OnTimer), 2, 0, 3000);
            Console.ReadLine();
        }
        static void OnTimer(object obj)
        {
            Console.WriteLine("Timer: {0} Thread: {1} Is pool thread: {2}",
               (int)obj,
               Thread.CurrentThread.GetHashCode(),
               Thread.CurrentThread.IsThreadPoolThread);
        }
        //static void Main(string[] args)
        //{
        //    Timer timer1 = new Timer(Handler, 1, 0, 2000);
        //    Timer timer2 = new Timer(Handler, 2, 0, 3000);

        //    Console.ReadKey();
        //}

        //private static void Handler(object state)
        //{
        //    Console.WriteLine("Timer: '{0}'. Is pool thread:{1}, Hash:{2}", state, Thread.CurrentThread.IsThreadPoolThread, System.Threading.Thread.CurrentThread.GetHashCode());

        //}
    }
}
