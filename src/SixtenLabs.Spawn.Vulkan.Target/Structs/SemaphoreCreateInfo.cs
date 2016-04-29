using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct SemaphoreCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public uint flags;
    }
}