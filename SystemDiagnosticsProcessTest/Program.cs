using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemDiagnosticsProcessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ie = new System.Diagnostics.Process();
            //ie.StartInfo.FileName = "IEXPLORE.EXE";
            //ie.StartInfo.Arguments = @"http://www.hao123.com";
            //ie.Start();

            var ps = Process.GetProcessesByName("QQ");

            foreach (var p in ps)
            {
                p.Close();
            }
            //打开百度
            //  System.Diagnostics.Process.Start("iexplore", @"http://www.baidu.com");
            //打开D盘
            //   Process.Start("explorer.exe", @"d:/");
            //打开控制面板
            Process.Start("rundll32.exe", @"shell32.dll,Control_RunDLL");
            var person = new Person() { name = "paul", age = 25 };
            
            var newPerson = person.Clone();
           // newPerson.name = "nihao"; newPerson.age = 20;
            Console.WriteLine(person.ToString());
            Console.WriteLine(newPerson.ToString());
            Console.ReadKey();
        }
    }

    public struct Person
    {
        public string name;
        public int age;
        public Person Clone()
        {
            return (Person)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", this.name, this.age);
        }
    }
}
