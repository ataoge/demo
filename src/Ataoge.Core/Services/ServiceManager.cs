using System;
using System.Reflection;
using System.Collections.Concurrent;

namespace Ataoge.Services
{
    public class ServiceManager : IServiceManager
    {
        private static ConcurrentDictionary<string, Type> typeDicts = new ConcurrentDictionary<string, Type>();
        private static ConcurrentDictionary<string, MethodInfo> methodDicts = new ConcurrentDictionary<string, MethodInfo>();
        public Type GetServiceType(string serviceName)
        {
             string serviceKey = GetServciceKey(serviceName);
             if (typeDicts.ContainsKey(serviceKey))
                return typeDicts[serviceKey];
            return null;
        }

        public void RegisterServiceType(Type serviceType)
        {
            string keyName = serviceType.Name;
            if (typeDicts.ContainsKey(keyName))
                throw new ArgumentException(nameof(serviceType));
            
            typeDicts.TryAdd(keyName, serviceType);
            foreach (MethodInfo methodInfo in serviceType.GetTypeInfo().DeclaredMethods)
            {
                if (methodInfo.IsPublic && !methodInfo.IsAbstract)
                {
                    string methodKey = keyName + methodInfo.Name;
                    methodDicts.TryAdd(methodKey, methodInfo);
                }
            }
        }

        private string GetServciceKey(string serviceName)
        {
            if (serviceName.EndsWith("Service"))
            {
                return serviceName;
            }
            return serviceName + "Service";
        }


        public virtual object ExecuteService(string serviceName, string actionName, IApplicationService service, params object[] arguments)
        {
            string serviceKey = GetServciceKey(serviceName);
            MethodInfo method = null;
            string methodKey = serviceKey + actionName;
            if (methodDicts.TryGetValue(methodKey, out method))
            {
                return method.Invoke(service, arguments);
            }
            throw new CoreException(string.Format("执行服务动作{0}.{1}失败!",serviceName, actionName));
        }
    }
}