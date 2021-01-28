using SpecificationPattern.Models;
using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SpecificationPattern.Specicications
{
    public sealed class KidsMovieSpecification : Query<Movie>
    {
        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.MpaaRating <= MpaaRating.PG;
        }
    }
}
