using Ataoge.Core;

namespace Ataoge.AspNetCore
{
    public class CoreOptions 
    {
        public bool UserDefaultCache { get; set;} = false;

        public IModule Module { get; set;}
    }
}