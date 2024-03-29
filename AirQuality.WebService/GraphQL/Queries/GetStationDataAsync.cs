using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
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
    public async Task<IEnumerable<StationData>> GetStationData([Service] ApplicationDbContext db)
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
