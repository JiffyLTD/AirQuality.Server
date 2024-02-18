using AirQuality.Core.DAL.Models;
using AirQuality.Core.Loggers;
using AirQuality.SensorService.DAL;
using AirQuality.SensorService.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.SensorService.Services;

public class InfoByLocationService
{
    private readonly MasterDbContext _db;
    private readonly ILogger<InfoByLocationService> _log;
    private readonly YandexChatGpt _yandexChatGpt;

    public InfoByLocationService(MasterDbContext db, ILogger<InfoByLocationService> log, YandexChatGpt yandexChatGpt)
    {
        _db = db;
        _log = log;
        _yandexChatGpt = yandexChatGpt;
    }

    public async Task<bool> CreateOrUpdateAsync(string stationIdString)
    {
        try
        {
            var stationId = Guid.Parse(stationIdString);

            var dateNow = DateTime.Now;
            var dateMin = dateNow.AddDays(-1);
            var dateMax = dateNow.AddDays(1);

            var stationDatas = await _db.StationsData
                .Where(x => x.StationId == stationId && x.CreatedAt >= dateMin && x.CreatedAt <= dateMax)
                .ToListAsync();

            var infoByLocation = await _db.InfosByLocation.FirstOrDefaultAsync(x => x.StationId == stationId);

            // TODO: Сделать сервис поиска названия населенного пункта по координатам
            var locationName = "Ярославль";
            var avgTemperature = stationDatas.Average(x => x.Temperature);
            var avgHumidity = (int)stationDatas.Average(x => x.Humidity);
            var avgPm_1 = (int)stationDatas.Average(x => x.Pm_1);
            var avgPm_2_5 = (int)stationDatas.Average(x => x.Pm_2_5);
            var avgPm_10 = (int)stationDatas.Average(x => x.Pm_10);
            var avgCo = (int)stationDatas.Average(x => x.Co);
            var avgPressure = (int)stationDatas.Average(x => x.Pressure);
            var aiAdvices = await _yandexChatGpt.GetAdvices(locationName, avgTemperature, avgHumidity, avgPm_1, avgPm_2_5, avgPm_10, avgCo, avgPressure);

            if (infoByLocation == null)
            {
                var newInfoByLocation
                    = new InfoByLocation(stationIdString, locationName, avgTemperature, avgHumidity, avgPm_1, avgPm_2_5, avgPm_10, avgCo, avgPressure, aiAdvices);

                await _db.InfosByLocation.AddAsync(newInfoByLocation);
                await _db.SaveChangesAsync();

                return true;
            }
            else
            {
                infoByLocation.UpdateInfo(locationName, avgTemperature, avgHumidity, avgPm_1, avgPm_2_5, avgPm_10, avgCo, avgPressure, aiAdvices);
                await _db.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception ex)
        {
            _log.LogError(LoggerMessages.Error(ex.Message.ToString()));

            return false;
        }
    }
}
