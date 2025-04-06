namespace Uralruin_back.Models.MapRoute;

public static class MapRouteExtensions
{
    public static MapRouteDto ToDto(this MapRoute mapRoute)
    {
        return new MapRouteDto
        {
            Name = mapRoute.Name,
            Description = mapRoute.Description,
            Points = mapRoute.Points
        };
    }
}
