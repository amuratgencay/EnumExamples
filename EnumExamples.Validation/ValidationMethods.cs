using System.Text.RegularExpressions;

namespace EnumExamples.Validation
{
    public class ValidationMethods
    {
        public static bool StringEmptyValidation(string value)
            => !string.IsNullOrEmpty(value);

        public static bool NumericValidation(string value)
            => double.TryParse(value, out _);

        public static bool PhoneNumberValidation(string value)
            => Regex.IsMatch(value, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

        public static bool EmailValidation(string value)
            => Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    }
}