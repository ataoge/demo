using Ataoge.Core;

namespace Ataoge.Services
{
    public abstract class ApplicationServiceBase : IApplicationService
    {
        protected ApplicationServiceBase(ISysSession session)
        {
            this.Session = session;
        }

        public ISysSession Session { get; private set;}
    }
}