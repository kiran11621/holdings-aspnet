using Neoble.AssetProvider.Application.DTOs;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Interfaces.Clients.Brokers;

public interface IBrokerHoldingClient
{
    BrokerType BrokerType { get; }
    Task<IReadOnlyCollection<HoldingDto>> GetHoldingsAsync(CancellationToken cancellationToken = default);
}
