using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class RegionProfiles:Profile
    {


        public RegionProfiles()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Regions>()
             .ReverseMap();
        }
    }
}
