using Componse.Xml;
using NUnit.Framework;

namespace Componse.UnitTest
{
    [TestFixture]
    public class TestXml
    {
        [Test(Description = "测试组合模式")]
        public void Test()
        {
            var target = new Corporate();
            var departments = target.GetDepartments();

            Assert.AreEqual(2,departments.Count);

            Assert.AreEqual("market",departments[0].Name);
            Assert.AreEqual("sales",departments[1].Name);
        }
    }
}
