namespace DataAccess.Models.MapObject;

public static class MapObjectExtensions
{
    public static MapObjectDto ToDto(this MapObject mapObject)
    {
        return new MapObjectDto
        {
            Type = mapObject.Type,
            Name = mapObject.Name,
            Description = mapObject.Description,
            Address = mapObject.Address,
            Lat = mapObject.Lat,
            Long = mapObject.Long,
            PhotoPath = mapObject.PhotoPath
        };
    }
}
