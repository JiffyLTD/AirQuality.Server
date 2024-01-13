namespace AirQuality.Domain.Entities
{
    public class StationData
    {
        public StationData()
        {
        }

        public StationData(float temperature, Guid stationId, Station station, float humidity, int pm_1, int pm_2_5, int pm_10, int co, int pressure)
        {
            Id = Guid.NewGuid();
            StationId = stationId;
            Station = station;
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
        public Guid StationId { get; private set; }
        public Station Station { get; private set; } = null!;
        public float Temperature { get; private set; }
        public float Humidity { get; private set; }
        public int Pm_1 { get; private set; }
        public int Pm_2_5 { get; private set; }
        public int Pm_10 { get; private set; }
        public int Co { get; private set; }
        public int Pressure { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
