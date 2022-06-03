namespace SeenLive.Bands.CreateOrUpdate;

public class CreateOrUpdateBandBody
{
    public string Name { get; init; } = string.Empty;
    public string? AlternativeNames { get; init; }
    public string? Info { get; init; }
}