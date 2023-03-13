using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        //Get All Walk 
        Task<IEnumerable<Walk>> GetAllWalkAsync();

        //Get Walk By Id
        Task<Walk> GetWalkAsync(Guid id);

        //Add Walk
        Task<Walk> AddWalkAsync(Models.Domain.Walk walk );

        //Update Walk
        Task<Walk> UpdateWalkAsync(Guid id,Models.Domain.Walk walk);

        //Delete Walk
        Task<Walk> DeleteWalkAsync(Guid id);
    }
}
