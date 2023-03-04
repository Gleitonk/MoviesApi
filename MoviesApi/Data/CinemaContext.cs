using MoviesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Data;

public class CinemaContext : DbContext
{
    public DbSet<Cinema> Cinemas { get; set; }

    public CinemaContext(DbContextOptions<CinemaContext> opts) : base(opts)
    {
    }
}

