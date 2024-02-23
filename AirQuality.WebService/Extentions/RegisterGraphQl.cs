using AirQuality.WebService.GraphQL.Queries;

namespace AirQuality.WebService.Extentions;

public static class RegisterGraphQl
{
    public static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddAuthorization()
            .AddQueryType<Queries>()
            .AddProjections()
            .AddSorting()
            .AddFiltering()
            ;

        return services;
    }
}
