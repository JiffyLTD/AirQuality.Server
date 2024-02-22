using AirQuality.Core;
using AirQuality.Core.Loggers;
using AirQuality.SensorService.Extentions;
using AirQuality.SensorService.Helpers;
using AirQuality.SensorService.Loggers;
using AirQuality.SensorService.Services;
using Zefirrat.YandexGpt.AspNet.Di;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), Constants.LogsFilename));

builder.Services
    .AddMvc().Services
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
    ;

var app = builder.Build();

try
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection()
        .UseAuthentication()
        .UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogError(LoggerMessages.Error(ex.Message.ToString()));
}


