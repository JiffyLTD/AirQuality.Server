using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию о средних показателях метеостанции")]
    [UseProjection]
    public IQueryable<InfoByLocation?> GetInfoByLocation([Service] MasterDbContext db, Guid stationId)
    {
        return db.InfosByLocation.Where(x => x.StationId == stationId);
    }
}
