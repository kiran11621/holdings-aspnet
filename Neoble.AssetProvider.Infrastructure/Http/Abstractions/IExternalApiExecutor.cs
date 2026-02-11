namespace Neoble.AssetProvider.Infrastructure.Http.Abstractions;

public interface IExternalApiExecutor
{
    Task<TResponse> PostAsync<TRequest, TResponse>(
        string providerName,
        string endpointKey,
        TRequest request,
        bool encrypt = false,
        CancellationToken ct = default);
}
