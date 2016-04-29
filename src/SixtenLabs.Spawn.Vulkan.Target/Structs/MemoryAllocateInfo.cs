using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct MemoryAllocateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public ulong allocationSize;
        public uint memoryTypeIndex;
    }
}