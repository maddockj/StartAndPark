using FluentValidation;
using StageRaceFantasy.Application.ValidationRules;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Update
{
    public class UpdateDriverRaceEntryCommandValidator : AbstractValidator<UpdateDriverRaceEntryCommand>
    {
        public UpdateDriverRaceEntryCommandValidator()
        {
            // used to be a bib number validation here
        }
    }
}
