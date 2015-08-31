using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace1
{
    //有道云：利用C#自带组件强壮程序日志
    class Program
    {
        static void Main(string[] args)
        {
            //Trace.Listeners.Clear();
            //Trace.Listeners.Add(new MyTraceListener());

            try
            {
                int i = 0;
                Console.WriteLine(5 / i);
            }
            catch (Exception ex)
            {
                Trace.TraceError("出现异常：" + ex.Message);
            }
        }
    }

    public class MyTraceListener : TraceListener
    {
        public string FilePath { get; private set; }

        public MyTraceListener(string filepath)
        {
            FilePath = filepath;
        }

        public override void Write(string message)
        {
            File.AppendAllText(FilePath, message);
        }

        public override void WriteLine(string message)
        {
            File.AppendAllText(FilePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss    ") + message + Environment.NewLine);
        }

        public override void Write(object o, string category)
        {
            string msg = "";

            if (string.IsNullOrWhiteSpace(category) == false) //category参数不为空
            {
                msg = category + " : ";
            }

            if (o is Exception) //如果参数o是异常类,输出异常消息+堆栈,否则输出o.ToString()
            {
                var ex = (Exception)o;
                msg += ex.Message + Environment.NewLine;
                msg += ex.StackTrace;
            }
            else if (o != null)
            {
                msg = o.ToString();
            }

            WriteLine(msg);
        }
    }
}
