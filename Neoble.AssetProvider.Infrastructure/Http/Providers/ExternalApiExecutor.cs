using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Neoble.AssetProvider.Infrastructure.Http.Abstractions;

namespace Neoble.AssetProvider.Infrastructure.Http.Providers;

public sealed class ExternalApiExecutor : IExternalApiExecutor
{
    private readonly HttpClient _client;
    private readonly IExternalApiConfigResolver _resolver;
    private readonly ILogger<ExternalApiExecutor> _logger;

    public ExternalApiExecutor(HttpClient client, IExternalApiConfigResolver resolver, ILogger<ExternalApiExecutor> logger)
    {
        _client = client;
        _resolver = resolver;
        _logger = logger;
    }

    public async Task<TResponse?> GetAsync<TResponse>(
        string providerName,
        string endpointKey,
        CancellationToken cancellationToken = default)
    {
        var cfg = _resolver.Resolve(providerName);
        if (!cfg.Endpoints.TryGetValue(endpointKey, out var endpoint))
        {
            throw new InvalidOperationException($"Endpoint {endpointKey} not configured for {providerName}");
        }

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(TimeSpan.FromSeconds(cfg.TimeoutSeconds));

        var url = $"{cfg.BaseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
        var response = await _client.GetAsync(url, cts.Token);
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("External API error {Provider}: {StatusCode}", providerName, response.StatusCode);
            throw new HttpRequestException($"External API failed: {providerName}");
        }

        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cts.Token);
    }
}
