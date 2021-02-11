using FluentValidation;

namespace StageRaceFantasy.Application.ValidationRules
{
    public static class RaceRules
    {
        private const int NameMaxLength = 200;

        public static void RaceNameRules<T>(this IRuleBuilder<T, string> rule)
        {
            rule
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        }
    }
}
