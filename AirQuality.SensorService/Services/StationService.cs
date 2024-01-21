using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.SensorService.Services
{
    public class StationService
    {
        private readonly MasterDbContext _db;

        public StationService(MasterDbContext db)
        {
            _db = db;
        }

        public async Task<Station> TryCreateOrUpdateAsync(CreateStationDto createStationDto)
        {
            var existStation = await _db.Stations.FirstOrDefaultAsync(s => s.SensorId == Guid.Parse(createStationDto.SensorId));

            if (existStation == null)
            {
                var station = StationMapper.CreateStationDtoToStation(createStationDto);

                await _db.Stations.AddAsync(station);
                await _db.SaveChangesAsync();

                return station;
            }

            existStation.SetLocation(createStationDto.Location);
            await _db.SaveChangesAsync();

            return existStation;
        }
    }
}
