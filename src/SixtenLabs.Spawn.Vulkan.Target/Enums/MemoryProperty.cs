using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum MemoryProperty : int
    {
        MemoryPropertyDeviceLocalBit = 1 << 0,
        MemoryPropertyHostVisibleBit = 1 << 1,
        MemoryPropertyHostCoherentBit = 1 << 2,
        MemoryPropertyHostCachedBit = 1 << 3,
        MemoryPropertyLazilyAllocatedBit = 1 << 4
    }
}