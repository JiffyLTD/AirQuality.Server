using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить данные от всех метеостанций")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<StationData> GetStationDatas([Service] MasterDbContext db)
    {
        return db.StationsData;
    }
}
