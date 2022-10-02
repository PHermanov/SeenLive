using System.Text.Json.Serialization;

namespace SeenLive.Infrastructure;

public class SuccessResult<TData> : IHandlerResult<TData>
{
    public TData Data { get; init; } = default!;

    [JsonIgnore]
    public Error? Error => default;
}