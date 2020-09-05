using SpecificationPattern.ValueObjects;
using System;


namespace SpecificationPattern.Models
{
    public class Movie 
    {
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
