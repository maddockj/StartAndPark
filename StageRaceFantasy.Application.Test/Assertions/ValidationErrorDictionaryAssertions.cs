using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace StageRaceFantasy.Application.IntegrationTests.Assertions
{
    public static class ValidationErrorDictionaryExtensions
    {
        public static ValidationErrorDictionaryAssertions Should(this Dictionary<string, string[]> validationErrorDictionary)
        {
            return new ValidationErrorDictionaryAssertions(validationErrorDictionary);
        }
    }

    public class ValidationErrorDictionaryAssertions
    {
        private readonly Dictionary<string, string[]> _subject;

        public ValidationErrorDictionaryAssertions(Dictionary<string, string[]> subject)
        {
            _subject = subject;
        }

        // TODO: Unit test this.
        public AndConstraint<ValidationErrorDictionaryAssertions> ContainPartialValidationErrorForProperty(string propertyName, string partialErrorMessage)
        {
            Execute.Assertion
                .ForCondition(!string.IsNullOrEmpty(propertyName) && !string.IsNullOrEmpty(partialErrorMessage))
                .FailWith($"You must provide {nameof(propertyName)} and {nameof(partialErrorMessage)}.")
                .Then
                .ForCondition(_subject.ContainsKey(propertyName))
                .FailWith("Expected there to be an error for key {0}.", propertyName)
                .Then
                .ForCondition(_subject[propertyName].Any(x => x.Contains(partialErrorMessage)))
                .FailWith("Expected error for property {0} to contain {1}.", propertyName, partialErrorMessage);

            return new AndConstraint<ValidationErrorDictionaryAssertions>(this);
        }



        // TODO: Unit test this.
        public AndConstraint<ValidationErrorDictionaryAssertions> ContainNotEmptyValidationErrorForProperty(string propertyName)
        {
            return ContainPartialValidationErrorForProperty(propertyName, ValidationMessageFragments.NotEmpty);
        }
    }
}
