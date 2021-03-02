using MediatR;
using System.Collections.Generic;

namespace SeenLive.Bands.GetAll
{
    public class GetAllBandsQuery
        : IRequest<IEnumerable<BandViewModel>>
    {
    }
}
