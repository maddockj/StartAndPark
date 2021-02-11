using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.FantasyTeams.Commands.Update
{
    public class UpdateFantasyTeamCommandValidator : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateFantasyTeamCommandValidator()
        {
            RuleFor(c => c.Name).OwnerNameRules();
        }
    }
}
