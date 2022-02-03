using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;

namespace SeenLive.Events.GetByBandId
{
    public class GetEventByBandIdQueryHandler
    : HandlerBase, IRequestHandler<GetEventByBandIdQuery, IHandlerResult<IEnumerable<EventViewModel>>>
    {
        private readonly AppDbContext _context;
        public GetEventByBandIdQueryHandler(AppDbContext context)
            => _context = context;

        public async Task<IHandlerResult<IEnumerable<EventViewModel>>> Handle(GetEventByBandIdQuery request, CancellationToken cancellationToken)
        {
            var band = await _context
                .Bands
                .Include(b => b.Events)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            return band == null
                ? NotFound<IEnumerable<EventViewModel>>("Band was not found")
                : Data(band.Events == null 
                    ? Array.Empty<EventViewModel>() 
                    : band.Events.Select(e => e.ToViewModel()));
        }
    }
}