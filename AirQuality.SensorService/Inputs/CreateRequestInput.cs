namespace AirQuality.SensorService.Inputs;

public interface ICreateRequestInput
{
    public static CreateStationInput CreateStationInput => null!;
    public static CreateStationDataInput CreateStationDataInput => null!;
}

public class CreateRequestInput : ICreateRequestInput
{
    public CreateStationInput CreateStationInput { get; set; } = null!;
    public CreateStationDataInput CreateStationDataInput { get; set; } = null!;
}
