using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationPattern.Specicications
{
    public class GenericSpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }
        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}
