using AirQuality.Domain.DTOs.Station;
using AirQuality.Domain.Entities;

namespace AirQuality.Domain.Interfaces
{
    public interface IStationService
    {
        public Task<int> GetCountAllStationsAsync();
        public Task<List<Station>> GetStationsAsync(int limit);
        public Task<Station> TryCreateAsync(StationCreateDTO stationCreateDto);
        public Task<Station> TryUpdateAsync(StationUpdateDTO stationUpdateDto);
    }
}
