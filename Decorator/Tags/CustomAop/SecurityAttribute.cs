using System.Diagnostics;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace MuNaiYiPattern.Decorator.Tags.CustomAop
{
    public class SecurityAttribute:HandlerAttribute,ICallHandler
    {
        public override ICallHandler CreateHandler(IUnityContainer container) => this;

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Trace.WriteLine("******************************machine name******************************");
            Trace.WriteLine("******************************domain name******************************");
            return getNext()(input, getNext);
        }
    }
}
