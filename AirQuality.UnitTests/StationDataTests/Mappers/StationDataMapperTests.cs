using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;

namespace AirQuality.UnitTests.TestsStationData.Mappers
{
    [TestFixture]
    public class StationDataMapperTests
    {
        [Test]
        public void Test_CreateStationDataDtoToStationData()
        {
            Random random = new();

            var stationId = Guid.NewGuid().ToString();
            var temperature = NextFloat(random);
            var humidity = random.Next(100);
            var Pm_1 = random.Next(500);
            var Pm_2_5 = random.Next(500);
            var Pm_10 = random.Next(500);
            var co = random.Next(1023);
            var pressure = random.Next(9000, 11000);
            CreateStationDataDto createStationDataDto = new(
                temperature,
                humidity,
                Pm_1,
                Pm_2_5,
                Pm_10,
                co,
                pressure
                );

            StationData stationData = StationDataMapper.CreateStationDataDtoToStationData(createStationDataDto, stationId);

            Assert.That(stationData, Is.Not.Null);
        }

        private static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));

            return (float)(mantissa * exponent);
        }
    }
}
