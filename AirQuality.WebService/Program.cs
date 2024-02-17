using AirQuality.WebService;
using AirQuality.WebService.Extentions;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext(builder.Configuration)
    .AddGraphQL()
    ;

try
{
    var app = builder.Build();

    app.UseHttpsRedirection();
    app.UseRouting();

    app.MapGraphQL(Constants.GraphQLEndpoint);

    app.Run();
}
catch (Exception ex)
{
    Trace.WriteLine("ERROR|| " + ex.ToString());
}


