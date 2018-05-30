namespace MuNaiYiPattern.Decorator.Classic
{
    public abstract class DecoratorBase:IDecorator
    {
        //has a
        protected readonly IText target;

        protected DecoratorBase(IText target)
        {
            this.target = target;
        }

        public abstract string Content { get; }
    }
}
