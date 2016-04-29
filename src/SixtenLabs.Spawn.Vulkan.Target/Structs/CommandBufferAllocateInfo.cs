using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct CommandBufferAllocateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public CommandPool commandPool;
        public CommandBufferLevel level;
        public uint commandBufferCount;
    }
}