using System;

namespace SixtenLabs.Spawn.Vulkan.Target
{
    [Flags]
    public enum ColorComponent : int
    {
        ColorComponentRBit = 1 << 0,
        ColorComponentGBit = 1 << 1,
        ColorComponentBBit = 1 << 2,
        ColorComponentABit = 1 << 3
    }
}