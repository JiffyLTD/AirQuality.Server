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

        public Task<DBResponse> AddAsync(WeatherStationDataDto wsdDto)
        {
            WeatherStationData wsd = WsdDtoToWsd.Map(wsdDto);

            return _db.TryAddAsync(wsd);
        }
        
        public Task<DBResponse> GetAllAsync()
        {
            return _db.TryGetAllAsync();
        }
    }
}
