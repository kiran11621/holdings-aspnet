using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.DTOs;

public class HoldingDto
{
    public long UserId { get; set; }
    public BrokerType Broker { get; set; }
    public string? Isin { get; set; }
    public string? TradingSymbol { get; set; }
    public string? Exchange { get; set; }
    public decimal Quantity { get; set; }
    public decimal LastPrice { get; set; }
    public decimal Pnl { get; set; }
}
