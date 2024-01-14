using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;

namespace AirQuality.UnitTests.TestsStationService.Mappers
{
    [TestFixture]
    public class StationMapperTests
    {
        [Test]
        public void Test_CreateStationDtoToStation()
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
}
