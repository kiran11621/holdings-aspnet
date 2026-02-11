using System.Text.Json.Serialization;

namespace Neoble.AssetProvider.Infrastructure.Clients.Brokers.Upstox;

public class UpstoxHoldingResponse
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public List<UpstoxHoldingItem> Data { get; set; } = new();
}

public class UpstoxHoldingItem
{
    [JsonPropertyName("isin")] public string? Isin { get; set; }
    [JsonPropertyName("trading_symbol")] public string? TradingSymbol { get; set; }
    [JsonPropertyName("exchange")] public string? Exchange { get; set; }
    [JsonPropertyName("quantity")] public decimal Quantity { get; set; }
    [JsonPropertyName("last_price")] public decimal LastPrice { get; set; }
    [JsonPropertyName("pnl")] public decimal Pnl { get; set; }
}
