using System.ComponentModel.DataAnnotations;

namespace Uralruin_back.Models.MapObject;

public class MapObject
{
    [Key] public long Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    [Required] public string Address { get; set; }
    [Required] public double[] Latlong { get; set; }
}
