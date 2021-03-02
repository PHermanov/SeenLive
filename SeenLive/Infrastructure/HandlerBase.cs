namespace SeenLive.Infrastructure
{
    public class HandlerBase
    {
        protected static IHandlerResult<T> Data<T>(T data) =>
            new HandlerResult<T> { Data = data };
    }
}
