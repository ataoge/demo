using System.Collections.Generic;
using Ataoge.Core;

namespace Ataoge.PlugIns
{
    public interface IPlugInManager
    {
        List<IModule> Modules {get; }
    }
}