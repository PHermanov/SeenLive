using MediatR;
using System.Collections.Generic;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.GetAll;

public class GetAllBandsQuery
    : IRequest<IHandlerResult<IEnumerable<BandViewModel>>>
{
}