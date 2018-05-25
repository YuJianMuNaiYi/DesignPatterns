namespace AbstractFactory.Classic
{
    public class ConcreateFactory1 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IProductB CreateProductB()
        {
            return new ProductB1();
        }

        public IProductC CreateProductC()
        {
            return new ProductC1();
        }
    }
    public class ConcreateFactory2 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2Y();
        }

        public IProductB CreateProductB()
        {
            return new ProductB2();
        }

        public IProductC CreateProductC()
        {
            return new ProductC2();
        }
    }
}
