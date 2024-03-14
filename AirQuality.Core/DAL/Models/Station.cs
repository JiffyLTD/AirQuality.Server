using AirQuality.Core.DAL.Abstractions;

namespace AirQuality.Core.DAL.Models;

public class Station : IStation
{
    public Guid Id { get; init; }
    
    public Guid SensorId { get; init; }
    
    public string Location { get;  set; } = null!;
    
    public DateTime CreatedAt { get; init; } 
    
    public DateTime UpdatedAt { get;  set; }
}
