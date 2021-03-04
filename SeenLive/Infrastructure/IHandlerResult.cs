namespace SeenLive.Infrastructure
{
    public interface IHandlerResult<out TData>
    {
        TData Data { get; }
        Error Error { get; }
    }
}
