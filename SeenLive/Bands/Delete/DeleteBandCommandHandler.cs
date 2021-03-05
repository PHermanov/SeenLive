using MediatR;
using SeenLive.Infrastructure;
using SeenLive.Persistence.Repositories.Bands;
using System.Threading;
using System.Threading.Tasks;

namespace SeenLive.Bands.Delete
{
    public class DeleteBandCommandHandler
    : HandlerBase, IRequestHandler<DeleteBandCommand, IHandlerResult<Unit>>
    {
        private readonly IBandRepository _bandRepository;

        public DeleteBandCommandHandler(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IHandlerResult<Unit>> Handle(DeleteBandCommand request, CancellationToken cancellationToken)
        {
            var bandEntity = await _bandRepository.FindByIdAsync(request.Id);

            if (bandEntity == null)
            {
                return NotFound<Unit>("Band was not found");
            }

            await _bandRepository.DeleteAsync(bandEntity);

            return NoData();
        }
    }
}
