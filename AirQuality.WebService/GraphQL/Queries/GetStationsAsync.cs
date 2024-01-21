using AirQuality.Core.DAL.Models;
using AirQuality.WebService.DAL;
using Microsoft.EntityFrameworkCore;

namespace AirQuality.WebService.GraphQL.Queries
{
    public partial class Query
    {
        [UseFiltering]
        [UseSorting]
        public async Task<List<Station>> GetStationsAsync([Service] MasterDbContext db)
        {
            return await db.Stations.ToListAsync();
        }
    }
}
