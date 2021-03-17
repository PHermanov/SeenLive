using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SeenLive.Infrastructure;
using SeenLive.Persistence.Repositories.Bands;

namespace SeenLive.Bands.Update
{
    public class UpdateBandCommandHandler
    : HandlerBase, IRequestHandler<UpdateBandCommand, IHandlerResult<BandViewModel>>
    {
        private readonly IBandRepository _bandRepository;

        public UpdateBandCommandHandler(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }
        
        public async Task<IHandlerResult<BandViewModel>> Handle(UpdateBandCommand request, CancellationToken cancellationToken)
        {
            var band = await _bandRepository.FindByIdAsync(request.Id);

            if (band == null)
            {
                return NotFound<BandViewModel>("Band was not found");
            }

            var updatedBand = await _bandRepository.UpdateAsync(band, request.ToEntity(), cancellationToken);
            return Data(updatedBand.ToViewModel());
        }
    }
}
