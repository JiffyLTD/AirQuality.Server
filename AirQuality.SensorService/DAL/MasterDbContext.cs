using AirQuality.Core.DAL;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.SensorService.DAL;

public class MasterDbContext : ApplicationDbContext
{
    public MasterDbContext(DbContextOptions options) : base(options)
    {
    }
}
