using System;
using System.Runtime.Remoting.Messaging;

namespace MuNaiYiPattern.Decorator.Tags.Way1
{
    /// <inheritdoc />
    /// <summary>
    /// 定制具体装饰属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ArgumentTypeRestrictionAttribute:DecoratorAttributeBase
    {
        private readonly Type type;

        public ArgumentTypeRestrictionAttribute(Type type)
        {
            this.type = type;
        }

        public override void Intercept(object target)
        {
            var caller = (MethodCallMessageWrapper)target;
            if (caller?.Args == null || caller.ArgCount==0)
            {
                return;
            }

            for (var i = 0; i < caller.ArgCount; i++)
            {
                var arg = caller.Args[i];
                if (arg.GetType()!=type &&(!arg.GetType().IsAssignableFrom(type)))
                {
                    throw new ArgumentNullException(i.ToString());
                }
            }
        }
    }
}
