using Neoble.AssetProvider.Application.Interfaces.Providers;
using Neoble.AssetProvider.Application.Services.Mappers.Holdings;
using Neoble.AssetProvider.Application.Services.Portfolio;
using Neoble.AssetProvider.Infrastructure.Clients.Brokers.Upstox;
using Neoble.AssetProvider.Infrastructure.Clients.Brokers.Zerodha;
using Neoble.AssetProvider.Infrastructure.Factories;
using Neoble.AssetProvider.Infrastructure.Http;

namespace Neoble.API.Configuration.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNeobleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExternalHttp(configuration);

        services.AddScoped<IHoldingMapper, UpstoxHoldingMapper>();
        services.AddScoped<IHoldingMapper, ZerodhaHoldingMapper>();
        services.AddScoped<IHoldingMapper<Neoble.AssetProvider.Application.Services.DTOs.UpstoxHoldingResponseDto>, UpstoxHoldingMapper>();
        services.AddScoped<IHoldingMapper<Neoble.AssetProvider.Application.Services.DTOs.ZerodhaHoldingResponseDto>, ZerodhaHoldingMapper>();
        services.AddScoped<HoldingMapperResolver>();

        services.AddScoped<IBrokerProvider, UpstoxBrokerClient>();
        services.AddScoped<IBrokerProvider, ZerodhaBrokerClient>();
        services.AddScoped<IBrokerProviderFactory, BrokerProviderFactory>();

        services.AddScoped<HoldingService>();

        return services;
    }
}
