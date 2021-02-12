using FluentValidation;
using StartAndPark.Application.ValidationRules;

namespace StartAndPark.Application
{
    public class UpdateOwnerCommandValidator : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateOwnerCommandValidator()
        {
            RuleFor(c => c.Name).OwnerNameRules();
        }
    }
}
