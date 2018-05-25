namespace Prototype
{
    public class ConcretePrototype : IPrototype
    {
        public IPrototype Clone()
        {
            return (IPrototype)MemberwiseClone();
        }

        public string Name { get; set; }
    }
}
