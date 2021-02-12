using FluentValidation;
using StartAndPark.Application.ValidationRules;

namespace StartAndPark.Application
{
    public class CreateRaceCommandValidator : AbstractValidator<CreateTrackCommand>
    {
        public CreateRaceCommandValidator()
        {
            RuleFor(x => x.Name).RaceNameRules();
        }
    }
}
