using AirQuality.SensorService.DAL;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;
using Serilog;

namespace AirQuality.SensorService.Services;

public class StationDataService(MasterDbContext db)
{
    private readonly MasterDbContext _db = db;

    public async Task<bool> CreateAsync(CreateStationDataDto createStationDataDto, string stationId)
    {
        try
        {
            var stationData = StationDataMapper.CreateStationDataDtoToStationData(createStationDataDto, stationId);

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
