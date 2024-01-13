using AirQuality.Domain.DTOs.Station;
using AirQuality.Domain.Entities;
using AutoMapper;

namespace AirQuality.Services.Mappers
{
    public static class StationMapper
    {
        public static Station StationCreateDtoToStation(StationCreateDTO stationCreateDto)
        {
            var config = new MapperConfiguration(config => config.CreateMap<StationCreateDTO, Station>());

            var mapper = new Mapper(config);

            var station = mapper.Map<Station>(stationCreateDto);

            return station;
        }
    }
}
