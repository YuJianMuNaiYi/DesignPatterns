namespace MuNaiYiPattern.Decorator.Classic
{
    /// <summary>
    /// 具体装饰类
    /// 属于"马甲"
    /// </summary>
    public class ColorDecorator:DecoratorBase
    {
        public ColorDecorator(IText target) : base(target)
        {
        }

        public override string Content => AddColorTag(target.Content);

        private static string AddColorTag(string content) => $"<color>{content}<color/>";
    }
}
