using SpecificationPattern.Models;
using SpecificationPattern.Repositories;
using SpecificationPattern.ValueObjects;
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
            if (movie.MpaaRating > MpaaRating.PG)
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
            if (movie.RealeaseDate <= DateTime.Now.AddMonths(-6))
            {
                Console.WriteLine("Movie is not available on cd");
                return;
            }

            Console.WriteLine("You have bought a ticket successfully");
        }




        public void LoadMovies()
        {
            Movies = _repository.GetList(ForKidsOnly, AvailableOnCd, RatingAtLeast);
        }
        
    }
}
 