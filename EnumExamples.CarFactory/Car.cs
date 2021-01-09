namespace EnumExamples.CarFactory
{
    public class Car
    {
        public override string ToString()
        {
            return $"{nameof(Brand)}: {Brand,8}, {nameof(Model)}: {Model,6}, {nameof(Price)}: {Price}$";
        }

        public Car(string brand, string model, decimal price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }


    }
}