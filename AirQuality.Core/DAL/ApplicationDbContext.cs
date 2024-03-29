using AirQuality.Core.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.Core.DAL;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Station> Stations { get; set; }
    public DbSet<StationData> StationsData { get; set; }
    public DbSet<InfoByLocation> InfosByLocation { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Station>(builder =>
        {
            builder.HasKey(x => x.Id);
        });
        
        modelBuilder.Entity<StationData>(builder =>
        {
            builder.HasKey(x => x.Id);
        });
        
        modelBuilder.Entity<InfoByLocation>(builder =>
        {
            builder.HasKey(x => x.Id);
        });
    }
}
