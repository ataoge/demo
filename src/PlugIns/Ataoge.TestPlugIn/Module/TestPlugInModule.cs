using System;
using Ataoge.Core;

namespace Ataoge.TestPlugIn
{
    public class TestPlugInModule : PlugInModule
    {
        public override string Name => "Ataoge.TestPlugIn";

        public override bool HasViews => true;
    }
}