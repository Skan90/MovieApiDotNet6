using Microsoft.EntityFrameworkCore;
using MovieApiDotNet6.Models;

namespace MovieApiDotNet6.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
}