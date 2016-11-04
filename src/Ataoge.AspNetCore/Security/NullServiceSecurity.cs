using System;
using Ataoge.Core;

namespace Ataoge.AspNetCore
{
    public class NullServiceSecurity : IServiceSecurity
    {
        public bool CanAccess(int userId, string serviceName, string actionName)
        {
            return true;
        }
    }
}