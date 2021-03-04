namespace SeenLive.Infrastructure
{
    public class Error
    {
        public string Message { get; set; }
        public ErrorType Type { get; set; }
    }

    public enum ErrorType
    {
        Undefined,
        NotFound
    }
}
