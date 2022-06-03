using System;
using System.ComponentModel.DataAnnotations;

namespace SeenLive.Locations;

public class CityEntity
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required] 
    public CountryEntity Country { get; set; } = new();
}