using AirQuality.Core.Extentions;
using AirQuality.WebService;
using AirQuality.WebService.Extentions;
using AirQuality.Core.Loggers;
using AirQuality.WebService.Loggers;
using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFile(System.IO.Path.Combine(Directory.GetCurrentDirectory(), AirQuality.Core.Constants.LogsFilename));

builder.Services
    .AddDbContext(builder.Configuration)
    .AddAuthentication(builder.Configuration)
    .AddAuthorization(options =>
    {
        options.AddOnlyServicePolicy();
    })
    .AddGraphQl()
    .AddCors()
    ;

var app = builder.Build();

try
{
    app.UseHttpsRedirection()
        .UseAuthentication()
        .UseAuthorization()
        .UseRouting()
        .UseCors(options => options.AllowAnyOrigin().AllowAnyHeader())
        ;
    
    app.MapGraphQL(Constants.GraphQlEndpoint)
        .WithOptions(new GraphQLServerOptions()
        {
            Tool =
            {
                Enable = false
            }
        });

    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogError(LoggerMessages.Error(ex.Message.ToString()));
}


