using Neoble.AssetProvider.Application.Interfaces.Providers;
using Neoble.AssetProvider.Domain.Enums;

namespace Neoble.AssetProvider.Infrastructure.Factories;

public class BrokerProviderFactory : IBrokerProviderFactory
{
    private readonly IReadOnlyDictionary<Broker, IBrokerProvider> _providers;

    public BrokerProviderFactory(IEnumerable<IBrokerProvider> providers)
    {
        _providers = providers.ToDictionary(x => x.Broker, x => x);
    }

    public IBrokerProvider Resolve(Broker broker)
    {
        if (_providers.TryGetValue(broker, out var provider))
        {
            return provider;
        }

        throw new NotSupportedException($"Broker provider not available for {broker}");
    }
}
