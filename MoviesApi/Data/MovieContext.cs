using MoviesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Data;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {
    }
}
