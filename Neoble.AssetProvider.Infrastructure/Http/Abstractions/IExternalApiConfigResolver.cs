using Neoble.AssetProvider.Infrastructure.Http.Models;

namespace Neoble.AssetProvider.Infrastructure.Http.Abstractions;

public interface IExternalApiConfigResolver
{
    ExternalApiOptions Resolve(string providerName);
}
