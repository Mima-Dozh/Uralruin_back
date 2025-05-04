namespace DataAccess.Models.MapObject;

public class MapObjectDto
{
    public ObjectType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public double Lat { get; set; }
    public double Long { get; set; }
    public string PhotoPath { get; set; }
}
