using System.Text.Json.Serialization;

namespace SeenLive.Bands
{
    public class BandViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("alternativeNames")]
        public string AlternativeNames { get; init; }

        [JsonPropertyName("info")]
        public string Info { get; init; }
    }
}
