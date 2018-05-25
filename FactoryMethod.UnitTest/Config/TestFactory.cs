using FactoryMethod.Sources.Batch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethod.UnitTest.Config
{
    [TestClass]
    public class TestFactory
    {
        [TestMethod]
        public void CreateFactoryByName()
        {
            var factory = new Factory();

            //Default
            Assert.IsInstanceOfType(factory.Create(), typeof (ProductA));

            Assert.IsInstanceOfType(factory.Create("a"), typeof (ProductA));
            Assert.IsInstanceOfType(factory.Create("b"), typeof (ProductB));
        }
    }
}