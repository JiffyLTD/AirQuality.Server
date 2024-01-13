namespace AirQuality.Domain.DTOs.Station
{
    public class StationCreateDTO
    {
        public StationCreateDTO(Guid stationId, string? location)
        {
            StationId = stationId;
            Location = location;
        }

        public Guid StationId { get; private set; }

        // Представляет собой строку с данными от GPS датчика
        public string? Location { get; private set; }
    }
}
