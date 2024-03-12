using AirQuality.SensorService.DAL;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AirQuality.SensorService.Services;

public class StationService(MasterDbContext db)
{
    private readonly MasterDbContext _db = db;

    public async Task<Guid> CreateOrUpdateAsync(CreateStationDto createStationDto)
    {
        try
        {
            var sensorId = Guid.Parse(createStationDto.SensorId);
            var existStation = await _db.Stations.FirstOrDefaultAsync(s => s.SensorId == sensorId);

            if (existStation == null)
            {
                var station = StationMapper.CreateStationDtoToStation(createStationDto);

                await _db.Stations.AddAsync(station);
                await _db.SaveChangesAsync();

                Log.Information($"Station {{ SensorId = {sensorId} }} was created");

                return station.Id;
            }

            existStation.SetLocation(createStationDto.Location);
            await _db.SaveChangesAsync();
            
            Log.Information($"Station {{ SensorId = {sensorId} }} was updated");

            return existStation.Id;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);

            return Guid.Empty;
        }
    }
}
