using Microsoft.AspNetCore.Authorization;

namespace AirQuality.Core.Extentions;

public static class AuthorizationOptionsExtentions
{
    public static AuthorizationOptions AddOnlyServicePolicy(this AuthorizationOptions options)
    {
        options.AddPolicy(Constants.Policies.OnlyService, policy => 
            policy.RequireAssertion(context =>
            {
                var claim = context.User.Claims.FirstOrDefault(x => x is { Type: Constants.ServiceClientId, Value: "true" });
                
                return claim != null;
            }));

        return options;
    }
}