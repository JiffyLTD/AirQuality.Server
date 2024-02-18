using AirQuality.Core.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.Core.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Station> Stations { get; set; }
    public DbSet<StationData> StationsData { get; set; }
    public DbSet<InfoByLocation> InfosByLocation { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
