using AirQuality.Core.DAL.Abstractions;
using AirQuality.Core.Helpers;

namespace AirQuality.Core.DAL.Models;

public class Station : IStation
{
    public Station()
    {
    }

    public Station(string sensorId, string location)
    {
        SensorId = Guid.Parse(sensorId);
        Location = GetLongitudeAndLatitudeStringFromLocation(location);
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Guid Id { get; init; }
    public Guid SensorId { get; init; }
    public string Location { get; private set; } = null!;
    public DateTime CreatedAt { get; init; } 
    public DateTime UpdatedAt { get; private set; }

    /// <summary>
    /// Обновить данные по местоположению и время обновления записи
    /// </summary>
    public void SetLocation(string location)
    {
        var newLocation = GetLongitudeAndLatitudeStringFromLocation(location);
        
        if (newLocation != "Invalid")
        {
            Location = newLocation;
            UpdatedAt = DateTime.Now;
        }
    }

    /// <summary>
    /// Выборка широты и долготы из строки NMEA
    /// </summary>
    private static string GetLongitudeAndLatitudeStringFromLocation(string location)
    {
        if (string.IsNullOrEmpty(location) || location[0] != '$')
        {
            return "Invalid";
        }
        
        var fields = location.Split(',');
        
        if (fields.Length < 6)
        {
            return "Invalid";
        }
        
        var messageId = fields[0];
        
        if (messageId != "$GPGGA")
        {
            return "Invalid";
        }
        
        var latitude = fields[2];
        var latitudeHemisphere = fields[3];
        var longitude = fields[4];
        var longitudeHemisphere = fields[5];
        
        if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(latitudeHemisphere) ||
            string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(longitudeHemisphere))
        {
            return "Invalid";
        }
        
        var latitudeDecimal = Helper.ConvertToDecimalDegrees(latitude, latitudeHemisphere);
        var longitudeDecimal = Helper.ConvertToDecimalDegrees(longitude, longitudeHemisphere);
        
        var latitudeString = latitudeDecimal.ToString("F4");
        var longitudeString = longitudeDecimal.ToString("F4");
        
        var coordinates = latitudeString + "," + longitudeString;
        
        return coordinates;
    }
}
