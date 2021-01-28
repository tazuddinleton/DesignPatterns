using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpecificationPattern.Specicications
{
    internal sealed class And<T> : Query<T>
    {
        private readonly Query<T> _left;
        private readonly Query<T> _right;


        private readonly Expression<Func<T, bool>> _lefteExpression;
        private readonly Expression<Func<T, bool>> _rightExpression;

        public And(Query<T> left, Query<T> right)
        {
            _left = left;
            _right = right;
        }

        public And(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            _lefteExpression = left;
            _rightExpression = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpr = _left.ToExpression();
            var rightExpr = _right.ToExpression();

            BinaryExpression expression = Expression.AndAlso(leftExpr.Body, rightExpr.Body);
            return Expression.Lambda<Func<T, bool>>(expression, leftExpr.Parameters.Single());
        }
    }
}
