using System.ServiceModel;

namespace MuNaiYiPattern.Proxy.RemoteProxy
{

    [ServiceContract]
    public interface ISubject
    {
        [OperationContract]
        string Request();
    }
}
