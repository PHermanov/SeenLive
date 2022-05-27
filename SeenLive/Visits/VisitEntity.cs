using System;
using System.ComponentModel.DataAnnotations;
using SeenLive.Events;

namespace SeenLive.Visits;

public class VisitEntity
{
    public int Id { get; init; }
    [Required(AllowEmptyStrings = false)]
    public string UserId { get; init; }
    public EventEntity Event { get; init; }
    public int[] SeenBandsIds { get; set; } = Array.Empty<int>();
    
    public VisitViewModel ToViewModel()
        => new()
        {
            Id = Id,
            UserId = UserId,
            Event = Event.ToViewModel(),
            SeenBandsIds = SeenBandsIds
        };
}