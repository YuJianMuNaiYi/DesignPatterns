using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace MuNaiYiPattern.Decorator.Tags.Way1
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ArgumentNotEmptyAttribute:DecoratorAttributeBase
    {
        public override void Intercept(object target)
        {
            var caller = (MethodCallMessageWrapper)target;
            if (caller?.Args == null || caller.ArgCount == 0)
            {
                return;
            }

            if (caller.Args.Any(callerArg => string.IsNullOrEmpty((string)callerArg)))
            {
                throw new ArgumentException();
            }
        }
    }
}
