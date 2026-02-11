namespace Neoble.AssetProvider.Infrastructure.Http.Models;

public class ExternalApiOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public Dictionary<string, string> Endpoints { get; set; } = new();
    public int TimeoutSeconds { get; set; } = 30;
}
