namespace AirQuality.SensorService.Inputs;

public interface ICreateStationDataInput
{
    public float Temperature { get;  set; }
    public int Humidity { get;  set; }
    public int Pm1 { get;  set; }
    public int Pm2 { get;  set; }
    public int Pm10 { get;  set; }
    public int Co { get; set; }
    public int Pressure { get; set; }
}

public class CreateStationDataInput : ICreateStationDataInput
{
    public float Temperature { get;  set; }
    public int Humidity { get;  set; }
    public int Pm1 { get;  set; }
    public int Pm2 { get;  set; }
    public int Pm10 { get;  set; }
    public int Co { get; set; }
    public int Pressure { get; set; }
}
