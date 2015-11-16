using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Now;

            Console.WriteLine(date.ToLongTimeString());
            Console.WriteLine(date.ToLongDateString());
            Console.WriteLine(date.ToString("HH:mm"));
            Console.ReadKey();

        }
    }
}