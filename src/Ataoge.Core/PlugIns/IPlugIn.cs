using Ataoge.Core;

namespace Ataoge.PlugIns
{
    public interface IPlugIn : IModule
    {
        string Name { get; }

        bool HasViews { get; }
    }
}