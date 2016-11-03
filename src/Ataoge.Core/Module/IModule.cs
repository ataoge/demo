using Microsoft.Extensions.DependencyInjection;

namespace Ataoge.Core
{
    public interface IModule
    {
        void Initilize(IServiceCollection services);
    }
}