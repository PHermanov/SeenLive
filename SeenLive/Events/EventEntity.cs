using SeenLive.Bands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SeenLive.Locations;

namespace SeenLive.Events;

public class EventEntity
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    [MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    public DateTime Date { get; init; }
    public string? Info { get; init; } = string.Empty;
    public EventType EventType { get; init; }
    public ICollection<BandEntity>? Bands { get; set; }

    public LocationEntity Location { get; set; } = new();

    public EventViewModel ToViewModel()
        => new()
        {
            Id = Id,
            Name = Name,
            Date = Date,
            EventType = EventType.ToString(),
            BandNames = Bands?.Select(b => b.Name).ToArray(),
            Location = Location.Name
        };
}