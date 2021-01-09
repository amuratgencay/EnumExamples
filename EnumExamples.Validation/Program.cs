using static System.Console;
using static EnumExamples.Validation.ValidationTypeEnumerations;
using static EnumExamples.Validation.ValidationTypes;

namespace EnumExamples.Validation
{
    internal class Program
    {
        private static void ShowValidationMessageEnum(string value, ValidationTypes validationTypes)
            => WriteLine(ValidationService.GetValidationMessage(value, validationTypes));

        private static void Main()
        {
            const string emptyString = "";
            const string nonEmptyString = "Murat";

            const string nonNumericString = "12as";
            const string numericString = "3.14";

            const string nonValidPhoneNumber = "(555)555555";
            const string validPhoneNumber = "(555) 5555555";

            const string validEMail = "amuratgencay@gmail.com";
            const string nonValidEMail = "amuratgencaygmail.com";


            

            ShowValidationMessageEnum(emptyString, StringEmpty);
            ShowValidationMessageEnumeration(emptyString, StringEmptyValidator);
            ShowValidationMessageEnum(nonEmptyString, StringEmpty);
            ShowValidationMessageEnumeration(nonEmptyString, StringEmptyValidator);
            WriteLine();

            ShowValidationMessageEnum(numericString, Numeric);
            ShowValidationMessageEnumeration(numericString, NumericValidator);
            ShowValidationMessageEnum(nonNumericString, Numeric);
            ShowValidationMessageEnumeration(nonNumericString, NumericValidator);
            WriteLine();

            ShowValidationMessageEnum(validPhoneNumber, PhoneNumber);
            ShowValidationMessageEnumeration(validPhoneNumber, PhoneNumberValidator);
            ShowValidationMessageEnum(nonValidPhoneNumber, PhoneNumber);
            ShowValidationMessageEnumeration(nonValidPhoneNumber, PhoneNumberValidator);
            WriteLine();

            ShowValidationMessageEnum(validEMail, EMail);
            ShowValidationMessageEnumeration(validEMail, EmailValidator);
            ShowValidationMessageEnum(nonValidEMail, EMail);
            ShowValidationMessageEnumeration(nonValidEMail, EmailValidator);
            WriteLine();
        }
    }
}