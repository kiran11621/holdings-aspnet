namespace Neoble.AssetProvider.Infrastructure.Security.Token.Abstractions;

public interface ITokenProvider
{
    Task<string> GetTokenAsync(string providerName, CancellationToken ct = default);
}
