using lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab3.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Record> Records { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=PhoneDictionary;Username=postgres;Password=0711");
    }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
}