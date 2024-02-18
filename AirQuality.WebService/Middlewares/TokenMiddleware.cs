using AirQuality.Core.Loggers;

namespace AirQuality.WebService.Middlewares;

public class TokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TokenMiddleware> _log;

    public TokenMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<TokenMiddleware> log)
    {
        _next = next;
        _configuration = configuration;
        _log = log;
    }

    public Task InvokeAsync(HttpContext context)
    {
        try
        {
            var requestToken = context.Request.Headers.Authorization.FirstOrDefault();

            if (string.IsNullOrEmpty(requestToken))
            {
                context.Response.StatusCode = 401;
                var response = new
                {
                    code = StatusCodes.Status401Unauthorized,
                    message = "Invalid token"
                };

                return context.Response.WriteAsJsonAsync(response);
            }

            var checkToken = _configuration.GetSection("Token").Value?.ToString();

            if (requestToken != checkToken)
            {
                context.Response.StatusCode = 401;
                var response = new
                {
                    code = StatusCodes.Status401Unauthorized,
                    message = "Invalid token"
                };

                return context.Response.WriteAsJsonAsync(response);
            }

            return _next.Invoke(context);
        }
        catch (Exception ex) 
        {
            _log.LogWarning(LoggerMessages.Warning(ex.Message.ToString()));

            context.Response.StatusCode = 401;
            var response = new
            {
                code = StatusCodes.Status401Unauthorized,
                message = "Invalid token"
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
