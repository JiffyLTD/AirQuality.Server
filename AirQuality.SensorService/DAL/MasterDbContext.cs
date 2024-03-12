using AirQuality.Core.DAL;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AirQuality.SensorService.DAL;

public sealed class MasterDbContext : ApplicationDbContext
{
    public MasterDbContext(DbContextOptions options) : base(options)
    {
        try
        {
            Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }
}
