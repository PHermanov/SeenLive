using MediatR;
using SeenLive.Infrastructure;
using System.Collections.Generic;

namespace SeenLive.Events.GetAll;

public class GetAllEventsQuery
    : IRequest<IHandlerResult<IEnumerable<EventViewModel>>>
{
}