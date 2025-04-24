using Uralruin_back.Models.MapObject;

namespace Uralruin_back.Infrastructure.IRepositories;

public interface IMapObjectRepository
{
    Task<MapObject[]> GetAll();
    Task<MapObject> Get(long id);
    Task<MapObject> Add(MapObjectDto mapObjectDto);
}
