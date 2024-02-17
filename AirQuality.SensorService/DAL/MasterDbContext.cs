using AirQuality.Core.DAL;
using AirQuality.Core.Loggers;
using AirQuality.SensorService.Services;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.SensorService.DAL;

public class MasterDbContext : ApplicationDbContext
{
    private readonly ILogger<StationService> _log;
    public MasterDbContext(DbContextOptions options, ILogger<StationService> log) : base(options)
    {
        _log = log;

        try
        {
            Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            _log.LogError(LoggerMessages.Error(ex.Message.ToString()));
        }
    }
}
