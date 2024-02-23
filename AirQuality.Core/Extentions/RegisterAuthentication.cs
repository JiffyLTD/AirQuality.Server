using AirQuality.Core.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirQuality.Core.Extentions;

public static class RegisterAuthentication
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(TokenOptions.DefaultScheme)
            .AddToken()
            ;

        return services;
    }
}
