using System;
using System.Text.Json.Serialization;
using SeenLive.Events;

namespace SeenLive.Visits;

public class VisitViewModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("userId")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("event")] 
    public EventViewModel Event { get; init; } = new();
    
    [JsonPropertyName("seenBandsIds")]
    public int[] SeenBandsIds { get; init; } = Array.Empty<int>();
}