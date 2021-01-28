using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationPattern.Specicications
{
    public abstract class Query<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            return ToExpression().Compile().Invoke(entity);
        }

        public static readonly Query<T> All = new All<T>();

        public abstract Expression<Func<T, bool>> ToExpression();

        public Query<T> And(Query<T> other)
        {
            return new And<T>(this, other);    
        }

        public Query<T> Or(Query<T> other)
        {
            return new Or<T>(this, other);
        }

        public Query<T> Not()
        {
            return new Not<T>(this);
        }

        
    }
}
