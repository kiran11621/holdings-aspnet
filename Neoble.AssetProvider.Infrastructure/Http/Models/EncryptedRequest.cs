using System.Text.Json.Serialization;

namespace Neoble.AssetProvider.Infrastructure.Http.Models;

public class EncryptedRequest
{
    [JsonPropertyName("encryptedRequestData")]
    public string EncryptedRequestData { get; set; } = string.Empty;
}
