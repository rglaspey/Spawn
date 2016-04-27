using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum MemoryPropertyFlags
    {
        MemoryPropertyDeviceLocalBit = 0,
        MemoryPropertyHostVisibleBit = 1,
        MemoryPropertyHostCoherentBit = 2,
        MemoryPropertyHostCachedBit = 3,
        MemoryPropertyLazilyAllocatedBit = 4
    }
}