namespace EnumExamples.CarFactory.OOPApproach
{
    public static class ModelExtensions
    {
        public static Car Create(this Model model)
            => new Car(model.Brand.Name, model.Name, model.Price);
    }
}