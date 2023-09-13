using AirQuality.DAL.DTOs;
using AirQuality.Domain.Entities;

namespace AirQuality.DAL.Interfaces
{
    public interface IWsdRepository
    {
        public Task<DBResponse> TryGetAllAsync();
        public Task<DBResponse> TryAddAsync(WeatherStationData data);
        public Task<DBResponse> TryGetLastAsync();
    }
}
