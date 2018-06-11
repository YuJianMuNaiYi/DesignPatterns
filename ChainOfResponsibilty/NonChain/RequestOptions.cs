using System;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    [Flags]
    public enum RequestOptions
    {
        /// <summary>
        /// 购买
        /// </summary>
        Purchase=0x1,

        /// <summary>
        /// 退货
        /// </summary>
        Return=0x2,

        /// <summary>
        /// 破损
        /// </summary>
        Damaged=0x3
    }
}
