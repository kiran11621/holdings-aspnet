using Neoble.AssetProvider.Application.DTOs;
using Neoble.AssetProvider.Domain.Entities.Asset;

namespace Neoble.AssetProvider.Application.Mappers;

public static class HoldingDomainMapper
{
    public static HoldingDto ToDto(this Holding entity) => new()
    {
        UserId = entity.UserId,
        Broker = entity.Broker,
        Isin = entity.Isin,
        TradingSymbol = entity.TradingSymbol,
        Exchange = entity.Exchange,
        Quantity = entity.Quantity,
        LastPrice = entity.LastPrice,
        Pnl = entity.ProfitAndLoss
    };
}
