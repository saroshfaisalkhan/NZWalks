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

        public async Task<Region> GetRegionAsync(Guid id)
        {
            return await nZWalkDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
           
        }


        public async Task<Region?> AddRegionAsync(Region region)
        {
            if (region != null)
            {
                region.Id=new Guid();
                await nZWalkDbContext.AddAsync(region);
                await nZWalkDbContext.SaveChangesAsync();
                return region;
            }
            else
                return null;
            

        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            //1. Find Region exist or not
            var region=await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return null;
            }
            //2. Delete Region
           nZWalkDbContext.Regions.Remove(region);
           await nZWalkDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> UpdateRegionAsync(Guid id, Region region)
        {
            //1. Find Region exist or not
            var existingRegion = await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //2. If it is not exist then return null
            if (region == null)
            {
                return null;
            }

            //3. If its exits then update the model
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.Area = region.Area;
            existingRegion.Latitude = region.Latitude;
            existingRegion.Longitude = region.Longitude;
            existingRegion.Population = region.Population;


            //.4 Save the existingRegion in database

            await nZWalkDbContext.SaveChangesAsync();

            //5. return the region
            return existingRegion;
        }
    }

        
    
}
