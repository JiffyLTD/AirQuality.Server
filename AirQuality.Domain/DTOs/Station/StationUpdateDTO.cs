namespace AirQuality.Domain.DTOs.Station
{
    public class StationUpdateDTO
    {
        public StationUpdateDTO(Guid stationId, string? location)
        {
            Location = location;
            StationId = stationId;
        }

        public Guid StationId { get; private set; }

        // Представляет собой строку с данными от GPS датчика
        public string? Location { get; private set; }
    }
}
