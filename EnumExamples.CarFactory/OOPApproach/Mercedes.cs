using System;
using System.Collections.Generic;

namespace EnumExamples.CarFactory.OOPApproach
{
    public partial class Brands
    {
        public partial class Mercedes
        {
            public enum MercedesModel
            {
                CLK,
                GLA
            }

            private static readonly Dictionary<MercedesModel, Model> Map =
                new Dictionary<MercedesModel, Model>
                {
                    {MercedesModel.CLK, CLK},
                    {MercedesModel.GLA, GLA},
                };

            private static Lazy<Brand> BrandLazy =>
                new Lazy<Brand>(() => new Brand(nameof(Mercedes)));

            private static Lazy<Model> CLKLazy =>
                new Lazy<Model>(() => new Model(nameof(CLK), Brand, 50000m));

            private static Lazy<Model> GLALazy =>
                new Lazy<Model>(() => new Model(nameof(GLA), Brand, 550000m));

            private static Brand Brand => BrandLazy.Value;
            public static Model CLK => CLKLazy.Value;
            public static Model GLA => GLALazy.Value;

            public static Car Create(MercedesModel mercedesModel)
            {
                var model = Map[mercedesModel];
                return new Car(Brand.Name, model.Name, model.Price);
            }
        }
    }
}