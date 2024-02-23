using Microsoft.AspNetCore.Authentication;

namespace AirQuality.Core.Authentication;

public static class TokenExtentions
{
    public static AuthenticationBuilder AddToken(this AuthenticationBuilder builder)
    {
        return builder.AddScheme<TokenOptions, TokenHandler>(TokenOptions.DefaultScheme, options => {});
    }
}