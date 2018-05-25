namespace Prototype
{
    public interface IPrototype
    {
        IPrototype Clone();
        string Name { get; set; }//为了演示,增加了额外的属性
    }
}
