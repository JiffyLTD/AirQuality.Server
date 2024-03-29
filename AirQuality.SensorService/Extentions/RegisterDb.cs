using AirQuality.Core.DAL;
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
            .AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                )
            .AddScoped<DbInitializer<ApplicationDbContext>>()
                ;

        return services;
    }
}
