using FluentValidation;
using StartAndPark.Application.ValidationRules;

namespace StartAndPark.Application.Owners.Commands.Update
{
    public class UpdateOwnerCommandValidator : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateOwnerCommandValidator()
        {
            RuleFor(c => c.Name).OwnerNameRules();
        }
    }
}
