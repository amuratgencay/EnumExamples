using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static EnumExamples.Validation.ValidationMethods;
using static EnumExamples.Validation.ValidationTypes;
using ValidationMethodList = System.Collections.Generic.List<System.Func<string, bool>>;
using ValidationTypeFuncMap = System.Collections.Generic.Dictionary<EnumExamples.Validation.ValidationTypes, System.Func<string, bool>>;
using ValidationTypeEnumerationMap = System.Collections.Generic.Dictionary<EnumExamples.Validation.ValidationTypes, EnumExamples.Validation.ValidationTypeEnumerations>;
namespace EnumExamples.Validation
{
    public class ValidationTypeEnumerations
    {
        public ValidationTypes ValidationTypes { get; set; }

        public static void ShowValidationMessageEnumeration(string value,
            ValidationTypeEnumerations validationTypeEnumerations)
        {
            WriteLine(
                $"{"\"" + value + "\"",25} validate for ({validationTypeEnumerations.Validations()}) = {validationTypeEnumerations.Validate(value)}");
        }

        public string Validations() =>
            string.Join(" | ", Enum.GetValues(typeof(ValidationTypes))
                .OfType<ValidationTypes>()
                .Where(x => ValidationTypes.HasFlag(x))
                .Select(x => x.ToString()));

        private readonly ValidationMethodList _validationFunc = new ValidationMethodList();

        private static Lazy<ValidationTypeEnumerations> Create(ValidationTypes validationTypes) =>
            new Lazy<ValidationTypeEnumerations>(() =>
                new ValidationTypeEnumerations(validationTypes));

        private static readonly Lazy<ValidationTypeEnumerations> StringEmptyLazy
            = Create(StringEmpty);

        private static readonly Lazy<ValidationTypeEnumerations> EmailLazy
            = Create(EMail);

        private static readonly Lazy<ValidationTypeEnumerations> PhoneNumberLazy
            = Create(PhoneNumber);

        private static readonly Lazy<ValidationTypeEnumerations> NumericLazy
            = Create(Numeric);

        public ValidationTypeEnumerations(ValidationTypes validationTypes)
        {
            ValidationTypes = validationTypes;
        }

        private static readonly ValidationTypeFuncMap FuncMap
            = new ValidationTypeFuncMap
            {
                {StringEmpty, StringEmptyValidation},
                {EMail, EmailValidation},
                {PhoneNumber, PhoneNumberValidation},
                {Numeric, NumericValidation}
            };

        private static readonly ValidationTypeEnumerationMap Map
            = new ValidationTypeEnumerationMap
            {
                {StringEmpty, StringEmptyValidator},
                {EMail, EmailValidator},
                {PhoneNumber, PhoneNumberValidator},
                {Numeric, NumericValidator}
            };

        public static ValidationTypeEnumerations CreateInstance(ValidationTypes validationTypes)
            => Map[validationTypes];

        static ValidationTypeEnumerations()
        {
            static void FillMethods(IEnumerable array,
                ValidationTypeEnumerations validationTypeEnumerations)
            {
                foreach (var enumValue in array)
                {
                    var value = (ValidationTypes) enumValue;
                    if (validationTypeEnumerations.ValidationTypes.HasFlag(value))
                        validationTypeEnumerations._validationFunc.Add(FuncMap[value]);
                }
            }

            var enumValues = Enum.GetValues(typeof(ValidationTypes));
            FillMethods(enumValues, StringEmptyValidator);
            FillMethods(enumValues, EmailValidator);
            FillMethods(enumValues, PhoneNumberValidator);
            FillMethods(enumValues, NumericValidator);
        }


        public static ValidationTypeEnumerations StringEmptyValidator => StringEmptyLazy.Value;
        public static ValidationTypeEnumerations EmailValidator => EmailLazy.Value;
        public static ValidationTypeEnumerations PhoneNumberValidator => PhoneNumberLazy.Value;
        public static ValidationTypeEnumerations NumericValidator => NumericLazy.Value;

        public bool Validate(string value)
            => _validationFunc.All(x => x(value));
    }

    public static class ValidationTypesExtensions
    {
        public static bool Validate(this ValidationTypes validationTypes, string value)
            => ValidationTypeEnumerations.CreateInstance(validationTypes).Validate(value);
    }
}