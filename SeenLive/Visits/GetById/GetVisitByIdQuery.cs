using MediatR;
using SeenLive.Infrastructure;
using SeenLive.Infrastructure.Common;

namespace SeenLive.Visits.GetById;

public class GetVisitByIdQuery
    : GetByIdQuery, IRequest<IHandlerResult<VisitViewModel>>
{
}