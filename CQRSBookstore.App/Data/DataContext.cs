using Microsoft.EntityFrameworkCore;
using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Data;

// please ignores this file as it is just for demo purposes
public class DataContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public DataContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"Host=containers-us-west-183.railway.app;Port=7864;Username=postgres;Password=dXuwyTUW5uKVej2o1TR6;Database=railway"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Book>()
            .HasData(
                new Book
                {
                    Id = new Guid("9b0896fa-3880-4c2e-bfd6-925c87f22878"),
                    Title = "CQRS for Dummies",
                    Author = "CQRS Queen",
                    ISBN = 2345019330124,
                    PublishedAt = new DateTime(2015, 7, 01).ToUniversalTime()
                },
                new Book
                {
                    Id = new Guid("0550818d-36ad-4a8d-9c3a-a715bf15de76"),
                    Title = "Visual Studio Tips",
                    Author = "VS Vibe",
                    ISBN = 1343019320124,
                    PublishedAt = new DateTime(2011, 01, 01).ToUniversalTime()
                },
                new Book
                {
                    Id = new Guid("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1"),
                    Title = "NHibernate Cookbook",
                    Author = "NHibernate King",
                    ISBN = 5343012320111,
                    PublishedAt = new DateTime(2022, 08, 10).ToUniversalTime()
                }
            );

        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "John Doe",
                    Email = "johndoe123@gmail.com",
                    Password = "johndoe"
                }
            );

        modelBuilder
            .Entity<Reservation>()
            .HasData(
                new Reservation { Id = Guid.NewGuid(), Number = new Random().Next(1000, 9999), }
            );
    }
}
