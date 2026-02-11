using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Domain.Entities;

public class Holding
{
    public long UserId { get; set; }
    public Broker Broker { get; set; }

    public string? Isin { get; set; }
    public string? DpId { get; set; }
    public string? ClientId { get; set; }
    public string? TradingSymbol { get; set; }
    public string? InstrumentToken { get; set; }
    public string? Exchange { get; set; }
    public string? CompanyName { get; set; }

    public decimal MarketValue { get; set; }
    public string? Product { get; set; }

    public int Quantity { get; set; }
    public int UsedQuantity { get; set; }
    public int T1Quantity { get; set; }
    public int RealisedQuantity { get; set; }
    public int AuthorisedQuantity { get; set; }
    public int OpeningQuantity { get; set; }
    public int ShortQuantity { get; set; }

    public decimal LastPrice { get; set; }
    public decimal ProfitandLoss { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal LastTradedPrice { get; set; }
    public decimal ClosePrice { get; set; }
    public decimal DayChange { get; set; }

    public int CollateralQuantity { get; set; }
    public string? CollateralType { get; set; }
    public decimal Haircut { get; set; }
}
