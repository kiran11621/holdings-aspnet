using Neoble.AssetProvider.Application.Interfaces.Providers;
using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Services.Portfolio;

public class HoldingService
{
    private readonly IBrokerProviderFactory _brokerProviderFactory;

    public HoldingService(IBrokerProviderFactory brokerProviderFactory)
    {
        _brokerProviderFactory = brokerProviderFactory;
    }

    public Task<List<Holding>> GetHoldingsAsync(
        Broker broker,
        long userId,
        string dpId,
        string clientId,
        CancellationToken cancellationToken = default)
    {
        var provider = _brokerProviderFactory.Resolve(broker);
        return provider.GetHoldingsAsync(userId, dpId, clientId, cancellationToken);
    }
}
