using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Events.AssignBands;

public class AssignBandsCommand
    : IRequest<IHandlerResult<EventViewModel>>
{
    public int EventId { get; set; }
    public AssignBandsBody Body { get; set; } = new ();
}