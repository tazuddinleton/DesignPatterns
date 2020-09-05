using SpecificationPattern.Models;
using SpecificationPattern.Repositories;
using SpecificationPattern.Specicications;
using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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
            GenericSpecification<Movie> specification =
               new GenericSpecification<Movie>(x => x.MpaaRating <= MpaaRating.PG);

            if (specification.IsSatisfiedBy(movie))
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

            GenericSpecification<Movie> specification =
                new GenericSpecification<Movie>(x => x.RealeaseDate <= DateTime.Now.AddMonths(-6));

            if (specification.IsSatisfiedBy(movie))
            {
                Console.WriteLine("Movie is not available on cd");
                return;
            }

            Console.WriteLine("You have bought a ticket successfully");
        }




        public void LoadMovies()
        {

            GenericSpecification<Movie> specification =
              new GenericSpecification<Movie>(x => x.MpaaRating <= MpaaRating.PG);

            // Problem 1: Back to square one, manually declaring the lamda wrapping inside a generic class.
            // Problem 2: Lack of encapsulation,

            // Advice 1: Generic specification should be avoided.
            // Advice 2: Never return IQueryable or IQueryable<T> from repository

            //

            Movies = _repository.GetList(specification);

            // Or we can return IQueryable
            var movies = _repository.Find()
                .Where(Movie.forKids)
                .Where(Movie.availableOnCd)
                .ToList();
            // Problems with the above query
            // 1. User of the method can create arbitray queryies including unsupported ones.
            // 2. Lacks encapsulation which is a desirable feature of OO
            // 3. It will create run-time exception instead of compile time exception in case of unsupported linq to entity queries.
        }
        
    }
}
 