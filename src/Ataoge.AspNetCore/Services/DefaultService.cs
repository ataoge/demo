using Ataoge.Core;

namespace Ataoge.Services
{
    public class DefaultService : ApplicationServiceBase
    {
        public DefaultService(ISysSession session) : base(session)
        {
            
        }

        public string DoAction1(string cmd)
        {
            return string.Format("输入的是：{0}", cmd);
        }

        public TestObject DoAction2(string cmd)
        {
            return new TestObject() {Id = 1, Message = DoAction1(cmd) };
        }
    }

    public class TestObject
    {
        public int Id {get; set;}
        public string Message { get; set;}
    }
}