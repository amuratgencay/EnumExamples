using System;
using System.Collections.Generic;

namespace EnumExamples.CarFactory.OOPApproach
{
    public partial class Brands
    {
        public partial class BMW
        {
            public enum BMWModel
            {
                X6,
                Z8
            }

            private static readonly Dictionary<BMWModel, Model> Map =
                new Dictionary<BMWModel, Model>
                {
                    {BMWModel.X6, X6},
                    {BMWModel.Z8, Z8},
                };

            private static Lazy<Brand> BrandLazy =>
                new Lazy<Brand>(() => new Brand(nameof(BMW)));

            private static Lazy<Model> X6Lazy =>
                new Lazy<Model>(() => new Model(nameof(X6), Brand, 150000m));

            private static Lazy<Model> Z8Lazy =>
                new Lazy<Model>(() => new Model(nameof(Z8), Brand, 135000m));

            private static Brand Brand => BrandLazy.Value;
            public static Model X6 => X6Lazy.Value;
            public static Model Z8 => Z8Lazy.Value;

            public static Car Create(BMWModel bmwModel)
            {
                var model = Map[bmwModel];
                return new Car(Brand.Name, model.Name, model.Price);
            }
        }
    }
}