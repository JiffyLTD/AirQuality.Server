using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;

namespace AirQuality.SensorService.Services
{
    public class StationDataService
    {
        private readonly MasterDbContext _db;

        public StationDataService(MasterDbContext db)
        {
            _db = db;
        }

        public async Task<StationData> TryCreateAsync(CreateStationDataDto createStationDataDto, string stationId)
        {
            var stationData = StationDataMapper.CreateStationDataDtoToStationData(createStationDataDto, stationId);

            await _db.StationsData.AddAsync(stationData);
            await _db.SaveChangesAsync();

            return stationData;
        }
    }
}
