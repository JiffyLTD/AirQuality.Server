namespace AirQuality.Domain.Entities
{
    public class WeatherStationData
    {
        public WeatherStationData(float temperature, float humidity)
        {
            ID = new Guid();
            Temperature = temperature;
            Humidity = humidity;
        }

        public Guid ID { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
