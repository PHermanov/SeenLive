using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.GetById
{
    public class GetBandByIdQuery
        : IRequest<IHandlerResult<BandViewModel>>
    {
        public int Id { get; set; }
    }
}
