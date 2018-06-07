namespace MuNaiYiPattern.ChainOfResponsibilty.Classic
{
    /// <inheritdoc />
    /// <summary>
    /// 只适用于"邮购价格"的操作
    /// </summary>
    public class MailHandler : HandlerBase
    {
        public MailHandler()
        {
            Type = PurchaseType.Mail;
        }

        public override void Process(Request request)
        {
            request.Price *= 1.3;
        }
    }
}
