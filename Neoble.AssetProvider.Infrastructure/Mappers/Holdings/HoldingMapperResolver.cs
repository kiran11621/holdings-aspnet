using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Infrastructure.Mappers.Holdings;

public class HoldingMapperResolver
{
    private readonly IEnumerable<IHoldingMapper> _mappers;

    public HoldingMapperResolver(IEnumerable<IHoldingMapper> mappers)
    {
        _mappers = mappers;
    }

    public List<Holding> Map<TDto>(
        TDto dto,
        Broker broker,
        long userId,
        string dpId,
        string clientId)
    {
        var mapper = _mappers
            .OfType<IHoldingMapper<TDto>>()
            .FirstOrDefault(m => m.Broker == broker);

        if (mapper == null)
        {
            throw new InvalidOperationException($"No mapper found for {broker}");
        }

        return mapper.Map(dto!, userId, dpId, clientId);
    }
}
