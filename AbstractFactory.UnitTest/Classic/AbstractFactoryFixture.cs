using AbstractFactory.Classic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbstractFactory.UnitTest.Classic
{
    [TestClass]
    public class TestAbstractFacrory
    {
        [TestMethod]
        public void Test()
        {
            var factory = new ConcreateFactory2();
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Assert.IsTrue(productA is ProductA2Y);

            Assert.IsTrue(productB is ProductB2);
        }
    }
}
