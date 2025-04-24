using DataAccess.Models.MapObject;
using DataAccess.Models.MapRoute;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<MapObject> MapObjects { get; set; } = null!;
    public DbSet<MapRoute> MapRoutes { get; set; } = null!;

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