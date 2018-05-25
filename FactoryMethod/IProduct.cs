namespace FactoryMethod.Sources
{
    public interface IProduct
    {
        string Name { get; }
    }

    public class ProductA : IProduct
    {
        public string Name
        {
            get { return "A"; }
        }
    }

    public class ProductB : IProduct
    {
        public string Name
        {
            get { return "B"; }
        }
    }
}