using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable双重继承
{
    class Program
    {

        static void Main(string[] args)
        {
            X x = new X();

            foreach (int i in x) // A
                Console.Write(i + " ");

            Console.WriteLine();
            var y = from int i in x select i;
            foreach (int i in y) // B
                Console.Write(i + " ");

            Console.ReadKey();
        }
    }

    class X : ICollection, IEnumerable
    {
        public int[] A = { 1, 2, 3 };
        public int[] B = { 4, 5, 6 };

        #region ICollection 成员

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IEnumerable 成员

        public IEnumerator GetEnumerator()
        {
            return A.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return B.GetEnumerator();
        }

        #endregion
    }
}
