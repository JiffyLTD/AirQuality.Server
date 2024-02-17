using AirQuality.Core.DAL;
using AirQuality.SensorService.DAL;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.SensorService.Extentions;

public static class RegisterDb
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AirQuality.Core.Constants.DbConnectionStringSection);

        if (connectionString == null)
            throw new Exception("Invalid connection string");

        services
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                )
            .AddDbContext<MasterDbContext>(options =>
                options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                );

        return services;
    }
}
