using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.Inputs;
using Serilog;

namespace AirQuality.SensorService.Services;

public class StationDataService(MasterDbContext db)
{
    private readonly MasterDbContext _db = db;

    public async Task<bool> CreateAsync(CreateStationDataInput createStationDataInput, string stationId)
    {
        try
        {
           var stationData = new StationData()
           {
               Id = Guid.NewGuid(),
               StationId = Guid.Parse(stationId),
               Temperature = createStationDataInput.Temperature,
               Humidity = createStationDataInput.Humidity,
               Pm1 = createStationDataInput.Pm1,
               Pm2 = createStationDataInput.Pm2,
               Pm10 = createStationDataInput.Pm10,
               Co = createStationDataInput.Co,
               Pressure = createStationDataInput.Pressure,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
           };

            await _db.StationsData.AddAsync(stationData);
            await _db.SaveChangesAsync();

            Log.Information($"StationData {{ StationId = {stationData.StationId} }} was created");

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);

            return false;
        }
    }
}
