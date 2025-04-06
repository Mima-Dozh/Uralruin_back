using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uralruin_back.Models.MapRoute;

namespace Uralruin_back.Controlers;


[ApiController]
[Route("/api/v1/routes")]
public class MapRouteController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public MapRouteController(AppDbContext dbContext) => _dbContext = dbContext;

    [HttpGet]
    public async Task<ActionResult<MapRoute[]>> GetAllMapRoutes()
    {
        return await _dbContext.MapRoutes.ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MapRoute>> GetMapRoute(int id)
    {
        try
        {
            var obj = await _dbContext.MapRoutes.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            return obj;
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<MapRoute>> CreateMapRoute(MapRouteDto mapRouteDto)
    {
        var mapRoute = new MapRoute
        {
            Name = mapRouteDto.Name,
            Description = mapRouteDto.Description,
            Points = mapRouteDto.Points
        };

        _dbContext.MapRoutes.Add(mapRoute);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMapRoute), new { id = mapRoute.Id }, mapRouteDto);
    }
}
