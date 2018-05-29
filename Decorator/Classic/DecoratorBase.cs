namespace MuNaiYiPattern.Decorator.Classic
{
    public abstract class DecoratorBase:IDecorator
    {
        protected IText target;

        public DecoratorBase(IText target)
        {
            this.target = target;
        }

        public abstract string Content { get; }
    }
}
