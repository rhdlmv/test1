using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 语法优化
{
    class Program
    {
        readonly static Func<string>[] GetTemplate;

        private static Func<string>[] InitTemplateFunction()
        {
            var arr = new Func<string>[5];
            arr[1] = GetHead;
            arr[2] = GetMenu;
            arr[3] = GetFoot;
            arr[4] = GetWelcome;
            return arr;
        }
        static void Main(string[] args)
        {
            var s = string.Empty;
            if ((s + "").Length == 0) { }


            IConvertible conv = s as IConvertible;
            if (conv != null)
            {
                switch (conv.GetTypeCode())
                {
                    case TypeCode.Boolean:
                        break;
                    case TypeCode.Int32:
                        break;
                    case TypeCode.Object:
                        break;
                    case TypeCode.String:
                        break;
                    default:
                        break;
                }
            }
        }

        private static string GetHead() { return string.Empty; }
        private static string GetMenu() { return string.Empty; }
        private static string GetFoot() { return string.Empty; }
        private static string GetWelcome() { return string.Empty; }
    }
}
