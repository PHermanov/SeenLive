using System;
using System.Text.Json.Serialization;

namespace SeenLive.Events
{
    public class EventViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("date")]
        public DateTime Date { get; init; }
    }
}
