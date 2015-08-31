using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ManualResetEventDemo
{
    class MREDemo
    {
        private ManualResetEvent _mre;

        public MREDemo()
        {
            this._mre = new ManualResetEvent(false);
        }

        public void CreateThreads()
        {
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(Run));
            t2.Start();
        }

        public void Set()
        {
            this._mre.Set();
        }

        public void Reset()
        {
            this._mre.Reset();
        }

        private void Run()
        {
            string strThreadID = string.Empty;
            try
            {
                while (true)
                {
                 
                    strThreadID = Thread.CurrentThread.ManagedThreadId.ToString();
                    Console.WriteLine("Thread(" + strThreadID + ") is running...");
                    // 阻塞当前线程
                    this._mre.WaitOne();

                    Thread.Sleep(5000);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("线程(" + strThreadID + ")发生异常！错误描述：" + ex.Message.ToString());
            }
        }

    }
}
