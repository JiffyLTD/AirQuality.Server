using AirQuality.DAL.DTOs;
using AirQuality.DAL.Interfaces;
using AirQuality.Domain.Entities;
using AirQuality.Services.DTOs;
using AirQuality.Services.Interfaces;
using AirQuality.Services.Mappers;

namespace AirQuality.Services.Services
{
    public class WsdService: IWsdService
    {
        private readonly IWsdRepository _db;

        public WsdService(IWsdRepository db)
        {
            _db = db;
        }

        public async Task<DBResponse> AddAsync(WeatherStationDataDto wsdDto)
        {
            WeatherStationData wsd = WsdDtoToWsd.Map(wsdDto);

            return await _db.TryAddAsync(wsd);
        }
        
        public async Task<DBResponse> GetAllAsync()
        {
            return await _db.TryGetAllAsync();
        }

        public async Task<DBResponse> GetLastAsync()
        {
            return await _db.TryGetLastAsync();
        }
    }
}
