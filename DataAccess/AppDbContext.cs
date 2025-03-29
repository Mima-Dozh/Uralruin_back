using Microsoft.EntityFrameworkCore;
using Uralruin_back.Models.MapObject;

public class AppDbContext : DbContext
{
    public DbSet<MapObject> MapObjects { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
                    $"Server=localhost;" +
                    $"Port=5432;" +
                    $"Database=UralruinDB;" +
                    $"Username=postgres;" +
                    $"Password=postgres;"
                );
    }
}