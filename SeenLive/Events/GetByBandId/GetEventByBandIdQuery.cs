using System.Collections.Generic;
using MediatR;
using SeenLive.Infrastructure;
using SeenLive.Infrastructure.Common;

namespace SeenLive.Events.GetByBandId
{
    public class GetEventByBandIdQuery
        : GetByIdQuery, IRequest<IHandlerResult<IEnumerable<EventViewModel>>>
    {
    }
}