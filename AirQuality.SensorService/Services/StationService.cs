using AirQuality.Core;
using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.Helpers;
using AirQuality.SensorService.Inputs;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AirQuality.SensorService.Services;

public class StationService(ApplicationDbContext db)
{
    public async Task<Guid> CreateOrUpdateAsync(CreateStationInput createStationInput)
    {
        try
        {
            var sensorId = Guid.Parse(createStationInput.SensorId);
            var existStation = await db.Stations.FirstOrDefaultAsync(s => s.SensorId == sensorId);

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

                await db.Stations.AddAsync(station);
                await db.SaveChangesAsync();

                Log.Information($"Station {{ SensorId = {sensorId} }} was created");

                return station.Id;
            }

            var newLocation = Helper.GetLongitudeAndLatitudeStringFromLocation(createStationInput.Location);
            if (newLocation != Constants.NotValidLocation)
            {
                existStation.Location = newLocation;
                await db.SaveChangesAsync();
            
                Log.Information($"Station {{ SensorId = {sensorId} }} was updated");   
            }

            return existStation.Id;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);

            throw new Exception(ex.Message);
        }
    }
}
