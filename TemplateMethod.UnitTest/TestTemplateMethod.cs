using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MuNaiYiPattern.TemplateMethod.UnitTest
{
    [TestClass]
    public class TestTemplateMethod
    {
        const double MaxMistake = 0.0001;
        [TestMethod]
        public void Test()
        {

            IAbstract i1=new ArrayData();
            Assert.AreEqual(2.2,i1.Average,MaxMistake);

            IAbstract i2 = new GridData();
            Assert.AreEqual(2.2 / 3, i2.Average, MaxMistake);
        }
    }
}
