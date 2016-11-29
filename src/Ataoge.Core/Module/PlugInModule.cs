using System;
using Microsoft.Extensions.DependencyInjection;
using Ataoge.Services;
using Ataoge.PlugIns;

namespace Ataoge.Core
{
    public class PlugInModule : CoreModule,IPlugIn
    {
        public virtual bool HasViews => false;
        public virtual string Name  => string.Empty;
       

        public override void Initilize(IServiceCollection services)
        {
            RegisterAssembly(services, this.GetType());
        }
    }
}