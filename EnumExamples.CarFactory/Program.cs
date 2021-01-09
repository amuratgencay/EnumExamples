using EnumExamples.CarFactory.OOPApproach;
using static System.Console;
using static EnumExamples.CarFactory.OOPApproach.Brands.BMW.BMWModel;
using static EnumExamples.CarFactory.OOPApproach.Brands.Mercedes.MercedesModel;
using static EnumExamples.CarFactory.OOPApproach.Brands.Opel.OpelModel;
using static EnumExamples.CarFactory.CarBrandModelEnum;
using static EnumExamples.CarFactory.CarFactory;

namespace EnumExamples.CarFactory
{
    internal class Program
    {
        private static void Main()
        {
            ShowBMWModels();
            ShowMercedesModels();
            ShowOpeModels();
        }

        private static void WriteLineTab(object value, int tabCount = 1)
            => WriteLine("".PadLeft(tabCount, '\t') + value);
        private static void ShowOpeModels()
        {
            WriteLine($"\n<{nameof(Brands.Opel)}>");
          
            WriteLineTab(Create(Opel_Astra));
            WriteLineTab(Brands.Opel.Astra.Create());
            WriteLineTab(Brands.Opel.Create(Astra));
            
            WriteLine();
            
            WriteLineTab(Create(Opel_Corsa));
            WriteLineTab(Brands.Opel.Corsa.Create());
            WriteLineTab(Brands.Opel.Create(Corsa));
            
            WriteLine($"</{nameof(Brands.Opel)}>");
        }

        private static void ShowMercedesModels()
        {
            WriteLine($"\n<{nameof(Brands.Mercedes)}>");

            WriteLineTab(Create(Mercedes_CLK));
            WriteLineTab(Brands.Mercedes.CLK.Create());
            WriteLineTab(Brands.Mercedes.Create(CLK));

            WriteLine();

            WriteLineTab(Create(Mercedes_GLA));
            WriteLineTab(Brands.Mercedes.GLA.Create());
            WriteLineTab(Brands.Mercedes.Create(GLA));
           
            WriteLine($"</{nameof(Brands.Mercedes)}>");

        }

        private static void ShowBMWModels()
        {
            WriteLine($"\n<{nameof(Brands.BMW)}>");

            WriteLineTab(Create(BMW_X6));
            WriteLineTab(Brands.BMW.X6.Create());
            WriteLineTab(Brands.BMW.Create(X6));

            WriteLine();

            WriteLineTab(Create(BMW_Z8));
            WriteLineTab(Brands.BMW.Z8.Create());
            WriteLineTab(Brands.BMW.Create(Z8));

            WriteLine($"</{nameof(Brands.BMW)}>");
        }
    }
}