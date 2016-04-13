using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannels
{
    public static class PrintHelper
    {
        public static void Print(object instance, string method)
        {
            Console.WriteLine("{0}.{1}", instance.GetType().Name, method);
        }
    }
}
