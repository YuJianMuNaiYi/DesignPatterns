namespace AdapterPattern
{
    /// <summary>
    /// 类适配器
    /// </summary>

    public class ClassAdapter : Adaptee2, ITarget
    {
        public void Request()
        {
            base.SpecifiedRequest();
        }
    }
}
