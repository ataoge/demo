using System;
namespace Ataoge.Services
{
    public interface IServiceManager
    {
        Type GetServiceType(string servcieName);

        void RegisterServiceType(Type serviceType);

        object ExecuteService(string serviceName, string actionName, IApplicationService service, params object[] arguments);
    }
}