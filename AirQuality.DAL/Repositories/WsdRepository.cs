using AirQuality.DAL.DataContext;
using AirQuality.DAL.DTOs;
using AirQuality.DAL.Interfaces;
using AirQuality.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.DAL.Repositories
{
    public class WsdRepository : IWsdRepository
    {
        private readonly AppDbContext _db;

        public WsdRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<DBResponse> TryAddAsync(WeatherStationData data)
        {
            try
            {
                await _db.WeatherStationData.AddAsync(data);
                await _db.SaveChangesAsync();

                return new DBResponse(data, "Данные успешно получены");
            }
            catch (Exception ex)
            {
                return new DBResponse(null, ex.Message);
            }
        }

        public async Task<DBResponse> TryGetAllAsync()
        {
            try
            {
                var list = await _db.WeatherStationData.ToListAsync();

                return new DBResponse(list, "Данные успешно получены");
            }
            catch (Exception ex)
            {
                return new DBResponse(null, ex.Message);
            }
        }

        public async Task<DBResponse> TryGetLastAsync()
        {
            try
            {
                var lastData = await _db.WeatherStationData.LastAsync();

                return new DBResponse(lastData, "Данные успешно получены");
            }
            catch (Exception ex)
            {
                return new DBResponse(null, ex.Message);
            }
        }
    }
}
