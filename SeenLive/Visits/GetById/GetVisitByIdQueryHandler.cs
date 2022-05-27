using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SeenLive.EfCore.Contexts;
using SeenLive.Infrastructure;

namespace SeenLive.Visits.GetById;

public class GetVisitByIdQueryHandler
    :HandlerBase, IRequestHandler<GetVisitByIdQuery, IHandlerResult<VisitViewModel>>
{
    private readonly AppDbContext _context;

    public GetVisitByIdQueryHandler(AppDbContext context)
        => _context = context;
    
    public async Task<IHandlerResult<VisitViewModel>> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
    {
        var foundVisit = await _context.Visits.FindAsync(request.Id);

        return foundVisit switch
        {
            null => NotFound<VisitViewModel>("Visit does not exist"),
            _ => Data(foundVisit.ToViewModel())
        };
    }
}