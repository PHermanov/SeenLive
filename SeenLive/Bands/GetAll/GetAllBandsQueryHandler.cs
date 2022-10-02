using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.GetAll;

public class GetAllBandsQueryHandler
    : HandlerBase, IRequestHandler<GetAllBandsQuery, IHandlerResult<IEnumerable<BandViewModel>>>
{
    private readonly AppDbContext _context;

    public GetAllBandsQueryHandler(AppDbContext context)
        => _context = context;

    public async Task<IHandlerResult<IEnumerable<BandViewModel>>> Handle(GetAllBandsQuery request, CancellationToken cancellationToken)
    {
        var allBands = await _context.Bands.ToListAsync(cancellationToken);
        return Data(allBands.Select(b => b.ToViewModel()));
    }
}