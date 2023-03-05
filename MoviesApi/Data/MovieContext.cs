using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Data;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }

    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Session>()
            .HasKey(session => new { session.MovieId, session.CinemaId });

        modelBuilder.Entity<Session>()
            .HasOne(session => session.Cinema)
            .WithMany(cinema => cinema.Sessions)
            .HasForeignKey(session => session.CinemaId);

        modelBuilder.Entity<Session>()
           .HasOne(session => session.Movie)
           .WithMany(movie => movie.Sessions)
           .HasForeignKey(session => session.MovieId);

        modelBuilder.Entity<Address>()
            .HasOne(address => address.Cinema)
            .WithOne(cinema => cinema.Address)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
