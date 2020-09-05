using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpecificationPattern.Specicications
{
    internal sealed class AndSpecification<T> : AbstractSpecification<T>
    {
        private readonly AbstractSpecification<T> _left;
        private readonly AbstractSpecification<T> _right;

        public AndSpecification(AbstractSpecification<T> left, AbstractSpecification<T> right)
        {
            _left = left;
            _right = right;
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
