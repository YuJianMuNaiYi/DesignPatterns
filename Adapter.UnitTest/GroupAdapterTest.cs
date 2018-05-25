using AdapterPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adapter.UnitTest
{
    [TestClass]
    public class GroupAdapterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var factory=new FactoryMethod.Exercise.Factory()
                                        .RegisterType<IDataBaseAdapter, OracleAdapter>("ora")
                                        .RegisterType<IDataBaseAdapter, SqlserverAdapter>("sql");

            var oracleAdapter = factory.Create<IDataBaseAdapter>("ora");
            var sqlserverAdapter = factory.Create<IDataBaseAdapter>("sql");

            //确认之前完全不同的Adaptee被同意抽象为ITarget所定义的接口类型
            Assert.AreEqual("Oracle",oracleAdapter.PridoverName);
            Assert.AreEqual("SQL Server",sqlserverAdapter.PridoverName);
        }
    }
}
