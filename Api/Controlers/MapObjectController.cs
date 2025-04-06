using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uralruin_back.Models;
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
        return await _dbContext.MapObjects.Select(MapObj => MapObj.ToDto()).ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapObjectDto>> GetMapObject(int id)
    {
        try
        {
            var obj = await _dbContext.MapObjects.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            return obj.ToDto();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<MapObject>> CreateMapObject(MapObjectDto mapObjectDto)
    {
        
        var parsed = Enum.TryParse<ObjectType>(mapObjectDto.Type, out var objType);

        if (!parsed)
        {
            return UnprocessableEntity(
                new
                {
                    message = $"Object type '{mapObjectDto.Type}' is not valid. Valid types are: {string.Join(", ", Enum.GetNames(typeof(ObjectType)))}"
                }
            );
        }

        var mapObject = new MapObject
        {
            Type = objType,
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
