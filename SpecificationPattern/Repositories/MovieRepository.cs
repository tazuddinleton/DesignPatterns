using SpecificationPattern.Persistence;
using System;
using System.Collections.Generic;
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




    }
}
