using System;
using Microsoft.Extensions.DependencyInjection;
using Ataoge.Services;

namespace Ataoge.Core
{
    public abstract class PlugInModule : CoreModule
    {

        public override void Initilize(IServiceCollection services)
        {
            RegisterAssembly(services, this.GetType());
        }
    }
}