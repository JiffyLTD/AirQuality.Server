using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.Inputs;
using Serilog;

namespace AirQuality.SensorService.Services;

public class StationDataService(ApplicationDbContext db)
{
    public async Task CreateAsync(CreateStationDataInput createStationDataInput, string stationId)
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

            await db.StationsData.AddAsync(stationData);
            await db.SaveChangesAsync();

            Log.Information($"StationData {{ StationId = {stationData.StationId} }} was created");
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);

            throw new Exception(ex.Message);
        }
    }
}
