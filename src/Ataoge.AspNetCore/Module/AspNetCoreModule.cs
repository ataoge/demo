using Ataoge.Core;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Ataoge.Services;

namespace Ataoge.AspNetCore
{
    public class AspNetCoreModule : CoreModule
    {
        public override void Initilize(IServiceCollection services)
        {
            base.Initilize(services);
            RegisterService(services);
        }

        public virtual void RegisterService(IServiceCollection services)
        {
            var types = typeof(AspNetCoreModule).GetTypeInfo().Assembly.GetTypes().Where(type => typeof(IApplicationService).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract);
            foreach(var type in types)
            {
                this.ServiceManager.RegisterServiceType(type);
                services.AddTransient(type, type);
            }
        }
    }
}