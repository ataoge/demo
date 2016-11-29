using Ataoge.Core;

namespace Ataoge.Services
{
    public abstract class ApplicationServiceBase : IApplicationService
    {
        protected ApplicationServiceBase(ServiceContext serviceContext)
        {
            this.ServiceContext = serviceContext;
            this.Session = serviceContext.Session;
        }

        protected ServiceContext ServiceContext {get;}

        public ISysSession Session { get; private set;}
    }
}