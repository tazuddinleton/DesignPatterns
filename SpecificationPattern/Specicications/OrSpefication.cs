using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpecificationPattern.Specicications
{
    internal sealed class OrSpefication<T> : AbstractSpecification<T>
    {
        private readonly AbstractSpecification<T> _left;
        private readonly AbstractSpecification<T> _right;

        public OrSpefication(AbstractSpecification<T> left, AbstractSpecification<T> right)
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
