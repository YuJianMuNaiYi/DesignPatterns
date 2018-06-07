namespace MuNaiYiPattern.ChainOfResponsibilty.Classic
{
    /// <inheritdoc />
    /// <summary>
    /// 只适用于"内部价格"的操作
    /// </summary>
    public class InternalHandler : HandlerBase
    {
        public InternalHandler()
        {
            Type = PurchaseType.Internal;
        }

        public override void Process(Request request)
        {
            request.Price *= 0.6;
        }
    }
}
