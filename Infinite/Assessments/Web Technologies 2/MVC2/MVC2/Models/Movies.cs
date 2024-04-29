using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; // Add this line

namespace MVC2.Models
{
    public class Movie
    {
        public int Mid { get; set; }
        public string MovieName { get; set; }
        public DateTime DateOfRelease { get; set; }
    }

    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("MoviesDbContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
