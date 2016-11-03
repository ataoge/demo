using System;
using Ataoge.AspNetCore.Identity.Entities;
using Ataoge.AspNetCore.Identity.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Contains extension methods to <see cref="IServiceCollection"/> for configuring identity services.
    /// </summary>
    internal static class InMemoryIdentityServiceCollectionExtensions
    {
         public static IdentityBuilder AddInMemoryIdentity(this  IServiceCollection services, Action<IdentityOptions> setupAction = null)
         {
             // Services used by identity
            services.AddAuthentication(options =>
            {
                // This is the Default value for ExternalCookieAuthenticationScheme
                options.SignInScheme = new IdentityCookieOptions().ExternalCookieAuthenticationScheme;
            });

            // Hosting doesn't add IHttpContextAccessor by default
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Identity services
            services.TryAddSingleton<IdentityMarkerService>();
            services.TryAddScoped<IUserValidator<IntIdentityUser>, UserValidator<IntIdentityUser>>();
            services.TryAddScoped<IPasswordValidator<IntIdentityUser>, PasswordValidator<IntIdentityUser>>();
            services.TryAddScoped<IPasswordHasher<IntIdentityUser>, PasswordHasher<IntIdentityUser>>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IRoleValidator<IntIdentityRole>, RoleValidator<IntIdentityRole>>();
            // No interface for the error describer so we can add errors without rev'ing the interface
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<IntIdentityUser>>();
            services.TryAddScoped<IUserClaimsPrincipalFactory<IntIdentityUser>, UserClaimsPrincipalFactory<IntIdentityUser, IntIdentityRole>>();
            services.TryAddScoped<UserManager<IntIdentityUser>, UserManager<IntIdentityUser>>();
            services.TryAddScoped<SignInManager<IntIdentityUser>, SignInManager<IntIdentityUser>>();
            services.TryAddScoped<RoleManager<IntIdentityRole>, RoleManager<IntIdentityRole>>();

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }



            var builder = new IdentityBuilder(typeof(IntIdentityUser), typeof(IntIdentityRole), services);
            var  innerServices = new ServiceCollection();
            innerServices.AddScoped(
                typeof(IUserStore<IntIdentityUser>), typeof(InMemoryUserStore));
            innerServices.AddScoped(
                typeof(IRoleStore<IntIdentityRole>), typeof(InMemoryRoleStore));
            builder.Services.TryAdd(innerServices);
            return builder;
             
         }
    }
}