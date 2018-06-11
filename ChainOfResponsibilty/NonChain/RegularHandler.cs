using MuNaiYiPattern.ChainOfResponsibilty.Classic;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    /// <summary>
    /// 适于"平价"购买和退货操作
    /// </summary>
    public class RegularHandler:HandlerBase
    {
        public RegularHandler()
        {
            Type = PurchaseType.Regular;
            Option = RequestOptions.Purchase | RequestOptions.Return;
        }
    }
}
