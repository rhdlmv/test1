using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTByKey("member", GetMemberCount));
            Console.WriteLine(GetTByKey("account", GetAccountName));
            Console.ReadKey();
        }

        static T GetTByKey<T>(string key, Func<string, bool, T> get)
        {
            //other
            var condition = string.Format("key = {0}", key);
            Console.WriteLine(condition);
            var result = get(condition, false);
            return result;
        }

        static int GetMemberCount(string condition, bool isExit)
        {
            return 10;
        }

        static string GetAccountName(string condition, bool isExit)
        {
            return "hellale";
        }




    }
}
