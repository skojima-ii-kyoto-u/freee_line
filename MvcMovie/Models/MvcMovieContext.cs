using System;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
namespace MvcMovie.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
    }
}
