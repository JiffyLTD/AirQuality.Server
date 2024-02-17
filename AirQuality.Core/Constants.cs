namespace AirQuality.Core;

public static class Constants
{
    public const string DbConnectionStringSection = "PostgreDb";
    public const string LogsFilename = "logs.txt";

    public const int TemperatureMaxValue = 100;
    public const int TemperatureMinValue = -273;
    public const int HumidityMaxValue = 100;
    public const int HumidityMinValue = 0;
    public const int Pm_1MaxValue = 500;
    public const int Pm_1MinValue = 0;
    public const int Pm_2_5MaxValue = 500;
    public const int Pm_2_5MinValue = 0;
    public const int Pm_10MaxValue = 500;
    public const int Pm_10MinValue = 0;
    public const int CoMaxValue = 1024;
    public const int CoMinValue = 0;
    public const int PressureMaxValue = 90000;
    public const int PressureMinValue = 100000;
}
