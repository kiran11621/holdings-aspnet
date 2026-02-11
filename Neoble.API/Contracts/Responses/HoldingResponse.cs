namespace Neoble.API.Contracts.Responses;

public class HoldingResponse
{
    public long UserId { get; set; }
    public string Broker { get; set; } = string.Empty;
    public string? Isin { get; set; }
    public string? TradingSymbol { get; set; }
    public string? Exchange { get; set; }
    public decimal Quantity { get; set; }
    public decimal LastPrice { get; set; }
    public decimal Pnl { get; set; }
}
