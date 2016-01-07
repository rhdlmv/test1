using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ioc_Autofac
{
    public class OracleDatebase : IDatabase
    {
        public string Name
        {
            get { return "oracle server"; }
        }
        public void Delete(string commandText)
        {
            Console.WriteLine("'{0}' is a delete sql in {1}", commandText, Name);
        }

        public void Insert(string commandText)
        {
            Console.WriteLine("'{0}' is a insert sql in {1}", commandText, Name);
        }

        public void Select(string commandText)
        {
            Console.WriteLine("'{0}' is a query sql in {1}", commandText, Name);
        }

        public void Update(string commandText)
        {
            Console.WriteLine("'{0}' is a update sql in {1}", commandText, Name);
        }
    }
}
