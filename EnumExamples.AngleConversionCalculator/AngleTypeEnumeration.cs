using System;
using System.Linq;
using static EnumExamples.AngleConversionCalculator.AngleType;
using LazyType = System.Lazy<EnumExamples.AngleConversionCalculator.AngleTypeEnumeration>;
using LazyTypeDictionary =
    System.Collections.Generic.Dictionary<EnumExamples.AngleConversionCalculator.AngleType,
        System.Lazy<EnumExamples.AngleConversionCalculator.AngleTypeEnumeration>>;
using AngleTypeDictionary =
    System.Collections.Generic.Dictionary<EnumExamples.AngleConversionCalculator.AngleType, double>;

namespace EnumExamples.AngleConversionCalculator
{
    public class AngleTypeEnumeration
    {
        private readonly AngleTypeDictionary _factorMap = new AngleTypeDictionary();

        private AngleTypeEnumeration(params (AngleType destAngleType, double factor)[] destFactors) 
            => destFactors.ToList().ForEach(x=> _factorMap[x.destAngleType] = x.factor);

        private static readonly LazyTypeDictionary Map = new LazyTypeDictionary();

        private static void Create(AngleType angleType,
            params (AngleType destAngleType, double factor)[] destFactors) =>
            Map[angleType] = new LazyType(() => new AngleTypeEnumeration(destFactors));

        static AngleTypeEnumeration()
        {
            Create(Degree, (Degree, 1), (Radian, 0.0174532925), (Gradian, 1.1111111111111));
            Create(Radian, (Degree, 57.2957795), (Radian, 1), (Gradian, 63.661977236758));
            Create(Gradian, (Degree, 1.1111111111111), (Radian, 0.9), (Gradian, 1));
        }

        private static bool CheckEnumValue(int value)
            => Enum.IsDefined(typeof(AngleType), value)
                ? true
                : throw new ArgumentOutOfRangeException(nameof(value), value, null);

        public static double ConvertAngle(double angle, AngleType srcAngleType, AngleType destAngleType)
            => CheckEnumValue((int) srcAngleType) && CheckEnumValue((int) destAngleType)
                ? angle * Map[srcAngleType].Value._factorMap[destAngleType]
                : 0;
    }
}