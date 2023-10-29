namespace AirQuality.Domain.Entities
{
    public class WeatherStationData
    {
        public WeatherStationData(float temperature, float humidity, float pm_1, float pm2_5, float pm_10, int co)
        {
            ID = new Guid();
            Temperature = temperature;
            Humidity = humidity;
            CreationDate = DateTime.Now;
            Pm_1 = pm_1;
            Pm2_5 = pm2_5;
            Pm_10 = pm_10;
            Co = co;
        }

        public Guid ID { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Pm_1 { get; set; }
        public float Pm2_5 { get; set; }
        public float Pm_10 { get; set; }
        public int Co { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
