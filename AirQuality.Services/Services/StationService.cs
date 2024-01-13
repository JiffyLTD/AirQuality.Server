using AirQuality.DAL.DataContext;
using AirQuality.Domain.DTOs.Station;
using AirQuality.Domain.Entities;
using AirQuality.Domain.Interfaces;
using AirQuality.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.Services.Services
{
    public class StationService : IStationService
    {
        private readonly AppDbContext _db;

        public StationService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Station> TryCreateAsync(StationCreateDTO stationCreateDto)
        {
            Station station = StationMapper.StationCreateDtoToStation(stationCreateDto);

            var addResult = await _db.Station.AddAsync(station);
            await _db.SaveChangesAsync();

            return addResult.Entity;
        }

        public async Task<int> GetCountAllStationsAsync()
        {
            var countStations = await _db.Station.CountAsync();

            return countStations;
        }

        public async Task<List<Station>> GetStationsAsync(int limit)
        {
            var listStations = await _db.Station.Take(limit).ToListAsync();

            return listStations;    
        }

        public async Task<Station> TryUpdateAsync(StationUpdateDTO stationUpdateDto)
        {
            var station = await _db.Station.FirstOrDefaultAsync(x => x.StationId == stationUpdateDto.StationId);

            if(station == null)
            {
                throw new NullReferenceException();
            }

            station.Location = stationUpdateDto.Location;
            station.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            return station;
        }
    }
}
