namespace SeenLive.Infrastructure
{
    public class HandlerBase
    {
        protected static IHandlerResult<TData> Data<TData>(TData data)
            => new SuccessResult<TData> { Data = data };

        protected static IHandlerResult<TData> NotFound<TData>(string message)
            => new ErrorResult<TData> { Error = new Error { Message = message, Type = ErrorType.NotFound } };
    }
}
