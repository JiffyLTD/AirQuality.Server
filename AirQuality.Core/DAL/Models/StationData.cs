using AirQuality.Core.DAL.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirQuality.Core.DAL.Models;

public class StationData : IStationData
{
    public const int TemperatureMaxValue = 100;
    public const int TemperatureMinValue = -273;
    public const int HumidityMaxValue = 100;
    public const int HumidityMinValue = 0;
    public const int Pm1MaxValue = 500;
    public const int Pm1MinValue = 0;
    public const int Pm2_5MaxValue = 500;
    public const int Pm2_5MinValue = 0;
    public const int Pm10MaxValue = 500;
    public const int Pm10MinValue = 0;
    public const int CoMaxValue = 1024;
    public const int CoMinValue = 0;
    public const int PressureMaxValue = 90000;
    public const int PressureMinValue = 100000;
    public StationData()
    {
    }

    public StationData(string stationId, float temperature, int humidity, int pm_1, int pm_2_5, int pm_10, int co, int pressure)
    {
        Id = Guid.NewGuid();
        StationId = Guid.Parse(stationId);
        Temperature = temperature;
        Humidity = humidity;
        Pm_1 = pm_1;
        Pm_2_5 = pm_2_5;
        Pm_10 = pm_10;
        Co = co;
        Pressure = pressure;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }

    [ForeignKey("Station")]
    public Guid StationId { get; private set; }

    public float Temperature { get; private set; }

    public int Humidity { get; private set; }

    public int Pm_1 { get; private set; }

    public int Pm_2_5 { get; private set; }

    public int Pm_10 { get; private set; }

    public int Co { get; private set; }

    public int Pressure { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}
