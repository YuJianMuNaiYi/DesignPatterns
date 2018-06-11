using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuNaiYiPattern.ChainOfResponsibilty.NonChain;

namespace ChainOfResponsibilty.UnitTest
{
    [TestClass]
    public class TestHandlerFixture
    {
        private const double OriginalPrice = 100;
        private Request mailRequest;

        [TestInitialize]
        public void Initialize()=> mailRequest = new Request
        {
            Option = RequestOptions.Purchase,
            Price = 100,
            Type = PurchaseType.Mail
        };

        [TestMethod]
        public void TestPurchaseHandlerCor()
        {
            Trace.Write("验证购买过程处理CoR");
            var head=new HandlerCorFactory().CreateHandlerCor(RequestOptions.Purchase);
            //  验证通过Lamada筛选出来的适用的Handler数量
            //  InternalHandler、MailPurchaseHandler、DiscountPurchaseHandler、RegularHandler 

            Assert.AreEqual(4,head.Count());

            head.ToList().ForEach(x=>x.HandleRequest(mailRequest));

            Assert.AreEqual(OriginalPrice*1.3,mailRequest.Price);
        }

        /// <summary>
        /// 验证退货过程处理CoR
        /// </summary>
        [TestMethod]
        public void TestReturnHandlerCor()
        {
            Trace.WriteLine("验证退货过程处理Cor");
            var head=new HandlerCorFactory().CreateHandlerCor(RequestOptions.Return);
            //  验证通过Lamada筛选出来的适用的Handler数量
            //  InternalHandler、MailReturnHandler、DiscountReturnHandler、RegularHandler 

            Assert.AreEqual(4,head.Count());

            head.ToList().ForEach(x=>x.HandleRequest(mailRequest));
            //  验证邮购价格退货时只退还原价
            Assert.AreEqual(OriginalPrice,mailRequest.Price);
        }

        /// <summary>
        /// 验证不能退货的情况
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestCannotReturnHandlerCor()
        {
            Trace.Write("验证不能退货的情况CoR");
            var discountRequest = new Request()
            {
                Option = RequestOptions.Return,
                Price = OriginalPrice,
                Type = PurchaseType.Discount
            };

            new HandlerCorFactory().CreateHandlerCor(RequestOptions.Return).ToList().ForEach(x=>x.HandleRequest(discountRequest));
        }
    }
}
