using MuNaiYiPattern.ChainOfResponsibilty.Classic;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    /// <summary>
    /// 适于"折扣价"购买操作
    /// </summary>
    public class DiscountPurchaseHandler : HandlerBase
    {
        public DiscountPurchaseHandler()
        {
            Type = PurchaseType.Discount;
            Option = RequestOptions.Purchase;
        }

        protected override void Process(Request request)
        {
            request.Price *= 0.9;
        }
    }
}
