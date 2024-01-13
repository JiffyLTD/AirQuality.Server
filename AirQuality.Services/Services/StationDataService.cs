using AirQuality.DAL.DataContext;
using AirQuality.Domain.DTOs.StationData;
using AirQuality.Domain.Entities;
using AirQuality.Domain.Interfaces;

namespace AirQuality.Services.Services
{
    public class StationDataService : IStationDataService
    {
        private readonly AppDbContext _db;

        public StationDataService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<StationData> CreateAsync(StationDataCreateDTO stationDataCreateDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StationData>> GetAllAsync(int page, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<StationData> GetLastAsync(Guid stationId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StationData>> GetLastAsync(Guid stationId, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
