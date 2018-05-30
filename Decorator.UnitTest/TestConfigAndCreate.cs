using MuNaiYiPattern.Decorator.Classic;
using MuNaiYiPattern.Decorator.ConfigAndCreate;
using NUnit.Framework;

namespace MuNaiYiPattern.Decorator.UnitTest
{
    [TestFixture]
    public class TestConfigAndCreate
    {
        [Test]
        public void Test()
        {
            //修改后的IText仅仅依赖于一个Builder类型
            IText text = new TextObject();
            //通过引入创建者,客户类型(TextObject)与多个装饰类型的依赖关系变成了客户类型与创建者类型之间1:1的依赖关系,
            //而这里的Builder类型可以进一步设计为泛型Builder<T>,这样就可以减少多个客户类型使用装饰模式时"繁文缛节"的构造过程。

            //另外,装配对象的加入也给我们从外部配置目标类型及其相关装饰类型的机会。
            text = (new DecoratorBuilder()).BuildUp(text);

            Assert.AreEqual("<color><b>Hello<b/><color/>", text.Content);
        }
    }
}
