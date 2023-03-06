using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;

        public SqlRegionRepository(NZWalkDbContext nZWalkDbContext)
        {
            this.nZWalkDbContext = nZWalkDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalkDbContext.Regions.ToListAsync();
        }
    }
}
