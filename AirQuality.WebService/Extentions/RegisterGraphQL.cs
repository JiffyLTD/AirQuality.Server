using AirQuality.WebService.GraphQL.Queries;

namespace AirQuality.WebService.Extentions;

public static class RegisterGraphQL
{
    public static IServiceCollection AddGraphQL(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<Queries>()
            .AddProjections()
            .AddSorting()
            .AddFiltering()
            ;

        return services;
    }
}
