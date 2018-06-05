using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuNaiYiPattern.Proxy.Classic;

namespace MuNaiYiPatternProxy.UnitTest
{
    [TestClass]
    public class TestProxy
    {
        [TestMethod]
        public void Test()
        {
            ISubject subject=new Proxy();
            Assert.AreEqual("from real subject.",subject.Request());
        }
    }
}
