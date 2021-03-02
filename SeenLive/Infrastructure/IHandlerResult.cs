namespace SeenLive.Infrastructure
{
    public interface IHandlerResult<T>
    {
        T Data { get; set; }
    }
}
