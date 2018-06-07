namespace MuNaiYiPattern.ChainOfResponsibilty.Classic
{
    /// <summary>
    /// 影响各个"操作对象"是否会执行的因素
    /// </summary>
    public enum PurchaseType
    {
        /// <summary>
        /// 内部认购价格
        /// </summary>
        Internal,
        
        /// <summary>
        /// 折扣
        /// </summary>
        Discount,

        /// <summary>
        /// 平价
        /// </summary>
        Regular,

        /// <summary>
        /// 邮购价
        /// </summary>
        Mail
    }
}
