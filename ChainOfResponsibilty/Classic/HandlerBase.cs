using System;
using System.Diagnostics;

namespace MuNaiYiPattern.ChainOfResponsibilty.Classic
{
    /// <summary>
    /// 操作的抽象类型
    /// </summary>
    public abstract class HandlerBase:IHandler
    {
        public IHandler Successor { get; set; }
        public PurchaseType Type { get; protected set; }

        public virtual void Process(Request request)
        {

        }

        public virtual void HandleRequest(Request request)
        {
            if (request==null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Trace.WriteLine("");
            Trace.Write(GetType().Name);

            if (request.Type==Type)
            {
                Process(request);
                Trace.WriteLine(" has been processed");
            }
            else
            {
                //把调用继续下去
                Successor?.HandleRequest(request);
            }
        }

    }
}
