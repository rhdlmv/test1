using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class OperationsVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add)
            {
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);
                return Expression.Subtract(left, right);
            }
            return base.VisitBinary(node);
        }
    }
}
