using AirQuality.Domain.Entities;
using AirQuality.Services.DTOs;
using AutoMapper;

namespace AirQuality.Services.Mappers
{
    internal class WsdDtoToWsd
    {
        public static WeatherStationData Map(WeatherStationDataDto wsdDto)
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WeatherStationDataDto, WeatherStationData>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var wsd = mapper.Map<WeatherStationData>(wsdDto);

            return wsd;
        }
    }
}
