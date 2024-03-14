namespace AirQuality.Core.DAL.Abstractions;

internal interface IInfoByLocation
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
    /// Название локации
    /// </summary>
    public string LocationName { get; }

    /// <summary>
    /// Советы от ИИ по имеющимся данным о погоде
    /// </summary>
    public string AiAdvices { get; }

    /// <summary>
    /// Средняя температура окружающего воздуха
    /// </summary>
    public float AvgTemperature { get; }

    /// <summary>
    /// Средняя влажность окружающего воздуха
    /// </summary>
    public int AvgHumidity { get; }

    /// <summary>
    /// Среднее количество частиц в воздухе размером до 1мкм
    /// </summary>
    public int AvgPm1 { get; }

    /// <summary>
    /// Среднее количество частиц в воздухе размером до 2.5мкм
    /// </summary>
    public int AvgPm2 { get; }

    /// <summary>
    /// Среднее количество частиц в воздухе размером от 10мкм
    /// </summary>
    public int AvgPm10 { get; }

    /// <summary>
    /// Среднее количество угарного газа в воздухе ppm
    /// </summary>
    public int AvgCo { get; }

    /// <summary>
    /// Среднее давление воздуха в ПА
    /// </summary>
    public int AvgPressure { get; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Дата обновления записи
    /// </summary>
    public DateTime UpdatedAt { get; }
}
