using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить данные от всех метеостанций")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<StationData>> GetStationData([Service] MasterDbContext db)
    {
        try
        {
            var stationData = await db.StationsData.ToArrayAsync();
            return stationData;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
