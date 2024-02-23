using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию о средних показателях метеостанции")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UseProjection]
    public IQueryable<InfoByLocation?> GetInfoByLocation([Service] MasterDbContext db, Guid stationId)
    {
        return db.InfosByLocation.Where(x => x.StationId == stationId);
    }
}
