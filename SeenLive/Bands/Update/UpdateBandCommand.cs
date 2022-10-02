using MediatR;
using SeenLive.Bands.CreateOrUpdate;
using SeenLive.Infrastructure;

namespace SeenLive.Bands.Update;

public class UpdateBandCommand 
    : IRequest<IHandlerResult<BandViewModel>>
{
    public int Id { get; init; }

    public CreateOrUpdateBandBody Body { get; init; } = new();

    public BandEntity ToEntity() => new()
    {
        Id = Id, 
        Name = Body.Name.Trim(), 
        AlternativeNames = Body.AlternativeNames, 
        Info = Body.Info
    };
}