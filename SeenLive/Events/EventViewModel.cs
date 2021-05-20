using System;
using System.Text.Json.Serialization;

namespace SeenLive.Events
{
    public class EventViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        [JsonPropertyName("date")]
        public DateTime Date { get; init; }

        [JsonPropertyName("type")]
        public string EventType { get; init; }
    }
}
