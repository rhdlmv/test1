using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ioc_Autofac
{
    public interface IDatabase
    {
        void Select(string commandText);
        void Insert(string commandText);
        void Update(string commandText);
        void Delete(string commandText);
    }
}
