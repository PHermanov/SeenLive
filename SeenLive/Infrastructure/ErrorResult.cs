using System.Text.Json.Serialization;

namespace SeenLive.Infrastructure
{
    public class ErrorResult<TData> : IHandlerResult<TData>
    {
        [JsonIgnore]
        public TData Data => default;
        public Error Error { get; set; }
    }
}
