using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    public struct PhysicalDeviceMemoryProperties
    {
        public uint memoryTypeCount;
        public MemoryType memoryTypes;
        public uint memoryHeapCount;
        public MemoryHeap memoryHeaps;
    }
}