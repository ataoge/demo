using System;
using Ataoge.Core;

namespace Ataoge.AspNetCore
{
    public class CoreOptions 
    {
        public bool UserDefaultCache { get; set;} = false;

        public IModule Module { get; set;}

        public string PlugInPath { get; set; }

        public Type ServiceSecurityType { get; set;} = typeof(NullServiceSecurity);
    }
}