using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ataoge.Core;
using Ataoge.Utility;

namespace Ataoge.PlugIns
{
    public class PlugInManager : IPlugInManager
    {
        public PlugInManager(string path)
        {
            this.Assemblies = AssemblyHelper.GetAllAssembliesInFolder(path);
        }

        public List<Assembly> Assemblies { get; private set;}

        private List<IModule> modules = null;
        public List<IModule> Modules {
            get 
            {
                if (modules == null)
                { 
                    modules =  new List<IModule>();
                    foreach (var asm in this.Assemblies)
                    {
                        foreach(var type in asm.GetTypes().Where(t => typeof(IModule).GetTypeInfo().IsAssignableFrom(t)))
                        {
                            IModule module = Activator.CreateInstance(type) as IModule;
                            if (module != null)
                                modules.Add(module);
                        }
                    }
                }
                return modules;
            }
        }
    }
}