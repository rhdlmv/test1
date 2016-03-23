using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonT
{
    public class Person
    {
        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
        public Action GetName;

        private string _name;
        private int _age;

        public string GetNameAget()
        {
            var name = this._name;
            if (GetName != null)
                GetName();

            return name;
        }
    }
}
