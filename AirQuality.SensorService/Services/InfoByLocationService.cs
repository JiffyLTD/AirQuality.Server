using AirQuality.Core;
using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AirQuality.SensorService.Services;

public class InfoByLocationService(ApplicationDbContext db, YandexChatGptService yandexChatGptService)
{
    public async Task CreateOrUpdateAsync(string stationIdString)
    {
        try
        {
            var stationId = Guid.Parse(stationIdString);
            var station = await db.Stations.FirstOrDefaultAsync(x => x.Id == stationId);

            if (station!.Location == Constants.NotValidLocation)
                return;
            
            var yesterday = DateTime.Now.AddDays(-1);
            
            var stationDataList = await db.StationsData
                .Where(x => 
                    x.StationId == stationId &&
                    x.CreatedAt >= yesterday)
                .ToListAsync();

            // TODO: Сделать сервис поиска названия населенного пункта по координатам
            var locationName = "Ярославль";
            var avgTemperature = stationDataList.Average(x => x.Temperature);
            var avgHumidity = (int)stationDataList.Average(x => x.Humidity);
            var avgPm1 = (int)stationDataList.Average(x => x.Pm1);
            var avgPm2 = (int)stationDataList.Average(x => x.Pm2);
            var avgPm10 = (int)stationDataList.Average(x => x.Pm10);
            var avgCo = (int)stationDataList.Average(x => x.Co);
            var avgPressure = (int)stationDataList.Average(x => x.Pressure);
            // TODO: заменить параметры на один объект
            var aiAdvices 
                = await yandexChatGptService.GetAdvices(locationName, avgTemperature, avgHumidity, avgPm1, avgPm2, avgPm10, avgCo, avgPressure);

            var infoByLocation = await db.InfosByLocation.FirstOrDefaultAsync(x => x.StationId == stationId);
            
            // TODO: Добавить логгирование
            if (infoByLocation == null)
            {
                var newInfoByLocation = new InfoByLocation()
                {
                    Id = Guid.NewGuid(),
                    StationId = stationId,
                    LocationName = locationName,
                    AiAdvices = aiAdvices,
                    AvgTemperature = avgTemperature,
                    AvgHumidity = avgHumidity,
                    AvgCo = avgCo,
                    AvgPressure = avgPressure,
                    AvgPm1 = avgPm1,
                    AvgPm2 = avgPm2,
                    AvgPm10 = avgPm10,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                await db.InfosByLocation.AddAsync(newInfoByLocation);
                await db.SaveChangesAsync();
            }
            else
            {
                infoByLocation.LocationName = locationName;
                infoByLocation.AiAdvices = aiAdvices;
                infoByLocation.AvgTemperature = avgTemperature;
                infoByLocation.AvgHumidity = avgHumidity;
                infoByLocation.AvgPressure = avgPressure;
                infoByLocation.AvgCo = avgCo;
                infoByLocation.AvgPm1 = avgPm1;
                infoByLocation.AvgPm2 = avgPm2;
                infoByLocation.AvgPm10 = avgPm10;
                infoByLocation.UpdatedAt = DateTime.Now;
                
                await db.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);

            throw new Exception(ex.Message);
        }
    }
}
