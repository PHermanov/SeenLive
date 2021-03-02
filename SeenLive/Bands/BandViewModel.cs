using SeenLive.Events;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SeenLive.Bands
{
    public class BandViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("alternativeNames")]
        public string AlternativeNames { get; set; }

        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("events")]
        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
