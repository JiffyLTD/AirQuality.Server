using AirQuality.Core;
using AirQuality.Core.Loggers;
using AirQuality.SensorService.Extentions;
using AirQuality.SensorService.Loggers;
using AirQuality.SensorService.Middlewares;
using AirQuality.SensorService.Services;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), Constants.LogsFilename));

builder.Services
    .AddMvc().Services
    .AddControllers().Services
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddDbContext(builder.Configuration)
    .AddScoped<StationDataService>()
    .AddScoped<StationService>()
    ;

var app = builder.Build();

try
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
  
    app.UseWhen(context => 
        context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase), 
        appBuilder =>
        {
            appBuilder.UseMiddleware<TokenMiddleware>();
        });

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogError(LoggerMessages.Error(ex.Message.ToString()));
}


