using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Delete
{
    public class DeleteBandCommand
    : IRequest<IHandlerResult<Unit>>
    {
        public int Id { get; set; }
    }
}
