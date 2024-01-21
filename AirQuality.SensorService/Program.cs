using AirQuality.Core.DAL;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.Extentions.ServiceCollections;
using AirQuality.SensorService.Middlewares;
using AirQuality.SensorService.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PostgreDb");

if (connectionString == null)
    throw new Exception("Invalid connection string");

builder.Services
    .AddMvc().Services
    .AddControllers().Services
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddDbContext<ApplicationDbContext>(options => 
        options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        )
    .AddDbContext<MasterDbContext>(options =>
        options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        )
    .AddScoped<StationDataService>()
    .AddScoped<StationService>()
    ;

try
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<TokenMiddleware>()
        .UseHttpsRedirection()
        ;

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Trace.WriteLine("ERROR|| " + ex.ToString());
}


