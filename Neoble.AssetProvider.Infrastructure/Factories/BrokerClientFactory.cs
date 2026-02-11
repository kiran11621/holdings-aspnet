using Neoble.AssetProvider.Application.Interfaces.Clients.Brokers;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Infrastructure.Factories;

public class BrokerClientFactory : IBrokerClientFactory
{
    private readonly IReadOnlyDictionary<BrokerType, IBrokerHoldingClient> _clients;

    public BrokerClientFactory(IEnumerable<IBrokerHoldingClient> clients)
    {
        _clients = clients.ToDictionary(x => x.BrokerType, x => x);
    }

    public IBrokerHoldingClient Resolve(BrokerType brokerType)
    {
        if (_clients.TryGetValue(brokerType, out var client))
        {
            return client;
        }

        throw new NotSupportedException($"Broker client not available for {brokerType}");
    }
}
