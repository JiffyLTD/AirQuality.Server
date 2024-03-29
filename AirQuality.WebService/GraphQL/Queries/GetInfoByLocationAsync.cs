using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию о средних показателях метеостанции")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UseProjection]
    public async Task<InfoByLocation> GetInfoByLocation([Service] ApplicationDbContext db, Guid stationId)
    {
        try
        {
            if (stationId == Guid.Empty)
            {
                throw new Exception("Not found");
            }
        
            var info = await db.InfosByLocation.FirstOrDefaultAsync(x => x.StationId == stationId);

            if (info == null)
            {
                throw new Exception("Not found");
            }
        
            return info;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
