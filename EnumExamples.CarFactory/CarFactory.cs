using System;
using static EnumExamples.CarFactory.CarBrandModelEnum;

namespace EnumExamples.CarFactory
{
    public class CarFactory
    {
        public static Car Create(CarBrandModelEnum carBrandModelEnum) =>
            carBrandModelEnum switch
            {
                BMW_X6 => new Car("BMW", "X6", 150000m),
                BMW_Z8 => new Car("BMW", "Z8", 135000m),
                Mercedes_GLA => new Car("Mercedes", "GLA", 50000m),
                Mercedes_CLK => new Car("Mercedes", "CLK", 550000m),
                Opel_Astra => new Car("Opel", "Astra", 35000m),
                Opel_Corsa => new Car("Opel", "Corsa", 70000m),
                _ => throw new ArgumentOutOfRangeException(nameof(carBrandModelEnum), carBrandModelEnum, null)
            };
    }
}