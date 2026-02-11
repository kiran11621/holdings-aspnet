using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Interfaces.Clients.Brokers;

public interface IBrokerClientFactory
{
    IBrokerHoldingClient Resolve(BrokerType brokerType);
}
