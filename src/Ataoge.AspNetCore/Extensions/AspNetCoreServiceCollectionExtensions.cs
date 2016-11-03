using System;
using Ataoge.AspNetCore;
using Ataoge.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddAtaogeAspNetCore(this IServiceCollection services, Action<CoreOptionsBuilder> optionsAction = null)
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
            
            services.AddScoped<ISysSession, ClaimsSession>();

            return services;
        }
    }
}