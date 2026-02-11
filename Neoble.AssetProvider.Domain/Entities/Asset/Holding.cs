using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Domain.Entities.Asset;

public class Holding
{
    public long UserId { get; set; }
    public BrokerType Broker { get; set; }

    public string? Isin { get; set; }
    public string? TradingSymbol { get; set; }
    public string? InstrumentToken { get; set; }
    public string? Exchange { get; set; }
    public string? CompanyName { get; set; }

    public decimal Quantity { get; set; }
    public decimal UsedQuantity { get; set; }
    public decimal T1Quantity { get; set; }
    public decimal CollateralQuantity { get; set; }

    public decimal LastPrice { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal ClosePrice { get; set; }
    public decimal ProfitAndLoss { get; set; }
    public decimal DayChange { get; set; }

    public string? Product { get; set; }
    public string? CollateralType { get; set; }
    public decimal Haircut { get; set; }
}
