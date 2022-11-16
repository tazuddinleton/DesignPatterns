using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SpecificationPattern.Models;
using SpecificationPattern.ValueObjects;
using System;

namespace SpecificationPattern.Persistence
{
    public class MoviesConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.Property(c => c.RealeaseDate)
            .HasColumnType("datetime");

            builder.Property(x => x.MpaaRating)
                .HasConversion<int>();


            for (int i = 1; i < 1001; i++)
            {
                int mpaa = new Random().Next(4);
                double rating = new Random().NextDouble() * (10 - 1) + 1;

                var start = new DateTime(1950, 1, 1);
                var range = (DateTime.Today - start).Days;

                var random = new Random();
                DateTime releaseDate = start.AddDays(random.Next(range));

                var runTime = new Random(50).Next(210);
                builder.HasData(new Movie()
                {
                    Id = i,
                    Title = $"Movie {i}",
                    Director = $"Director {i % 20}",
                    BudgetInMills = i % 100,
                    Genre = $"Genre {i % 12}",
                    MpaaRating = (MpaaRating)mpaa,
                    Rating = rating,
                    RealeaseDate = releaseDate,
                    RunningLength = runTime
                });
            }

        }
    }
}
