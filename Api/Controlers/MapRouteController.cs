using DataAccess.Models.MapRoute;
using Microsoft.AspNetCore.Mvc;
using Uralruin_back.Infrastructure.IRepositories;

namespace Uralruin_back.Controlers;

[ApiController]
[Route("/api/v1/routes")]
public class MapRouteController(IMapRouteRepository mapRouteRepository) : ControllerBase
{
    private readonly IMapRouteRepository _mapRouteRepository = mapRouteRepository;

    [HttpGet]
    public async Task<ActionResult<MapRouteDto[]>> GetAllMapRoutes()
    {
        var mapRoutes = await _mapRouteRepository.GetAll();
        return mapRoutes.Select(mapObject => mapObject.ToDto()).ToArray();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapRouteDto>> GetMapRoute(long id)
    {
        var mapRoute = await _mapRouteRepository.Get(id);
        return mapRoute.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<MapRouteDto>> CreateMapRoute(MapRouteDto mapRouteDto)
    {
        var addedMapRoute = await _mapRouteRepository.Add(mapRouteDto);
        return CreatedAtAction(nameof(GetMapRoute), new { id = addedMapRoute.Id }, addedMapRoute.ToDto());
    }
}