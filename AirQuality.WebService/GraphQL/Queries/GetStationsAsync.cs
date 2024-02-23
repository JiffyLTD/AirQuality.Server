using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию по всем метеостанциям")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Station> GetStations([Service] MasterDbContext db)
    {
        return db.Stations;
    }
}
