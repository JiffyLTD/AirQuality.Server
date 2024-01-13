namespace AirQuality.SensorService.DTO
{
    public class CreateStationDto
    {
        public CreateStationDto(string stationId, string location)
        {
            StationId = stationId;
            Location = location;
        }

        public string StationId { get; private set; } = null!;
        public string Location { get; private set; } = null!;
    }
}
