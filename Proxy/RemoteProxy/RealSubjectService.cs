namespace MuNaiYiPattern.Proxy.RemoteProxy
{
    public class RealSubjectService : ISubject
    {
        public string Request() => RealSubject.Instance.Request();
    }
}
