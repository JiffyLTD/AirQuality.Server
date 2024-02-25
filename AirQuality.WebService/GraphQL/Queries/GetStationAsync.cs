using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.WebService.GraphQL.Queries;

public partial class Queries
{
    [GraphQLDescription("Получить информацию по метеостанции")]
    [Authorize(Policy = Core.Constants.Policies.OnlyService)]
    [UseProjection]
    public async Task<Station?> GetStation([Service] MasterDbContext db, Guid sensorId)
    {
        try
        {
            if (sensorId == Guid.Empty)
            {
                throw new Exception("Not found");
            }

            var station = await db.Stations.FirstOrDefaultAsync(x => x.SensorId == sensorId);
        
            if (station == null)
            {
                throw new Exception("Not found");
            }
        
            return station;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
