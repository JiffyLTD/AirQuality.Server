using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить данные от метеостанции")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<StationData?> GetStationData([Service] MasterDbContext db, Guid stationId)
    {
        return db.StationsData.Where(x => x.StationId == stationId);
    }
}
