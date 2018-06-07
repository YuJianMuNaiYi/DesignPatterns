using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuNaiYiPattern.ChainOfResponsibilty.Classic;

namespace ChainOfResponsibilty.UnitTest
{
    [TestClass]
    public class TestChain
    {
        [TestMethod]
        public void Test()
        {
            var head = new InternalHandler
            {
                Successor = new DiscountHandler
                {
                    Successor = new MailHandler
                    {
                        Successor = new RegularHandler()
                    }
                }
            };

            var request=new Request
            {
                Price = 20,Type = PurchaseType.Mail
            };

            head.HandleRequest(request);
            Assert.AreEqual(20*1.3,request.Price);

            request = null;

            //重新组织链表结构
            //此时,head指向internal
            var discountHandler = head.Successor;
            //短路掉Discount Handler
            head.Successor = head.Successor.Successor;

            discountHandler = null;

            request=new Request
            {
                Price = 20,Type =PurchaseType.Discount
            };
            head.HandleRequest(request);

            //价格没有折扣打折,确认被短路的部分无法生效
            //验证CoR可以通过动态维护链表调整操作对象(Handler)的组织结构
            Assert.AreEqual(20,request.Price);
        }
    }
}
