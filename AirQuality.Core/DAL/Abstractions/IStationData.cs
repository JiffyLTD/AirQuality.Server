namespace AirQuality.Core.DAL.Abstractions;

public interface IStationData
{
    /// <summary>
    /// Уникальный идентификатор записи
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Уникальный идентификатор станции от которой получаем данные
    /// </summary>
    public Guid StationId { get; }

    /// <summary>
    /// Температура окружающего воздуха
    /// </summary>
    public float Temperature { get; }

    /// <summary>
    /// Влажность окружающего воздуха
    /// </summary>
    public int Humidity { get; }

    /// <summary>
    /// Количество частиц в воздухе размером до 1мкм
    /// </summary>
    public int Pm_1 { get; }

    /// <summary>
    /// Количество частиц в воздухе размером до 2.5мкм
    /// </summary>
    public int Pm_2_5 { get; }

    /// <summary>
    /// Количество частиц в воздухе размером от 10мкм
    /// </summary>
    public int Pm_10 { get; }

    /// <summary>
    /// Количество угарного газа в воздухе ppm
    /// </summary>
    public int Co { get; }

    /// <summary>
    /// Давление воздуха в ПА
    /// </summary>
    public int Pressure { get; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Дата обновления записи
    /// </summary>
    public DateTime UpdatedAt { get; }
}
