using AirQuality.WebService.Middlewares;
using AirQuality.WebService;
using AirQuality.WebService.Extentions;
using AirQuality.Core.Loggers;
using AirQuality.WebService.Loggers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFile(System.IO.Path.Combine(Directory.GetCurrentDirectory(), AirQuality.Core.Constants.LogsFilename));

builder.Services
    .AddDbContext(builder.Configuration)
    .AddGraphQL()
    ;

var app = builder.Build();

try
{
    app.UseHttpsRedirection();
    app.UseRouting();

    app.MapGraphQL(Constants.GraphQlEndpoint);

    app.UseWhen(context =>
        context.Request.Path.StartsWithSegments("/webservice", StringComparison.OrdinalIgnoreCase),
        appBuilder =>
        {
            appBuilder.UseMiddleware<TokenMiddleware>();
        });

    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogError(LoggerMessages.Error(ex.Message.ToString()));
}


