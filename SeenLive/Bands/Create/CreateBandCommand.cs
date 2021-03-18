using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Create
{
    public class CreateBandCommand
        : IRequest<IHandlerResult<BandViewModel>>
    {
        public string Name { get; set; }
        public string AlternativeNames { get; set; }
        public string Info { get; set; }

        public BandEntity ToEntity() => new()
        {
            Name = Name.Trim(), 
            AlternativeNames = AlternativeNames, 
            Info = Info
        };
    }
}
