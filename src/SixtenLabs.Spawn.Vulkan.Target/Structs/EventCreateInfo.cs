using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct EventCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
    }
}