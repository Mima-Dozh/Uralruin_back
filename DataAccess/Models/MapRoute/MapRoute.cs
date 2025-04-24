using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.MapRoute;

public class MapRoute
{
    [Key] public long Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
    [Required] public int[] Points { get; set; }
}
