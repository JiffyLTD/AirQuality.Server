using AirQuality.SensorService.Inputs;
using AirQuality.SensorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirQuality.SensorService.Controllers;

[ApiController]
public class SensorController : ControllerBase
{
    private readonly StationService _stationService;
    private readonly StationDataService _stationDataService;
    private readonly InfoByLocationService _infoByLocationService;

    public SensorController(StationService stationService,
        StationDataService stationDataService, InfoByLocationService infoByLocationService)
    {
        _stationService = stationService;
        _stationDataService = stationDataService;
        _infoByLocationService = infoByLocationService;
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

        var infoByLocation = await _infoByLocationService.CreateOrUpdateAsync(stationId.ToString());

        if (!infoByLocation)
        {
            return Results.BadRequest(new { errors = "Не удалось создать данные InfoByLocation" });
        }

        return Results.Ok(true);
    }
}
