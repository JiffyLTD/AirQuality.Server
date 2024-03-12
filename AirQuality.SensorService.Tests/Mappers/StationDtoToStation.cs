using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;
using FluentAssertions;

namespace AirQuality.SensorService.Tests.Mappers;

public class StationDtoToStation
{
    [Fact]
    public void StationDtoToStation_Ok()
    {
        var sensorDtoId = Guid.NewGuid().ToString();
        var locationDto = "Invalid";
        var createStationDto = new CreateStationDto(sensorDtoId, locationDto);

        var station = StationMapper.CreateStationDtoToStation(createStationDto);

        station.Should().NotBeNull();
        station.SensorId.Should().Be(sensorDtoId);
        station.Location.Should().Be(locationDto);
    }
}