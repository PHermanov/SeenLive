using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.GetById
{
    public class GetBandByIdQueryHandler
        : HandlerBase, IRequestHandler<GetBandByIdQuery, IHandlerResult<BandViewModel>>
    {
        private readonly AppDbContext _context;
        public GetBandByIdQueryHandler(AppDbContext context)
            => _context = context;

        public async Task<IHandlerResult<BandViewModel>> Handle(GetBandByIdQuery request, CancellationToken cancellationToken)
        {
            var band = await _context.Bands.FindAsync(request.Id);

            return band switch
            {
                null => NotFound<BandViewModel>("Band doesn't exist"),
                _ => Data(band.ToViewModel())
            };
        }
    }
}
