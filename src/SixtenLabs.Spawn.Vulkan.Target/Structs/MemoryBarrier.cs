using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct MemoryBarrier
    {
        public StructureType sType;
        public IntPtr pNext;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
    }
}