using System;
using MuNaiYiPattern.ChainOfResponsibilty.Classic;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    /// <summary>
    /// 适于"折扣价"退货操作
    /// </summary>
    public class DiscountReturnHandler:HandlerBase
    {
        public DiscountReturnHandler()
        {
            Type = PurchaseType.Discount;
            Option = RequestOptions.Return;
        }

        protected override void Process(Request request)
        {
            throw new NotSupportedException();
        }
    }
}
