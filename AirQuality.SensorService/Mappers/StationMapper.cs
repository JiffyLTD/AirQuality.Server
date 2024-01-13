using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DTO;
using AutoMapper;

namespace AirQuality.SensorService.Mappers
{
    public static class StationMapper
    {
        public static Station CreateStationDtoToStation(CreateStationDto createStationDto)
        {
            var station = new Station(createStationDto.StationId, createStationDto.Location);

            return station;
        }
    }
}
