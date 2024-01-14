namespace AirQuality.SensorService.DTO
{
    public class CreateStationDataDto
    {
        public CreateStationDataDto(float temperature, int humidity, int pm_1, int pm_2_5, int pm_10, int co, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pm_1 = pm_1;
            Pm_2_5 = pm_2_5;
            Pm_10 = pm_10;
            Co = co;
            Pressure = pressure;
        }
        public float Temperature { get; private set; }
        public int Humidity { get; private set; }
        public int Pm_1 { get; private set; }
        public int Pm_2_5 { get; private set; }
        public int Pm_10 { get; private set; }
        public int Co { get; private set; }
        public int Pressure { get; private set; }
    }
}
