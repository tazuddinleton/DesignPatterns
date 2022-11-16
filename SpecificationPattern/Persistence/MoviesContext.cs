using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPattern.Persistence
{
    public class MoviesContext : DbContext
    {
        private readonly string _connString = "Server=localhost;User Id=sa;Password=Pass@123; Database=Movies;";

        public DbSet<Movie> Movies { get; set; }


        public MoviesContext()
        {

        }

        public MoviesContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

    }
}
