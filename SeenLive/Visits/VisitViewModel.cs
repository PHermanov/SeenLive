using System;
using System.Text.Json.Serialization;
using SeenLive.Events;

namespace SeenLive.Visits;

public class VisitViewModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("userId")]
    public string UserId { get; set; }
    [JsonPropertyName("event")]
    public EventViewModel Event { get; set; }
    [JsonPropertyName("seenBandsIds")]
    public int[] SeenBandsIds { get; set; } = Array.Empty<int>();
}