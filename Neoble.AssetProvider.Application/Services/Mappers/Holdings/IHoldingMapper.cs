using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Services.Mappers.Holdings;

public interface IHoldingMapper
{
    Broker Broker { get; }
    Type SourceType { get; }

    List<Holding> MapFromObject(
        object source,
        long userId,
        string dpId,
        string clientId);
}

public interface IHoldingMapper<TSource> : IHoldingMapper
{
    List<Holding> Map(
        TSource source,
        long userId,
        string dpId,
        string clientId);
}
