using AirQuality.Core.DAL;
using AirQuality.SensorService.Extentions.ServiceCollections;
using AirQuality.SensorService.Middlewares;
using AirQuality.SensorService.Services;
using Microsoft.EntityFrameworkCore;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PostgreDb");

if(connectionString == null)
    throw new Exception("Invalid connection string");

builder.Services
    .AddMvc().Services
    .AddControllers().Services
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString))
    .AddScoped<StationDataService>()
    .AddScoped<StationService>()
    ;
    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TokenMiddleware>()
    .UseHttpsRedirection()
    ;

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

