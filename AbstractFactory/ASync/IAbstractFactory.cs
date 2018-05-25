using System;

namespace AbstractFactory.ASync
{
    public interface IFactory
    {
        IProduct Create();
    }

    public interface IFactoryWithNotifier : IFactory
    {
        void Create(Action<IProduct> callback);
    }
}
