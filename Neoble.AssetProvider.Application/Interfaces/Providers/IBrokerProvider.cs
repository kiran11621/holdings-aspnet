using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Interfaces.Providers;

public interface IBrokerProvider
{
    Broker Broker { get; }
    Task<List<Holding>> GetHoldingsAsync(long userId, string dpId, string clientId, CancellationToken cancellationToken = default);
}
