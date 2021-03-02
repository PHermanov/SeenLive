namespace SeenLive.Infrastructure
{
    public class HandlerResult<T> : IHandlerResult<T>
    {
        public T Data { get; set; }
    }
}
