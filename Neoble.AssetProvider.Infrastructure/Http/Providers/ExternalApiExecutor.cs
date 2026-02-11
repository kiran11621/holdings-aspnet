using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Neoble.AssetProvider.Infrastructure.Http.Abstractions;
using Neoble.AssetProvider.Infrastructure.Http.Models;
using Neoble.AssetProvider.Infrastructure.Security.Encryption.Abstractions;
using Neoble.AssetProvider.Infrastructure.Security.Token.Abstractions;
using Newtonsoft.Json;

namespace Neoble.AssetProvider.Infrastructure.Http.Providers;

public sealed class ExternalApiExecutor : IExternalApiExecutor
{
    private readonly HttpClient _client;
    private readonly ITokenProvider _tokenProvider;
    private readonly IExternalApiConfigResolver _resolver;
    private readonly IEncryptionProvider? _crypto;
    private readonly ILogger<ExternalApiExecutor> _logger;

    public ExternalApiExecutor(
        HttpClient client,
        ITokenProvider tokenProvider,
        IExternalApiConfigResolver resolver,
        IEncryptionProvider? crypto,
        ILogger<ExternalApiExecutor> logger)
    {
        _client = client;
        _tokenProvider = tokenProvider;
        _resolver = resolver;
        _crypto = crypto;
        _logger = logger;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(
        string providerName,
        string endpointKey,
        TRequest request,
        bool encrypt = false,
        CancellationToken ct = default)
    {
        var cfg = _resolver.Resolve(providerName);
        var token = await _tokenProvider.GetTokenAsync(providerName, ct);

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
        cts.CancelAfter(TimeSpan.FromSeconds(cfg.TimeoutSeconds));

        ConfigureClient(cfg, token);

        var url = BuildUrl(cfg, endpointKey);
        object payload = PrepareRequest(request, encrypt, providerName, cfg);

        var response = await _client.PostAsJsonAsync(url, payload, cts.Token);
        if (!response.IsSuccessStatusCode)
        {
            await LogError(response, providerName);
            throw new HttpRequestException($"External API failed: {providerName}");
        }

        return await ParseResponse<TResponse>(response, encrypt, providerName, cfg, cts.Token);
    }

    private void ConfigureClient(ExternalApiOptions cfg, string token)
    {
        _client.DefaultRequestHeaders.Clear();
        if (!string.IsNullOrWhiteSpace(token))
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        foreach (var h in cfg.Headers)
        {
            _client.DefaultRequestHeaders.Add(h.Key, h.Value);
        }
    }

    private static string BuildUrl(ExternalApiOptions cfg, string endpointKey)
    {
        if (!cfg.Endpoints.TryGetValue(endpointKey, out var ep))
        {
            throw new InvalidOperationException($"Endpoint {endpointKey} not configured");
        }

        return $"{cfg.BaseUrl.TrimEnd('/')}/{ep.TrimStart('/')}";
    }

    private object PrepareRequest<T>(T request, bool encrypt, string providerName, ExternalApiOptions cfg)
    {
        if (!encrypt || !cfg.UseEncryption || _crypto == null) return request!;

        var json = JsonConvert.SerializeObject(request);
        var encrypted = _crypto.Encrypt(providerName, json);

        return new EncryptedRequest { EncryptedRequestData = encrypted };
    }

    private async Task<T> ParseResponse<T>(HttpResponseMessage res, bool encrypt, string providerName, ExternalApiOptions cfg, CancellationToken ct)
    {
        var body = await res.Content.ReadAsStringAsync(ct);

        if (!encrypt || !cfg.UseEncryption || _crypto == null)
        {
            return JsonConvert.DeserializeObject<T>(body)!;
        }

        var enc = JsonConvert.DeserializeObject<EncryptedRequest>(body);
        var decrypted = _crypto.Decrypt(providerName, enc!.EncryptedRequestData);
        return JsonConvert.DeserializeObject<T>(decrypted)!;
    }

    private async Task LogError(HttpResponseMessage res, string provider)
    {
        var body = await res.Content.ReadAsStringAsync();
        _logger.LogError("External API error: {Provider} Status:{Status} Body:{Body}", provider, res.StatusCode, body);
    }
}
