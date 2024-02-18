using AirQuality.Core.DAL.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirQuality.Core.DAL.Models;

public class InfoByLocation : IInfoByLocation
{
    public InfoByLocation()
    {
    }

    public InfoByLocation(string stationId, string locationName, float avgTemperature,
        int avgHumidity, int avgPm_1, int avgPm_2_5, int avgPm_10, int avgCo, int avgPressure, string aiAdvices)
    {
        Id = Guid.NewGuid();
        StationId = Guid.Parse(stationId);
        LocationName = locationName;
        AvgTemperature = avgTemperature;
        AvgHumidity = avgHumidity;
        AvgPm_1 = avgPm_1;
        AvgPm_2_5 = avgPm_2_5;
        AvgPm_10 = avgPm_10;
        AvgCo = avgCo;
        AvgPressure = avgPressure;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        AiAdvices = aiAdvices;
    }

    public Guid Id { get; private set; }

    [ForeignKey("Station")]
    public Guid StationId { get; private set; }

    public string LocationName { get; private set; }
    public string AiAdvices { get; private set; }

    public float AvgTemperature { get; private set; }

    public int AvgHumidity { get; private set; }

    public int AvgPm_1 { get; private set; }

    public int AvgPm_2_5 { get; private set; }

    public int AvgPm_10 { get; private set; }

    public int AvgCo { get; private set; }

    public int AvgPressure { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    /// <summary>
    /// Обновить данные по средним показателям по местоположению
    /// </summary>
    public void UpdateInfo(string locationName, float avgTemperature, int avgHumidity,
        int avgPm_1, int avgPm_2_5, int avgPm_10, int avgCo, int avgPressure, string aiAdvices)
    {
        AiAdvices = aiAdvices;
        LocationName = locationName;
        AvgTemperature = avgTemperature;
        AvgHumidity = avgHumidity;
        AvgPm_1 = avgPm_1;
        AvgPm_2_5 = avgPm_2_5;
        AvgPm_10 = avgPm_10;
        AvgCo = avgCo;
        AvgPressure = avgPressure;
        UpdatedAt = DateTime.Now;
    }
}
