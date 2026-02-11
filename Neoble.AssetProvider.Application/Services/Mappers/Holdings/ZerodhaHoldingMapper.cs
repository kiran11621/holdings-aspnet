using Neoble.AssetProvider.Application.Services.DTOs;
using Neoble.AssetProvider.Domain.Entities;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Services.Mappers.Holdings;

public sealed class ZerodhaHoldingMapper : IHoldingMapper<ZerodhaHoldingResponseDto>
{
    public Broker Broker => Broker.Zerodha;
    public Type SourceType => typeof(ZerodhaHoldingResponseDto);

    public List<Holding> Map(ZerodhaHoldingResponseDto source, long userId, string dpId, string clientId)
    {
        if (source?.Data == null || !source.Data.Any()) return new List<Holding>();

        return source.Data.Select(dto => new Holding
        {
            UserId = userId,
            Broker = Broker.Zerodha,
            DpId = dpId,
            ClientId = clientId,
            Isin = dto.Isin,
            TradingSymbol = dto.Tradingsymbol,
            InstrumentToken = dto.InstrumentToken?.ToString(),
            Exchange = dto.Exchange,
            Product = dto.Product,
            Quantity = dto.Quantity ?? 0,
            UsedQuantity = dto.UsedQuantity ?? 0,
            T1Quantity = dto.T1Quantity ?? 0,
            LastPrice = dto.LastPrice ?? 0m,
            ProfitandLoss = dto.Pnl ?? 0m,
            MarketValue = (dto.Quantity ?? 0) * (dto.LastPrice ?? 0m),
            LastTradedPrice = dto.LastPrice ?? 0m
        }).ToList();
    }

    public List<Holding> MapFromObject(object source, long userId, string dpId, string clientId)
        => source is ZerodhaHoldingResponseDto dto ? Map(dto, userId, dpId, clientId) : new List<Holding>();
}
