using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct MemoryRequirements
    {
        public ulong size;
        public ulong alignment;
        public uint memoryTypeBits;
    }
}