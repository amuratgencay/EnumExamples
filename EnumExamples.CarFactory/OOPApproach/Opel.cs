using System;
using System.Collections.Generic;
using BrandLazy = System.Lazy<EnumExamples.CarFactory.OOPApproach.Brand>;
using ModelLazy = System.Lazy<EnumExamples.CarFactory.OOPApproach.Model>;

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

            private static BrandLazy BrandLazy => CreateBrand(nameof(Opel));

            private static ModelLazy AstraLazy => CreateModel(nameof(Astra), Brand, 35000m);

            private static ModelLazy CorsaLazy => CreateModel(nameof(Corsa), Brand, 70000m);

            private static Brand Brand => BrandLazy.Value;
            public static Model Astra => AstraLazy.Value;
            public static Model Corsa => CorsaLazy.Value;

            public static Car Create(OpelModel opelModel)
            {
                var model = Map[opelModel];
                return new Car(Brand.Name, model.Name, model.Price);
            }

            private static BrandLazy CreateBrand(string name)
                => new BrandLazy(() => new Brand(name));

            private static ModelLazy CreateModel(string name, Brand brand, decimal price)
                => new ModelLazy(() => new Model(name, brand, price));
        }
    }
}