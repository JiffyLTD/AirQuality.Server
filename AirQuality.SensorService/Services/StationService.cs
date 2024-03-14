using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.Helpers;
using AirQuality.SensorService.Inputs;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AirQuality.SensorService.Services;

public class StationService(MasterDbContext db)
{
    private readonly MasterDbContext _db = db;

    public async Task<Guid> CreateOrUpdateAsync(CreateStationInput createStationInput)
    {
        try
        {
            var sensorId = Guid.Parse(createStationInput.SensorId);
            var existStation = await _db.Stations.FirstOrDefaultAsync(s => s.SensorId == sensorId);

            if (existStation == null)
            {
                var station = new Station()
                {
                    Id = Guid.NewGuid(),
                    SensorId = Guid.Parse(createStationInput.SensorId),
                    Location = Helper.GetLongitudeAndLatitudeStringFromLocation(createStationInput.Location),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                await _db.Stations.AddAsync(station);
                await _db.SaveChangesAsync();

                Log.Information($"Station {{ SensorId = {sensorId} }} was created");

                return station.Id;
            }

            var newLocation = Helper.GetLongitudeAndLatitudeStringFromLocation(createStationInput.Location);
            if (newLocation != "Invalid")
            {
                existStation.Location = newLocation;
                await _db.SaveChangesAsync();
            
                Log.Information($"Station {{ SensorId = {sensorId} }} was updated");   
            }

            return existStation.Id;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);

            return Guid.Empty;
        }
    }
}
