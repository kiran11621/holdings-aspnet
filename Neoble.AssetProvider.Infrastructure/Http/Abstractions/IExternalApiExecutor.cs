namespace Neoble.AssetProvider.Infrastructure.Http.Abstractions;

public interface IExternalApiExecutor
{
    Task<TResponse?> GetAsync<TResponse>(
        string providerName,
        string endpointKey,
        CancellationToken cancellationToken = default);
}
