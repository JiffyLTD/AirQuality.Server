namespace AirQuality.Domain.Entities
{
    public class Station
    {
        public Station()
        {
        }

        public Station(Guid stationId, string? location)
        {
            Id = Guid.NewGuid();
            StationId = stationId;
            Location = location;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public Guid StationId { get; private set; }

        // Представляет собой строку с данными от GPS датчика
        public string? Location { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
    }
}
