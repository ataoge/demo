using Ataoge.Core;

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
    }
}