using AirQuality.SensorService.DTO;

namespace AirQuality.SensorService.Inputs;

public class CreateRequestInput
{
    public CreateStationDto CreateStationDto { get; set; } = null!;
    public CreateStationDataDto CreateStationDataDto { get; set; } = null!;
}
