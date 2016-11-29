using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private List<IPlugIn> _plugIns = null;
        public List<IPlugIn> PlugIns
        {
            get 
            {
                if (_plugIns == null)
                { 
                    _plugIns =  new List<IPlugIn>();
                    foreach (var asm in this.Assemblies)
                    {
                        foreach(var type in asm.GetTypes().Where(t => typeof(IPlugIn).GetTypeInfo().IsAssignableFrom(t)))
                        {
                            IPlugIn plugIn = Activator.CreateInstance(type) as IPlugIn;
                            if (_plugIns != null)
                                _plugIns.Add(plugIn);
                        }
                    }
                }
                return _plugIns;
            }
        }
    }
}