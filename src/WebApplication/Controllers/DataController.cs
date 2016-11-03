using Ataoge.Core;
using Ataoge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Ataoge;

namespace WebApplication.Controllers
{
    [Authorize]
    [RouteAttribute("data")]
    public class DataController
    {
        public DataController(IServiceManager serviceManager, ISysSession sysSession, IServiceProvider serviceProvider)
        {
            this.ServiceManager = serviceManager;
            this.Session = sysSession;
            this.ServiceProvider = serviceProvider;
        }

        public ISysSession Session
        {
            get;
            private set;
        }

        public IServiceManager ServiceManager
        {
            get;
            private set;
        }

        public IServiceProvider ServiceProvider{ get; private set;}

        [RouteAttribute("{serviceName}/{actionName}")]
        public IActionResult Index(string serviceName, string actionName)
        {
            Type serviceType =ServiceManager.GetServiceType(serviceName);
            if (serviceType == null)
                  throw new CoreException("服务未注册");
            
            string paramValue = Session.GetParam("cmd");
            IApplicationService service = ServiceProvider.GetService(serviceType) as IApplicationService;
            if (service == null)
                 throw new CoreException("未获取到服务");
            
            var result = ServiceManager.ExecuteService(serviceName, actionName, service, paramValue);

            return new JsonResult(new {status = 0, message = "success", serviceName = serviceName, actionName = actionName, result = result});
        }
    }
}