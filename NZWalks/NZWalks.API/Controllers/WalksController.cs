using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;

        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;

        }

        public IMapper Mapper { get; }

        //1. Get All Walk
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllWalkAsync()
        {
            //fetch data from database

            var walkDomain = await walkRepository.GetAllWalkAsync();

            // Convert  DomainList to DTO
            var walkDTO = mapper.Map<List<Models.DTO.Walks>>(walkDomain);

            //return DTO to client

            return Ok(walkDTO);
        }



        //2. Update Walk
        [HttpPut]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            //convert updateWalkRequest TO Domain Walk

            var walkDomain = new Walk()
            {
                Name = updateWalkRequest.Name,
                Length = updateWalkRequest.Length,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };

            // Pass walkDomain to Repository
            var updatedWalk = await walkRepository.UpdateWalkAsync(id, walkDomain);

            if (updatedWalk == null)
            {
                return NotFound();
            }

            // Convert  Domain to DTO
            var walkDTO = mapper.Map<Models.DTO.Walks>(updatedWalk);

            //return DTO to client

            return Ok(walkDTO);

        }


        //3. Delet Walk
        [HttpDelete]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute]Guid id)
        { 

            // Pass Id to Repository
          var deleted_walk=await walkRepository.DeleteWalkAsync(id);

            if (deleted_walk == null)
            {
                return NotFound();
            }

            // Convert  Domain to DTO
            var deleted_walkDTO = mapper.Map<Models.DTO.Walks>(deleted_walk);

            //return DTO to client

            return Ok(deleted_walkDTO);

        }
    }
}
