using AirQuality.Core.DAL;
using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.WebService.GraphQL.Queries
{
    public partial class Query
    {
        public async Task<Station?> GetStationAsync([Service] MasterDbContext db, Guid id)
        {
            return await db.Stations.FirstOrDefaultAsync(x => x.SensorId == id);
        }
    }
}
