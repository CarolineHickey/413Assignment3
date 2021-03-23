using System;
using Microsoft.EntityFrameworkCore;
namespace JoelMovies.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationResponse> applicationResponses { get; set; }
    }
}
