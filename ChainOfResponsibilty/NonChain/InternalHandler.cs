using MuNaiYiPattern.ChainOfResponsibilty.Classic;


namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    /// <summary>
    /// 适于"内部价格"的购买和退货操作
    /// </summary>
    public class InternalHandler:HandlerBase
    {
        public InternalHandler()
        {
            Type = PurchaseType.Internal;
            Option = RequestOptions.Purchase | RequestOptions.Return;
        }

        protected override void Process(Request request)
        {
            request.Price *= 0.6;
        }
    }
}
