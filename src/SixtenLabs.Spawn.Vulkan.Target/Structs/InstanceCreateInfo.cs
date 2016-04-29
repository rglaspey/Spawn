using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct InstanceCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
        public ApplicationInfo pApplicationInfo;
        public uint enabledLayerCount;
        public char ppEnabledLayerNames;
        public uint enabledExtensionCount;
        public char ppEnabledExtensionNames;
    }
}