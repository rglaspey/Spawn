using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CompositeAlphaKHR : int
    {
        CompositeAlphaOpaqueBitKhr = 1 << 0,
        CompositeAlphaPreMultipliedBitKhr = 1 << 1,
        CompositeAlphaPostMultipliedBitKhr = 1 << 2,
        CompositeAlphaInheritBitKhr = 1 << 3
    }
}