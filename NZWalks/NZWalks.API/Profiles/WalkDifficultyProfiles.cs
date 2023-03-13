using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalkDifficultyProfiles:Profile
    {
        public WalkDifficultyProfiles()
        {
            CreateMap<Models.Domain.WalkDifficulty,Models.DTO.WalkDifficulty>()
                .ReverseMap();
        }
    }
}
