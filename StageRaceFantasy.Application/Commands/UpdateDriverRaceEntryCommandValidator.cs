using FluentValidation;
using StartAndPark.Application.ValidationRules;

namespace StartAndPark.Application
{
    public class UpdateDriverRaceEntryCommandValidator : AbstractValidator<UpdateDriverRaceEntryCommand>
    {
        public UpdateDriverRaceEntryCommandValidator()
        {
            // used to be a bib number validation here
        }
    }
}
