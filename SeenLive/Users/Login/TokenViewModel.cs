using System;
using System.Text.Json.Serialization;

namespace SeenLive.Users.Login
{
    public class TokenViewModel 
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }
    }
}
