using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression paraLeft = Expression.Parameter(typeof(int), "a");
            var paraRight = Expression.Parameter(typeof(int), "b");
            BinaryExpression binaryLeft = Expression.Multiply(paraLeft, paraRight);
            ConstantExpression conRight = Expression.Constant(2, typeof(int));
            BinaryExpression binaryBody = Expression.Add(binaryLeft, conRight);
            Expression<Func<int, int, int>> lambda = Expression.Lambda<Func<int, int, int>>(binaryBody, paraLeft, paraRight);
            Func<int, int, int> myFunc = lambda.Compile();

            int result = myFunc(3, 5);
            Console.WriteLine(result);
            Console.ReadKey();

            Expression<Func<int, int, int>> expression = (a, b) => a + b * 3;

            var operationsVisitor = new OperationsVisitor();
            Expression modifyExpression = operationsVisitor.Modify(expression);
            Console.WriteLine(modifyExpression.ToString());
            //var lambda2 = expression.Compile();
            //Console.WriteLine(lambda2());
            Console.ReadKey();



            LinkedList<string> l;
            ArrayList al = new ArrayList(20);

        }
    }
}
