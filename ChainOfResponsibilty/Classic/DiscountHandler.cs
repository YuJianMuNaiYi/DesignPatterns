namespace MuNaiYiPattern.ChainOfResponsibilty.Classic
{
    /// <inheritdoc />
    /// <summary>
    /// 只适用于"折扣价"的操作
    /// </summary>
    public class DiscountHandler : HandlerBase
    {
        public DiscountHandler()
        {
            Type = PurchaseType.Discount;
        }

        public override void Process(Request request)
        {
            request.Price *= 0.9;
        }
    }
}
