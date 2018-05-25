using System;

namespace FactoryMethod.Sources.Batch
{
    public class Factory : IFactory
    {
        public const string DefaultName = "DEFAULT";
        public readonly ProductRegistry ProductRegistry = new ProductRegistry();

        public IProduct Create()
        {
            return (IProduct) Activator.CreateInstance(ProductRegistry[DefaultName]);
        }

        public IProduct Create(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            return (IProduct) Activator.CreateInstance(ProductRegistry[name]);
        }
    }
}