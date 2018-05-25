using System;
using AbstractFactory.ASync;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.UnitTest.ASync
{
    [TestClass]
    public class FactoryFixture
    {
        class ConcreateProduct : IProduct
        {
        }

        class ConcreateFactory : IFactoryWithNotifier
        {
            /// <summary>
            /// 同比构造过程
            /// </summary>
            /// <returns></returns>
            public IProduct Create()
            {
                return new ConcreateProduct();
            }

            /// <summary>
            /// 异步构造过程
            /// </summary>
            /// <param name="callback"></param>
            public void Create(Action<IProduct> callback)
            {
                callback(Create());
            }
        }

        class Subscribe
        {
            public IProduct Product { get; set; }
        }

        [TestMethod]
        public void Test()
        {
            IFactoryWithNotifier factoryWithNotifier = new ConcreateFactory();

            var subscrible = new Subscribe();
            Assert.IsNull(subscrible.Product);
            factoryWithNotifier.Create(x => { subscrible.Product = x; });
            Assert.IsNotNull(subscrible.Product);
            Assert.IsTrue(subscrible.Product is ConcreateProduct);
        }

    }
}
