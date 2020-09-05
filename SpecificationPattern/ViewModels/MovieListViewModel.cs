using SpecificationPattern.Models;
using SpecificationPattern.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificationPattern.ViewModels
{
    public class MovieListViewModel
    {

        MovieRepository _repository = new MovieRepository();

        public MovieListViewModel()
        {
            
        }

        public IReadOnlyList<Movie> Movies { get; private set; }

        public bool ForKidsOnly { get; set; }


        public void LoadMovies()
        {
            Movies = _repository.GetList(ForKidsOnly);
        }
        
    }
}
