using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Update
{
   public class UpdateBandCommand 
       : IRequest<IHandlerResult<BandViewModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AlternativeNames { get; set; }
        public string Info { get; set; }

        public BandEntity ToEntity() => new() { Id = Id, Name = Name.Trim(), AlternativeNames = AlternativeNames, Info = Info };
    }
}
