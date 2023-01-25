using Microsoft.EntityFrameworkCore;
using CQRSBookstore.App.Models;

namespace CQRSBookstore.App.Data;

// please ignores this file as it is just for demo purposes
public class DataContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Book>? Books {get; set;}

    public DataContext() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"Host=containers-us-west-183.railway.app;Port=7864;Username=postgres;Password=dXuwyTUW5uKVej2o1TR6;Database=railway"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}