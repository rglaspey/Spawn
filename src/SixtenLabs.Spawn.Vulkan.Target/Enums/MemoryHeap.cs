using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum MemoryHeap : int
    {
        MemoryHeapDeviceLocalBit = 1 << 0
    }
}