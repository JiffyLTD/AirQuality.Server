using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AirQuality.SensorService.Authentication;

public class TokenHandler(IOptionsMonitor<TokenOptions> options, ILoggerFactory logger, UrlEncoder encoder, IConfiguration configuration)
    : AuthenticationHandler<TokenOptions>(options, logger, encoder)
{
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(Options.TokenHeaderName, out var value))
            return AuthenticateResult.Fail($"Missing header: {Options.TokenHeaderName}");
        
        return await ValidateToken(configuration, value!) ? 
            AuthenticateResult.Success(new AuthenticationTicket(GetFakeClaimsPrincipal(), Scheme.Name)) 
            : AuthenticateResult.Fail($"Invalid token.");
    }

    private static async Task<bool> ValidateToken(IConfiguration configuration, string requestToken)
    {
        var token = configuration.GetSection("Token").Value;

        if (token.IsNullOrEmpty())
            throw new Exception("Check configuration Token");

        return await Task.Run(() => requestToken != token);
    }

    private ClaimsPrincipal GetFakeClaimsPrincipal()
    {
        var claims = new List<Claim>()
        {
            new Claim("ClaimName", "ClaimValue")
        };

        var claimsIdentity = new ClaimsIdentity(claims, this.Scheme.Name);
        
        return  new ClaimsPrincipal(claimsIdentity);
    }
}