namespace AirQuality.Services.DTOs
{
    public class WeatherStationDataDto
    {
        public WeatherStationDataDto(float temperature, float humidity)
        {
            Temperature = temperature;
            Humidity = humidity;
        }

        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
