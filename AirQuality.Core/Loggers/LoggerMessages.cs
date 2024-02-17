using System.Text;

namespace AirQuality.Core.Loggers;

public static class LoggerMessages
{
    public static string Error(string message)
    {
        var error = new StringBuilder("ERROR|| ");

        return error.AppendLine(message).ToString();
    }

    public static string Warning(string message)
    {
        var warning = new StringBuilder("WARNING|| ");

        return warning.AppendLine(message).ToString();
    }

    public static string Info(string message)
    {
        var info = new StringBuilder("INFO|| ");

        return info.AppendLine(message).ToString();
    }
}
