using AirQuality.Core.DAL.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirQuality.Core.DAL.Models;

public class InfoByLocation : IInfoByLocation
{
    public Guid Id { get; set; }

    [ForeignKey("Station")]
    public Guid StationId { get; set; }

    public string LocationName { get; set; }
    
    public string AiAdvices { get; set; }

    public float AvgTemperature { get; set; }

    public int AvgHumidity { get; set; }

    public int AvgPm1 { get; set; }

    public int AvgPm2 { get; set; }

    public int AvgPm10 { get; set; }

    public int AvgCo { get; set; }

    public int AvgPressure { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
