using FluentValidation;

namespace StartAndPark.Application.ValidationRules
{
    public static class OwnerRules
    {
        private const int NameMaxLength = 200;

        public static void OwnerNameRules<T>(this IRuleBuilder<T, string> rule)
        {
            rule
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        }
    }
}
