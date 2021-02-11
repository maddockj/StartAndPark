using FluentValidation;
using StartAndPark.Application.ValidationRules;

namespace StartAndPark.Application.DriverRaceEntries.Commands.Update
{
    public class UpdateDriverRaceEntryCommandValidator : AbstractValidator<UpdateDriverRaceEntryCommand>
    {
        public UpdateDriverRaceEntryCommandValidator()
        {
            // used to be a bib number validation here
        }
    }
}
