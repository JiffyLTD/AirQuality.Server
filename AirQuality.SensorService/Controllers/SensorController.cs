using AirQuality.Core;
using AirQuality.SensorService.Inputs;
using AirQuality.SensorService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AirQuality.SensorService.Controllers;

[ApiController]
[Authorize(Policy = Constants.Policies.OnlyService)]
public class SensorController(
    StationService stationService,
    StationDataService stationDataService,
    InfoByLocationService infoByLocationService) : ControllerBase
{
    [HttpPost("api/sensor")]
    public async Task<IResult> Post(CreateRequestInput input)
    {
        try
        {
            var stationId = await stationService.CreateOrUpdateAsync(input.CreateStationInput);

            await stationDataService.CreateAsync(input.CreateStationDataInput, stationId.ToString());

            await infoByLocationService.CreateOrUpdateAsync(stationId.ToString());

            return Results.Ok(true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            
            return Results.BadRequest(false);
        }
    }
}
