using System;
using System.Diagnostics;
using MuNaiYiPattern.ChainOfResponsibilty.Classic;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
  public  abstract class HandlerBase:Ihandler
    {
        public Ihandler Successor { get; set; }
        public PurchaseType Type { get; protected set; }
        public RequestOptions Option { get; protected set; }

        /// <summary>
        /// Handle需要处理的内容
        /// </summary>
        /// <param name="request"></param>
        protected virtual void Process(Request request) { }

        /// <summary>
        /// 按照链式方式依次把调用继续下去
        /// </summary>
        /// <param name="request"></param>
        public virtual void HandleRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Trace.WriteLine("");
            Trace.Write(GetType().Name);

            if (request.Type != Type)
            {
                return;
            }

            Process(request);
            Trace.WriteLine(" has been processed");
        }
    }
}
