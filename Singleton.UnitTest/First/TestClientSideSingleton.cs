using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton.First;

namespace Singleton.UnitTest.First
{
    [TestClass]
    public class TestClientSideSingleton
    {
        [TestMethod]
        public void Test()
        {
            var client1 = new Client();
            client1.SomeMethod();

            var client2 = new Client();
            client2.SomeMethod();

            Trace.WriteLine("client1:" + client1.Target.GetHashCode());
            Trace.WriteLine("client2:" + client2.Target.GetHashCode());
            Assert.AreEqual(client1.Target.GetHashCode(), client2.Target.GetHashCode());
        }
    }
}