using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ioc_Autofac
{
    public class DatabaseManager
    {
        private IDatabase _database;
        public DatabaseManager(IDatabase datebase)
        {
            _database = datebase;
        }

        public void Select(string commandText)
        {
            _database.Select(commandText);
        }

        public void Update(string commandText)
        {
            _database.Update(commandText);
        }

        public void Insert(string commandText)
        {
            _database.Insert(commandText);
        }

        public void Delete(string commandText)
        {
            _database.Delete(commandText);
        }
    }
}
