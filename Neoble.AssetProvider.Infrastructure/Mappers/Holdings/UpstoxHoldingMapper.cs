using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;
using Neoble.AssetProvider.Infrastructure.Clients.Brokers.Upstox;

namespace Neoble.AssetProvider.Infrastructure.Mappers.Holdings;

public sealed class UpstoxHoldingMapper : IHoldingMapper<UpstoxHoldingResponseDto>
{
    public Broker Broker => Broker.Upstox;

    public List<Holding> Map(UpstoxHoldingResponseDto source, long userId, string dpId, string clientId)
    {
        if (source?.Data == null || !source.Data.Any()) return new List<Holding>();

        return source.Data.Select(dto =>
        {
            var quantity = dto.Quantity ?? 0;
            var lastPrice = ToDecimal(dto.LastPrice);

            return new Holding
            {
                UserId = userId,
                Broker = Broker.Upstox,
                DpId = dpId,
                ClientId = clientId,
                Isin = dto.Isin,
                TradingSymbol = dto.TradingSymbol ?? dto.Tradingsymbol,
                InstrumentToken = dto.InstrumentToken,
                Exchange = dto.Exchange,
                CompanyName = dto.CompanyName,
                Product = dto.Product,
                Quantity = quantity,
                UsedQuantity = dto.CncUsedQuantity ?? 0,
                T1Quantity = dto.T1Quantity ?? 0,
                LastPrice = lastPrice,
                AveragePrice = ToDecimal(dto.AveragePrice),
                ClosePrice = ToDecimal(dto.ClosePrice),
                ProfitandLoss = ToDecimal(dto.Pnl),
                DayChange = ToDecimal(dto.DayChange),
                CollateralQuantity = dto.CollateralQuantity ?? 0,
                CollateralType = dto.CollateralType,
                Haircut = ToDecimal(dto.Haircut),
                MarketValue = quantity * lastPrice,
                LastTradedPrice = lastPrice
            };
        }).ToList();
    }

    private static decimal ToDecimal(double? value) => value.HasValue ? Convert.ToDecimal(value.Value) : 0m;
}
