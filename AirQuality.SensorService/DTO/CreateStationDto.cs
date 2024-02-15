namespace AirQuality.SensorService.DTO;

public class CreateStationDto
{
    public CreateStationDto(string sensorId, string location)
    {
        SensorId = sensorId;
        Location = location;
    }

    public string SensorId { get; private set; } = null!;
    public string Location { get; private set; } = null!;
}
