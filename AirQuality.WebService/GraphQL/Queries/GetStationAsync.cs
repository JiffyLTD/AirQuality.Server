using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию по метеостанции")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Station?> GetStation([Service] MasterDbContext db, Guid sensorId)
    {
        return db.Stations.Where(x => x.SensorId == sensorId);
    }
}
