using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpecificationPattern.Specicications
{
    internal sealed class Not<T> : Query<T>
    {
        private readonly Query<T> _expression;        

        public Not(Query<T> expression)
        {
            _expression = expression;            
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var expr = _expression.ToExpression();

            UnaryExpression notSpec = Expression.Not(expr.Body);
            return Expression.Lambda<Func<T, bool>>(notSpec, expr.Parameters.Single());
        }
    }
}
