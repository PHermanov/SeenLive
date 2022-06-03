using MediatR;
using SeenLive.Infrastructure;
using SeenLive.Infrastructure.Common;

namespace SeenLive.Bands.GetById;

public class GetBandByIdQuery
    : GetByIdQuery, IRequest<IHandlerResult<BandViewModel>>
{
}