using SpecificationPattern.Models;
using SpecificationPattern.Persistence;
using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IReadOnlyList<Movie> GetList(Expression<Func<Movie, bool>> filter)
        {
            return _context.Movies
                .Where(filter)
                .ToList();
        }
    }
}
