using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Ioc_Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseManager>();
            builder.RegisterType<OracleDatebase>().As<IDatabase>();
            //builder.RegisterType<SqlDatebase>().As<IDatabase>();
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DatabaseManager>();
                manager.Select("select * from customer");
            }

            Console.ReadKey();
        }
    }
}
