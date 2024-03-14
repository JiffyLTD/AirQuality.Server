using AirQuality.Core;
using AirQuality.Core.Extentions;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.Extentions;
using AirQuality.SensorService.Helpers;
using AirQuality.SensorService.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Zefirrat.YandexGpt.AspNet.Di;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(Constants.LogsFilename)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services
        .AddControllers().Services
        .AddEndpointsApiExplorer()
        .AddSwagger()
        .AddDbContext(builder.Configuration)
        .AddYandexGpt(builder.Configuration)
        .AddScoped<StationDataService>()
        .AddScoped<StationService>()
        .AddScoped<InfoByLocationService>()
        .AddScoped<YandexChatGpt>()
        .AddAuthentication(builder.Configuration)
        .AddAuthorization(options => { options.AddOnlyServicePolicy(); })
        ;
    
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<MasterDbContext>();

        try
        {
            context.Database.Migrate();
            
            Log.Information("Миграции успешно применены");
        }
        catch (Exception ex)
        {
            Log.Information("Ошибка при выполнении миграций - " + ex.Message);
        }
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection()
        .UseAuthentication()
        .UseAuthorization()
        ;

    app.UseSerilogRequestLogging();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


