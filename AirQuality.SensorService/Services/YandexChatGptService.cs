﻿using Serilog;
using Zefirrat.YandexGpt.Abstractions;

namespace AirQuality.SensorService.Services;

public class YandexChatGptService(IYaPrompter prompter)
{
    public async Task<string> GetAdvices(string locationName, float avgTemperature, int avgHumidity,
        int avgPm1, int avgPm2, int avgPm10, int avgCo, int avgPressure)
    {
        try
        {
            var requestText = $"В городе {locationName} " +
                $"сейчас средняя температура воздуха {avgTemperature} градусов," +
                $"влажность воздуха {avgHumidity}%," +
                $"содержание pm 1 в воздухе {avgPm1}," +
                $"содержание pm 2.5 в воздухе {avgPm2}," +
                $"содержание pm 10 в воздухе {avgPm10}," +
                $"содержание co в воздухе {avgCo}," +
                $"и среднее давление {avgPressure}," + 
                $"что ты можешь сказать об этом и какие дашь советы как лучше одеться?";

            var response = await prompter.SendAsync(requestText);

            return response;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);

            return "Сегодня без советов";
        }
    }
}
