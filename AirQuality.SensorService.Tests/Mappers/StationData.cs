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
        var temperature = Helper.GetRandomFloat(Constants.TemperatureMinValue, Constants.TemperatureMaxValue);
        var humidity = Helper.GetRandomInt(Constants.HumidityMinValue, Constants.HumidityMaxValue);
        var Pm_1 = Helper.GetRandomInt(Constants.Pm1MinValue, Constants.Pm1MaxValue);
        var Pm_2_5 = Helper.GetRandomInt(Constants.Pm2_5MinValue, Constants.Pm2_5MaxValue);
        var Pm_10 = Helper.GetRandomInt(Constants.Pm10MinValue, Constants.Pm10MaxValue);
        var co = Helper.GetRandomInt(Constants.CoMinValue, Constants.CoMaxValue);
        var pressure = Helper.GetRandomInt(Constants.PressureMinValue, Constants.PressureMaxValue);
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
