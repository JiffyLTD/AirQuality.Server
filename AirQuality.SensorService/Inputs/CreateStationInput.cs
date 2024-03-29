namespace AirQuality.SensorService.Inputs;

public interface ICreateStationInput
{
    public string SensorId { get; }
    public string Location { get; }
}

public class CreateStationInput : ICreateStationInput
{
    public string SensorId { get; set; } = null!;
    public string Location { get; set; } = null!;
}
