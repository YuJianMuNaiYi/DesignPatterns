namespace AdapterPattern
{
    /// <summary>
    /// 对象适配器
    /// </summary>
    public class ObjectAdapter : ITarget
    {
        private readonly Adaptee2 Adaptee;

        public ObjectAdapter(Adaptee2 adaptee)
        {
            Adaptee = adaptee;
        }

        public void Request()
        {
            Adaptee.SpecifiedRequest();
        }
    }
}
