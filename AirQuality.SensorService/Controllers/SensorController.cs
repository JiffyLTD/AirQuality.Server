using AirQuality.SensorService.DTO;
using AirQuality.SensorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirQuality.SensorService.Controllers
{
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly StationService _stationService;
        private readonly StationDataService _stationDataService;

        public SensorController(StationService stationService, StationDataService stationDataService)
        {
            _stationService = stationService;
            _stationDataService = stationDataService;
        }

        [HttpPost("api/sensor")]
        public async Task<IResult> Post(CreateRequest createRequest)
        {
            try
            {
                var station = await _stationService.TryCreateOrUpdateAsync(createRequest.CreateStationDto);

                if(station == null)
                    throw new Exception("Не удалось создать или обновить данные станции");

                string stationId = station.Id.ToString();
                var stationData = await _stationDataService.TryCreateAsync(createRequest.CreateStationDataDto, stationId);

                var response = new
                {
                    data = new
                    {
                        station,
                        stationData
                    }
                };

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    error = ex.Message.ToString()
                };

                return Results.BadRequest(response);
            }
        }
    }
}
