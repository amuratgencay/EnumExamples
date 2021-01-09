using System;
using static EnumExamples.AngleConversionCalculator.AngleType;

namespace EnumExamples.AngleConversionCalculator
{
    public static class AngleConverter
    {
        private const double DegToRad = 0.0174532925;
        private const double DegToGrad = 1.1111111111111;
        private const double RadToDeg = 57.2957795;
        private const double RadToGrad = 63.661977236758;
        private const double GradToDeg = 1.1111111111111;
        private const double GradToRad = 0.9;

        public static double ConvertAngle(double angle, AngleType srcAngleType, AngleType destAngleType)
        {
            return srcAngleType == destAngleType
                ? angle
                : srcAngleType switch
                {
                    Degree => destAngleType switch
                    {
                        Radian => angle * DegToRad,
                        Gradian => angle * DegToGrad,
                        _ => ThrowException(nameof(destAngleType), destAngleType)
                    },
                    Radian => destAngleType switch
                    {
                        Degree => angle * RadToDeg,
                        Gradian => angle * RadToGrad,
                        _ => ThrowException(nameof(destAngleType), destAngleType)
                    },
                    Gradian => destAngleType switch
                    {
                        Degree => angle * GradToDeg,
                        Radian => angle * GradToRad,
                        _ => ThrowException(nameof(destAngleType), destAngleType)
                    },
                    _ => ThrowException(nameof(srcAngleType), srcAngleType)
                };
        }


        private static double ThrowException(string paramName, AngleType angleType)
        {
            throw new ArgumentOutOfRangeException(paramName, angleType, null);
        }
    }
}