using MediatR;
using SeenLive.Persistence.Repositories.Bands;
using System.Threading;
using System.Threading.Tasks;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.GetById
{
    public class GetBandByIdQueryHandler
        : HandlerBase, IRequestHandler<GetBandByIdQuery, IHandlerResult<BandViewModel>>
    {
        private readonly IBandRepository _bandRepository;

        public GetBandByIdQueryHandler(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IHandlerResult<BandViewModel>> Handle(GetBandByIdQuery request, CancellationToken cancellationToken)
        {
            var band = await _bandRepository.FindByIdWithEventsAsync(request.Id);
            return Data(band.ToViewModel());
        }
    }
}
