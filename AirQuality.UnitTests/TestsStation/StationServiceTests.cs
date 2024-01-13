using AirQuality.DAL.DataContext;
using AirQuality.Domain.DTOs.Station;
using AirQuality.Domain.Entities;
using AirQuality.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.UnitTests.TestsStationService
{
    [TestFixture]
    public class StationServiceTests
    {
        private AppDbContext _fakeDb;
        private StationService _stationService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("FakeAQIDb").Options;

            _fakeDb = new AppDbContext(options);
            _stationService = new StationService(_fakeDb);
        }

        [Test]
        public async Task Test_CreateStation()
        {
            var stationId = Guid.NewGuid();
            var location = "INVALID";
            StationCreateDTO stationCreateDto = new(stationId, location);

            var createdStation = await _stationService.TryCreateAsync(stationCreateDto);

            Assert.Multiple(() =>
            {
                Assert.That(createdStation, Is.Not.Null);
                Assert.That(stationId, Is.EqualTo(createdStation.StationId));
                Assert.That(location, Is.EqualTo(createdStation.Location));
            });

            _fakeDb.Station.Remove(createdStation);
            await _fakeDb.SaveChangesAsync();
        }

        [Test]
        public async Task Test_1_GetCountAllStationsAsync()
        {
            var countStationsActual = 0;
            var countStations = await _stationService.GetCountAllStationsAsync();

            Assert.That(countStationsActual, Is.EqualTo(countStations));
        }

        [Test]
        public async Task Test_2_GetCountAllStationsAsync()
        {
            List<Station> listStations = new(){
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID")
            };

            await _fakeDb.Station.AddRangeAsync(listStations);
            await _fakeDb.SaveChangesAsync();

            var countStations = await _stationService.GetCountAllStationsAsync();

            Assert.That(listStations, Has.Count.EqualTo(countStations));

            _fakeDb.Station.RemoveRange(listStations);
            await _fakeDb.SaveChangesAsync();
        }

        [Test]
        public async Task Test_1_GetStationsAsync()
        {
            List<Station> listStations = new(){
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID")
            };

            await _fakeDb.Station.AddRangeAsync(listStations);
            await _fakeDb.SaveChangesAsync();

            int limit = 2;
            var listStationsGet = await _stationService.GetStationsAsync(limit);

            Assert.That(listStationsGet, Has.Count.EqualTo(limit));

            _fakeDb.Station.RemoveRange(listStations);
            await _fakeDb.SaveChangesAsync();
        }

        [Test]
        public async Task Test_2_GetStationsAsync()
        {
            List<Station> listStations = new(){
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID")
            };

            await _fakeDb.Station.AddRangeAsync(listStations);
            await _fakeDb.SaveChangesAsync();

            int limit = 5;
            var listStationsGet = await _stationService.GetStationsAsync(limit);

            Assert.That(listStationsGet, Has.Count.EqualTo(limit));

            _fakeDb.Station.RemoveRange(listStations);
            await _fakeDb.SaveChangesAsync();
        }

        [Test]
        public async Task Test_3_GetStationsAsync()
        {
            List<Station> listStations = new(){
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID"),
                new Station(Guid.NewGuid(), "INVALID")
            };

            await _fakeDb.Station.AddRangeAsync(listStations);
            await _fakeDb.SaveChangesAsync();

            int limit = 3;
            var listStationsGet = await _stationService.GetStationsAsync(limit);

            Assert.That(listStationsGet, Has.Count.EqualTo(limit));

            _fakeDb.Station.RemoveRange(listStations);
            await _fakeDb.SaveChangesAsync();
        }

        [Test]
        public async Task Test_1_UpdateStation()
        {
            var stationId = Guid.NewGuid();
            var location = "INVALID";
            Station station = new (stationId, location);

            await _fakeDb.Station.AddAsync(station);
            await _fakeDb.SaveChangesAsync();

            var newLocation = "New Location";
            StationUpdateDTO stationUpdateDto = new(stationId, newLocation);

            var updatedStation = await _stationService.TryUpdateAsync(stationUpdateDto);

            Assert.Multiple(() =>
            {
                Assert.That(updatedStation, Is.Not.Null);
                Assert.That(stationId, Is.EqualTo(updatedStation.StationId));
                Assert.That(newLocation, Is.EqualTo(updatedStation.Location));
            });

            _fakeDb.Station.Remove(updatedStation);
            await _fakeDb.SaveChangesAsync();
        }

        [Test]
        public void Test_2_UpdateStation()
        {
            var stationId = Guid.NewGuid();
            var location = "INVALID";

            StationUpdateDTO stationUpdateDto = new(stationId, location);

            Assert.CatchAsync<NullReferenceException>(async () => await _stationService.TryUpdateAsync(stationUpdateDto));
        }

        [TearDown] 
        public void TearDown() 
        {
            _fakeDb.Database.EnsureDeleted();
            _fakeDb.Dispose();
        }
    }
}