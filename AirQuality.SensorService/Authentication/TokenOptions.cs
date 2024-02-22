using Microsoft.AspNetCore.Authentication;

namespace AirQuality.SensorService.Authentication;

public class TokenOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "TokenAuthenticationScheme";
    public string TokenHeaderName { get; private set; } = "API-Key";
}