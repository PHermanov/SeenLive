using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;

namespace SeenLive.Events.GetById;

public class GetEventByIdQueryHandler
    : HandlerBase, IRequestHandler<GetEventByIdQuery, IHandlerResult<EventViewModel>>
{
    private readonly AppDbContext _context;
    public GetEventByIdQueryHandler(AppDbContext context)
        => _context = context;

    public async Task<IHandlerResult<EventViewModel>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var foundEvent = await _context.Events.FindAsync(new object?[] { request.Id }, cancellationToken);

        return foundEvent switch
        {
            null => NotFound<EventViewModel>("Event doesn't exist"),
            _ => Data(foundEvent.ToViewModel())
        };
    }
}