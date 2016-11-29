using Ataoge.Core;
using Microsoft.Extensions.Logging;

namespace Ataoge.Services
{
    public class ServiceContext
    {
        public ServiceContext(ISysSession session, ILoggerFactory loggerFactory)
        {
            this.Session = session;
            this._loggerFactory = loggerFactory;
        }

        public ISysSession Session { get;}

        private readonly ILoggerFactory _loggerFactory;

        public ILogger CreateLogger<T>()
        {
            return this._loggerFactory.CreateLogger<T>();
        }
    }
}