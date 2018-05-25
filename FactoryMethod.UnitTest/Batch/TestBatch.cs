using System.Collections.Generic;
using System.Linq;
using FactoryMethod.Sources.Batch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethod.UnitTest.Batch
{
    [TestClass]
    public class TestBatch
    {
        [TestMethod]
        public void BatchCreateProductByName()
        {
            const int batchSize = 5;
            var factory = new BatchFactory();

            IEnumerable<IProduct> products = factory.Create(batchSize);

            Assert.AreEqual(batchSize, products.Count());
            Assert.AreEqual(batchSize, products.Count(x => x is ProductA));

            products = factory.Create("a", batchSize);
            Assert.AreEqual(batchSize, products.Count());
            Assert.AreEqual(batchSize, products.Count(x => x is ProductA));

            products = factory.Create("b", batchSize);
            Assert.AreEqual(batchSize, products.Count());
            Assert.AreEqual(batchSize, products.Count(x => x is ProductB));
        }
    }
}