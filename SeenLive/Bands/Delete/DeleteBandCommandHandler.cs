using MediatR;
using SeenLive.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeenLive.EfCore.Contexts;

namespace SeenLive.Bands.Delete
{
    public class DeleteBandCommandHandler
    : HandlerBase, IRequestHandler<DeleteBandCommand, IHandlerResult<Unit>>
    {
        private readonly AppDbContext _context;

        public DeleteBandCommandHandler(AppDbContext context)
            => _context = context;

        public async Task<IHandlerResult<Unit>> Handle(DeleteBandCommand request, CancellationToken cancellationToken)
        {
            var band = await _context
                .Bands
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            
            if (band == null)
                return NotFound<Unit>("Band was not found");

            _context.Bands.Remove(band);
            await _context.SaveChangesAsync(cancellationToken);
            
            return NoData();
        }
    }
}
