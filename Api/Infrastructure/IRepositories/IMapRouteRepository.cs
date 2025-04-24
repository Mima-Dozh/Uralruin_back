using Uralruin_back.Models.MapRoute;

namespace Uralruin_back.Infrastructure.IRepositories;

public interface IMapRouteRepository
{
    Task<MapRoute[]> GetAll();
    Task<MapRoute> Get(long id);
    Task<MapRoute> Add(MapRouteDto mapRouteDto);
}
