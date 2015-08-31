using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace 算法的运行时间
{
    class Program
    {
        static void Main()
        {
            int[] nums = new int[100000];
            BuildArray(nums);
            Timing tObj = new Timing();
            tObj.StartTime();
            DisplayNums(nums);
            tObj.StopTime();
            Console.WriteLine("time (.NET): " + tObj.Result().TotalSeconds);
            Console.ReadKey();
        }
        static void BuildArray(int[] arr)
        {
            for (int i = 0; i < 100000; i++)
                arr[i] = i;
        }
        static void DisplayNums(int[] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                Console.Write(arr[i] + " ");
        }
    }

    public class Timing
    {
        TimeSpan startingTime;
        TimeSpan duration;

        public Timing()
        {
            startingTime = new TimeSpan(0);
        }

        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void StopTime()
        {
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }

        public TimeSpan Result()
        {
            return this.duration;
        }
    }
}
