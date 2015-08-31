using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thread1
{
    class Program
    {
        private static readonly object locker = new object();
        private bool done;
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";
            var t = new Thread(PrintYou);
            t.Start("you");
            t.Name = "Thread1";
            var d = t.Join(1000);
            

            new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("me ");
                    var currentThread = Thread.CurrentThread;
                    var name = currentThread.Name;
                }
            }) { Name = "Thread2" }.Start();

            Console.WriteLine("Thread t has ended!");
            Console.ReadKey();
            var currentThread1 = Thread.CurrentThread;
            var name1 = currentThread1.Name;

        }

        private static void PrintYou(object messageObj)
        {
            for (int i = 0; i < 100; i++)
            {
                var currentThread = Thread.CurrentThread;
                var name = currentThread.Name;
                Console.Write(messageObj.ToString() + " ");
            }
        }
    }
}
