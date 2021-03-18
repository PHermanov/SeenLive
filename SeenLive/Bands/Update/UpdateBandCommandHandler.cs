using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Update
{
    public class UpdateBandCommandHandler
    : HandlerBase, IRequestHandler<UpdateBandCommand, IHandlerResult<BandViewModel>>
    {
        private readonly AppDbContext _context;

        public UpdateBandCommandHandler(AppDbContext context)
            => _context = context;
        
        public async Task<IHandlerResult<BandViewModel>> Handle(UpdateBandCommand request, CancellationToken cancellationToken)
        {
            var band = await _context
                .Bands
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (band == null)
            {
                return NotFound<BandViewModel>("Band was not found");
            }
            
            var updated = _context.Bands.Update(request.ToEntity()).Entity;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Data(updated.ToViewModel());
        }
    }
}
