using System;
using Ataoge.AspNetCore;
using Ataoge.Core;
using Ataoge.PlugIns;
using Ataoge.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        public static CoreOptionsBuilder AddAtaogeAspNetCore(this IServiceCollection services, Action<CoreOptionsBuilder> optionsAction = null)
        {
            CoreOptionsBuilder builder = new CoreOptionsBuilder(new CoreOptions());
            if (optionsAction != null)
            {
                optionsAction.Invoke(builder);
            }
            if (builder.Options.UserDefaultCache)
            {
                services.AddInMemoryIdentity()
                        .AddDefaultTokenProviders();
            }

            if (builder.Options.Module != null)
            {
                builder.Options.Module.Initilize(services);
            }

            if (!string.IsNullOrEmpty(builder.Options.PlugInPath))
            {
                IPlugInManager plugInManager = new PlugInManager(builder.Options.PlugInPath);
                builder.PlugInManager = plugInManager;
                services.AddSingleton<IPlugInManager>(plugInManager);
                foreach(IPlugIn plugIn in plugInManager.PlugIns)
                {
                    plugIn.Initilize(services);
                }
            }

            services.AddSingleton(typeof(IServiceSecurity), builder.Options.ServiceSecurityType);
            
            services.AddScoped<ISysSession, ClaimsSession>();

            services.AddTransient<ServiceContext>();

            return builder;
        }
    }
}