using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Infrastructure.Mappers.Holdings;

public interface IHoldingMapper
{
    Broker Broker { get; }
}

public interface IHoldingMapper<TSource> : IHoldingMapper
{
    List<Holding> Map(
        TSource source,
        long userId,
        string dpId,
        string clientId);
}
