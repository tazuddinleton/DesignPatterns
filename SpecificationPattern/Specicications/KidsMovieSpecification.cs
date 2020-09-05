using SpecificationPattern.Models;
using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationPattern.Specicications
{
    public sealed class KidsMovieSpecification : AbstractSpecification<Movie>
    {
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.MpaaRating <= MpaaRating.PG;
        }
    }
}
