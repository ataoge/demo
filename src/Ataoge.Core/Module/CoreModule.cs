using System;
using Microsoft.Extensions.DependencyInjection;
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

        public IServiceManager ServiceManager
        {
            get;
            private set;
        }
    }
}