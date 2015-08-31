using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class QueryableData<TData> : IQueryable<TData>
    {
        public QueryableData()
        {
            Provider = new TerryQueryProvider();
            Expression = Expression.Constant(this);
        }
        public QueryableData(TerryQueryProvider provider,
       Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (!typeof(IQueryable<TData>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            Provider = provider;
            Expression = expression;
        }

        public IQueryProvider Provider { get; private set; }
        public Expression Expression { get; private set; }

        public Type ElementType
        {
            get { return typeof(TData); }
        }

        public IEnumerator<TData> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<TData>>(Expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Provider.Execute<IEnumerable>(Expression)).GetEnumerator();
        }
    }

    public class TerryQueryProvider// : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            //Type elementType = TypeSystem.GetElementType(expression.Type);
            return null;
        }

        public IQueryable<TResult> CreateQuery<TResult>(Expression expression)
        {
            return new QueryableData<TResult>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return null;
            // ......
        }

        //public TResult Execute<TResult>(Expression expression)
        //{
        //    // ......
        //}
    }
}
