using AirQuality.DAL.DataContext;
using AirQuality.DAL.Interfaces;
using AirQuality.DAL.Repositories;
using AirQuality.Services.Interfaces;
using AirQuality.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// DI
builder.Services.AddScoped<IWsdRepository, WsdRepository>();
builder.Services.AddScoped<IWsdService, WsdService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

app.UseAuthorization();

app.MapControllers();

app.Run();
