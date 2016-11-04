namespace Ataoge.Core
{
    public interface IServiceSecurity
    {
        bool CanAccess(int userId, string serviceName, string actionName);
    }
}