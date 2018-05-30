using System;

namespace MuNaiYiPattern.Decorator.Tags.Way1
{
    /// <inheritdoc />
    /// <summary>
    /// 装饰属性的基类
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public abstract class DecoratorAttributeBase : Attribute
    {
        public abstract void Intercept(object target);
    }
}
