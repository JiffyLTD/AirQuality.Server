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
    public const int Pm2MaxValue = 500;
    public const int Pm2MinValue = 0;
    public const int Pm10MaxValue = 500;
    public const int Pm10MinValue = 0;
    public const int CoMaxValue = 1024;
    public const int CoMinValue = 0;
    public const int PressureMinValue = 90000;
    public const int PressureMaxValue = 100000;

    public Guid Id { get; set; }

    [ForeignKey("Station")]
    public Guid StationId { get; set; }

    public float Temperature { get; set; }

    public int Humidity { get; set; }

    public int Pm1 { get; set; }

    public int Pm2 { get; set; }

    public int Pm10 { get; set; }

    public int Co { get; set; }

    public int Pressure { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
