using MediatR;
using SeenLive.Persistence.Repositories.Bands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeenLive.Bands.GetAll
{
    public class GetAllBandsQueryHandler
        : IRequestHandler<GetAllBandsQuery, IEnumerable<BandViewModel>>
    {
        private readonly IBandRepository _bandRepository;

        public GetAllBandsQueryHandler(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IEnumerable<BandViewModel>> Handle(GetAllBandsQuery request, CancellationToken cancellationToken)
        {
            var allBands = await _bandRepository.ListAsync();
            return allBands.Select(b => b.ToViewModel());
        }
    }
}
