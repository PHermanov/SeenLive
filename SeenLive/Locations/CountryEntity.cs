using System.ComponentModel.DataAnnotations;

namespace SeenLive.Locations;

public class CountryEntity
{
    public int Id { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required(AllowEmptyStrings = false)]
    [MaxLength(2)]
    public string Code { get; set; } = string.Empty;
}