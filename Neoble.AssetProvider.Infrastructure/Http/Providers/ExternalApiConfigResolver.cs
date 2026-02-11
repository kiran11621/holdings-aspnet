using Microsoft.Extensions.Options;
using Neoble.AssetProvider.Infrastructure.Http.Abstractions;
using Neoble.AssetProvider.Infrastructure.Http.Models;

namespace Neoble.AssetProvider.Infrastructure.Http.Providers;

public sealed class ExternalApiConfigResolver : IExternalApiConfigResolver
{
    private readonly IDictionary<string, ExternalApiOptions> _configs;

    public ExternalApiConfigResolver(IOptions<Dictionary<string, ExternalApiOptions>> options)
    {
        _configs = options.Value;
    }

    public ExternalApiOptions Resolve(string providerName)
    {
        if (!_configs.TryGetValue(providerName, out var cfg))
        {
            throw new InvalidOperationException($"External API config missing for {providerName}");
        }

        return cfg;
    }
}
