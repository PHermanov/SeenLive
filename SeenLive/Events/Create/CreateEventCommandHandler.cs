using MediatR;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace SeenLive.Events.Create
{
    public class CreateEventCommandHandler
        : HandlerBase, IRequestHandler<CreateEventCommand, IHandlerResult<EventViewModel>>
    {
        private readonly AppDbContext _context;

        public CreateEventCommandHandler(AppDbContext context)
            => _context = context;


        public async Task<IHandlerResult<EventViewModel>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var createdEvent = await _context.Events.AddAsync(request.ToEntity(), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Data(createdEvent.Entity.ToViewModel());
        }
    }
}
