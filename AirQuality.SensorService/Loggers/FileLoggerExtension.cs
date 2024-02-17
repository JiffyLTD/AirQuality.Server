﻿namespace AirQuality.SensorService.Loggers;

public static class FileLoggerExtension
{
    public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filePath)
    {
        builder.AddProvider(new FileLoggerProvider(filePath));
        return builder;
    }
}