using MediatR;
using SeenLive.Persistence.Repositories.Bands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.GetAll
{
    public class GetAllBandsQueryHandler
        : HandlerBase, IRequestHandler<GetAllBandsQuery, IHandlerResult<IEnumerable<BandViewModel>>>
    {
        private readonly IBandRepository _bandRepository;

        public GetAllBandsQueryHandler(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IHandlerResult<IEnumerable<BandViewModel>>> Handle(GetAllBandsQuery request, CancellationToken cancellationToken)
        {
            var allBands = await _bandRepository.ListAsync();
            return Data(allBands.Select(b => b.ToViewModel()));
        }
    }
}
