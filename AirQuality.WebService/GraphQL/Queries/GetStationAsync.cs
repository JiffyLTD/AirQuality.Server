using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Query
{
    [GraphQLDescription("Получить данные по метеостанции")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Station?> GetStation([Service] MasterDbContext db, Guid sensorId)
    {
        return db.Stations.Where(x => x.SensorId == sensorId);
    }
}
