namespace MuNaiYiPattern.TemplateMethod
{
    public abstract class AbstractBase : IAbstract
    {
        public abstract int Quantity { get; }
        public abstract double Total { get; }
        public virtual double Average => Total / Quantity;
    }
}
