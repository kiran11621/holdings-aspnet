using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Application.Interfaces.Providers;

public interface IBrokerProviderFactory
{
    IBrokerProvider Resolve(Broker broker);
}
