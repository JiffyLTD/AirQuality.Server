using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить данные от метеостанции")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UseProjection]
    public async Task<StationData?> GetStationDataLast([Service] ApplicationDbContext db, Guid stationId)
    {
        try
        {
            if (stationId == Guid.Empty)
            {
                throw new Exception("Not found");
            }

            var stationData = await db.StationsData
                .OrderBy(x => x.CreatedAt)
                .LastOrDefaultAsync(x => x.StationId == stationId);

            if (stationData == null)
            {
                throw new Exception("Not found");
            }

            return stationData;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
