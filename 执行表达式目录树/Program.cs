using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Facebook;

namespace 执行表达式目录树
{
    class Program
    {
        static void Main(string[] args)
        {

            Expression<Func<int, int, int>> lambda = (a, b) => a * b + 2;
            Func<int, int, int> myLambda = lambda.Compile();
            int result = myLambda(2, 3);
            Console.WriteLine(lambda.ToString());

            Console.Write("result: " + result);
            Console.Read();


            
        }
    }
}
