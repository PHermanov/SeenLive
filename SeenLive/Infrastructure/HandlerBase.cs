using MediatR;

namespace SeenLive.Infrastructure;

public class HandlerBase
{
    protected static IHandlerResult<TData> Data<TData>(TData data)
        => new SuccessResult<TData> { Data = data };

    protected static IHandlerResult<Unit> NoData()
        => new SuccessResult<Unit>();

    protected static IHandlerResult<TData> NotFound<TData>(string message)
        => new ErrorResult<TData> { Error = new Error { Message = message, Type = ErrorType.NotFound } };

    protected static IHandlerResult<TData> Unauthorized<TData>(string message)
        => new ErrorResult<TData> { Error = new Error { Message = message, Type = ErrorType.Unauthorized } };

    protected static IHandlerResult<TData> BadRequest<TData>(string message)
        => new ErrorResult<TData> { Error = new Error { Message = message, Type = ErrorType.BadRequest } };

    protected static IHandlerResult<TData> ValidationError<TData>(string message, string field)
        => new ErrorResult<TData> { Error = new Error { Message = message, Field = field, Type = ErrorType.Validation } };
        
    protected static IHandlerResult<TData> InternalError<TData>(string message)
        => new ErrorResult<TData> { Error = new Error { Message = message, Type = ErrorType.InternalError } };
}