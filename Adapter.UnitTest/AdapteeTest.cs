using System.Collections.Generic;
using System.Diagnostics;
using AdapterPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adapter.UnitTest
{
    [TestClass]
    public class AdapteeTest
    {
        [TestMethod]
        public void Test()
        {
            var adaptee3=new Adaptee3();
            Target3 target3 = adaptee3;
            Assert.AreEqual(adaptee3.Code,target3.Data);
            Trace.WriteLine("adaptee3.Code:"+ adaptee3.Code);
            Trace.WriteLine("target3.Data:" + target3.Data);

            var target3s = new List<Target3>
            {
                adaptee3,
                adaptee3
            };
            Assert.AreEqual(adaptee3.Code, target3s[1].Data);

            Trace.WriteLine("************************************");
            Trace.WriteLine("adaptee3.Code:" + adaptee3.Code);
            Trace.WriteLine("target3s[1].Data:" + target3s[1].Data);
        }
    }
}
