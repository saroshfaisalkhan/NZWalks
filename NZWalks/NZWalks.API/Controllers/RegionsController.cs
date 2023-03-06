using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

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
    }
}
