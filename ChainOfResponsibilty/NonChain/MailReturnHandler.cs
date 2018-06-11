namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    public class MailReturnHandler:HandlerBase
    {
        public MailReturnHandler()
        {
            Type = PurchaseType.Mail;
            Option = RequestOptions.Return;
        }
    }
}
