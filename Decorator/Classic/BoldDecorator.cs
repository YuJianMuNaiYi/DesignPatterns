namespace MuNaiYiPattern.Decorator.Classic
{
    /// <summary>
    /// 具体装饰类
    /// 属于"马甲"
    /// </summary>
    public class BoldDecorator:DecoratorBase
    {
        public BoldDecorator(IText target) : base(target)
        {

        }

        public override string Content => ChangeToBoldFont(target.Content);

        private static string ChangeToBoldFont(string content) => $"<b>{content}<b/>";
    }
}
