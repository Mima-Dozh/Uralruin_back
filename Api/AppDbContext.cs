using Microsoft.EntityFrameworkCore;
using Uralruin_back.Models.MapObject;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<MapObject> MapObjects { get; set; }
}