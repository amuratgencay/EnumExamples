namespace EnumExamples.CarFactory.OOPApproach
{
    public class Model
    {
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public Model(string name, Brand brand, decimal price)
        {
            Brand = brand;
            Price = price;
            Name = name;
            brand.Models.Add(this);
        }
    }
}