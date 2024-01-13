namespace AirQuality.SensorService.DTO
{
    public class CreateRequest
    {
        public CreateStationDto CreateStationDto { get; set; } = null!;
        public CreateStationDataDto CreateStationDataDto { get; set; } = null!;
    }
}
