using Microsoft.EntityFrameworkCore;
using Uralruin_back.Infrastructure.Exceptions;
using Uralruin_back.Infrastructure.IRepositories;
using Uralruin_back.Models.MapRoute;

namespace Uralruin_back.Infrastructure.Repositories;

public class MapRouteRepository(AppDbContext dbContext) : IMapRouteRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<MapRoute> Get(long id)
    {
        var mapRoute = await _dbContext.MapRoutes.FindAsync(id);
        return mapRoute is null
            ? throw new NotFoundException($"route with id {id} not found")
            : mapRoute;
    }

    public async Task<MapRoute[]> GetAll() => await _dbContext.MapRoutes.ToArrayAsync();

    public async Task<MapRoute> Add(MapRouteDto mapRouteDto)
    {
        var mapRoute = new MapRoute
        {
            Name = mapRouteDto.Name,
            Description = mapRouteDto.Description,
            Points = mapRouteDto.Points
        };

        var addedMapRoute = await _dbContext.MapRoutes.AddAsync(mapRoute);
        await _dbContext.SaveChangesAsync();
        return addedMapRoute.Entity;
    }
}
