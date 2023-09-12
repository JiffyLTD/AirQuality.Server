using AirQuality.DAL.DTOs;
using AirQuality.Services.DTOs;

namespace AirQuality.Services.Interfaces
{
    public interface IWsdService
    {
        public Task<DBResponse> GetAllAsync();
        public Task<DBResponse> AddAsync(WeatherStationDataDto wsdDto);
    }
}
