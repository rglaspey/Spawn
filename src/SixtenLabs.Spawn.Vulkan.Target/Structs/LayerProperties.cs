using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct LayerProperties
    {
        public char[] layerName;
        public uint specVersion;
        public uint implementationVersion;
        public char[] description;
    }
}