using AirQuality.Core.DAL.Models;

namespace AirQuality.SensorService.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public TokenMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        
        public async Task InvokeAsync(HttpContext context)
        {
            var requestToken = context.Request.Headers.Authorization.ToString();

            var checkToken = _configuration.GetSection("Token").Value?.ToString(); 
            
            if (requestToken != checkToken)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                var response = new
                {
                    code = StatusCodes.Status401Unauthorized,
                    message = "Invalid token"
                };
                await context.Response.WriteAsJsonAsync(response);
            }

            await _next.Invoke(context);
        }
    }
}
