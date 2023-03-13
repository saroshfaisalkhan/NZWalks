using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkProfiles:Profile
    {
        public WalkProfiles()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walks>()
                .ReverseMap();
        }
    }
}
