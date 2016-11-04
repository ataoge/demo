namespace Ataoge.Services
{
    public class TestService : IApplicationService
    {
        public string DoSomeThing(string cmd)
        {
            return $"Test Service DoSomeThing {cmd}";
        }
    }
}