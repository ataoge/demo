

using System;
using System.Linq;
using System.Security.Claims;
using Ataoge.Core;
using Microsoft.AspNetCore.Http;

namespace Ataoge.AspNetCore
{
    public class ClaimsSession : ISysSession
    {
        public ClaimsSession(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        private readonly IHttpContextAccessor httpContextAccessor;

        public int? UserId
        {
            get
            {
                var userIdClaim =  this.httpContextAccessor.HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim?.Value))
                {
                    return null;
                }

                int userId;
                if (!int.TryParse(userIdClaim.Value, out userId))
                {
                    return null;
                }

                return userId;
            }
        }

        public string GetParam(string name, string defaultValue = null)
        {
            if (httpContextAccessor.HttpContext.Request.Query.ContainsKey(name))
                return httpContextAccessor.HttpContext.Request.Query[name];
            return defaultValue;
        }
    }
}