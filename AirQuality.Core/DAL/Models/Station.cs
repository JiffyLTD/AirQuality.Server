using AirQuality.Core.DAL.Abstractions;

namespace AirQuality.Core.DAL.Models;

public class Station : IStation
{
    public Station()
    {
    }

    public Station(string sensorId, string location)
    {
        Id = Guid.NewGuid();
        SensorId = Guid.Parse(sensorId);
        Location = location;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }

    public Guid SensorId { get; private set; }

    public string Location { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    /// <summary>
    /// Обновить данные по местоположению и время обновления записи
    /// </summary>
    public void SetLocation(string location)
    {
        Location = location;
        UpdatedAt = DateTime.Now;
    }
}
