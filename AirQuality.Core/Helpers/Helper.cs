namespace AirQuality.Core.Helpers;

public static class Helper
{
    public static double ConvertToDecimalDegrees(string expression, string hemisphere)
    {
        var degrees = Math.Floor(double.Parse(expression) / 100);
        var minutes = double.Parse(expression) % 100; 
        
        var decimalPart = minutes / 60;
        
        var decimalDegree = degrees + decimalPart;
        
        if (hemisphere is "S" or "W")
        {
            decimalDegree = -decimalDegree;
        }
        
        return decimalDegree;
    }

}