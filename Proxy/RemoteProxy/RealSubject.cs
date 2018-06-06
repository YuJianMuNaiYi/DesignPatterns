namespace MuNaiYiPattern.Proxy.RemoteProxy
{
    /// <inheritdoc />
    /// <summary>
    /// 具体实现客户程序需要的类型
    /// </summary>
    public class RealSubject : ISubject
    {
        public static  readonly RealSubject Instance=new RealSubject();
        public string Request() => "from real subject.";
    }
}
