using AirQuality.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherStationData> WeatherStationData { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
