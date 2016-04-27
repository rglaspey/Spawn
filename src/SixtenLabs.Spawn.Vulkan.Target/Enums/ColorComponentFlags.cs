using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ColorComponentFlags
    {
        ColorComponentRBit = 0,
        ColorComponentGBit = 1,
        ColorComponentBBit = 2,
        ColorComponentABit = 3
    }
}