using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetAllAsync();

        //Section 4 Get Region By id
        public Task<Region> GetRegionAsync(Guid id);

        // Add Region
        public Task<Region> AddRegionAsync(Region region);

        // Delete a resource based on id
        public Task<Region> DeleteRegionAsync(Guid id);

        //Update Region
        public Task<Region> UpdateRegionAsync(Guid id, Region region);
    }
}
