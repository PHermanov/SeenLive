using MediatR;
using SeenLive.Infrastructure;
using SeenLive.Infrastructure.Common;

namespace SeenLive.Events.GetById
{
    public class GetEventByIdQuery
        : GetByIdQuery, IRequest<IHandlerResult<EventViewModel>>
    {
    }
}
