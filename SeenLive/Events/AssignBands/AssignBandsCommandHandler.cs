using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
        var foundEvent = await _context.Events.FindAsync(request.EventId);
        
        if(foundEvent == null)
            return NotFound<EventViewModel>("Event was not found");

        var bandsToAttach = new List<BandEntity>();
        foreach (var bandId in request.BandIds)
        {
            var band = await _context.Bands.FindAsync(bandId);
            
            if(band == null)
                return NotFound<EventViewModel>($"Band with id: {bandId} was not found");
            
            bandsToAttach.Add(band);
        }
        
        foundEvent.Bands = bandsToAttach;
        
        await _context.SaveChangesAsync(cancellationToken);

        return Data(foundEvent.ToViewModel());
    }
}