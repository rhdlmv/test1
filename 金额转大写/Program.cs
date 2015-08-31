using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 金额转大写
{
    class Program
    {
        static void Main(string[] args)
        {
            string readStr = string.Empty;
            while (true)
            {
                readStr = Console.ReadLine();
                if (string.IsNullOrEmpty(readStr))
                    return;

                var amount = decimal.Parse(readStr);
                var convered = AmountConverter.NumGetStr(amount);
                Console.WriteLine(convered);
            }
        }
    }
}
