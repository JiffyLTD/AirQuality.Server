using AirQuality.SensorService.Mappers;
using AirQuality.SensorService.Tests.Fake;
using FluentAssertions;

namespace AirQuality.SensorService.Tests.Mappers;

public class StationDataDtoToStationData
{
    [Fact]
    public void StationDataDtoToStationData_Ok()
    {
        var stationId = Guid.NewGuid().ToString();
        var createStationDataDto = FakeData.GetCreateStationDataDto();

        var stationData = StationDataMapper.CreateStationDataDtoToStationData(createStationDataDto, stationId);

        stationData.Should().NotBeNull();
        stationData.StationId.Should().Be(stationId);
        stationData.Pm_1.Should().Be(createStationDataDto.Pm_1);
        stationData.Pm_2_5.Should().Be(createStationDataDto.Pm_2_5);
        stationData.Pm_10.Should().Be(createStationDataDto.Pm_10);
        stationData.Temperature.Should().Be(createStationDataDto.Temperature);
        stationData.Humidity.Should().Be(createStationDataDto.Humidity);
        stationData.Pressure.Should().Be(createStationDataDto.Pressure);
        stationData.Co.Should().Be(createStationDataDto.Co);
    }
}