using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Query
{
    [GraphQLDescription("Получить информацию по всем метеостанциям")]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Station> GetStations([Service] MasterDbContext db)
    {
        return db.Stations;
    }
}
