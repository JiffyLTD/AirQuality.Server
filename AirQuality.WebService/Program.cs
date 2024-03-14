using AirQuality.Core.Extentions;
using AirQuality.WebService;
using AirQuality.WebService.DAL;
using AirQuality.WebService.Extentions;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(AirQuality.Core.Constants.LogsFilename)
    .CreateLogger();

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
    
    app.UseHttpsRedirection()
        .UseAuthentication()
        .UseAuthorization()
        .UseRouting()
        .UseCors(
            options => 
                options.AllowAnyOrigin()
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


