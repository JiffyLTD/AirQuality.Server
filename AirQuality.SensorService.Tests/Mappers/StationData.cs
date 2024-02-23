using AirQuality.Core;
using AirQuality.Core.DAL.Models;
using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Mappers;
using AirQuality.SensorService.Tests.Helpers;
using NUnit.Framework;

namespace AirQuality.SensorService.Tests.Mappers;

[TestFixture]
internal partial class MappersTests
{
    [Test]
    public void StationDataDtoToStationData()
    {
        var stationId = Guid.NewGuid().ToString();
        var temperature = Helper.GetRandomFloat(StationData.TemperatureMinValue, StationData.TemperatureMaxValue);
        var humidity = Helper.GetRandomInt(StationData.HumidityMinValue, StationData.HumidityMaxValue);
        var Pm_1 = Helper.GetRandomInt(StationData.Pm1MinValue, StationData.Pm1MaxValue);
        var Pm_2_5 = Helper.GetRandomInt(StationData.Pm2_5MinValue, StationData.Pm2_5MaxValue);
        var Pm_10 = Helper.GetRandomInt(StationData.Pm10MinValue, StationData.Pm10MaxValue);
        var co = Helper.GetRandomInt(StationData.CoMinValue, StationData.CoMaxValue);
        var pressure = Helper.GetRandomInt(StationData.PressureMinValue, StationData.PressureMaxValue);
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
}
