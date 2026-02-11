using System.Text.Json.Serialization;

namespace Neoble.AssetProvider.Application.Services.DTOs;

public class UpstoxHoldingResponseDto
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("data")]
    public List<HoldingDatum>? Data { get; set; }
}

public class HoldingDatum
{
    [JsonPropertyName("isin")] public string? Isin { get; set; }
    [JsonPropertyName("cnc_used_quantity")] public int? CncUsedQuantity { get; set; }
    [JsonPropertyName("collateral_type")] public string? CollateralType { get; set; }
    [JsonPropertyName("company_name")] public string? CompanyName { get; set; }
    [JsonPropertyName("haircut")] public double? Haircut { get; set; }
    [JsonPropertyName("product")] public string? Product { get; set; }
    [JsonPropertyName("quantity")] public int? Quantity { get; set; }
    [JsonPropertyName("trading_symbol")] public string? TradingSymbol { get; set; }
    [JsonPropertyName("tradingsymbol")] public string? Tradingsymbol { get; set; }
    [JsonPropertyName("last_price")] public double? LastPrice { get; set; }
    [JsonPropertyName("close_price")] public double? ClosePrice { get; set; }
    [JsonPropertyName("pnl")] public double? Pnl { get; set; }
    [JsonPropertyName("day_change")] public double? DayChange { get; set; }
    [JsonPropertyName("instrument_token")] public string? InstrumentToken { get; set; }
    [JsonPropertyName("average_price")] public double? AveragePrice { get; set; }
    [JsonPropertyName("collateral_quantity")] public int? CollateralQuantity { get; set; }
    [JsonPropertyName("t1_quantity")] public int? T1Quantity { get; set; }
    [JsonPropertyName("exchange")] public string? Exchange { get; set; }
}
