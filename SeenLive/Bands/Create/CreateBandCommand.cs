using MediatR;
using SeenLive.Bands.CreateOrUpdate;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Create;

public class CreateBandCommand
    : IRequest<IHandlerResult<BandViewModel>>
{
    public CreateOrUpdateBandBody Body { get; init; } = new();

    public BandEntity ToEntity()
        => new()
        {
            Name = Body.Name.Trim(),
            AlternativeNames = Body.AlternativeNames,
            Info = Body.Info
        };
}