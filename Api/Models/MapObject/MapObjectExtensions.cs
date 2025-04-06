namespace Uralruin_back.Models.MapObject;

public static class MapObjectExtensions
{
    public static MapObjectDto ToDto(this MapObject mapObject)
    {
        return new MapObjectDto
        {
            Type = mapObject.Type.ToString(),
            Name = mapObject.Name,
            Description = mapObject.Description,
            Address = mapObject.Address,
            Latlong = mapObject.Latlong
        };
    }
}
