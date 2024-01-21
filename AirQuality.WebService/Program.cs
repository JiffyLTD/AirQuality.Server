using AirQuality.Core.DAL;
using AirQuality.WebService.DAL;
using AirQuality.WebService.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PostgreDb");

if (connectionString == null)
    throw new Exception("Invalid connection string");

builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        )
    .AddDbContext<MasterDbContext>(options =>
        options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention()
        )
    .AddGraphQLServer()
    .AddQueryType<Query>()
    ;

try
{
    var app = builder.Build();

    app.UseHttpsRedirection();
    app.UseRouting();

    app.MapGraphQL("/webservice/graphql");

    app.Run();
}
catch (Exception ex)
{ 
    Trace.WriteLine("ERROR|| " + ex.ToString());
}


