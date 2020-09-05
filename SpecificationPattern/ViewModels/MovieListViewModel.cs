using SpecificationPattern.Models;
using SpecificationPattern.Repositories;
using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public bool AvailableOnCd { get; set; }
        public double RatingAtLeast { get; set; }

        public void BuyAdultTicket(int movieId)
        {
            Movie movie = _repository.GetOne(movieId);
            if (movie == null)
                return;
            Console.WriteLine("You have bought a ticket successfully");
        }
        public void BuyChildTicket(int movieId)
        {
            Movie movie = _repository.GetOne(movieId);
            if (movie == null)
                return;
            if (Movie.forKids.Compile().Invoke(movie))
            {
                Console.WriteLine("Movie is not suitable for children");
                return;
            }


            Console.WriteLine("You have bought a ticket successfully");
        }
        public void BuyOnCd(int movieId)
        {
            Movie movie = _repository.GetOne(movieId);
            if (movie == null)
                return;
            if (Movie.availableOnCd.Compile().Invoke(movie))
            {
                Console.WriteLine("Movie is not available on cd");
                return;
            }

            Console.WriteLine("You have bought a ticket successfully");
        }




        public void LoadMovies()
        {
            Expression<Func<Movie, bool>> expression = !ForKidsOnly ? Movie.forKids : x => true;
            Expression<Func<Movie, bool>> expression2 = !AvailableOnCd ? Movie.availableOnCd : x => true;

            // Problem 1: Doesn't scale. combining expression is not easy 
            // Problem 2: Client code is dealing with low level stuff...like compiling an expression to lampda
            // before using it.
            // Problem 3: Not encapsulated
            Movies = _repository.GetList(expression);
        }
        
    }
}
 