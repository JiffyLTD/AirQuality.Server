namespace AirQuality.SensorService.Tests.Helpers;

public static class TestHelper
{
    public static float GetRandomFloat(int min, int max)
    {
        Random random = new();

        var mantissa = random.NextDouble() * 2.0 - 1.0;
        var exponent = Math.Pow(2.0, random.Next(min, max));

        return (float)(mantissa * exponent);
    }

    public static int GetRandomInt(int min, int max)
    {
        Random random = new();

        return random.Next(min, max);
    }
}