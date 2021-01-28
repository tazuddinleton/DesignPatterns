using SpecificationPattern.Models;
using SpecificationPattern.ValueObjects;
using System;

namespace SpecificationPattern.Specicications
{
    public sealed class MovieSpec 
    {
        public static Query<Movie> All = Query<Movie>.All;

        public static Query<Movie> KidsMovie = Query<Movie>.All
            .And(movie => movie .MpaaRating <= MpaaRating.PG);
        
        public static Query<Movie> RatingGreatherThan(double minRate) => Query<Movie>.All
            .And(movie => movie.Rating >= minRate);

        public static Query<Movie> MoviesOnCd = Query<Movie>.All
            .And(movie => movie.RealeaseDate <= DateTime.Now.AddMonths(-6));
    }
}
