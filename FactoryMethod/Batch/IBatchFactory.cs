using System.Collections.Generic;

namespace FactoryMethod.Sources.Batch
{
    public interface IBatchFactory : IFactory
    {
        IEnumerable<IProduct> Create(string name, int quantity);
        IEnumerable<IProduct> Create(int quantity);
    }
}