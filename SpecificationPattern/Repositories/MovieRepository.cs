using SpecificationPattern.Models;
using SpecificationPattern.Persistence;
using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecificationPattern.Repositories
{
    public class MovieRepository 
    {
        private readonly MoviesContext _context;
        public MovieRepository()
        {
            _context = new MoviesContext();
        }


        public Movie GetOne(int id)
        {
            return _context.Movies.SingleOrDefault(x => x.Id == id);
        }

        public IReadOnlyList<Movie> GetList(
                bool forKidsOnly,
                bool availableOnCd,
                double minimumRating
            )
        {
            return _context.Movies
                .Where(
                x => (x.MpaaRating <= MpaaRating.PG || !forKidsOnly) &&
                x.Rating >= minimumRating && 
                (x.RealeaseDate <= DateTime.Now.AddMonths(-6) || !availableOnCd)
                )
                .ToList();
        }
    }
}
