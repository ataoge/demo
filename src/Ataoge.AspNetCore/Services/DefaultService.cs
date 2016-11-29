using Ataoge.Core;
using Microsoft.Extensions.Logging;

namespace Ataoge.Services
{
    public class DefaultService : ApplicationServiceBase
    {
        public DefaultService(ServiceContext sc) : base(sc)
        {
            logger = sc.CreateLogger<DefaultService>();
        }

        private ILogger logger;

        public string DoAction1(string cmd)
        {
            logger.LogInformation(cmd);
            return string.Format("输入的是：{0}", cmd);
        }

        public TestObject DoAction2(string cmd)
        {
            logger.LogInformation(cmd);
            return new TestObject() {Id = Session.UserId ?? -1, Message = DoAction1(cmd)};
        }
    }

    public class TestObject
    {
        public int Id {get; set;}
        public string Message { get; set;}
    }
}