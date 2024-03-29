namespace AirQuality.Core;

public static class Constants
{
    public const string DbConnectionStringSection = "PostgreDb";
    public const string LogsFilename = "logs.txt";
    
    public const string ServiceClientId = "airquality-service";
    
    public const string NotValidLocation = "Invalid";

    public static class Policies
    {
        public const string OnlyService = "OnlyService";
    }
}
