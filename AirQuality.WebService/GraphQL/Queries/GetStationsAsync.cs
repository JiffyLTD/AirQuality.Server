using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию по всем метеостанциям")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<Station>> GetStations([Service] MasterDbContext db)
    {
        try
        {
            var stations = await db.Stations.ToArrayAsync();
            return stations;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
