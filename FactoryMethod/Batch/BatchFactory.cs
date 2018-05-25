using System;
using System.Collections.Generic;

namespace FactoryMethod.Sources.Batch
{
    public class BatchFactory : Factory, IBatchFactory
    {
        public IEnumerable<IProduct> Create(string name, int quantity)
        {
            if (name == null) throw new ArgumentNullException("name");
            return InternalCreate<IProduct>(ProductRegistry[name], quantity);
        }

        public IEnumerable<IProduct> Create(int quantity)
        {
            if (quantity <= 0) throw new IndexOutOfRangeException("quantity");
            return InternalCreate<IProduct>(ProductRegistry[DefaultName], quantity);
        }

        private IEnumerable<T> InternalCreate<T>(Type type, int quantity)
        {
            if (quantity <= 0) throw new IndexOutOfRangeException("quantity");
            if (type == null) throw new ArgumentNullException("type");

            IList<T> results = new List<T>();

            for (int i = 0; i < quantity; i++)
                results.Add((T) Activator.CreateInstance(type));

            return results;
        }
    }
}