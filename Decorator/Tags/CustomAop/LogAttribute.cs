using System.Diagnostics;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace MuNaiYiPattern.Decorator.Tags.CustomAop
{
    /// <summary>
    /// 自定义的装饰属性
    /// </summary>
    public class LogAttribute:HandlerAttribute,ICallHandler
    {
        public override ICallHandler CreateHandler(IUnityContainer container) => this;

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Trace.WriteLine("******************************log******************************");
            return getNext()(input, getNext);
        }
    }
}
