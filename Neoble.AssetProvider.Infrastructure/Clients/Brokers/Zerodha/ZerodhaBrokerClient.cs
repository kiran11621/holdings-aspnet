using Neoble.AssetProvider.Application.Interfaces.Providers;
using Neoble.AssetProvider.Application.Services.DTOs;
using Neoble.AssetProvider.Application.Services.Mappers.Holdings;
using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;
using Neoble.AssetProvider.Infrastructure.Http.Abstractions;

namespace Neoble.AssetProvider.Infrastructure.Clients.Brokers.Zerodha;

public class ZerodhaBrokerClient : IBrokerProvider
{
    private readonly IExternalApiExecutor _externalApiExecutor;
    private readonly HoldingMapperResolver _holdingMapperResolver;

    public ZerodhaBrokerClient(IExternalApiExecutor externalApiExecutor, HoldingMapperResolver holdingMapperResolver)
    {
        _externalApiExecutor = externalApiExecutor;
        _holdingMapperResolver = holdingMapperResolver;
    }

    public Broker Broker => Broker.Zerodha;

    public async Task<List<Holding>> GetHoldingsAsync(long userId, string dpId, string clientId, CancellationToken cancellationToken = default)
    {
        var response = await _externalApiExecutor.PostAsync<object, ZerodhaHoldingResponseDto>(
            "Zerodha",
            "Holding",
            new { },
            false,
            cancellationToken);

        return _holdingMapperResolver.Map(response, Broker, userId, dpId, clientId);
    }
}
