using AirQuality.Core.DAL;
using AirQuality.Core.Extentions;
using AirQuality.WebService;
using AirQuality.WebService.Extentions;
using HotChocolate.AspNetCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(AirQuality.Core.Constants.LogsFilename)
    .CreateLogger()
    ;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

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
    
    using (var scope = app.Services.CreateScope())
    {
        await scope.ServiceProvider
            .GetRequiredService<DbInitializer<ApplicationDbContext>>()
            .InitAsync();
    }
    
    app.UseHttpsRedirection()
        .UseAuthentication()
        .UseAuthorization()
        .UseRouting()
        .UseCors(
            options => 
                options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                )
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
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


