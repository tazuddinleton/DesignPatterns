using System;
using System.Linq.Expressions;

namespace SpecificationPattern.Specicications
{
    internal sealed class InitialSpecification<T> : AbstractSpecification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
