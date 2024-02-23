using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить данные от метеостанции")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UseProjection]
    public IQueryable<StationData?> GetStationData([Service] MasterDbContext db, Guid stationId)
    {
        return db.StationsData.Where(x => x.StationId == stationId);
    }
}
