using Microsoft.EntityFrameworkCore;
using Uralruin_back.Infrastructure.Exceptions;
using Uralruin_back.Infrastructure.IRepositories;
using Uralruin_back.Models.MapObject;

namespace Uralruin_back.Infrastructure.Repositories;

public class MapObjectRepository(AppDbContext dbContext) : IMapObjectRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<MapObject> Get(long id)
    {
        var mapObject = await _dbContext.MapObjects.FindAsync(id);
        return mapObject is null 
            ? throw new NotFoundException($"object with id {id} not found") 
            : mapObject;
    }

    public async Task<MapObject[]> GetAll() => await _dbContext.MapObjects.ToArrayAsync();

    public async Task<MapObject> Add(MapObjectDto mapObjectDto)
    {
        var mapObject = new MapObject
        {
            Type = mapObjectDto.Type,
            Name = mapObjectDto.Name,
            Description = mapObjectDto.Description,
            Address = mapObjectDto.Address,
            Lat = mapObjectDto.Lat,
            Long = mapObjectDto.Long
        };

        var addedMapObject = await _dbContext.MapObjects.AddAsync(mapObject);
        await _dbContext.SaveChangesAsync();
        return addedMapObject.Entity;
    }
}
