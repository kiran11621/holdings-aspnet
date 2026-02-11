using System.Text.Json.Serialization;

namespace Neoble.AssetProvider.Application.Services.DTOs;

public class ZerodhaHoldingResponseDto
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("data")]
    public List<ZerodhaHoldingDatum>? Data { get; set; }
}

public class ZerodhaHoldingDatum
{
    [JsonPropertyName("tradingsymbol")] public string? Tradingsymbol { get; set; }
    [JsonPropertyName("exchange")] public string? Exchange { get; set; }
    [JsonPropertyName("instrument_token")] public long? InstrumentToken { get; set; }
    [JsonPropertyName("isin")] public string? Isin { get; set; }
    [JsonPropertyName("product")] public string? Product { get; set; }
    [JsonPropertyName("quantity")] public int? Quantity { get; set; }
    [JsonPropertyName("used_quantity")] public int? UsedQuantity { get; set; }
    [JsonPropertyName("t1_quantity")] public int? T1Quantity { get; set; }
    [JsonPropertyName("last_price")] public decimal? LastPrice { get; set; }
    [JsonPropertyName("pnl")] public decimal? Pnl { get; set; }
}
