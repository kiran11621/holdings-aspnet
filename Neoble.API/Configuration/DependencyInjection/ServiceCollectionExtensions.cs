using Neoble.AssetProvider.Application.Interfaces.Clients.Brokers;
using Neoble.AssetProvider.Application.Services.Portfolio;
using Neoble.AssetProvider.Infrastructure.Clients.Brokers.Upstox;
using Neoble.AssetProvider.Infrastructure.Clients.Brokers.Zerodha;
using Neoble.AssetProvider.Infrastructure.Factories;
using Neoble.AssetProvider.Infrastructure.Http.Abstractions;
using Neoble.AssetProvider.Infrastructure.Http.Models;
using Neoble.AssetProvider.Infrastructure.Http.Providers;

namespace Neoble.API.Configuration.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNeobleServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Dictionary<string, ExternalApiOptions>>(configuration.GetSection("ExternalApis"));

        services.AddHttpClient<IExternalApiExecutor, ExternalApiExecutor>();
        services.AddSingleton<IExternalApiConfigResolver, ExternalApiConfigResolver>();

        services.AddScoped<IBrokerHoldingClient, UpstoxBrokerClient>();
        services.AddScoped<IBrokerHoldingClient, ZerodhaBrokerClient>();
        services.AddScoped<IBrokerClientFactory, BrokerClientFactory>();

        services.AddScoped<HoldingService>();

        return services;
    }
}
