namespace FactoryMethod.Sources.Batch
{
    public interface IFactory
    {
        IProduct Create();
        IProduct Create(string name);
    }
}