namespace AirQuality.SensorService.Tests.Helpers;

internal static class Helper
{
    public static float GetRandomFloat(int min, int max)
    {
        Random random = new();

        double mantissa = random.NextDouble() * 2.0 - 1.0;
        double exponent = Math.Pow(2.0, random.Next(min, max));

        return (float)(mantissa * exponent);
    }

    public static int GetRandomInt(int min, int max)
    {
        Random random = new();

        return random.Next(min, max);
    }
}
