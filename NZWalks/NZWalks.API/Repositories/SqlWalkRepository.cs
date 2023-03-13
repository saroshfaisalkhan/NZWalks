using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using System.Linq;

namespace NZWalks.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;

        public SqlWalkRepository(NZWalkDbContext nZWalkDbContext)
        {
            this.nZWalkDbContext = nZWalkDbContext;
        }



        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            if(walk==null)
            {
                return null;
            }
            else
            await nZWalkDbContext.Walks.AddAsync(walk);
            await nZWalkDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteWalkAsync(Guid id)
        {
            var walk_to_be_delete = await nZWalkDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walk_to_be_delete == null)
            {
                return null;
            }
            else

           nZWalkDbContext.Walks.Remove(walk_to_be_delete);

            return walk_to_be_delete;


        }

        public async Task<IEnumerable<Walk>> GetAllWalkAsync()
        {
            return await nZWalkDbContext.Walks
                .Include(x=>x.Region)  // Fetch walks data including Region property of Walks
                .Include(x=>x.WalkDifficulty)  // Fetch walks data including WalkDifficulty property of Walks
                .ToListAsync();

              
                
          
        }

        public async Task<Walk> GetWalkAsync(Guid id)
        {
            var walk =await  nZWalkDbContext.Walks.FirstOrDefaultAsync(x=>x.Id==id);
            if (walk == null)
            {
                return null;
            }
            else
                return walk;
        }

        public async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existing_walk = await nZWalkDbContext.Walks.FindAsync(id);

            if (walk != null)
            {
                existing_walk.Name = walk.Name;
                existing_walk.Length = walk.Length;
                existing_walk.RegionId = walk.RegionId;
                existing_walk.WalkDifficultyId = walk.WalkDifficultyId;
                await nZWalkDbContext.SaveChangesAsync();
                return existing_walk;


            }
            else
                return null;
         
        }
    }
}
