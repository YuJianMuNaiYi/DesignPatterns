using MuNaiYiPattern.Decorator.Classic;
using NUnit.Framework;

namespace MuNaiYiPattern.Decorator.UnitTest
{
    [TestFixture]
    public class TestDecorator
    {
        [Test]
        public void Test()
        {
            //建立对象,并对其进行两次装饰
            IText text = new TextObject();
            text=new BoldDecorator(text);
            text=new ColorDecorator(text);

            Assert.AreEqual("<color><b>Hello<b/><color/>",text.Content);

            //建立对象,并对其进行一次装饰
            text=new TextObject();
            text=new ColorDecorator(text);
            Assert.AreEqual("<color>Hello<color/>", text.Content);

            text=new BlockAllDecorator(text);
            Assert.IsTrue(string.IsNullOrEmpty(text.Content));
        }
    }
}
