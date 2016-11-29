using System.Collections.Generic;

namespace Ataoge.PlugIns
{
    public interface IPlugInManager
    {
        List<IPlugIn> PlugIns {get; }
    }
}