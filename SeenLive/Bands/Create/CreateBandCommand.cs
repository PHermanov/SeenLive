using MediatR;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Create
{
    public class CreateBandCommand
        : IRequest<IHandlerResult<BandViewModel>>
    {
        public string Name { get; init; } = string.Empty;
        public string? AlternativeNames { get; init; }
        public string? Info { get; init; }

        public BandEntity ToEntity()
            => new()
            {
                Name = Name.Trim(),
                AlternativeNames = AlternativeNames,
                Info = Info
            };
    }
}
