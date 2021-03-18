using MediatR;
using SeenLive.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using SeenLive.EfCore.Contexts;

namespace SeenLive.Bands.Create
{
    public class CreateBandCommandHandler
        : HandlerBase, IRequestHandler<CreateBandCommand, IHandlerResult<BandViewModel>>
    {
        private readonly AppDbContext _context;

        public CreateBandCommandHandler(AppDbContext context)
            => _context = context;
        
        public async Task<IHandlerResult<BandViewModel>> Handle(CreateBandCommand request, CancellationToken cancellationToken)
        {
           var band = await _context.Bands.AddAsync(request.ToEntity(), cancellationToken);
           
           await _context.SaveChangesAsync(cancellationToken);
          
           return Data(band.Entity.ToViewModel());
        }
    }
}