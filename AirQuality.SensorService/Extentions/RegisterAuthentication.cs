using AirQuality.SensorService.Authentication;

namespace AirQuality.SensorService.Extentions;

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
