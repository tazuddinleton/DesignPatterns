using SpecificationPattern.Models;
using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationPattern.Specicications
{
    public class MinimumRatingSpecification : Query<Movie>
    {
        private readonly double _minimumRating;

        public MinimumRatingSpecification(double minimumRating)
        {
            _minimumRating = minimumRating;
        }

        public override Expression<Func<Movie, bool>> ToExpression()
        {
            return movie => movie.Rating >= _minimumRating;
        }
    }
}
