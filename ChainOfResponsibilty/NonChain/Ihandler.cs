using MuNaiYiPattern.ChainOfResponsibilty.Classic;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    /// <summary>
    /// 抽象的操作对象
    /// </summary>
    /// <remarks>通过LINQ方式组织链表,所以不需要定义后续节点(Successor)</remarks>
    public interface Ihandler
    {
        /// <summary>
        /// 当前Handler适用的业务流程
        /// </summary>
        RequestOptions Option { get; }

        /// <summary>
        /// 适于当前Handler处理的购买类型
        /// </summary>
        PurchaseType Type { get; }

        /// <summary>
        /// 处理客户端程序请求
        /// </summary>
        /// <param name="request"></param>
        void HandleRequest(Request request);
    }
}
