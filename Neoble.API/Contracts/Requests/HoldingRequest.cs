namespace Neoble.API.Contracts.Requests;

public class HoldingRequest
{
    public long UserId { get; set; }
    public string DpId { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
}
