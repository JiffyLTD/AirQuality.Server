using AirQuality.Domain.DTOs.StationData;
using AirQuality.Domain.Entities;

namespace AirQuality.Domain.Interfaces
{
    public interface IStationDataService
    {
        public Task<StationData> GetLastAsync(Guid stationId);
        public Task<List<StationData>> GetLastAsync(Guid stationId, int limit);
        public Task<List<StationData>> GetAllAsync(int page, int limit);
        public Task<StationData> CreateAsync(StationDataCreateDTO stationDataCreateDto);
    }
}
