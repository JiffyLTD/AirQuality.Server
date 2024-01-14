using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DTO;

namespace AirQuality.SensorService.Mappers
{
    public static class StationDataMapper
    {
        public static StationData CreateStationDataDtoToStationData(CreateStationDataDto createStationDataDto, string stationId)
        {
            var stationData = new StationData(
                stationId,
                createStationDataDto.Temperature,
                createStationDataDto.Humidity,
                createStationDataDto.Pm_1,
                createStationDataDto.Pm_2_5,
                createStationDataDto.Pm_10,
                createStationDataDto.Co,
                createStationDataDto.Pressure
                );

            return stationData;
        }
    }
}
