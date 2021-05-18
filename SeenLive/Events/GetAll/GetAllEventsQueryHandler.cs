using MediatR;
using Microsoft.EntityFrameworkCore;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeenLive.Events.GetAll
{
    public class GetAllEventsQueryHandler
       : HandlerBase, IRequestHandler<GetAllEventsQuery, IHandlerResult<IEnumerable<EventViewModel>>>
    {
        private readonly AppDbContext _context;

        public GetAllEventsQueryHandler(AppDbContext context)
            => _context = context;

        public async Task<IHandlerResult<IEnumerable<EventViewModel>>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _context.Events.ToListAsync(cancellationToken);
            return Data(allEvents.Select(b => b.ToViewModel()));
        }
    }
}
