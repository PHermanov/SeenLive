using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Update
{
   public class UpdateBandCommand 
       : IRequest<IHandlerResult<BandViewModel>>
    {
        public int Id { get; set; }
        public string Name { get; init; } = string.Empty;
        public string? AlternativeNames { get; init; }
        public string? Info { get; init; }

        public BandEntity ToEntity() => new() { Id = Id, Name = Name.Trim(), AlternativeNames = AlternativeNames, Info = Info };
    }
}
