using Neoble.AssetProvider.Application.DTOs;
using Neoble.AssetProvider.Application.Interfaces.Clients.Brokers;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Services.Portfolio;

public class HoldingService
{
    private readonly IBrokerClientFactory _brokerClientFactory;

    public HoldingService(IBrokerClientFactory brokerClientFactory)
    {
        _brokerClientFactory = brokerClientFactory;
    }

    public Task<IReadOnlyCollection<HoldingDto>> GetHoldingsAsync(
        BrokerType brokerType,
        CancellationToken cancellationToken = default)
    {
        var client = _brokerClientFactory.Resolve(brokerType);
        return client.GetHoldingsAsync(cancellationToken);
    }
}
