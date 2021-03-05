using MediatR;
using SeenLive.Infrastructure;
using SeenLive.Persistence.Repositories.Bands;
using System.Threading;
using System.Threading.Tasks;

namespace SeenLive.Bands.Create
{
    public class CreateBandCommandHandler
        : HandlerBase, IRequestHandler<CreateBandCommand, IHandlerResult<BandViewModel>>
    {
        private readonly IBandRepository _bandRepository;

        public CreateBandCommandHandler(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IHandlerResult<BandViewModel>> Handle(CreateBandCommand request, CancellationToken cancellationToken)
        {
            var band = await _bandRepository.AddAsync(request.ToEntity(), cancellationToken);

            return Data(band.ToViewModel());
        }
    }
}