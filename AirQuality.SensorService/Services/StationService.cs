using AirQuality.Core.Loggers;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.SensorService.Services;

public class StationService
{
    private readonly MasterDbContext _db;
    private readonly ILogger<StationService> _log;

    public StationService(MasterDbContext db, ILogger<StationService> log)
    {
        _db = db;
        _log = log;
    }

    public async Task<Guid> CreateOrUpdateAsync(CreateStationDto createStationDto)
    {
        try
        {
            var existStation = await _db.Stations.FirstOrDefaultAsync(s => s.SensorId == Guid.Parse(createStationDto.SensorId));

            if (existStation == null)
            {
                var station = StationMapper.CreateStationDtoToStation(createStationDto);

                await _db.Stations.AddAsync(station);
                await _db.SaveChangesAsync();

                _log.LogInformation(LoggerMessages.Info($"Station {{ SensorId = {station.SensorId} }} was created"));

                return station.Id;
            }

            existStation.SetLocation(createStationDto.Location);
            await _db.SaveChangesAsync();

            _log.LogInformation(LoggerMessages.Info($"Station {{ SensorId = {existStation.SensorId} }} was updated"));

            return existStation.Id;
        }
        catch (Exception ex)
        {
            _log.LogError(LoggerMessages.Error(ex.Message.ToString()));

            return Guid.Empty;
        }
    }
}
