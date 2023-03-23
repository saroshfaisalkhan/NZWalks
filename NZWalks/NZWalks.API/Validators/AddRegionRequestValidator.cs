using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validators
{
    public class AddRegionRequestValidator:AbstractValidator<AddRegionRequest>
    {

        public AddRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Latitude).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Population).NotEmpty().GreaterThanOrEqualTo(0);

        }
       
    }
}
