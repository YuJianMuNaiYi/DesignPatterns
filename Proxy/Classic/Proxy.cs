namespace MuNaiYiPattern.Proxy.Classic
{
    /// <inheritdoc />
    /// <summary>
    /// 代理类型,它知道如何满足客户程序的要求,同时知道如何访问具体类型
    /// </summary>
    public class Proxy:ISubject
    {
        public string Request() => RealSubject.Instance.Request();
    }
}
