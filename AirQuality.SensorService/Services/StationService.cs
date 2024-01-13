using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;

namespace AirQuality.SensorService.Services
{
    public class StationService
    {
        private readonly ApplicationDbContext _db;

        public StationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Station> TryCreateAsync(CreateStationDto createStationDto)
        {
            var station = StationMapper.CreateStationDtoToStation(createStationDto);

            await _db.Stations.AddAsync(station);
            await _db.SaveChangesAsync();

            return station;
        }
    }
}
