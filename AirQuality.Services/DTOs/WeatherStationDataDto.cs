namespace AirQuality.Services.DTOs
{
    public class WeatherStationDataDto
    {
        public WeatherStationDataDto(float temperature, float humidity, float pm_1, float pm2_5, float pm_10, int co)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pm_1 = pm_1;
            Pm2_5 = pm2_5;
            Pm_10 = pm_10;
            Co = co;
        }

        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Pm_1 { get; set; }
        public float Pm2_5 { get; set; }
        public float Pm_10 { get; set; }
        public int Co { get; set; }
    }
}
