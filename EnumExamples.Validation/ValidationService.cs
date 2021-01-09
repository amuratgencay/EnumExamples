using System;
using System.Collections.Generic;
using System.Linq;
using static EnumExamples.Validation.ValidationTypes;

namespace EnumExamples.Validation
{
    public class ValidationService
    {
        public static bool Validate(string value, ValidationTypes validationTypes)
        {
            return validationTypes switch
            {
                StringEmpty => ValidationMethods.StringEmptyValidation(value),
                EMail => ValidationMethods.EmailValidation(value),
                PhoneNumber => ValidationMethods.PhoneNumberValidation(value),
                Numeric => ValidationMethods.NumericValidation(value),
                _ => throw new ArgumentOutOfRangeException(nameof(validationTypes), validationTypes, null)
            };
        }

        public static string GetValidationMessage(string value, ValidationTypes validationTypes)
        {
            var validations = string.Join(" | ", new List<string>
            {
                validationTypes.HasFlag(StringEmpty) ? nameof(StringEmpty) : "",
                validationTypes.HasFlag(Numeric) ? nameof(Numeric) : "",
                validationTypes.HasFlag(EMail) ? nameof(EMail) : "",
                validationTypes.HasFlag(PhoneNumber) ? nameof(PhoneNumber) : ""
            }.Where(x => !string.IsNullOrEmpty(x)));

            return $"{"\"" + value + "\"",25} validate for ({validations}) = {Validate(value, validationTypes)}";
        }
    }
}