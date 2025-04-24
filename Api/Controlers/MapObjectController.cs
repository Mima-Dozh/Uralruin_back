using Microsoft.AspNetCore.Mvc;
using Uralruin_back.Infrastructure.IRepositories;
using Uralruin_back.Models.MapObject;

namespace Uralruin_back.Controlers;

[ApiController]
[Route("/api/v1/objects")]
public class MapObjectController(IMapObjectRepository mapObjectRepository) : ControllerBase
{
    private readonly IMapObjectRepository _mapObjectRepository = mapObjectRepository;

    [HttpGet]
    public async Task<ActionResult<MapObjectDto[]>> GetAllMapObjects()
    {
        var mapObjects = await _mapObjectRepository.GetAll();
        return mapObjects.Select(mapObject => mapObject.ToDto()).ToArray();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapObjectDto>> GetMapObject(long id)
    {
        var mapObject = await _mapObjectRepository.Get(id);
        return mapObject.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<MapObjectDto>> CreateMapObject(MapObjectDto mapObjectDto)
    {
        var addedMapObject = await _mapObjectRepository.Add(mapObjectDto);
        return CreatedAtAction(nameof(GetMapObject), new { id = addedMapObject.Id }, addedMapObject.ToDto());
    }
}