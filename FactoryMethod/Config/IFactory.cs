namespace FactoryMethod.Sources.Config
{
    public interface IFactory
    {
        IProduct Create();
        IProduct Create(string name);
    }
}