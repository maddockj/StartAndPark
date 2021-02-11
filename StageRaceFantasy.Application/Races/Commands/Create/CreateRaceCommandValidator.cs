using FluentValidation;
using StartAndPark.Application.ValidationRules;

namespace StartAndPark.Application.Races.Commands.Create
{
    public class CreateRaceCommandValidator : AbstractValidator<CreateRaceCommand>
    {
        public CreateRaceCommandValidator()
        {
            RuleFor(x => x.Name).RaceNameRules();
        }
    }
}
