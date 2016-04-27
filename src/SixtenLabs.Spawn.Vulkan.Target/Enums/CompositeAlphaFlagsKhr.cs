using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum CompositeAlphaFlagsKhr
    {
        CompositeAlphaOpaqueBitKhr = 0,
        CompositeAlphaPreMultipliedBitKhr = 1,
        CompositeAlphaPostMultipliedBitKhr = 2,
        CompositeAlphaInheritBitKhr = 3
    }
}