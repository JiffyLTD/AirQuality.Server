using AirQuality.Domain.DTOs.Station;
using AirQuality.Domain.Entities;
using AirQuality.Services.Mappers;

namespace AirQuality.UnitTests.TestsStationService.Mappers
{
    [TestFixture]
    public class StationMapperTests
    {
        [Test]
        public void Test_StationCreateDtoToStation()
        {
            var stationDtoId = Guid.NewGuid();
            var locationDto = "INVALID";
            StationCreateDTO stationCreateDto = new(stationDtoId, locationDto);

            Station station = StationMapper.StationCreateDtoToStation(stationCreateDto);

            Assert.Multiple(() =>
            {
                Assert.That(station, Is.Not.Null);
                Assert.That(stationDtoId, Is.EqualTo(station.StationId));
                Assert.That(locationDto, Is.EqualTo(station.Location));
            });
        }
    }
}
