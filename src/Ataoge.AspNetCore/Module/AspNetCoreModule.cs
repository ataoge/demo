using Ataoge.Core;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Ataoge.Services;
using System;

namespace Ataoge.AspNetCore
{
    public class AspNetCoreModule : CoreModule
    {
        public override void Initilize(IServiceCollection services)
        {
            base.Initilize(services);
            RegisterService(services, this.GetType());
        }

        public void RegisterService(IServiceCollection services, Type type)
        {
            RegisterAssembly(services, type);
            if (type.GetTypeInfo().BaseType != typeof(object))
            {
                RegisterService(services, type.GetTypeInfo().BaseType);
            }
            
        }

        
    }
}