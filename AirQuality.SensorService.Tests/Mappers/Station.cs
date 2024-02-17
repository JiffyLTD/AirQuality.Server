using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;
using NUnit.Framework;

namespace AirQuality.SensorService.Tests.Mappers;

[TestFixture]
internal partial class MappersTests
{
    [Test]
    public void StationDtoToStation()
    {
        var stationDtoId = Guid.NewGuid().ToString();
        var locationDto = "INVALID";
        CreateStationDto createStationDto = new(stationDtoId, locationDto);

        Station station = StationMapper.CreateStationDtoToStation(createStationDto);

        Assert.Multiple(() =>
        {
            Assert.That(station, Is.Not.Null);
            Assert.That(stationDtoId, Is.EqualTo(station.SensorId.ToString()));
            Assert.That(locationDto, Is.EqualTo(station.Location));
        });
    }
}
