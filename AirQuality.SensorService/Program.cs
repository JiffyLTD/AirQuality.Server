using AirQuality.Core;
using AirQuality.Core.DAL;
using AirQuality.Core.Extentions;
using AirQuality.SensorService.Extentions;
using AirQuality.SensorService.Services;
using Serilog;
using Zefirrat.YandexGpt.AspNet.Di;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(Constants.LogsFilename)
    .CreateLogger()
    ;

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
        .AddScoped<YandexChatGptService>()
        .AddAuthentication(builder.Configuration)
        .AddAuthorization(options => { options.AddOnlyServicePolicy(); })
        ;
    
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        await scope.ServiceProvider
            .GetRequiredService<DbInitializer<ApplicationDbContext>>()
            .InitAsync();
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


