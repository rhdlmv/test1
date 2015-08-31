using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManualResetEventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************************");
            Console.WriteLine("输入\"stop\"停止线程运行...");
            Console.WriteLine("输入\"run\"开启线程运行...");
            Console.WriteLine("****************************\r\n");

            MREDemo objMRE = new MREDemo();
            objMRE.CreateThreads();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "stop")
                {
                    Console.WriteLine("线程已停止运行...");
                    objMRE.Reset();
                }
                else if (input.Trim().ToLower() == "run")
                {
                    Console.WriteLine("线程开启运行...");
                    objMRE.Set();
                }
            }
            
        }
    }
}
