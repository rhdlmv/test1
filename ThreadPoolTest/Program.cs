using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.WaitCallback callBack;

            callBack = new System.Threading.WaitCallback(PooleFunc);
            //callBack = (state) => { };

            Console.WriteLine("Main thread is pool thread: {0}, hashCode:{1}", Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.GetHashCode());

            ThreadPool.QueueUserWorkItem(callBack, "Is there any screw left?");
            ThreadPool.QueueUserWorkItem(callBack, "How much is a 40w bulb?");
            ThreadPool.QueueUserWorkItem(callBack, "Decrease stock of monkey wrench");
            Console.ReadKey();
        }

        static void PooleFunc(object state)
        {
            Console.WriteLine("processing request '{0}'. Is pool thread:{1}, Hash:{2}", (string)state, Thread.CurrentThread.IsThreadPoolThread, System.Threading.Thread.CurrentThread.GetHashCode());

            // int ticks = Environment.TickCount;
            Thread.Sleep(2000);
            Console.WriteLine("Request processed");
        }
    }
}
