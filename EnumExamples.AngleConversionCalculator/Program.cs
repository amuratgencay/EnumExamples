using System;
using static System.Console;
using static EnumExamples.AngleConversionCalculator.AngleType;

namespace EnumExamples.AngleConversionCalculator
{
    internal class Program
    {
        private static Func<double, AngleType, AngleType, double> _converter;

        private static void ShowAngle(double angle, AngleType srcAngleType, AngleType destAngleType)
        {
            WriteLine(
                $"\t{angle,3} {srcAngleType,-8} = {_converter(angle, srcAngleType, destAngleType),7:##0.###} {destAngleType}");
        }

        private static void Main()
        {
            //_converter = AngleConverter.ConvertAngle;
            _converter = AngleTypeEnumeration.ConvertAngle;

            WriteLine($"<{nameof(Degree)}>");
            ShowAngle(1, Degree, Radian);
            ShowAngle(90, Degree, Radian);
            ShowAngle(180, Degree, Radian);
            WriteLine();
            ShowAngle(1, Degree, Gradian);
            ShowAngle(90, Degree, Gradian);
            ShowAngle(180, Degree, Gradian);
            WriteLine($"</{nameof(Degree)}>");
            WriteLine($"<{nameof(Radian)}>");
            ShowAngle(0.5, Radian, Degree);
            ShowAngle(1, Radian, Degree);
            ShowAngle(2, Radian, Degree);
            WriteLine();
            ShowAngle(0.5, Radian, Gradian);
            ShowAngle(1, Radian, Gradian);
            ShowAngle(2, Radian, Gradian);
            WriteLine($"</{nameof(Radian)}>");
            WriteLine($"<{nameof(Gradian)}>");
            ShowAngle(1, Gradian, Degree);
            ShowAngle(90, Gradian, Degree);
            ShowAngle(180, Gradian, Degree);
            WriteLine();
            ShowAngle(1, Gradian, Radian);
            ShowAngle(90, Gradian, Radian);
            ShowAngle(180, Gradian, Radian);
            WriteLine($"</{nameof(Gradian)}>");
        }
    }
}