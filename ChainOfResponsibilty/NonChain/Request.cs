namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    /// <summary>
    /// 调用者
    /// </summary>
   public class Request
    {
        public double Price { get; set; }

        public PurchaseType Type { get; set; }

        public RequestOptions Option { get; set; }
    }
}
