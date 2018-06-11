using MuNaiYiPattern.ChainOfResponsibilty.Classic;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    /// <summary>
    /// 适于"邮购价格"购买操作
    /// </summary>
    public class MailPurchaseHandler:HandlerBase
    {
        public MailPurchaseHandler()
        {
            Type = PurchaseType.Mail;
            Option = RequestOptions.Purchase;
        }

        protected override void Process(Request request)
        {
            request.Price *= 1.3;
        }
    }
}
