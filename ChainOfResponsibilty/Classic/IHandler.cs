namespace MuNaiYiPattern.ChainOfResponsibilty.Classic
{
    /// <summary>
    /// 抽象的操作对象
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// 处理客户端请求
        /// </summary>
        /// <param name="request"></param>
        void HandleRequest(Request request);

        /// <summary>
        /// 后续的操作节点
        /// </summary>
        IHandler Successor { get; set; }

        /// <summary>
        /// 适用于当前Handler操作的购买类型
        /// </summary>
        PurchaseType Type { get; }
    }
}
