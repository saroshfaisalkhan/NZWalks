using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using NZWalks.API.Models.DTO;
using AutoMapper.Configuration.Annotations;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
       public async Task<IActionResult> GetAllRegionAsync()
        {
            var regions = await regionRepository.GetAllAsync();


            var regionsDTO = new List<Models.DTO.Regions>();

            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Regions()
            //    {
            //        Id= region.Id,
            //        Name= region.Name,
            //        Code=region.Code,
            //        Area= region.Area,  
            //        Latitude=region.Latitude,
            //        Longitude=region.Longitude,
            //        Population=region.Population,

            //    };

            //    regionsDTO.Add(regionDTO);
            //}) ;

            regionsDTO = mapper.Map<List<Models.DTO.Regions>>(regions);
            return Ok(regionsDTO);
        }


        [HttpGet]
        [Route("[controller]/{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region= await regionRepository.GetRegionAsync(id);


           var one_region=  mapper.Map<Models.DTO.Regions>(region);
          
                return Ok(one_region);
        

          
        }


        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            //Taking Request and assigning to Domain region Model
            var region = new Region()
            {
                Name = addRegionRequest.Name,
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Latitude = addRegionRequest.Latitude,
                Longitude = addRegionRequest.Longitude,
                Population = addRegionRequest.Population
            };



            //2. Pass region to Repository, It'll automatically generate Id for region model, and return response back;

            var response = await regionRepository.AddRegionAsync(region);

            //3. Converting back to DTO regions

            var dto_region = new Regions()
            {
                Id = response.Id,
                Name = response.Name,
                Code = response.Code,
                Area = response.Area,
                Latitude = response.Latitude,
                Longitude=response.Longitude,
                Population=response.Population
            };


            return CreatedAtAction(nameof(GetRegionAsync), new { Id = dto_region.Id }, dto_region);

        }




        [HttpDelete]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //1.Get the region from database
            var region = await regionRepository.DeleteRegionAsync(id);


            //2.if null then return NotFound
            if(region==null)
            {
                return NotFound();
            }

            //3. If found then convert into DTO

            var deletedRegion=mapper.Map<Models.DTO.Regions>(region);

            //4. Return region which is recently deleted
            return Ok(deletedRegion);



        }


        [HttpPut]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            if (updateRegionRequest == null)
            {
                return NotFound();

            }
            else
            {

                var regionToBeUpdate = new Region()
                {
                    Name = updateRegionRequest.Name,
                    Code = updateRegionRequest.Code,
                    Area = updateRegionRequest.Area,
                    Latitude = updateRegionRequest.Latitude,
                    Longitude = updateRegionRequest.Longitude,
                    Population = updateRegionRequest.Population

                };

                var updateRegion = await regionRepository.UpdateRegionAsync(id, regionToBeUpdate);
                var region = mapper.Map<Models.Domain.Region>(updateRegion);
                return Ok(region);
            }
        }

    }
}
