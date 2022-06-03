using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeenLive.Bands;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;

namespace SeenLive.Events.AssignBands;

public class AssignBandsCommandHandler
    :HandlerBase, IRequestHandler<AssignBandsCommand, IHandlerResult<EventViewModel>>
{
    private readonly AppDbContext _context;

    public AssignBandsCommandHandler(AppDbContext context)
        => _context = context;

    public async Task<IHandlerResult<EventViewModel>> Handle(AssignBandsCommand request, CancellationToken cancellationToken)
    {
        var foundEvent = await _context.Events
            .Include(e => e.Bands)
            .FirstOrDefaultAsync(e => e.Id == request.EventId, cancellationToken);

        if(foundEvent == null)
            return NotFound<EventViewModel>("Event was not found");

        foundEvent.Bands ??= new List<BandEntity>();

        foreach (var bandToRemove in foundEvent.Bands
                     .Where(b => !request.Body.BandIds.Contains(b.Id)))
        {
            foundEvent.Bands.Remove(bandToRemove);
        }
        
        foreach (var bandId in request.Body.BandIds)
        {
            var band = await _context.Bands.FindAsync(new object?[] { bandId }, cancellationToken);
            
            if(band == null)
                return NotFound<EventViewModel>($"Band with id: {bandId} was not found");

            if (!foundEvent.Bands.Contains(band))
                foundEvent.Bands.Add(band);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Data(foundEvent.ToViewModel());
    }
}