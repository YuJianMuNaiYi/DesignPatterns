namespace MuNaiYiPattern.ChainOfResponsibilty.Classic
{
    /// <inheritdoc />
    /// <summary>
    /// 只适用于"平价"的操作
    /// </summary>
    public class RegularHandler : HandlerBase
    {
        public RegularHandler()
        {
            Type = PurchaseType.Regular;
        }
    }
}
