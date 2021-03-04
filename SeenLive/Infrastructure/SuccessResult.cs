namespace SeenLive.Infrastructure
{
    public class SuccessResult<TData> : IHandlerResult<TData>
    {
        public TData Data { get; init; }
        public Error Error => null;
    }
}
