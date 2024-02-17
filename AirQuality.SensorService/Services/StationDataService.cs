using AirQuality.Core.Loggers;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;

namespace AirQuality.SensorService.Services;

public class StationDataService
{
    private readonly MasterDbContext _db;
    private readonly ILogger<StationService> _log;

    public StationDataService(MasterDbContext db, ILogger<StationService> log)
    {
        _db = db;
        _log = log;
    }

    public async Task<bool> CreateAsync(CreateStationDataDto createStationDataDto, string stationId)
    {
        try
        {
            var stationData = StationDataMapper.CreateStationDataDtoToStationData(createStationDataDto, stationId);

            await _db.StationsData.AddAsync(stationData);
            await _db.SaveChangesAsync();

            _log.LogInformation(LoggerMessages.Info($"StationData {{ StationId = {stationData.StationId} }} was created"));

            return true;
        }
        catch (Exception ex)
        {
            _log.LogError(LoggerMessages.Error(ex.Message.ToString()));

            return false;
        }
    }
}
