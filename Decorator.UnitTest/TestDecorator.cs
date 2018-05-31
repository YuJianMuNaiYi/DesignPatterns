using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuNaiYiPattern.Decorator.Classic;

namespace MuNaiYiPattern.Decorator.UnitTest
{
    [TestClass]
    public class TestDecorator
    {
        [TestMethod]
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

            //通过装饰,撤销某些操作
            text=new BlockAllDecorator(text);
            Assert.IsTrue(string.IsNullOrEmpty(text.Content));
        }
    }
}
