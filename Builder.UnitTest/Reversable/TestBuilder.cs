using System.Diagnostics;
using Builder.Reversable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builder.UnitTest.Reversable
{
    [TestClass]
    public class TestBuilder
    {
        [TestMethod]
        public void Test()
        {
            Builder.Reversable.IBuilder<Product> builder = new ProductBuilder();
            var product = builder.BuildUp();
            Assert.AreEqual(5, product.Count);
            Trace.WriteLine("product.Count:"+product.Count);
            Assert.AreEqual(5, product.Items.Count);

            product = builder.TearDown();
            Assert.AreEqual(0, product.Count);
            Trace.WriteLine("product.Count:" + product.Count);
            Assert.AreEqual(0, product.Items.Count);
        }
    }
}
