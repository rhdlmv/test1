using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] A = new bool[] { true, false };
            bool[] B = new bool[] { true, false };
            bool[] C = new bool[] { true, false };
            bool[] D = new bool[] { true, false };
            bool[] E = new bool[] { true, false };
            bool[] F = new bool[] { true, false };
            bool[][] AA = new bool[][] { A, B, C, D, E, F };
            //foreach (var item in AA)
            //{
            //    foreach (var tt in item)
            //    {
            //        var testA = (a || b || c || d || e || f) == false;
            //        var testB = GetCount(a) + GetCount(b) + GetCount(c) + GetCount(d) + GetCount(e) + GetCount(f) > 1;
            //        var testC = (d || e) == false;
            //        var testD = GetCount(b) + GetCount(c) == 1;
            //        var testE = c == false;
            //        var testF = GetCount(e) + GetCount(f) == 1;
            //        if ((testA == a) && (testB == b) && (testC == c) && (testD == d) && (testE == e) && (testF == f))
            //        {
            //            Console.WriteLine("有答案： {0} {1} {2} {3} {4} {5}", a, b, c, d, e, f);

            //        }
            //        Console.WriteLine("无答案");
            //    }
            //}

            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    foreach (var c in C)
                    {
                        foreach (var d in D)
                        {
                            foreach (var e in E)
                            {
                                foreach (var f in F)
                                {
                                    var testA = (a || b || c || d || e || f) == false;
                                    var testB = GetCount(a) + GetCount(b) + GetCount(c) + GetCount(d) + GetCount(e) + GetCount(f) > 1;
                                    var testC = (d || e) == false;
                                    var testD = GetCount(b) + GetCount(c) == 1;
                                    var testE = c == false;
                                    var testF = GetCount(e) + GetCount(f) == 1;
                                    if ((testA == a) && (testB == b) && (testC == c) && (testD == d) && (testE == e) && (testF == f))
                                    {
                                        Console.WriteLine("有答案： {0} {1} {2} {3} {4} {5}", a, b, c, d, e, f);

                                    }
                                    Console.WriteLine("无答案");
                                }
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
        }



        static int GetCount(bool i)
        {
            return i ? 1 : 0;
        }
    }
}
