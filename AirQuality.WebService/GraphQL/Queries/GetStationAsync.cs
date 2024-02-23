using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию по метеостанции")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UseProjection]
    public IQueryable<Station?> GetStation([Service] MasterDbContext db, Guid sensorId)
    {
        return db.Stations.Where(x => x.SensorId == sensorId);
    }
}
