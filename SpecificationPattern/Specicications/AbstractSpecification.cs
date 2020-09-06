using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationPattern.Specicications
{
    public abstract class AbstractSpecification<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public static readonly AbstractSpecification<T> All = new InitialSpecification<T>();

        public abstract Expression<Func<T, bool>> ToExpression();

        public AbstractSpecification<T> And(AbstractSpecification<T> other)
        {
            return new AndSpecification<T>(this, other);    
        }

        public AbstractSpecification<T> Or(AbstractSpecification<T> other)
        {
            return new OrSpefication<T>(this, other);
        }

        public AbstractSpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        
    }
}
