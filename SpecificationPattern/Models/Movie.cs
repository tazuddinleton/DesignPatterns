using SpecificationPattern.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SpecificationPattern.Models
{
    public class Movie 
    {

        public static readonly Expression<Func<Movie, bool>> forKids = x => x.MpaaRating <= MpaaRating.PG;
        public static readonly Expression<Func<Movie, bool>> availableOnCd = x => x.RealeaseDate <= DateTime.Now.AddMonths(-6);

        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime RealeaseDate { get; set; }
        public int RunningLength { get; set; }
        public int BudgetInMills { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public MpaaRating MpaaRating { get; set; }

        public Movie()
        {

        }


    }
}
