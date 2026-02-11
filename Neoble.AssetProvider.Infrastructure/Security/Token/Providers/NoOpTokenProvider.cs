using Neoble.AssetProvider.Infrastructure.Security.Token.Abstractions;

namespace Neoble.AssetProvider.Infrastructure.Security.Token.Providers;

public class NoOpTokenProvider : ITokenProvider
{
    public Task<string> GetTokenAsync(string providerName, CancellationToken ct = default)
        => Task.FromResult(string.Empty);
}
