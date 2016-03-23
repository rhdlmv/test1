using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SqlConnection
{
    class Program
    {
        static void Main(string[] args)
        {

            DbCommand dc = DataAccessHelper.GetCommand();

            var person = new Person("Jim", 20);
            person.GetName += () =>
            {
                Console.WriteLine("excuted GetName method.");
            };

            var name = person.GetNameAget();
            Console.ReadKey();
            //var conn = ConfigurationManager.ConnectionStrings
        }

     
    }
}
