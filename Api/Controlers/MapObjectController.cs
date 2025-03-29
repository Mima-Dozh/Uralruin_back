using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uralruin_back.Models.MapObject;

namespace Uralruin_back.Controlers;

[ApiController]
[Route("/api/v1/objects")]
public class MapObjectController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public MapObjectController(AppDbContext dbContext) => _dbContext = dbContext;

    [HttpGet]
    public async Task<ActionResult<MapObjectDto[]>> GetAllMapObjects()
    {
        return await _dbContext.MapObjects.Select(mapObj => mapObj.ToDto()).ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapObject>> GetMapObject(int id)
    {
        try
        {
            var obj = await _dbContext.MapObjects.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            return obj;
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<MapObject>> CreateMapObject(MapObjectDto mapObjectDto)
    {
        var mapObject = new MapObject
        {
            Name = mapObjectDto.Name,
            Description = mapObjectDto.Description,
            Address = mapObjectDto.Address,
            Latlong = mapObjectDto.Latlong
        };

        _dbContext.MapObjects.Add(mapObject);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMapObject), new { id = mapObject.Id }, mapObjectDto);
    }
}
