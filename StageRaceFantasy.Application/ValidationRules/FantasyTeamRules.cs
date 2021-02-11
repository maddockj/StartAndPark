using FluentValidation;

namespace StageRaceFantasy.Application.ValidationRules
{
    public static class FantasyTeamRules
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
