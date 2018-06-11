using System.Collections.Generic;
using System.Linq;

namespace MuNaiYiPattern.ChainOfResponsibilty.NonChain
{
    public class HandlerCorFactory
    {
        private static readonly IEnumerable<Ihandler> registry=new List<Ihandler>
        {
            new InternalHandler(),

            new MailPurchaseHandler(),
            new MailReturnHandler(),

            new DiscountPurchaseHandler(),
            new DiscountReturnHandler(),

            new RegularHandler()
        };

        /// <summary>
        /// 构造适于不同业务流程操作的Handler Cor
        /// </summary>
        /// <param name="option"></param>
        /// <returns>筛选适于当前业务流程的Handler</returns>
        public IEnumerable<Ihandler> CreateHandlerCor(RequestOptions option)=> registry.Where(x => (x.Option & option) == option);
    }
}
