using System;
using System.Data.Entity;
using System.Linq;

namespace MVC2.Models
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext() : base("name=ICS-LT-3P1Y7G3")
        {
        }

        public DbSet<Movies> Movies { get; set; }
    }
}

   
}