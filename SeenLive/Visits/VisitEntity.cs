using System;
using System.ComponentModel.DataAnnotations;
using SeenLive.Events;
using SeenLive.Users;

namespace SeenLive.Visits;

public class VisitEntity
{
    public int Id { get; init; }
    
    [Required]
    public User User { get; init; } = new();
    
    [Required]
    public EventEntity Event { get; init; } = new();
    public int[] SeenBandsIds { get; set; } = Array.Empty<int>();
    
    public VisitViewModel ToViewModel()
        => new()
        {
            Id = Id,
            UserId = User.Id,
            Event = Event.ToViewModel(),
            SeenBandsIds = SeenBandsIds
        };
}