namespace SeenLive.Infrastructure
{
    public class ErrorResult<TData> : IHandlerResult<TData>
    {
        public TData Data => default;
        public Error Error { get; set; }
    }
}
