using AirQuality.Services.DTOs;
using AirQuality.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirQuality.API.ApiControllers
{
    [Route("api/wsd")]
    [ApiController]
    public class WSController : ControllerBase
    {
        private readonly IWsdService _wsService;

        public WSController(IWsdService wsService)
        {
            _wsService = wsService;
        }

        [HttpGet("getAll")]
        public async Task<IResult> GetAll()
        {
            var result = await _wsService.GetAllAsync();

            return Results.Ok(result);
        }

        [HttpPost("add")]
        public async Task<IResult> Post(WeatherStationDataDto wsdDto)
        {
            var result = await _wsService.AddAsync(wsdDto);

            return Results.Ok(result);
        }
    }
}
