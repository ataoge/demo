using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Ataoge.Services;

namespace Ataoge.Core
{
    public class CoreModule : IModule
    {
        public CoreModule()
        {
            this.ServiceManager = new ServiceManager();
        }

        public virtual void Initilize(IServiceCollection services)
        {
            services.AddSingleton<IServiceManager>(this.ServiceManager);
        }

        protected void RegisterAssembly(IServiceCollection services, Type typeAssembly)
        {
            var types = typeAssembly.GetTypeInfo().Assembly.GetTypes().Where(type => typeof(IApplicationService).GetTypeInfo().IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract);
            foreach(var type in types)
            {
                this.ServiceManager.RegisterServiceType(type);
                services.AddTransient(type, type);
            }
        }

        public IServiceManager ServiceManager
        {
            get;
            private set;
        }
    }
}