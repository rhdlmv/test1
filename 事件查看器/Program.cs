using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace 事件查看器
{
    //有道云：C# EventLog类应用
    //%windir%\system32\eventvwr.exe
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                int[] array = new int[] { 3, 4, 5, 7 };
                var a = array[4];
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists("MyEventDemo"))
                    EventLog.CreateEventSource("MyEventDemo", "MyEventLog");

                var myLog = new EventLog();
                myLog.Source = "MyEventDemo";

                myLog.WriteEntry(string.Format("{0}&{1}  StackTrace:{2}", "Hello World!!!", ex.Message, ex.StackTrace), EventLogEntryType.FailureAudit);
            }

        }
    }
}
