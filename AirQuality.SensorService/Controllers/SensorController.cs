using AirQuality.SensorService.Inputs;
using AirQuality.SensorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirQuality.SensorService.Controllers;

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
    public async Task<IResult> Post(CreateRequestInput input)
    {
        var stationId = await _stationService.CreateOrUpdateAsync(input.CreateStationDto);

        if(stationId == Guid.Empty)
        {
            return Results.BadRequest(new { errors = "Не удалось создать или обновить данные Station"});
        }

        var stationData = await _stationDataService.CreateAsync(input.CreateStationDataDto, stationId.ToString());

        if (!stationData)
        {
            return Results.BadRequest(new { errors = "Не удалось создать данные StationData" });
        }

        return Results.Ok(true);
    }
}
