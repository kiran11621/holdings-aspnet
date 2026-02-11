using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neoble.AssetProvider.Infrastructure.Http.Abstractions;
using Neoble.AssetProvider.Infrastructure.Http.Models;
using Neoble.AssetProvider.Infrastructure.Http.Providers;
using Neoble.AssetProvider.Infrastructure.Security.Token.Abstractions;
using Neoble.AssetProvider.Infrastructure.Security.Token.Providers;

namespace Neoble.AssetProvider.Infrastructure.Http;

public static class ExternalHttpModule
{
    public static IServiceCollection AddExternalHttp(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Dictionary<string, ExternalApiOptions>>(configuration.GetSection("AssetProvider"));

        services.AddHttpClient<ExternalApiExecutor>();
        services.AddScoped<IExternalApiConfigResolver, ExternalApiConfigResolver>();
        services.AddScoped<IExternalApiExecutor, ExternalApiExecutor>();
        services.AddScoped<ITokenProvider, NoOpTokenProvider>();

        return services;
    }
}
