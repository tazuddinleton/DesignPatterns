using SpecificationPattern.Models;
using System;
using System.Linq.Expressions;

namespace SpecificationPattern.Specicications
{
    public sealed class MoviesOnCdSpecification : Query<Movie>
    {
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.RealeaseDate <= DateTime.Now.AddMonths(-6);
        }
    }
}
