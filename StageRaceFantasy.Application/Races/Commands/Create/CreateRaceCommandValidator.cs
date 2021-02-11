using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.Races.Commands.Create
{
    public class CreateRaceCommandValidator : AbstractValidator<CreateRaceCommand>
    {
        public CreateRaceCommandValidator()
        {
            RuleFor(x => x.Name).RaceNameRules();
        }
    }
}
