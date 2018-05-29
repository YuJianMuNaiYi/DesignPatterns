namespace MuNaiYiPattern.Decorator.Classic
{
    /// <summary>
    /// 具体装饰类
    /// </summary>
    public class BlockAllDecorator:DecoratorBase
    {
        public BlockAllDecorator(IText target) : base(target)
        {
        }

        public override string Content => string.Empty;
    }
}
