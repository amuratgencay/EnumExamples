using System;
using System.Collections.Generic;

namespace EnumExamples.CarFactory.OOPApproach
{
    public partial class Brands
    {
        public partial class Opel
        {
            public enum OpelModel
            {
                Astra,
                Corsa
            }

            private static readonly Dictionary<OpelModel, Model> Map =
                new Dictionary<OpelModel, Model>
                {
                    {OpelModel.Astra, Astra},
                    {OpelModel.Corsa, Corsa},
                };

            private static Lazy<Brand> BrandLazy =>
                new Lazy<Brand>(() => new Brand(nameof(Opel)));

            private static Lazy<Model> AstraLazy =>
                new Lazy<Model>(() => new Model(nameof(Astra), Brand, 35000m));

            private static Lazy<Model> CorsaLazy =>
                new Lazy<Model>(() => new Model(nameof(Corsa), Brand, 70000m));

            private static Brand Brand => BrandLazy.Value;
            public static Model Astra => AstraLazy.Value;
            public static Model Corsa => CorsaLazy.Value;

            public static Car Create(OpelModel opelModel)
            {
                var model = Map[opelModel];
                return new Car(Brand.Name, model.Name, model.Price);
            }
        }
    }
}