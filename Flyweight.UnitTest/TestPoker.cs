using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuNaiYiPattern.Flyweight.Classic;

namespace MuNaiYiPattern.Flyweight.UnitTest
{
    [TestClass]
    public class TestPoker
    {
        [TestMethod]
        public void TestGetPoker()
        {
            var factory = new PokerFactory();

            var p1 = factory.CreatePoker(10, Suit.Heart);
            var p2 = factory.CreatePoker(10, Suit.Heart);

            var p3 = factory.CreatePoker(10, Suit.Spade);
            var p4 = factory.CreatePoker(11, Suit.Heart);

            //验证整体享元特性
            Assert.AreEqual<Poker>(p1,p2);
            Assert.AreNotEqual<Poker>(p1,p3);
            Assert.AreNotEqual<Poker>(p1,p4);

            //验证局部享元特性
            //都是10点
            Assert.AreEqual<PointBase>(p1.Point,p3.Point);
            //都是红桃
            Assert.AreEqual<SuitBase>(p1.Suit,p4.Suit);
        }
    }
}
