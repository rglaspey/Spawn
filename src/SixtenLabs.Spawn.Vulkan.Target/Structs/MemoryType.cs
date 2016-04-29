using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct MemoryType
    {
        public MemoryPropertyFlags propertyFlags;
        public uint heapIndex;
    }
}