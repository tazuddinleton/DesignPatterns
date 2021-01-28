using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpecificationPattern.Specicications
{
    internal sealed class Or<T> : Query<T>
    {
        private readonly Query<T> _left;
        private readonly Query<T> _right;

        public Or(Query<T> left, Query<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpr = _left.ToExpression();
            var rightExpr = _right.ToExpression();

            BinaryExpression orSpec = Expression.OrElse(leftExpr.Body, rightExpr.Body);
            return Expression.Lambda<Func<T, bool>>(orSpec, leftExpr.Parameters.Single());
        }
    }
}
