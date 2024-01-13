using AirQuality.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Station> Station { get; set; }
        public DbSet<StationData> StationData { get; set; }
    }
}
