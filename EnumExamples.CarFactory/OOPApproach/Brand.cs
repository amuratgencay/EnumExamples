using System.Collections.Generic;

namespace EnumExamples.CarFactory.OOPApproach
{
    public class Brand
    {
        public string Name { get; set; }
        public List<Model> Models { get; set; } = new List<Model>();

        public Brand(string name)
        {
            Name = name;
        }
    }
}