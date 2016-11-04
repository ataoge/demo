using Ataoge.Core;
using System;
using System.Reflection;

namespace Ataoge.AspNetCore
{
    public class CoreOptionsBuilder
    {
        public CoreOptionsBuilder(CoreOptions options)
        {
            this._options = options;
        }

        private CoreOptions _options;
		/// <summary>
		///     Gets the options being configured.
		/// </summary>
		public virtual CoreOptions Options
		{
			get
			{
				return this._options;
			}
		}

        public void UseDefaultCache()
        {
            this.Options.UserDefaultCache = true;
        }

        public void UserModule(IModule module)
        {
            this.Options.Module = module;
        }

        public void UserServiceSecurity(Type type = null)
        {
            if (type == null) {
                this.Options.ServiceSecurityType = typeof(NullServiceSecurity);
                return;
            }

            if (typeof(IServiceSecurity).IsAssignableFrom(type))
            {
                this.Options.ServiceSecurityType = type;
                return;
            }

            throw new ArgumentException(nameof(type));
            
        }

        public void UsePlugIn(string path)
        {
            this.Options.PlugInPath = path;
        }
    }
}